using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Setup.DAL;
using Setup.ITF.User.cart;
using Setup.Request.User.cart;
using Setup.Response.User.cart;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.BL.User.cart
{
    public class AddCart : IAddCart
    {
        private readonly IConfiguration _configuration;
        private readonly DataAccessClass _dataAccessClass;

        public AddCart(IConfiguration configuration)
        {
            _configuration = configuration;
            _dataAccessClass = new DataAccessClass(_configuration);
        }

        public CommonResponse<AddCartResponse> AddToCart (AddCartRequest objRequest)
        {
            CommonResponse<AddCartResponse> response = new CommonResponse<AddCartResponse> ();
            try
            {
                #region Parameters
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("@SPProductId", MySqlDbType.Int32) {Value = objRequest.ProductId },
                    new MySqlParameter("@SPVariarionID", MySqlDbType.Int32) {Value = objRequest.VariationId },
                    new MySqlParameter("@SPQty", MySqlDbType.Int32) {Value = objRequest.Qty },
                    new MySqlParameter("@SPUserID", MySqlDbType.String) {Value = objRequest.UserId }
                };
                #endregion

                DataSet ds = new DataSet();
                string[] TableName = { "Response", "Records"};
                _dataAccessClass.ExecuteQuery(CommandType.StoredProcedure, "InsertCartItem", ds, TableName, parameters);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    response.ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    response.ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);

                    if (response.ResponseCode != 0 && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                    {
                        string jsonData = JsonConvert.SerializeObject(ds.Tables[1]);
                        response.ResponseData = jsonData;
                        response.Token = null;
                    }
                }
                else
                {
                    response.ResponseCode = 0;
                    response.ResponseMessage = "No Data Found !";
                    response.ResponseData = null;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = 0;
                response.ResponseMessage = ex.Message;
            }

            return response;
        }
    }
}

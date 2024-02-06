using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
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
    public class UpdateCart : IUpdateCart
    {
        private readonly IConfiguration _configuration;
        private readonly DataAccessClass _dataAccessClass;

        public UpdateCart(IConfiguration configuration)
        {
            _configuration = configuration;
            _dataAccessClass = new DataAccessClass(_configuration);
        }

        public CommonResponse<UpdateCartResponse> UpdateCartQty(UpdateCartRequest objRequest)
        {
            CommonResponse<UpdateCartResponse> response = new CommonResponse<UpdateCartResponse>();
            try
            {
                #region Parameters
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("@SPQty", MySqlDbType.Int32) {Value = objRequest.Qty },
                    new MySqlParameter("@SPCartId", MySqlDbType.Int32) {Value = objRequest.CartId }
                };
                #endregion

                DataSet ds = new DataSet();
                string[] TableName = { "Response" };
                _dataAccessClass.ExecuteQuery(CommandType.StoredProcedure, "UpdateCartQuantity", ds, TableName, parameters);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    response.ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    response.ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
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

using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Setup.DAL;
using Setup.ITF.User.wishlist;
using Setup.Request.User.wishlist;
using Setup.Response.User.wishlist;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.BL.User.wishlist
{
    public class GetWishlist : IGetWishlist
    {
        private readonly IConfiguration _configuration;
        private readonly DataAccessClass _dataAccessClass;

        public GetWishlist(IConfiguration configuration)
        {
            _configuration = configuration;
            _dataAccessClass = new DataAccessClass(_configuration);
        }

        public CommonResponse<GetWishlistResponse> GetWishlistItem (GetWishlistRequest objRequest)
        {
            CommonResponse<GetWishlistResponse> response = new CommonResponse<GetWishlistResponse> ();

            try
            {
                #region Parameters
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("@SPUserID", MySqlDbType.String) {Value = objRequest.UserId }
                };
                #endregion

                DataSet ds = new DataSet();
                string[] TableName = { "Response", "Records" };
                _dataAccessClass.ExecuteQuery(CommandType.StoredProcedure, "GetWishlistItem", ds, TableName, parameters);
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
                    else
                    {
                        response.ResponseCode = 1;
                        response.ResponseMessage = "No Record To Display!";
                        response.ResponseData = null;
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

using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
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
    public class DeleteWishlist : IDeleteWishlist
    {
        private readonly IConfiguration _configuration;
        private readonly DataAccessClass _dataAccessClass;

        public DeleteWishlist(IConfiguration configuration)
        {
            _configuration = configuration;
            _dataAccessClass = new DataAccessClass(_configuration);
        }

        public CommonResponse<DeleteWishlistResponse> DeleteWishlistItem(DeleteWishlistRequest objRequest)
        {
            CommonResponse<DeleteWishlistResponse> response = new CommonResponse<DeleteWishlistResponse>();

            try
            {
                #region Parameters
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("@SPWishlistId", MySqlDbType.Int32) {Value = objRequest.WishlistId }
                };
                #endregion

                DataSet ds = new DataSet();
                string[] TableName = { "Response" };
                _dataAccessClass.ExecuteQuery(CommandType.StoredProcedure, "DeleteWishlistItem", ds, TableName, parameters);
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

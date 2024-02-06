using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
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
    public class DeleteCart : IDeleteCart
    {
        private readonly IConfiguration _configuration;
        private readonly DataAccessClass _dataAccessClass;

        public DeleteCart(IConfiguration configuration)
        {
            _configuration = configuration;
            _dataAccessClass = new DataAccessClass(_configuration);
        }

        #region Delete Cart Item Method
        public CommonResponse<DeleteCartItemResponse> DeleteCartItem (DeleteCartItemRequest objRequest)
        {
            CommonResponse<DeleteCartItemResponse> response = new CommonResponse<DeleteCartItemResponse> ();
            try
            {
                #region Parameters
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("@SPCartId", MySqlDbType.Int32) {Value = objRequest.CartId }
                };
                #endregion

                DataSet ds = new DataSet();
                string[] TableName = { "Response" };
                _dataAccessClass.ExecuteQuery(CommandType.StoredProcedure, "DeleteCartItem", ds, TableName, parameters);
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

        #endregion




        #region Clear All Cart Data Method
        public CommonResponse<ClearAllCartResponse> ClearCartData(ClearAllCartRequest Request)
        {
            CommonResponse<ClearAllCartResponse> response = new CommonResponse<ClearAllCartResponse>();
            try
            {
                #region Parameters
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("@SPUserId", MySqlDbType.Int32) {Value = Request.UserId }
                };
                #endregion

                DataSet ds = new DataSet();
                string[] TableName = { "Response" };
                _dataAccessClass.ExecuteQuery(CommandType.StoredProcedure, "ClearCartData", ds, TableName, parameters);
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

        #endregion
    }
}

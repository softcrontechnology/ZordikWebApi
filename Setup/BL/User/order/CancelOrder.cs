using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Setup.DAL;
using Setup.ITF.User.order;
using Setup.Request.User.order;
using Setup.Response.User.order;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.BL.User.order
{
    public class CancelOrder : ICancelOrder
    {
        private readonly IConfiguration _configuration;
        private readonly DataAccessClass _dataAccessClass;

        public CancelOrder(IConfiguration configuration)
        {
            _configuration = configuration;
            _dataAccessClass = new DataAccessClass(_configuration);
        }

        public CommonResponse<CancelOrderResponse> OrderCancel(CancelOrderRequest objRequest)
        {
            CommonResponse<CancelOrderResponse> response = new CommonResponse<CancelOrderResponse>();

            try
            {
                #region Parameters
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("@SPReason", MySqlDbType.String) {Value = objRequest.Reason },
                    new MySqlParameter("@SPOrderId", MySqlDbType.Int32) {Value = objRequest.OrderId }
                };
                #endregion

                DataSet ds = new DataSet();
                string[] TableName = { "Response", "Records" };
                _dataAccessClass.ExecuteQuery(CommandType.StoredProcedure, "OrderCancel", ds, TableName, parameters);
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

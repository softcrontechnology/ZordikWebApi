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
    public class CreateOrder : ICreateOrder
    {
        private readonly IConfiguration _configuration;
        private readonly DataAccessClass _dataAccessClass;

        public CreateOrder(IConfiguration configuration)
        {
            _configuration = configuration;
            _dataAccessClass = new DataAccessClass(_configuration);
        }

        #region Create User Order Method
        public CommonResponse<CreateOrderResponse> CreateUserOrder(CreateOrderRequest objRequest)
        {
            CommonResponse<CreateOrderResponse> response = new CommonResponse<CreateOrderResponse>();

            try
            {
                #region Parameters
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("@SPPaymentId", MySqlDbType.String) {Value = objRequest.PaymentId },
                    new MySqlParameter("@SPUserId", MySqlDbType.Int32) {Value = objRequest.UserId },
                    new MySqlParameter("@SPAddressId", MySqlDbType.Int32) {Value = objRequest.AddressId },
                    new MySqlParameter("@SPTotalAmt", MySqlDbType.Double) {Value = objRequest.TotalAmount },
                    new MySqlParameter("@SPGstAmt", MySqlDbType.Double) {Value = objRequest.GstAmount },
                    new MySqlParameter("@SPShippingAmt", MySqlDbType.Double) {Value = objRequest.ShippingAmount }
                };
                #endregion

                DataSet ds = new DataSet();
                string[] TableName = { "Response", "Records" };
                _dataAccessClass.ExecuteQuery(CommandType.StoredProcedure, "CreateUserOrder", ds, TableName, parameters);
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

        #endregion




        #region Insert Order Item Method
        public CommonResponse<OrderItemResponse> InsertOrderItem(OrderItemRequest Request)
        {
            CommonResponse<OrderItemResponse> response = new CommonResponse<OrderItemResponse>();

            try
            {
                #region Parameters
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("@SPOrderId", MySqlDbType.Int32) {Value = Request.OrderId },
                    new MySqlParameter("@SPProductId", MySqlDbType.Int32) {Value = Request.ProductId },
                    new MySqlParameter("@SPQuantity", MySqlDbType.Int32) {Value = Request.Quantity },
                    new MySqlParameter("@SPVariationId", MySqlDbType.Int32) {Value = Request.VariationId }
                };
                #endregion

                DataSet ds = new DataSet();
                string[] TableName = { "Response", "Records" };
                _dataAccessClass.ExecuteQuery(CommandType.StoredProcedure, "InsertOrderItem", ds, TableName, parameters);
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

        #endregion
    }
}

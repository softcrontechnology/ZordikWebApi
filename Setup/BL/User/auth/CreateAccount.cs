using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Setup.DAL;
using Setup.ITF.User.auth;
using Setup.Request.User.auth;
using Setup.Response.User.auth;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.BL.User.auth
{
    public class CreateAccount : ICreateAccount
    {
        private readonly IConfiguration _configuration;
        private readonly DataAccessClass dataAccess;

        public CreateAccount(IConfiguration config)
        {
            _configuration = config;
            dataAccess = new DataAccessClass(_configuration);
        }

        public CommonResponse<CreateAccountResponse> CreateUserAccount([FromBody] CreateAccountRequest objRequest)
        {
            CommonResponse<CreateAccountResponse> response = new CommonResponse<CreateAccountResponse>();

            try
            {
                #region Parameters
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("@SPName", MySqlDbType.String) {Value = objRequest.Name },
                    new MySqlParameter("@SPEmail", MySqlDbType.String) {Value = objRequest.Email },
                    new MySqlParameter("@SPPhone", MySqlDbType.String) {Value = objRequest.Phone },
                    new MySqlParameter("@SPPassword", MySqlDbType.String) {Value = objRequest.Password },
                    new MySqlParameter("@SPReferral_code", MySqlDbType.String) {Value = objRequest.ReferralCode },
                    new MySqlParameter("@SPSponsored_by", MySqlDbType.String) {Value = objRequest.SponsoredBy }
                };
                #endregion

                DataSet ds = new DataSet();
                string[] TableName = { "Response" };
                dataAccess.ExecuteQuery(CommandType.StoredProcedure, "InsertUserData", ds, TableName, parameters);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    response.ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    response.ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    response.ResponseData = null;
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

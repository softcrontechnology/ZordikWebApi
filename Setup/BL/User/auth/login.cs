using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using Setup.DAL;
using Setup.ITF.User.auth;
using Setup.Request.User.auth;
using Setup.Response.User.auth;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Setup.BL.User.auth
{
    public class Login : ILogin
    {
        private readonly IConfiguration _configuration;
        private readonly DataAccessClass dataAccess;

        public Login(IConfiguration config)
        {
            _configuration = config;
            dataAccess = new DataAccessClass(_configuration);
        }


        public CommonResponse<LoginResponse> AppLogin(LoginRequest objRequest)
        {
            CommonResponse<LoginResponse> response = new CommonResponse<LoginResponse>();

            try
            {
                #region Parameters
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("@SPEmail", MySqlDbType.String) {Value = objRequest.Email },
                    new MySqlParameter("@SPPassword", MySqlDbType.String) {Value = objRequest.PassWord },
                    new MySqlParameter("@SPSessionId", MySqlDbType.String) {Value = objRequest.SessionId}
                };
                #endregion

                DataSet ds = new DataSet();
                string[] TableName = { "Response", "UserData" };
                dataAccess.ExecuteQuery(CommandType.StoredProcedure, "UserLogin", ds, TableName, parameters);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    response.ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    response.ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    if (response.ResponseCode != 0 && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                    {
                        string jsonData = JsonConvert.SerializeObject(ds.Tables[1]);
                        response.ResponseData = jsonData;

                        var jwtToken = GenerateToken(objRequest.Email);

                        response.Token = jwtToken;
                    }
                    else
                    {
                        response.ResponseData = null;
                    }

                    //else if (response.ResponseCode != 0 && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                    //{
                    //    var objAddData = new LoginResponse();
                    //    objAddData.UserID = Convert.ToInt32(ds.Tables[2].Rows[0]["UserID"]);
                    //}
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






        // Method to Generate the Token When User Successfully Login
        protected string GenerateToken(string userEmail)
        {
            try
            {
                // Token Generation
                var issuer = _configuration["Jwt:Issuer"];
                var audience = _configuration["Jwt:Audience"];
                var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

                var signingCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature
                );

                var claims = new List<Claim>
            {
                              new Claim(ClaimTypes.Email, userEmail)
                        };

                var expires = DateTime.Now.AddMinutes(1);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = expires,
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = signingCredentials
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                return jwtToken;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

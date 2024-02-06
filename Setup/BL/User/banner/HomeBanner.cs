using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Setup.DAL;
using Setup.ITF.User.banner;
using Setup.Request.User.banner;
using Setup.Request.User.cart;
using Setup.Response.User.banner;
using Setup.Response.User.cart;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.BL.User.banner
{
    public class HomeBanner : IHomeBanner
    {
        private readonly IConfiguration _configuration;
        private readonly DataAccessClass _dataAccessClass;

        public HomeBanner(IConfiguration configuration)
        {
            _configuration = configuration;
            _dataAccessClass = new DataAccessClass(_configuration);
        }

        #region  GetHome Banner Method

        public CommonResponse<GetHomeBannerResponse> GetHomeBanner(GetHomeBannerRequest objRequest)
        {
            CommonResponse<GetHomeBannerResponse> response = new CommonResponse<GetHomeBannerResponse>();

            try
            {
                #region Parameters
                MySqlParameter[] parameters =
                {
                    
                };
                #endregion

                DataSet ds = new DataSet();
                string[] TableName = { "Response", "Records" };
                _dataAccessClass.ExecuteQuery(CommandType.StoredProcedure, "GetHomeBanner", ds, TableName, parameters);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    response.ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    response.ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);

                    if (ds.Tables.Count > 1 && ds.Tables[1].Columns.Contains("ResponseCode"))
                    {
                        response.ResponseCode = Convert.ToInt32(ds.Tables[1].Rows[0]["ResponseCode"]);
                        response.ResponseMessage = Convert.ToString(ds.Tables[1].Rows[0]["ResponseMessage"]);
                        response.ResponseData = null;
                    }
                    else if (response.ResponseCode != 0 && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                    {
                        string jsonData = JsonConvert.SerializeObject(ds.Tables[1]);
                        response.ResponseData = jsonData;
                        response.Token = null;
                    }
                    else
                    {
                        response.ResponseCode = 1;
                        response.ResponseMessage = "No Record Found !";
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

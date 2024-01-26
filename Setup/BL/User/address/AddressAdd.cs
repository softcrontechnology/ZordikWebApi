using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Setup.DAL;
using Setup.ITF.User.address;
using Setup.Request.User.address;
using Setup.Request.User.cart;
using Setup.Response.User.address;
using Setup.Response.User.cart;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.BL.User.address
{
    public class AddressAdd : IAddressAdd
    {

        private readonly IConfiguration _configuration;
        private readonly DataAccessClass _dataAccessClass;

        public AddressAdd (IConfiguration configuration)
        {
            _configuration = configuration;
            _dataAccessClass = new DataAccessClass(_configuration);
        }

        public CommonResponse<AddressAddResponse> AddAddress (AddressAddRequest objRequest)
        {
            CommonResponse<AddressAddResponse> response = new CommonResponse<AddressAddResponse>();
            try
            {
                #region Parameters
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("@SPUserid", MySqlDbType.Int32) {Value = objRequest.UserID },
                    new MySqlParameter("@SPName", MySqlDbType.String) {Value = objRequest.Name },
                    new MySqlParameter("@SPPhone", MySqlDbType.String) {Value = objRequest.Phone },
                    new MySqlParameter("@SPHouseNo", MySqlDbType.String) {Value = objRequest.HouseNo },
                    new MySqlParameter("@SPArea", MySqlDbType.String) {Value = objRequest.Area },
                    new MySqlParameter("@SPLankmark", MySqlDbType.String) {Value = objRequest.Landmark },
                    new MySqlParameter("@SPCity", MySqlDbType.String) {Value = objRequest.City },
                    new MySqlParameter("@SPState", MySqlDbType.String) {Value = objRequest.State },
                    new MySqlParameter("@SPCountry", MySqlDbType.String) {Value = objRequest.Country },
                    new MySqlParameter("@SPZipCode", MySqlDbType.Int32) {Value = objRequest.ZipCode }
                };
                #endregion

                DataSet ds = new DataSet();
                string[] TableName = { "Response" };
                _dataAccessClass.ExecuteQuery(CommandType.StoredProcedure, "InsertAddress", ds, TableName, parameters);
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

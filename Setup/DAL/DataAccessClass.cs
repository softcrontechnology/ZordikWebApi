using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.DAL
{
    public class DataAccessClass
    {
        private readonly IConfiguration _configuration;

        public DataAccessClass(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetConnectionString()
        {
            string? connString = _configuration?.GetConnectionString("Conn");
            return connString ?? string.Empty;
        }

        public void ExecuteQuery(CommandType commandType, string spName, DataSet dataSet, string[] dataTableName, params MySqlParameter[] parameters)
        {
            string connectionString = GetConnectionString();
            if (!string.IsNullOrEmpty(connectionString))
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(spName, connection))
                    {
                        command.CommandType = commandType;
                        command.Parameters.AddRange(parameters);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(dataSet);
                            int num = 0;
                            for (num = 0; num < dataSet.Tables.Count; num++)
                            {
                                dataSet.Tables[num].TableName = dataTableName[num];
                            }
                            command.Parameters.Clear();
                        }
                    }
                }
            }
        }





    }
}

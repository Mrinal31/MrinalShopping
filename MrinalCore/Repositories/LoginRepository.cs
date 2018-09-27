using Microsoft.Extensions.Options;
using MrinalCore.Entities;
using MrinalCore.Helpers;
using MrinalCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MrinalCore.Repositories
{
    public class LoginRepository : ILogin
    {

        private readonly ConnectionStrings _connectionString;
        public LoginRepository(IOptions<ConnectionStrings> options)
        {

            _connectionString = options.Value;

        }

        public User Login(string username, string password)
        {
            User User = new User();
            try
            {
                string ConnectionPath = _connectionString.DefaultConnection;
                using (var sqlCon = new SqlConnection(ConnectionPath))
                {
                    using (SqlCommand cmd = new SqlCommand("stp_ValidateUser", sqlCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Login", username);
                        cmd.Parameters.AddWithValue("@active", "yes");
                        cmd.Parameters.AddWithValue("@pw", password);

                        sqlCon.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                User.Username = DataHelper.ConvertTo<string>(reader["user_name"]);
                                User.FirstName = DataHelper.ConvertTo<string>(reader["UEmailId"]);
                                User.Id = DataHelper.ConvertTo<int>(reader["UId"]);
                            }
                        }

                        reader.Close();

                    }

                }



            }
            catch (Exception ex)
            {
                throw ex;

            }
            return User;


        }


    }
}

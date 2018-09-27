using MrinalCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MrinalCore.Entities;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Data;

namespace MrinalCore.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ConnectionStrings _connectionStrings;


        public UserRepository(IOptions<ConnectionStrings> connectionString)
        {
            _connectionStrings = connectionString.Value;


        }

        public User GetUserDetails(string UserId)
        {
            User User = new User();

            //    try
            //    {
            //        string ConnectionPath = _connectionStrings.DefaultConnection;
            //        using (var sqlCon = new SqlConnection(ConnectionPath))
            //        {
            //            using (SqlCommand cmd = new SqlCommand("stp_trv_getUserM", sqlCon))
            //            {
            //                cmd.CommandType = CommandType.StoredProcedure;
            //                cmd.Parameters.AddWithValue("@Login", UserId);
            //                cmd.Parameters.AddWithValue("@RequestAppid", _configurationOptions.RequestModuleId);
            //                cmd.Parameters.AddWithValue("@ReimbursementAppId", _configurationOptions.ReimbursementModuleId);

            //                sqlCon.Open();
            //                SqlDataReader reader = cmd.ExecuteReader();


            //                while (reader.Read())
            //                {
            //                    //User.FullName = DataHelper.ConvertTo<string>(reader["user_name"]);
            //                    //User.LoginId = DataHelper.ConvertTo<string>(reader["Login"]);


            //                }

            //                reader.NextResult();

            //                User.Projects = new List<LookUp>();

            //                while (reader.Read())
            //                {
            //                    User.Projects.Add(new LookUp
            //                    {
            //                        value = DataHelper.ConvertTo<string>(reader["project_code"]),
            //                        Description = DataHelper.ConvertTo<string>(reader["project_code"])
            //                    });


            //                }

            //                reader.NextResult();
            //                User.Roles = new List<AppUserRole>();

            //                while (reader.Read())
            //                {
            //                    AppUserRole role = new AppUserRole();
            //                    role.AppId = DataHelper.ConvertTo<int>(reader["AppId"]);
            //                    role.Approve = DataHelper.ConvertTo<int>(reader["Approve"]);
            //                    role.Read = DataHelper.ConvertTo<int>(reader["Read"]);
            //                    role.Modify = DataHelper.ConvertTo<int>(reader["Modify"]);
            //                    role.Write = DataHelper.ConvertTo<int>(reader["Write"]);
            //                    role.RoleName = DataHelper.ConvertTo<string>(reader["RoleName"]);
            //                    User.Roles.Add(role);

            //                }

            //                reader.NextResult();


            //                reader.Close();

            //            }

            //        }



            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;

            //    }
            return User;


        }

    }
}

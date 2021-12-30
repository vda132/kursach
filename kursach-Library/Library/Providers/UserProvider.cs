using Library.Models;
using Library.Providers.Abstract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Providers
{
    class UserProvider : CrudProviderBase<Users, int>
    {
        public override void Add(Users entity)
        {
            using (var connection = GetConnection())
            {
                var query = $"INSERT INTO Users(UserLogin, UserPassword, UserType) VALUES('{entity.UserLogin}','{entity.UserPassword}','{entity.UserType}')";
                var insert = new SqlCommand(query, connection);
                insert.ExecuteNonQuery();
            }
        }

        public override void Delete(int pk)
        {
            using (var connection = GetConnection())
            {
                var query = $"DELETE FROM Users WHERE IDUser = {pk}";
                var delete = new SqlCommand(query, connection);
                delete.ExecuteNonQuery();
            }
        }

        public override Users Get(int pk)
        {
            Users user = null;
            using (var connection = GetConnection())
            {
                var query = $"SELECT IDUser, UserLogin, UserPassword, UserType from Users WHERE IDUser={pk}";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();
                if (result.HasRows)
                {
                    result.Read();
                    user = new Users
                    {
                        IdUser = (int)result["IDUser"],
                        UserLogin = (string)result["UserLogin"],
                        UserPassword=(string)result["UserPassword"],
                        UserType = (string)result["UserType"]
                    };
                }
                else
                {
                    throw new ArgumentException("User has not been found.");
                }
            }
            return user;
        }

        public override IReadOnlyCollection<Users> GetAll()
        {
            var users = new List<Users>();
            using (var connection = GetConnection())
            {
                var query = $"SELECT IDUser, UserLogin, UserPassword, UserType from Users";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        users.Add(new Users
                        {
                            IdUser = (int)result["IDUser"],
                            UserLogin = (string)result["UserLogin"],
                            UserPassword = (string)result["UserPassword"],
                            UserType = (string)result["UserType"]
                        });
                    }
                }
            }
            return users;
        }

        public override void Update(int pk, Users entity)
        {
            using (var connection = GetConnection())
            {
                var query = $"UPDATE Users SET UserLogin='{entity.UserLogin}', UserPassword='{entity.UserPassword}', UserType='{entity.UserType}' WHERE IDUser={pk}";
                var update = new SqlCommand(query, connection);
                update.ExecuteNonQuery();
            }
        }
    }
}

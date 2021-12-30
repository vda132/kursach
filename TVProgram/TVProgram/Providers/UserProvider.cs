using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using TVProgram.Models;
using TVProgram.Providers.Abstract;

namespace TVProgram.Providers
{
    // Table: UserTable
    // Attributes: UserLogin, UserPassword, UserStatus
    class UserProvider : CrudProviderBase<User, string>
    {
        public override User Get(string login)
        {
            using (var connection = GetConnection())
            {
                var query = $"SELECT UserLogin, UserPassword, UserStatus FROM UserTable WHERE UserLogin = '{login}'";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();

                if (result.HasRows)
                {
                    result.Read();
                    return GetUser(result);
                }
                throw new ArgumentException("User has not been found");
            }
        }

        public override void Add(User entity)
        {
            using (var connection = GetConnection())
            {
                var query = $"INSERT INTO UserTable(UserLogin, UserPassword, UserStatus) VALUES ('{entity.Login}', '{entity.Password}', '{entity.Status}')";
                var insert = new SqlCommand(query, connection);
                insert.ExecuteNonQuery();
            }
        }

        public override IReadOnlyCollection<User> GetAll()
        {
            using (var connection = GetConnection())
            {
                var query = $"SELECT UserLogin, UserPassword, UserStatus FROM UserTable";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();

                var collection = new List<User>();

                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        collection.Add(GetUser(result));
                    }
                }

                return collection;
            }
        }

        public override void Update(string pk, User entity)
        {
            using (var connection = GetConnection())
            {
                var query = $"UPDATE UserTable SET UserPassword = '{entity.Password}', UserStatus = '{entity.Status}' WHERE UserLogin = '{entity.Login}'";
                var update = new SqlCommand(query, connection);
                update.ExecuteNonQuery();
            }
        }

        public override void Delete(string pk)
        {
            using (var connection = GetConnection())
            {
                var query = $"DELETE FROM UserTable WHERE UserLogin = '{pk}'";
                var delete = new SqlCommand(query, connection);
                delete.ExecuteNonQuery();
            }
        }

        private User GetUser(SqlDataReader reader)
        {
            return new User
            {
                Login = reader["UserLogin"].ToString(),
                Password = reader["UserPassword"].ToString(),
                Status = reader["UserStatus"].ToString()
            };
        }
    }
}

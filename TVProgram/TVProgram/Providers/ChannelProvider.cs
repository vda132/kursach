using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using TVProgram.Models;
using TVProgram.Providers.Abstract;

namespace TVProgram.Providers
{
    // Table: Channel
    // Attributes: IDChannel(pk), NameChannel
    class ChannelProvider : CrudProviderBase<TVChannel, int>
    {
        public override void Add(TVChannel entity)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var query = $"INSERT INTO Channel(NameChannel) VALUES ('{entity.NameChannel}')";
                var insert = new SqlCommand(query, connection);
                insert.ExecuteNonQuery();
            }
        }

        public override void Delete(int pk)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var query = $"DELETE FROM Channel WHERE IDChannel = {pk}";
                var delete = new SqlCommand(query, connection);
                delete.ExecuteNonQuery();
            }
        }

        public override TVChannel Get(int pk)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var query = $"SELECT IDChannel, NameChannel FROM Channel WHERE IDChannel = {pk}";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();

                if (result.HasRows)
                {
                    result.Read();

                    return new TVChannel
                    {
                        IDChannel = (int)result["IDChannel"],
                        NameChannel = (string)result["NameChannel"]
                    };
                }
                throw new ArgumentException("Channel has not been found");
            }
        }

        public override IReadOnlyCollection<TVChannel> GetAll()
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var query = $"SELECT IDChannel, NameChannel FROM Channel";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();

                var channels = new List<TVChannel>();
                if (result.HasRows)
                {
                    while(result.Read())
                    {
                        channels.Add(new TVChannel
                        {
                            IDChannel = (int)result["IDChannel"],
                            NameChannel = (string)result["NameChannel"],
                            Programs = GetPrograms((int)result["IDChannel"], connection)
                        });
                    }
                }
                return channels;
            }
        }

        public override void Update(int pk, TVChannel entity)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var query = $"UPDATE Channel SET NameChannel = '{entity.NameChannel}' WHERE IDChannel = {pk}";
                var update = new SqlCommand(query, connection);
                update.ExecuteNonQuery();
            }
        }

        public IReadOnlyCollection<Models.TVProgram> GetPrograms(int idChannel, SqlConnection connection)
        {
            var query = $"SELECT IDChannel, IDShow, DayWeekBegin, DayWeekEnd, TimeBegin, TimeEnd FROM Program WHERE IDChannel = '{idChannel}'";
            var select = new SqlCommand(query, connection);
            var result = select.ExecuteReader();

            var programs = new List<Models.TVProgram>();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    programs.Add(new Models.TVProgram
                    {
                        IDChannel = (int)result["IDChannel"],
                        IDShow = (int)result["IDShow"],
                        StartWeekDay = (string)result["DayWeekBegin"],
                        EndWeekDay = (string)result["DayWeekEnd"],
                        StartTime = Time.FromString(result["TimeBegin"].ToString()),
                        EndTime = Time.FromString(result["EndBegin"].ToString())
                    });
                }
            }
            return programs;
        }
    }
}

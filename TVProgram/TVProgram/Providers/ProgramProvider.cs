using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using TVProgram.Models;
using TVProgram.Providers.Abstract;

namespace TVProgram.Providers
{
    // Table: Program
    // Attributes: IDChannel, IDShow, DayWeekBegin, DayWeekEnd, TimeBegin, TimeEnd
    class ProgramProvider : CrudProviderBase<Models.TVProgram, TVProgramPK>
    {
        public override void Add(Models.TVProgram entity)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var query = $"INSERT INTO Program(IDChannel, IDShow, DayWeekBegin, DayWeekEnd, TimeBegin, TimeEnd) VALUES ({entity.IDChannel}, {entity.IDShow}, '{entity.StartWeekDay}', '{entity.EndWeekDay}', '{entity.StartTime}', '{entity.EndTime}')";
                var insert = new SqlCommand(query, connection);
                insert.ExecuteNonQuery();
            }
        }

        public override void Delete(TVProgramPK pk)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var query = $"DELETE FROM Program WHERE IDChannel = {pk.IDChannel} and IDShow = {pk.IDShow} and DayWeekBegin = '{pk.StartDayOfWeek}' and  TimeBegin = '{pk.StartTime}'";
                var delete = new SqlCommand(query, connection);
                delete.ExecuteNonQuery();
            }
        }

        public override Models.TVProgram Get(TVProgramPK pk)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var query = $"SELECT IDChannel, IDShow, DayWeekBegin, DayWeekEnd, TimeBegin, TimeEnd FROM Program WHERE IDChannel = {pk.IDChannel} and IDShow = {pk.IDShow} and DayWeekBegin = '{pk.StartDayOfWeek}' and  TimeBegin = '{pk.StartTime}'";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();

                if (result.HasRows)
                {
                    result.Read();

                    return new Models.TVProgram
                    {
                        IDChannel = (int)result["IDChannel"],
                        Channel = GetChannel((int)result["IDChannel"], connection),
                        IDShow = (int)result["IDShow"],
                        Show = GetShow((int)result["IDShow"], connection),
                        StartWeekDay = (string)result["DayWeekBegin"],
                        EndWeekDay = (string)result["DayWeekEnd"],
                        StartTime = Time.FromString(result["TimeBegin"].ToString()),
                        EndTime = Time.FromString(result["EndBegin"].ToString())
                    };
                }
                throw new ArgumentException("Program has not been found");
            }
        }

        public override IReadOnlyCollection<Models.TVProgram> GetAll()
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var query = $"SELECT IDChannel, IDShow, DayWeekBegin, DayWeekEnd, TimeBegin, TimeEnd FROM Program";
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
                            Channel = GetChannel((int)result["IDChannel"], connection),
                            IDShow = (int)result["IDShow"],
                            Show = GetShow((int)result["IDShow"], connection),
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

        public override void Update(TVProgramPK pk, Models.TVProgram entity)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var query = $"UPDATE Channel SET IDChannel = {entity.IDChannel}, IDShow = {entity.IDShow}, DayWeekBegin = '{entity.StartWeekDay}', DayWeekEnd = '{entity.EndWeekDay}', TimeBegin = '{entity.StartTime}', TimeEnd = '{entity.EndTime}' WHERE IDChannel = {pk.IDChannel} and IDShow = {pk.IDShow} and DayWeekBegin = '{pk.StartDayOfWeek}' and  TimeBegin = '{pk.StartTime}'";
                var update = new SqlCommand(query, connection);
                update.ExecuteNonQuery();
            }
        }

        private TVChannel GetChannel(int idChannel, SqlConnection connection)
        {
            var query = $"SELECT IDChannel, NameChannel FROM Channel WHERE IDChannel = {idChannel}";
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

        private TVShow GetShow(int idShow, SqlConnection connection)
        {
            var query = $"SELECT IDShow, NameShow FROM Show WHERE IDShow = {idShow}";
            var select = new SqlCommand(query, connection);
            var result = select.ExecuteReader();

            if (result.HasRows)
            {
                result.Read();

                return new TVShow
                {
                    IDShow = (int)result["IDShow"],
                    NameShow = (string)result["NameShow"]
                };
            }
            throw new ArgumentException("Show has not been found");
        }
    }
}

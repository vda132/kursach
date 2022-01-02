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
                var query = $"INSERT INTO Program(IDChannel, IDShow, DayWeekBegin, DayWeekEnd, TimeBegin, TimeEnd) VALUES ({entity.IDChannel}, {entity.IDShow}, '{entity.StartWeekDay}', '{entity.EndWeekDay}', '{entity.StartTime}', '{entity.EndTime}')";
                var insert = new SqlCommand(query, connection);
                insert.ExecuteNonQuery();
            }
        }

        public override void Delete(TVProgramPK pk)
        {
            using (var connection = GetConnection())
            {
                var query = $"DELETE FROM Program WHERE IDChannel = {pk.IDChannel} and IDShow = {pk.IDShow} and DayWeekBegin = '{pk.StartDayOfWeek}' and  TimeBegin = '{pk.StartTime}'";
                var delete = new SqlCommand(query, connection);
                delete.ExecuteNonQuery();
            }
        }

        public override Models.TVProgram Get(TVProgramPK pk)
        {
            using (var connection = GetConnection())
            {
                var query = $"SELECT Channel.IDChannel, NameChannel, Show.IDShow, NameShow, DayWeekBegin, DayWeekEnd, TimeBegin, TimeEnd FROM Program inner join Channel on Program.IDChannel = Channel.IDChannel inner join Show Program.IDShow = Show.IDShow WHERE IDChannel = {pk.IDChannel} and IDShow = {pk.IDShow} and DayWeekBegin = '{pk.StartDayOfWeek}' and  TimeBegin = '{pk.StartTime}'";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();

                if (result.HasRows)
                {
                    result.Read();
                    return GetProgram(result);                    
                }
                throw new ArgumentException("Program has not been found");
            }
        }

        public override IReadOnlyCollection<Models.TVProgram> GetAll()
        {
            using (var connection = GetConnection())
            {
                var query = $"SELECT Channel.IDChannel, NameChannel, Show.IDShow, NameShow, DayWeekBegin, DayWeekEnd, TimeBegin, TimeEnd FROM Program inner join Channel on Program.IDChannel = Channel.IDChannel inner join Show on Program.IDShow = Show.IDShow";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();

                var programs = new List<Models.TVProgram>();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        programs.Add(GetProgram(result));
                    }
                }
                return programs;
            }
        }

        public override void Update(TVProgramPK pk, Models.TVProgram entity)
        {
            using (var connection = GetConnection())
            {
                var query = $"UPDATE Channel SET IDChannel = {entity.IDChannel}, IDShow = {entity.IDShow}, DayWeekBegin = '{entity.StartWeekDay}', DayWeekEnd = '{entity.EndWeekDay}', TimeBegin = '{entity.StartTime}', TimeEnd = '{entity.EndTime}' WHERE IDChannel = {pk.IDChannel} and IDShow = {pk.IDShow} and DayWeekBegin = '{pk.StartDayOfWeek}' and  TimeBegin = '{pk.StartTime}'";
                var update = new SqlCommand(query, connection);
                update.ExecuteNonQuery();
            }
        }

        // Reduce amount of rows
        private Models.TVProgram GetProgram(SqlDataReader reader)
        {
            return new Models.TVProgram
            {
                IDChannel = (int)reader["IDChannel"],
                Channel = new TVChannel { IDChannel = (int)reader["IDChannel"], NameChannel = (string)reader["NameChannel"] },
                IDShow = (int)reader["IDShow"],
                Show = new TVShow { IDShow = (int)reader["IDShow"], NameShow = (string)reader["NameShow"] },
                StartWeekDay = (string)reader["DayWeekBegin"],
                EndWeekDay = (string)reader["DayWeekEnd"],
                StartTime = Time.FromString(reader["TimeBegin"].ToString()),
                EndTime = Time.FromString(reader["TimeEnd"].ToString())
            };
        }
    }
}

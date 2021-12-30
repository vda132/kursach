using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using TVProgram.Models;
using TVProgram.Providers.Abstract;

namespace TVProgram.Providers
{
    // Table: Show
    // Attributes: IDShow, NameShow
    class ShowProvider : CrudProviderBase<TVShow, int>
    {
        public override void Add(TVShow entity)
        {
            using (var connection = GetConnection())
            {
                var query = $"INSERT INTO Show(NameShow) VALUES ('{entity.NameShow}')";
                var insert = new SqlCommand(query, connection);
                insert.ExecuteNonQuery();
            }
        }

        public override void Delete(int pk)
        {
            using (var connection = GetConnection())
            {
                var query = $"DELETE FROM Show WHERE IDShow = {pk}";
                var delete = new SqlCommand(query, connection);
                delete.ExecuteNonQuery();
            }
        }

        public override TVShow Get(int pk)
        {
            using (var connection = GetConnection())
            {
                var query = $"SELECT IDShow, NameShow FROM Show WHERE IDShow = {pk}";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();

                if (result.HasRows)
                {
                    result.Read();

                    return GetShow(result, connection);
                }
                throw new ArgumentException("Show has not been found");
            }
        }

        public override IReadOnlyCollection<TVShow> GetAll()
        {
            using (var connection = GetConnection())
            {
                var query = $"SELECT IDShow, NameShow FROM Show";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();

                var shows = new List<TVShow>();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        shows.Add(GetShow(result, connection));
                    }
                }
                return shows;
            }
        }

        public override void Update(int pk, TVShow entity)
        {
            using (var connection = GetConnection())
            {
                var query = $"UPDATE Show SET NameShow = '{entity.NameShow}' WHERE IDShow = {pk}";
                var update = new SqlCommand(query, connection);
                update.ExecuteNonQuery();
            }
        }

        private TVShow GetShow(SqlDataReader reader, SqlConnection connection)
        {
            return new TVShow
            {
                IDShow = (int)reader["IDShow"],
                NameShow = (string)reader["NameShow"],
                Genres = GetGenres((int)reader["IDShow"], connection),
                Programs = GetPrograms((int)reader["IDShow"], connection)
            };
        }

        public IReadOnlyCollection<TVGenre> GetGenres(int idShow, SqlConnection connection)
        {
            var query = $"SELECT IDGenre, NameGenre FROM Genre INNER JOIN GenreShow ON Genre.IDGenre = GenreShow.IDGenre WHERE IDShow = {idShow}";
            var select = new SqlCommand(query, connection);
            var result = select.ExecuteReader();

            var genres = new List<TVGenre>();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    genres.Add(new TVGenre
                    {
                        IDGenre = (int)result["IDGenre"],
                        NameGenre = (string)result["NameGenre"]
                    });
                }
            }
            return genres;
        }

        public IReadOnlyCollection<Models.TVProgram> GetPrograms(int idShow, SqlConnection connection)
        {
            var query = $"SELECT IDChannel, IDShow, DayWeekBegin, DayWeekEnd, TimeBegin, TimeEnd FROM Program WHERE IDShow = '{idShow}'";
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

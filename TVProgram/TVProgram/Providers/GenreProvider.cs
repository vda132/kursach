using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using TVProgram.Models;
using TVProgram.Providers.Abstract;

namespace TVProgram.Providers
{
    // Table: Genre
    // Attributes: IDGenre, NameGenre
    class GenreProvider : CrudProviderBase<TVGenre, int>
    {
        public override void Add(TVGenre entity)
        {
            using (var connection = GetConnection())
            {
                var query = $"INSERT INTO Genre(NameGenre) VALUES ('{entity.NameGenre}')";
                var insert = new SqlCommand(query, connection);
                insert.ExecuteNonQuery();
            }
        }

        public override void Delete(int pk)
        {
            using (var connection = GetConnection())
            {
                var query = $"DELETE FROM Genre WHERE IDGenre = {pk}";
                var delete = new SqlCommand(query, connection);
                delete.ExecuteNonQuery();
            }
        }

        public override TVGenre Get(int pk)
        {
            using (var connection = GetConnection())
            {
                var query = $"SELECT IDGenre, NameGenre FROM Genre WHERE IDGenre = {pk}";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();

                if (result.HasRows)
                {
                    result.Read();
                    return GetGenre(result, connection);
                }
                throw new ArgumentException("Genre has not been found");
            }
        }

        public override IReadOnlyCollection<TVGenre> GetAll()
        {
            using (var connection = GetConnection())
            {
                var query = $"SELECT IDGenre, NameGenre FROM Genre";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();

                var genres = new List<TVGenre>();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        genres.Add(GetGenre(result, connection));
                    }
                }
                return genres;
            }
        }

        public override void Update(int pk, TVGenre entity)
        {
            using (var connection = GetConnection())
            {
                var query = $"UPDATE Genre SET NameGenre = '{entity.NameGenre}' WHERE IDGenre = {pk}";
                var update = new SqlCommand(query, connection);
                update.ExecuteNonQuery();
            }
        }

        private TVGenre GetGenre(SqlDataReader reader, SqlConnection connection)
        {
            return new TVGenre
            {
                IDGenre = (int)reader["IDGenre"],
                NameGenre = (string)reader["NameGenre"],
                Shows = GetShows((int)reader["IDGenre"], connection)
            };
        }

        private IReadOnlyCollection<TVShow> GetShows(int idGenre, SqlConnection connection)
        {
            var query = $"SELECT IDShow, NameShow FROM Show INNER JOIN GenreShow ON Show.IDShow = GenreShow.IDShow WHERE IDGenre = {idGenre}";
            var select = new SqlCommand(query, connection);
            var result = select.ExecuteReader();

            var shows = new List<TVShow>();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    shows.Add(new TVShow
                    {
                        IDShow = (int)result["IDShow"],
                        NameShow = (string)result["NameShow"]
                    });
                }
            }
            return shows;
        }
    }
}

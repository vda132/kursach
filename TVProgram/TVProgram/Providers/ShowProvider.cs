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

        public void AddGenre(int showId, int genreId)
        {
            using (var connection = GetConnection())
            {
                var query = $"INSERT INTO GenreShow(IDShow, IDGenre) VALUES ({showId}, {genreId})";
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

        public void DeleteGenre(int showId, int genreId)
        {
            using (var connection = GetConnection())
            {
                var query = $"DELETE FROM GenreShow WHERE IDShow = {showId} AND IDGenre = {genreId}";
                var delete = new SqlCommand(query, connection);
                delete.ExecuteNonQuery();
            }
        }

        public override TVShow Get(int pk)
        {
            TVShow show = null;

            using (var connection = GetConnection())
            {
                var query = $"SELECT IDShow, NameShow FROM Show WHERE IDShow = {pk}";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();

                if (result.HasRows)
                {
                    result.Read();

                    show = GetShow(result, connection);
                }
                else
                {
                    throw new ArgumentException("Show has not been found");
                }
            }

            SetLists(show.IDShow, show);

            return show;
        }

        public IReadOnlyCollection<TVGenre> GetGenres(int showId)
        {
            using (var connection = GetConnection())
            {
                var query = $"SELECT Genre.IDGenre, NameGenre FROM Genre INNER JOIN GenreShow ON Genre.IDGenre = GenreShow.IDGenre WHERE IDShow = {showId}";
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
        }

        public IReadOnlyCollection<TVChannel> GetChannels(int showId)
        {
            using (var connection = GetConnection())
            {
                var query = $"SELECT Channel.IDChannel, NameChannel FROM Channel INNER JOIN ShowChannel ON Channel.IDChannel = ShowChannel.IDChannel WHERE IDShow = {showId}";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();

                var channels = new List<TVChannel>();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        channels.Add(new TVChannel
                        {
                            IDChannel = (int)result["IDChannel"],
                            NameChannel = (string)result["NameChannel"]
                        });
                    }
                }
                return channels;
            }
        }

        public IReadOnlyCollection<Models.TVProgram> GetPrograms(int showId)
        {
            using (var connection = GetConnection())
            {
                var query = $"SELECT IDChannel, IDShow, DayWeekBegin, DayWeekEnd, TimeBegin, TimeEnd FROM Program WHERE IDShow = '{showId}'";
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
                            EndTime = Time.FromString(result["TimeEnd"].ToString())
                        });
                    }
                }
                return programs;
            }
        }

        public override IReadOnlyCollection<TVShow> GetAll()
        {
            var shows = new List<TVShow>();

            using (var connection = GetConnection())
            {
                var query = $"SELECT IDShow, NameShow FROM Show";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();

                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        shows.Add(GetShow(result, connection));
                    }
                }
            }

            foreach (var show in shows)
                SetLists(show.IDShow, show);

            return shows;
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
                NameShow = (string)reader["NameShow"]
            };
        }

        private void SetLists(int showId, TVShow show)
        {
            SetGenres(showId, show);
            SetChannels(showId, show);
            SetPrograms(showId, show);
        }

        private void SetGenres(int idShow, TVShow show)
        {
            show.Genres = GetGenres(idShow);
        }

        private void SetChannels(int idShow, TVShow show)
        {
            show.Channels = GetChannels(idShow);
        }

        private void SetPrograms(int idShow, TVShow show)
        {
            show.Programs = GetPrograms(idShow);
        }
    }
}

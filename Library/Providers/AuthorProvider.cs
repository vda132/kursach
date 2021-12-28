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
    class AuthorProvider : CrudProviderBase<Author, int>
    {
        public override void Add(Author entity)
        {
            using (var connection = GetConnection())
            {
                var query = $"INSERT INTO Author(AuthorName) VALUES('{entity.AuthorName}')";
                var insert = new SqlCommand(query, connection);
                insert.ExecuteNonQuery();
            }
        }

        public override void Delete(int pk)
        {
            using (var connection = GetConnection())
            {
                var query = $"DELETE FROM Author WHERE AuthorID = {pk}";
                var delete = new SqlCommand(query, connection);
                delete.ExecuteNonQuery();
            }
        }

        public override Author Get(int pk)
        {
            Author author = null;
            using (var connection = GetConnection())
            {
                var query = $"SELECT AuthorID, AuthorName FROM Author WHERE AuthorID = {pk}";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();
                if (result.HasRows)
                {
                    result.Read();
                    author = new Author
                    {
                        AuthorID = (int)result["AuthorID"],
                        AuthorName = (string)result["AuthorName"],
                    };
                }
                else
                {
                    throw new ArgumentException("Author has not been found.");
                }
            }
            author.AuthorBookFunds = GetAuthorBookFund(author.AuthorID);
            return author;
        }

        public override IReadOnlyCollection<Author> GetAll()
        {
            var authors = new List<Author>();
            using (var connection = GetConnection())
            {
                var query = $"SELECT AuthorID, AuthorName FROM Author";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        authors.Add(new Author
                        {
                            AuthorID = (int)result["AuthorID"],
                            AuthorName = (string)result["AuthorName"],
                        });
                    }
                }
            }
            foreach (var author in authors)
                author.AuthorBookFunds = GetAuthorBookFund(author.AuthorID);
            return authors;
        }

        public override void Update(int pk, Author entity)
        {
            using (var connection = GetConnection())
            {
                var query = $"UPDATE Author SET AuthorName='{entity.AuthorName}' WHERE AuthorID = {pk}";
                var update = new SqlCommand(query, connection);
                update.ExecuteNonQuery();
            }
        }
        public IReadOnlyCollection<AuthorBookFund> GetAuthorBookFund(int id)
        {
            using (var connection = GetConnection())
            {
                var query = $"SELECT BookID, LibraryBookNo, AuthorID from AuthorBookFund WHERE AuthorID={id}";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();

                var authorBookFund = new List<AuthorBookFund>();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        authorBookFund.Add(new AuthorBookFund
                        {
                            BookID = (int)result["BookID"],
                            LibraryBookNO = (int)result["LibraryBookNo"],
                            AuthorID = (int)result["AuthorID"],
                        });
                    }
                }
                return authorBookFund;
            }
        }
    }
}

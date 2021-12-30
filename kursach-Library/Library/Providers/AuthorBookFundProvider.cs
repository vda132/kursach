using Library.Models;
using Library.Models.PK;
using Library.Providers.Abstract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Providers
{
    class AuthorBookFundProvider : CrudProviderBase<AuthorBookFund, AuthorBookFundPK>
    {
        public override void Add(AuthorBookFund entity)
        {
            using (var connection = GetConnection())
            {
                var query = $"INSERT INTO AuthorBookFund(BookID, LibraryBookNO, AuthorID) VALUES({entity.BookID},{entity.LibraryBookNO},{entity.AuthorID})";
                var insert = new SqlCommand(query, connection);
                insert.ExecuteNonQuery();
            }
        }

        public override void Delete(AuthorBookFundPK pk)
        {
            using (var connection = GetConnection())
            {
                var query = $"DELETE FROM AuthorBookFund WHERE BookID = {pk.BookID} AND LibraryBookNO={pk.LibraryBookNO} AND AuthorID={pk.AuthorID}";
                var delete = new SqlCommand(query, connection);
                delete.ExecuteNonQuery();
            }
        }

        public override AuthorBookFund Get(AuthorBookFundPK pk)
        {
            AuthorBookFund authorBookFund = null;
            using (var connection = GetConnection())
            {
                var query = $"SELECT BookID, LibraryBookNO, AuthorID FROM AuthorBookFund WHERE BookID = {pk.BookID} AND LibraryBookNO={pk.LibraryBookNO} AND AuthorID={pk.AuthorID}";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();
                if (result.HasRows)
                {
                    result.Read();
                    authorBookFund = new AuthorBookFund
                    {
                        BookID = (int)result["BookID"],
                        LibraryBookNO = (int)result["LibraryBookNO"],
                        AuthorID = (int)result["AuthorID"]
                    };
                }
                else
                {
                    throw new ArgumentException("Author has not been found.");
                }
            }
            authorBookFund.Author = GetAuthor(pk);
            authorBookFund.BookFund = GetBookFund(pk);
            return authorBookFund;
        }

        public override IReadOnlyCollection<AuthorBookFund> GetAll()
        {
            var authorBookFunds = new List<AuthorBookFund>();
            using (var connection = GetConnection())
            {
                var query = $"SELECT BookID, LibraryBookNO, AuthorID FROM AuthorBookFund";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        authorBookFunds.Add(new AuthorBookFund
                        {
                            BookID = (int)result["BookID"],
                            LibraryBookNO = (int)result["LibraryBookNO"],
                            AuthorID = (int)result["AuthorID"]
                        });
                    }
                }
            }
            AuthorBookFundPK pk = new AuthorBookFundPK();
            foreach (var authorBookFund in authorBookFunds)
            {
                pk.BookID = authorBookFund.BookID;
                pk.LibraryBookNO = authorBookFund.LibraryBookNO;
                pk.AuthorID = authorBookFund.AuthorID;
                authorBookFund.BookFund = GetBookFund(pk);
                authorBookFund.Author = GetAuthor(pk);
            }
            return authorBookFunds;
        }

        public override void Update(AuthorBookFundPK pk, AuthorBookFund entity)
        {
            using (var connection = GetConnection())
            {
                var query = $"UPDATE AuthorBookFund SET BookID={entity.BookID}, LibraryBookNO={entity.LibraryBookNO}, AuthorID={entity.AuthorID} WHERE BookID = {pk.BookID} AND LibraryBookNO={pk.LibraryBookNO} AND AuthorID={pk.AuthorID}";
                var update = new SqlCommand(query, connection);
                update.ExecuteNonQuery();
            }
        }
        public Author GetAuthor(AuthorBookFundPK pk)
        {
            Author author = null;
            using (var connection = GetConnection())
            {
                var query = $"SELECT AuthorID, AuthorName FROM Author WHERE AuthorID = {pk.AuthorID}";
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
            return author;
        }
        public BookFund GetBookFund(AuthorBookFundPK pk)
        {
            BookFund bookFund = null;
            using (var connection = GetConnection())
            {
                var query = $"SELECT BookID, LibraryBookNO, BookName, DateOfPublication, Capacity, BookStatus FROM BookFund WHERE BookID = {pk.BookID} AND LibraryBookNO={pk.LibraryBookNO}";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();
                if (result.HasRows)
                {
                    result.Read();
                    bookFund = new BookFund
                    {
                        BookID = (int)result["BookID"],
                        LibraryBookNO = (int)result["LibraryBookNO"],
                        BookName=(string)result["BookName"],
                        DateOfPublication=(DateTime)result["DateOfPublication"],
                        Capacity=(int)result["Capacity"],
                        BookStatus = (bool)result["BookStatus"]
                    };
                }
                else
                {
                    throw new ArgumentException("BookFund has not been found.");
                }
            }
            return bookFund;
        }
    }
}

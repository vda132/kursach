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
    class BookFundProvider : CrudProviderBase<BookFund, BookFundPK>
    {
        public override void Add(BookFund entity)
        {
            using (var connection = GetConnection())
            {
                var query = $"INSERT INTO BookFund(BookID, BookName, DateOfPublication, Capacity, Price) VALUES({entity.BookID},'{entity.BookName}','{entity.DateOfPublication}','{entity.Capacity}','{entity.Capacity}')";
                var insert = new SqlCommand(query, connection);
                insert.ExecuteNonQuery();
            }
        }

        public override void Delete(BookFundPK pk)
        {
            using (var connection = GetConnection())
            {
                var query = $"DELETE FROM BookFund WHERE BookID = {pk.BookID} AND LibraryBookNO={pk.LibraryBookNO}";
                var delete = new SqlCommand(query, connection);
                delete.ExecuteNonQuery();
            }
        }

        public override BookFund Get(BookFundPK pk)
        {
            var bookFund = new BookFund();
            using (var connection = GetConnection())
            {
                var query = $"SELECT BookID, LibraryBookNO, BookName, DateOfPublication, Capacity, Price FROM BookFund WHERE BookID = {pk.BookID} AND LibraryBookNO = {pk.LibraryBookNO}";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();
                if (result.HasRows)
                {
                    result.Read();
                    bookFund = new BookFund
                    {
                        BookID = (int)result["BookID"],
                        LibraryBookNO = (int)result["LibraryBookNO"],
                        BookName = (string)result["BookName"],
                        DateOfPublication = (DateTime)result["DateOfPublication"],
                        Capacity = (int)result["Capacity"],
                        Price = (decimal)result["Price"]
                    };
                }
                else
                {
                    throw new ArgumentException("bookFund has not been found.");
                }
            }
            bookFund.Extraditions = GetExtradition(pk);
            bookFund.AuthorBookFunds = GetAuthorBookFund(pk);
            bookFund.ThemeBookFunds = GetThemeBookFund(pk);
            return bookFund;
        }

        public override IReadOnlyCollection<BookFund> GetAll()
        {
            var bookFunds = new List<BookFund>();
            using (var connection = GetConnection())
            {
                var query = $"SELECT BookID, LibraryBookNO, BookName, DateOfPublication, Capacity, Price FROM BookFund";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        bookFunds.Add(new BookFund
                        {
                            BookID = (int)result["BookID"],
                            LibraryBookNO = (int)result["LibraryBookNO"],
                            BookName = (string)result["BookName"],
                            DateOfPublication = (DateTime)result["DateOfPublication"],
                            Capacity = (int)result["Capacity"],
                            Price = (decimal)result["Price"]
                        });
                    }
                }
            }
            BookFundPK pk = new BookFundPK();
            foreach (var bookFund in bookFunds)
            {
                pk.BookID = bookFund.BookID;
                pk.LibraryBookNO = bookFund.LibraryBookNO;
                bookFund.Extraditions = GetExtradition(pk);
                bookFund.AuthorBookFunds = GetAuthorBookFund(pk);
                bookFund.ThemeBookFunds = GetThemeBookFund(pk);
            }
            return bookFunds;
        }

        public override void Update(BookFundPK pk, BookFund entity)
        {
            using (var connection = GetConnection())
            {
                var query = $"UPDATE BookFund SET BookName='{entity.BookName}', DateOfPublication='{entity.DateOfPublication}', Capacity={entity.Capacity}, Price={entity.Price} WHERE BookID={pk.BookID} AND LibraryBookNo={pk.LibraryBookNO}";
                var update = new SqlCommand(query, connection);
                update.ExecuteNonQuery();
            }
        }

        public IReadOnlyCollection<Extradition> GetExtradition(BookFundPK pk)
        {
            using (var connection = GetConnection())
            {
                var query = $"SELECT BookID, LibraryBookNo, ReaderNo, DateOfExtradition, DateOfReturn, Information from Extradition WHERE BookID={pk.BookID} AND LibraryBookNo={pk.LibraryBookNO}";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();

                var extraditions = new List<Extradition>();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        extraditions.Add(new Extradition
                        {
                            BookID = (int)result["BookID"],
                            LibraryBookNO = (int)result["LibraryBookNo"],
                            ReaderNo = (int)result["ReaderNo"],
                            DateOfExtradition = (DateTime)result["DateOfExtradition"],
                            DateOfReturn = (DateTime)result["DateOfReturn"],
                            Information = (string)result["Information"]
                        });
                    }
                }
                return extraditions;
            }
        }
        public IReadOnlyCollection<AuthorBookFund> GetAuthorBookFund(BookFundPK pk)
        {
            using (var connection = GetConnection())
            {
                var query = $"SELECT BookID, LibraryBookNO, AuthorID from AuthorBookFund WHERE BookID={pk.BookID} AND LibraryBookNo={pk.LibraryBookNO}";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();

                var authors = new List<AuthorBookFund>();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        authors.Add(new AuthorBookFund
                        {
                            BookID = (int)result["BookID"],
                            LibraryBookNO = (int)result["LibraryBookNo"],
                            AuthorID = (int)result["AuthorID"]
                        });
                    }
                }
                return authors;
            }
        }
        public IReadOnlyCollection<ThemeBookFund> GetThemeBookFund(BookFundPK pk)
        {
            using (var connection = GetConnection())
            {
                var query = $"SELECT BookID, LibraryBookNO, ThemeID  from ThemeBookFund WHERE BookID={pk.BookID} AND LibraryBookNo={pk.LibraryBookNO}";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();

                var authors = new List<ThemeBookFund>();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        authors.Add(new ThemeBookFund
                        {
                            BookID = (int)result["BookID"],
                            LibraryBookNO = (int)result["LibraryBookNo"],
                            ThemeID = (int)result["AuthorID"]
                        });
                    }
                }
                return authors;
            }
        }
    }
}

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
    class ExtraditionProvider : CrudProviderBase<Extradition, ExtraditionPK>
    {
        public override void Add(Extradition entity)
        {
            using (var connection = GetConnection())
            {
                var query = $"INSERT INTO Extradition(BookID, LibraryBookNO, ReaderNo, DateOfExtradition, DateOfReturn, Information) VALUES({entity.BookID},{entity.LibraryBookNO},{entity.ReaderNo},'{entity.DateOfExtradition}','{entity.DateOfReturn}','{entity.Information}')";
                var insert = new SqlCommand(query, connection);
                insert.ExecuteNonQuery();
            }
        }

        public override void Delete(ExtraditionPK pk)
        {
            using (var connection = GetConnection())
            {
                var query = $"DELETE FROM Extradition WHERE BookID = {pk.BookID} AND DateOfExtradition='{pk.LibraryBookNO}' AND ReaderNo={pk.DateOfExtradition}";
                var delete = new SqlCommand(query, connection);
                delete.ExecuteNonQuery();
            }
        }

        public override Extradition Get(ExtraditionPK pk)
        {
            Extradition extradition = null;
            using (var connection = GetConnection())
            {
                var query = $"SELECT BookID, LibraryBookNO, ReaderNo, DateOfExtradition, DateOfReturn, Information FROM AuthorBookFund WHERE BookID = {pk.BookID} AND LibraryBookNO={pk.LibraryBookNO} AND DateOfExtradition='{pk.DateOfExtradition}'";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();
                if (result.HasRows)
                {
                    result.Read();
                    extradition = new Extradition
                    {
                        BookID = (int)result["BookID"],
                        LibraryBookNO = (int)result["LibraryBookNO"],
                        ReaderNo = (int)result["ReaderNo"],
                        DateOfExtradition=(DateTime)result["DateOfExtradition"],
                        DateOfReturn=(DateTime)result["DateOfReturn"],
                        Information=(string)result["Information"]
                    };
                }
                else
                {
                    throw new ArgumentException("Author has not been found.");
                }
            }
            extradition.Reader = GetReader(extradition);
            extradition.BookFund = GetBookFund(pk);
            return extradition;
        }

        public override IReadOnlyCollection<Extradition> GetAll()
        {
            var extraditions = new List<Extradition>();
            using (var connection = GetConnection())
            {
                var query = $"SELECT BookID, LibraryBookNO, ReaderNo, DateOfExtradition, DateOfReturn, Information FROM Extradition";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        extraditions.Add(new Extradition
                        {
                            BookID = (int)result["BookID"],
                            LibraryBookNO = (int)result["LibraryBookNO"],
                            ReaderNo = (int)result["ReaderNo"],
                            DateOfExtradition = (DateTime)result["DateOfExtradition"],
                            DateOfReturn = (DateTime)result["DateOfReturn"],
                            Information = (string)result["Information"]
                        });
                    }
                }
            }
            ExtraditionPK pk = new ExtraditionPK();
            foreach (var extradition in extraditions)
            {
                pk.BookID = extradition.BookID;
                pk.LibraryBookNO = extradition.LibraryBookNO;
                pk.DateOfExtradition = extradition.DateOfExtradition;
                extradition.Reader = GetReader(extradition);
                extradition.BookFund = GetBookFund(pk);
            }
            return extraditions;
        }

        public override void Update(ExtraditionPK pk, Extradition entity)
        {
            using (var connection = GetConnection())
            {
                var query = $"UPDATE Extradition SET BookID={entity.BookID}, LibraryBookNO={entity.LibraryBookNO}, ReaderNo = {entity.ReaderNo}, DateOfExtradition='{entity.DateOfExtradition}', DateOfReturn='{entity.DateOfReturn}', Information='{entity.Information}' WHERE BookID = {pk.BookID} AND LibraryBookNO={pk.LibraryBookNO} AND DateOfExtradition='{entity.DateOfExtradition}'";
                var update = new SqlCommand(query, connection);
                update.ExecuteNonQuery();
            }
        }
        public Reader GetReader(Extradition pk)
        {
            Reader reader = null;
            using (var connection = GetConnection())
            {
                var query = $"SELECT ReaderNo, ReaderName, Adress, Phone FROM Reader WHERE ReaderNo = {pk.ReaderNo}";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();
                if (result.HasRows)
                {
                    result.Read();
                    reader = new Reader
                    {
                        ReaderNo = (int)result["ReaderNo"],
                        ReaderName = (string)result["ReaderName"],
                        Adress = (string)result["Adress"],
                        Phone = (string)result["Phone"]
                    };
                }
                else
                {
                    throw new ArgumentException("Reader has not been found.");
                }
            }
            return reader;
        }
        public BookFund GetBookFund(ExtraditionPK pk)
        {
            var bookFund = new BookFund();
            using (var connection = GetConnection())
            {
                var query = $"SELECT BookID, LibraryBookNO, BookName, DateOfPublication, Capacity, BookStatus FROM BookFund WHERE BookID = {pk.BookID} AND LibraryBookNO = {pk.LibraryBookNO}";
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
                        BookStatus = (bool)result["BookStatus"]
                    };
                }
                else
                {
                    throw new ArgumentException("bookFund has not been found.");
                }
            }
            return bookFund;
        }
    }
}

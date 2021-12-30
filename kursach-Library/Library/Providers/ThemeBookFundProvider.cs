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
    class ThemeBookFundProvider : CrudProviderBase<ThemeBookFund, ThemeBookFundPK>
    {
        public override void Add(ThemeBookFund entity)
        {
            using (var connection = GetConnection())
            {
                var query = $"INSERT INTO ThemeBookFund(BookID, LibraryBookNO, ThemeID) VALUES({entity.BookID},{entity.LibraryBookNO},{entity.ThemeID})";
                var insert = new SqlCommand(query, connection);
                insert.ExecuteNonQuery();
            }
        }

        public override void Delete(ThemeBookFundPK pk)
        {
            using (var connection = GetConnection())
            {
                var query = $"DELETE FROM ThemeBookFund WHERE BookID = {pk.BookID} AND LibraryBookNO={pk.LibraryBookNO} AND ThemeID={pk.ThemeID}";
                var delete = new SqlCommand(query, connection);
                delete.ExecuteNonQuery();
            }
        }

        public override ThemeBookFund Get(ThemeBookFundPK pk)
        {
            ThemeBookFund themeBookFund = null;
            using (var connection = GetConnection())
            {
                var query = $"SELECT BookID, LibraryBookNO, ThemeID FROM ThemeBookFund WHERE BookID = {pk.BookID} AND LibraryBookNO={pk.LibraryBookNO} AND ThemeID={pk.ThemeID}";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();
                if (result.HasRows)
                {
                    result.Read();
                    themeBookFund = new ThemeBookFund
                    {
                        BookID = (int)result["BookID"],
                        LibraryBookNO = (int)result["LibraryBookNO"],
                        ThemeID = (int)result["ThemeID"]
                    };
                }
                else
                {
                    throw new ArgumentException("ThemeBookFund has not been found.");
                }
            }
            themeBookFund.Theme = GetTheme(pk);
            themeBookFund.BookFund = GetBookFund(pk);
            return themeBookFund;
        }

        public override IReadOnlyCollection<ThemeBookFund> GetAll()
        {
            var themeBookFunds = new List<ThemeBookFund>();
            using (var connection = GetConnection())
            {
                var query = $"SELECT BookID, LibraryBookNO, ThemeID FROM ThemeBookFund";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        themeBookFunds.Add(new ThemeBookFund
                        {
                            BookID = (int)result["BookID"],
                            LibraryBookNO = (int)result["LibraryBookNO"],
                            ThemeID = (int)result["ThemeID"]
                        });
                    }
                }
                else
                {
                    throw new ArgumentException("Author has not been found.");
                }
            }
            ThemeBookFundPK pk = new ThemeBookFundPK();
            foreach (var themeBookFund in themeBookFunds)
            {
                pk.BookID = themeBookFund.BookID;
                pk.LibraryBookNO = themeBookFund.LibraryBookNO;
                pk.ThemeID = themeBookFund.ThemeID;
                themeBookFund.Theme = GetTheme(pk);
                themeBookFund.BookFund = GetBookFund(pk);
            }
            return themeBookFunds;
        }

        public override void Update(ThemeBookFundPK pk, ThemeBookFund entity)
        {
            using (var connection = GetConnection())
            {
                var query = $"UPDATE ThemeBookFund SET BookID={entity.BookID}, LibraryBookNO={entity.LibraryBookNO}, ThemeID={entity.ThemeID} WHERE BookID = {pk.BookID} AND LibraryBookNO={pk.LibraryBookNO} AND ThemeID={pk.ThemeID}";
                var update = new SqlCommand(query, connection);
                update.ExecuteNonQuery();
            }
        }

        public Theme GetTheme(ThemeBookFundPK pk)
        {
            Theme theme = null;
            using (var connection = GetConnection())
            {
                var query = $"SELECT ThemeID, ThemeName FROM Theme WHERE ThemeID  = {pk.ThemeID}";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();
                if (result.HasRows)
                {
                    result.Read();
                    theme = new Theme
                    {
                        ThemeId = (int)result["ThemeID"],
                        ThemeName = (string)result["ThemeName"],
                    };
                }
                else
                {
                    throw new ArgumentException("Author has not been found.");
                }
            }
            return theme;
        }
        public BookFund GetBookFund(ThemeBookFundPK pk)
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
                        BookName = (string)result["BookName"],
                        DateOfPublication = (DateTime)result["DateOfPublication"],
                        Capacity = (int)result["Capacity"],
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

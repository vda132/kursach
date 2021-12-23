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
    class ThemeProvider : CrudProviderBase<Theme, int>
    {
        public override void Add(Theme entity)
        {
            using (var connection = GetConnection())
            {
                var query = $"INSERT INTO Theme(ThemeID, ThemeName) VALUES({entity.ThemeId},'{entity.ThemeName}')";
                var insert = new SqlCommand(query, connection);
                insert.ExecuteNonQuery();
            }
        }

        public override void Delete(int pk)
        {
            using (var connection = GetConnection())
            {
                var query = $"DELETE FROM Theme WHERE ThemeID = {pk}";
                var delete = new SqlCommand(query, connection);
                delete.ExecuteNonQuery();
            }
        }

        public override Theme Get(int pk)
        {
            Theme theme = null;
            using (var connection = GetConnection())
            {
                var query = $"SELECT ThemeID, ThemeName FROM Theme WHERE ThemeID = {pk}";
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
                    throw new ArgumentException("Theme has not been found.");
                }
            }
            theme.ThemeBookFunds = GetThemeBookFund(pk);
            return theme;
        }

        public override IReadOnlyCollection<Theme> GetAll()
        {
            var themes = new List<Theme>();
            using (var connection = GetConnection())
            {
                var query = $"SELECT ThemeID, ThemeName FROM Theme";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        themes.Add(new Theme
                        {
                            ThemeId = (int)result["ThemeID"],
                            ThemeName = (string)result["ThemeName"]
                        });
                    }
                }
            }
            foreach (var theme in themes)
                theme.ThemeBookFunds = GetThemeBookFund(theme.ThemeId);
            return themes;
        }

        public override void Update(int pk, Theme entity)
        {
            using (var connection = GetConnection())
            {
                var query = $"UPDATE Theme SET ThemeName={entity.ThemeName} WHERE ThemeID={entity.ThemeId}";
                var update = new SqlCommand(query, connection);
                update.ExecuteNonQuery();
            }
        }
        public IReadOnlyCollection<ThemeBookFund> GetThemeBookFund(int pk)
        {
            using (var connection = GetConnection())
            {
                var query = $"SELECT BookID, LibraryBookNo, ThemeID from ThemeBookFund WHERE ReaderNo={pk}";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();

                var themeBookFunds = new List<ThemeBookFund>();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        themeBookFunds.Add(new ThemeBookFund
                        {
                            BookID = (int)result["BookID"],
                            LibraryBookNO = (int)result["LibraryBookNo"],
                            ThemeID=(int)result["ThemeID"]
                        });
                    }
                }
                return themeBookFunds;
            }
        }
    }
}

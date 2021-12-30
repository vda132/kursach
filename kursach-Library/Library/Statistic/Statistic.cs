using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Statistic
{
    public static class Statistic
    {
        private static string connectionString = $@"
            Data Source=DESKTOP-E8J0I95\SQLEXPRESS;Initial Catalog=Library;
            Integrated Security=True;
            Connect Timeout=30;Encrypt=False;
            TrustServerCertificate=False;
            ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";

        public static List<KeyValuePair<string, int>> GetExtraditionStatistic()
        {
            List<KeyValuePair<string, int>> extraditions = new List<KeyValuePair<string, int>>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "select distinct t1.BookName, count(*) over(partition by t1.BookName) as 'Кол-во выдач' from BookFund t1 inner join Extradition t2 on t1.BookID=t2.BookID and t1.LibraryBookNO=t2.LibraryBookNO";
                var adapter = new SqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                try
                {
                    adapter.Fill(ds, "Table");
                }
                catch (SqlException)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
                var dt = ds.Tables["Table"];
                foreach (DataRow row in dt.Rows)
                {
                    extraditions.Add(new KeyValuePair<string, int>(row["BookName"].ToString(), (int)row["Кол-во выдач"]));
                }
            }
            return extraditions;
        }

        public static List<KeyValuePair<string, int>> GetVisitingStatistic()
        {
            List<KeyValuePair<string, int>> visitings = new List<KeyValuePair<string, int>>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "select distinct t1.ReaderName, count(*) over(partition by t1.ReaderName) as 'Кол-во посещений'  from Reader t1 inner join Extradition t2 on t1.ReaderNo=t2.ReaderNo";
                var adapter = new SqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                try
                {
                    adapter.Fill(ds, "Table");
                }
                catch (SqlException)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
                var dt = ds.Tables["Table"];
                foreach (DataRow row in dt.Rows)
                {
                    visitings.Add(new KeyValuePair<string, int>(row["ReaderName"].ToString(), (int)row["Кол-во посещений"]));
                }
            }
            return visitings;
        }

        public static List<KeyValuePair<string, int>> GetThemeStatistic()
        {
            List<KeyValuePair<string, int>> themes = new List<KeyValuePair<string, int>>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "select distinct t1.ThemeName, count(*) over(partition by t1.ThemeName) as 'Кол-во книг'  from Theme t1 inner join ThemeBookFund t2 on t1.ThemeID=t2.ThemeID";
                var adapter = new SqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                try
                {
                    adapter.Fill(ds, "Table");
                }
                catch (SqlException)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
                var dt = ds.Tables["Table"];
                foreach (DataRow row in dt.Rows)
                {
                    themes.Add(new KeyValuePair<string, int>(row["ThemeName"].ToString(), (int)row["Кол-во книг"]));
                }
            }
            return themes;
        }
    }
}

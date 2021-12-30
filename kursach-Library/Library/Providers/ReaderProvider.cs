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
    class ReaderProvider : CrudProviderBase<Reader, int>
    {
        public override void Add(Reader entity)
        {
            using (var connection = GetConnection())
            {
                var query = $"INSERT INTO Reader(ReaderName, Adress, Phone) VALUES('{entity.ReaderName}','{entity.Adress}','{entity.Phone}')";
                var insert = new SqlCommand(query, connection);
                insert.ExecuteNonQuery();
            }
        }

        public override void Delete(int pk)
        {
            using (var connection = GetConnection())
            {
                var query = $"DELETE FROM Reader WHERE ReaderNo = {pk}";
                var delete = new SqlCommand(query, connection);
                delete.ExecuteNonQuery();
            }
        }

        public override Reader Get(int pk)
        {
            Reader reader = null;
            using (var connection = GetConnection())
            {
                var query = $"SELECT ReaderNo, ReaderName, Adress, Phone FROM Reader WHERE ReaderNo = {pk}";
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
            reader.Extraditions = GetExtraditions(reader.ReaderNo);
            return reader;
        }

        public override IReadOnlyCollection<Reader> GetAll()
        {
            var readers = new List<Reader>();
            using (var connection = GetConnection())
            {
                var query = $"SELECT ReaderNo, ReaderName, Adress, Phone FROM Reader";
                var select = new SqlCommand(query, connection);
                var result = select.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        readers.Add(new Reader
                        {
                            ReaderNo = (int)result["ReaderNo"],
                            ReaderName = (string)result["ReaderName"],
                            Adress = (string)result["Adress"],
                            Phone = (string)result["Phone"]
                        });
                    }
                }
            }
            foreach (var reader in readers)
                reader.Extraditions = GetExtraditions(reader.ReaderNo);
            return readers;
        }

        public override void Update(int pk, Reader entity)
        {
            using (var connection = GetConnection())
            {
                var query = $"UPDATE Reader SET ReaderName='{entity.ReaderName}', Adress='{entity.Adress}', Phone='{entity.Phone}' WHERE ReaderNo={entity.ReaderNo}";
                var update = new SqlCommand(query, connection);
                update.ExecuteNonQuery();
            }
        }

        public IReadOnlyCollection<Extradition> GetExtraditions(int pk)
        {
            using (var connection = GetConnection())
            {
                var query = $"SELECT BookID, LibraryBookNo, ReaderNo, DateOfExtradition, DateOfReturn, Information from Extradition WHERE ReaderNo={pk}";
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
    }
}

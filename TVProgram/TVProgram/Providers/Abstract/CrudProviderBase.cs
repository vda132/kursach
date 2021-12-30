using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using TVProgram.Models;

namespace TVProgram.Providers.Abstract
{
    abstract class CrudProviderBase<TEntity, TPrimaryKey> where TEntity : IModel
    {
        private string connectionString = $@"
            Data Source=.\SQLEXPRESS02;
            Initial Catalog=TVProgramDb;
            Integrated Security=True;
            Connect Timeout=30;
            Encrypt=False;
            TrustServerCertificate=False;
            ApplicationIntent=ReadWrite;
            MultiSubnetFailover=False;";

        protected SqlConnection GetConnection()
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        #region Abstract
        public abstract IReadOnlyCollection<TEntity> GetAll();
        public abstract TEntity Get(TPrimaryKey pk);
        public abstract void Add(TEntity entity);
        public abstract void Update(TPrimaryKey pk, TEntity entity);
        public abstract void Delete(TPrimaryKey pk);
        #endregion
    }
}

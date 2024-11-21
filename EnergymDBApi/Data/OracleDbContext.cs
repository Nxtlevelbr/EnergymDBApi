using Oracle.ManagedDataAccess.Client;

namespace EnergymDBApi.Data
{
    public class OracleDbContext
    {
        private readonly string _connectionString;

        public OracleDbContext(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        /// <summary>
        /// Cria e retorna uma conexão com o banco de dados Oracle.
        /// </summary>
        /// <returns>Uma instância de OracleConnection.</returns>
        public OracleConnection GetConnection()
        {
            return new OracleConnection(_connectionString);
        }
    }
}
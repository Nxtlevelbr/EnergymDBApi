using EnergymDBApi.Data;
using Oracle.ManagedDataAccess.Client;

namespace EnergymDBApi.Repository
{
    public class CepValidator
    {
        private readonly OracleDbContext _dbContext;

        public CepValidator(OracleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool ValidarCep(string cep)
        {
            using (var connection = _dbContext.GetConnection())
            {
                using (var command = new OracleCommand("SELECT fn_validar_cep(:cep) FROM DUAL", connection))
                {
                    command.Parameters.Add("cep", OracleDbType.Varchar2).Value = cep;

                    connection.Open();
                    var result = command.ExecuteScalar();
                    return Convert.ToInt32(result) == 1;
                }
            }
        }
    }
}
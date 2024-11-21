using Oracle.ManagedDataAccess.Client;
using System.Data;
using EnergymDBApi.Data;

namespace EnergymDBApi.Repositories
{
    public class EnderecoRepository
    {
        private readonly OracleDbContext _dbContext;

        public EnderecoRepository(OracleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void GerenciarEndereco(string operacao, int idEndereco, string logradouro, string numero, string cep, string complemento, int bairroId)
        {
            using (var connection = _dbContext.GetConnection())
            {
                using (var command = new OracleCommand("sp_gerenciar_endereco", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("p_operacao", OracleDbType.Varchar2).Value = operacao;
                    command.Parameters.Add("p_id_endereco", OracleDbType.Int32).Value = idEndereco;
                    command.Parameters.Add("p_logradouro", OracleDbType.Varchar2).Value = logradouro;
                    command.Parameters.Add("p_numero", OracleDbType.Varchar2).Value = numero;
                    command.Parameters.Add("p_cep", OracleDbType.Char).Value = cep;
                    command.Parameters.Add("p_complemento", OracleDbType.Varchar2).Value = complemento;
                    command.Parameters.Add("p_bairro_id_bairro", OracleDbType.Int32).Value = bairroId;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
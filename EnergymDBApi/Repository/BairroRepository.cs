using Oracle.ManagedDataAccess.Client;
using System.Data;
using EnergymDBApi.Data;

namespace EnergymDBApi.Repositories
{
    public class BairroRepository
    {
        private readonly OracleDbContext _dbContext;

        public BairroRepository(OracleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void GerenciarBairro(string operacao, int idBairro, string nomeBairro, int cidadeId)
        {
            using (var connection = _dbContext.GetConnection())
            {
                using (var command = new OracleCommand("sp_gerenciar_bairro", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("p_operacao", OracleDbType.Varchar2).Value = operacao;
                    command.Parameters.Add("p_id_bairro", OracleDbType.Int32).Value = idBairro;
                    command.Parameters.Add("p_nome_bairro", OracleDbType.Varchar2).Value = nomeBairro;
                    command.Parameters.Add("p_cidade_id_cidade", OracleDbType.Int32).Value = cidadeId;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
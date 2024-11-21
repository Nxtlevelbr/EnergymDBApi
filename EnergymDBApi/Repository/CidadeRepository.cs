using Oracle.ManagedDataAccess.Client;
using System.Data;
using EnergymDBApi.Data;

namespace EnergymDBApi.Repositories
{
    public class CidadeRepository
    {
        private readonly OracleDbContext _dbContext;

        public CidadeRepository(OracleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void GerenciarCidade(string operacao, int idCidade, string nomeCidade, int estadoId)
        {
            using (var connection = _dbContext.GetConnection())
            {
                using (var command = new OracleCommand("sp_gerenciar_cidade", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("p_operacao", OracleDbType.Varchar2).Value = operacao;
                    command.Parameters.Add("p_id_cidade", OracleDbType.Int32).Value = idCidade;
                    command.Parameters.Add("p_nome_cidade", OracleDbType.Varchar2).Value = nomeCidade;
                    command.Parameters.Add("p_estado_id_estado", OracleDbType.Int32).Value = estadoId;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
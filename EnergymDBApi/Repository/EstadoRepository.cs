using Oracle.ManagedDataAccess.Client;
using System.Data;
using EnergymDBApi.Data;

namespace EnergymDBApi.Repositories
{
    public class EstadoRepository
    {
        private readonly OracleDbContext _dbContext;

        public EstadoRepository(OracleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void GerenciarEstado(string operacao, int idEstado, string nomeEstado, int paisId)
        {
            using (var connection = _dbContext.GetConnection())
            {
                using (var command = new OracleCommand("sp_gerenciar_estado", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("p_operacao", OracleDbType.Varchar2).Value = operacao;
                    command.Parameters.Add("p_id_estado", OracleDbType.Int32).Value = idEstado;
                    command.Parameters.Add("p_nome_estado", OracleDbType.Varchar2).Value = nomeEstado;
                    command.Parameters.Add("p_pais_id_pais", OracleDbType.Int32).Value = paisId;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
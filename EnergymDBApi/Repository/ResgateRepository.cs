using System.Data;
using EnergymDBApi.Data;
using Oracle.ManagedDataAccess.Client;

namespace EnergymDBApi.Repository;

public class ResgateRepository
{
    private readonly OracleDbContext _dbContext;

    public ResgateRepository(OracleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void GerenciarResgate(string operacao, int idResgate, DateTime dataHora, int usuarioId, int premioId)
    {
        using (var connection = _dbContext.GetConnection())
        {
            using (var command = new OracleCommand("sp_gerenciar_resgate", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("p_operacao", OracleDbType.Varchar2).Value = operacao;
                command.Parameters.Add("p_id_resgate", OracleDbType.Int32).Value = idResgate;
                command.Parameters.Add("p_data_hora", OracleDbType.Date).Value = dataHora;
                command.Parameters.Add("p_usuario_id_usuario", OracleDbType.Int32).Value = usuarioId;
                command.Parameters.Add("p_premio_id_premio", OracleDbType.Int32).Value = premioId;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
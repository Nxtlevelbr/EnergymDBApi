using System.Data;
using EnergymDBApi.Data;
using Oracle.ManagedDataAccess.Client;

namespace EnergymDBApi.Repository;

public class TipoPremioRepository
{
    private readonly OracleDbContext _dbContext;

    public TipoPremioRepository(OracleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void GerenciarTipoPremio(string operacao, int idTipoPremio, string tipoPremio)
    {
        using (var connection = _dbContext.GetConnection())
        {
            using (var command = new OracleCommand("sp_gerenciar_tipo_premio", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("p_operacao", OracleDbType.Varchar2).Value = operacao;
                command.Parameters.Add("p_id_tipo_premio", OracleDbType.Int32).Value = idTipoPremio;
                command.Parameters.Add("p_tipo_premio", OracleDbType.Varchar2).Value = tipoPremio;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
using System.Data;
using EnergymDBApi.Data;
using Oracle.ManagedDataAccess.Client;

namespace EnergymDBApi.Repository;

public class TipoExercicioRepository
{
    private readonly OracleDbContext _dbContext;

    public TipoExercicioRepository(OracleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void GerenciarTipoExercicio(string operacao, int idTipoExercicio, string nomeTipoExercicio)
    {
        using (var connection = _dbContext.GetConnection())
        {
            using (var command = new OracleCommand("sp_gerenciar_tipo_exercicio", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("p_operacao", OracleDbType.Varchar2).Value = operacao;
                command.Parameters.Add("p_id_tipo_exercicio", OracleDbType.Int32).Value = idTipoExercicio;
                command.Parameters.Add("p_nome_tipo_exercicio", OracleDbType.Varchar2).Value = nomeTipoExercicio;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
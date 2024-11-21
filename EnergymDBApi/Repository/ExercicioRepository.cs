using System.Data;
using EnergymDBApi.Data;
using Oracle.ManagedDataAccess.Client;

namespace EnergymDBApi.Repository;

public class ExercicioRepository
{
    private readonly OracleDbContext _dbContext;

    public ExercicioRepository(OracleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void GerenciarExercicio(string operacao, int idExercicio, decimal distancia, int usuarioId, int academiaId, int tipoExercicioId)
    {
        using (var connection = _dbContext.GetConnection())
        {
            using (var command = new OracleCommand("sp_gerenciar_exercicio", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("p_operacao", OracleDbType.Varchar2).Value = operacao;
                command.Parameters.Add("p_id_exercicio", OracleDbType.Int32).Value = idExercicio;
                command.Parameters.Add("p_distancia_percorrida", OracleDbType.Decimal).Value = distancia;
                command.Parameters.Add("p_usuario_id_usuario", OracleDbType.Int32).Value = usuarioId;
                command.Parameters.Add("p_academia_id_academia", OracleDbType.Int32).Value = academiaId;
                command.Parameters.Add("p_tipo_exercicio_id_tipo_exercicio", OracleDbType.Int32).Value = tipoExercicioId;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
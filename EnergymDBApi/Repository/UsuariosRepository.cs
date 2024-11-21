using System.Data;
using EnergymDBApi.Data;
using Oracle.ManagedDataAccess.Client;

namespace EnergymDBApi.Repository;

public class UsuariosRepository
{
    private readonly OracleDbContext _dbContext;

    public UsuariosRepository(OracleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void GerenciarUsuarios(string operacao, int idUsuarios, string usuario, string senha)
    {
        using (var connection = _dbContext.GetConnection())
        {
            using (var command = new OracleCommand("sp_gerenciar_usuarios", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("p_operacao", OracleDbType.Varchar2).Value = operacao;
                command.Parameters.Add("p_id_usuarios", OracleDbType.Int32).Value = idUsuarios;
                command.Parameters.Add("p_usuario", OracleDbType.Varchar2).Value = usuario;
                command.Parameters.Add("p_senha", OracleDbType.Varchar2).Value = senha;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
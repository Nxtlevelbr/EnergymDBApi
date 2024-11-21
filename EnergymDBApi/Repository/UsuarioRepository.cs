using System.Data;
using EnergymDBApi.Data;
using Oracle.ManagedDataAccess.Client;

namespace EnergymDBApi.Repository;

public class UsuarioRepository
{
    private readonly OracleDbContext _dbContext;

    public UsuarioRepository(OracleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void GerenciarUsuario(string operacao, int idUsuario, string email, DateTime dataNascimento, string sexo, decimal pontos, string observacao, int tipoPessoaId, int usuariosId)
    {
        using (var connection = _dbContext.GetConnection())
        {
            using (var command = new OracleCommand("sp_gerenciar_usuario", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("p_operacao", OracleDbType.Varchar2).Value = operacao;
                command.Parameters.Add("p_id_usuario", OracleDbType.Int32).Value = idUsuario;
                command.Parameters.Add("p_email", OracleDbType.Varchar2).Value = email;
                command.Parameters.Add("p_data_nascimento", OracleDbType.Date).Value = dataNascimento;
                command.Parameters.Add("p_sexo", OracleDbType.Char).Value = sexo;
                command.Parameters.Add("p_pontos", OracleDbType.Decimal).Value = pontos;
                command.Parameters.Add("p_observacao", OracleDbType.Varchar2).Value = observacao ?? (object)DBNull.Value;
                command.Parameters.Add("p_tipo_pessoa_id_tipo_pessoa", OracleDbType.Int32).Value = tipoPessoaId;
                command.Parameters.Add("p_usuarios_id_usuarios", OracleDbType.Int32).Value = usuariosId;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
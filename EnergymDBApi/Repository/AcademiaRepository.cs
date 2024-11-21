using System.Data;
using EnergymDBApi.Data;
using Oracle.ManagedDataAccess.Client;

namespace EnergymDBApi.Repository
{
    public class AcademiaRepository
    {
        private readonly OracleDbContext _dbContext;

        public AcademiaRepository(OracleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void GerenciarAcademia(string operacao, int idAcademia, string nome, string? observacao, int enderecoId, int tipoPessoaId, int usuarioId)
        {
            using (var connection = _dbContext.GetConnection())
            {
                using (var command = new OracleCommand("sp_gerenciar_academia", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("p_operacao", OracleDbType.Varchar2).Value = operacao;
                    command.Parameters.Add("p_id_academia", OracleDbType.Int32).Value = idAcademia;
                    command.Parameters.Add("p_nome", OracleDbType.Varchar2).Value = nome;
                    command.Parameters.Add("p_observacao", OracleDbType.Varchar2).Value = observacao ?? (object)DBNull.Value;
                    command.Parameters.Add("p_endereco_id_endereco", OracleDbType.Int32).Value = enderecoId;
                    command.Parameters.Add("p_tipo_pessoa_id_tipo_pessoa", OracleDbType.Int32).Value = tipoPessoaId;
                    command.Parameters.Add("p_usuarios_id_usuarios", OracleDbType.Int32).Value = usuarioId;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
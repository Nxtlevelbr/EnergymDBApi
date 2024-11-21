using System.Data;
using EnergymDBApi.Data;
using Oracle.ManagedDataAccess.Client;

namespace EnergymDBApi.Repository;

public class TipoPessoaRepository
{
    private readonly OracleDbContext _dbContext;

    public TipoPessoaRepository(OracleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void GerenciarTipoPessoa(string operacao, int idTipoPessoa, string tipoPessoa, string numeroDocumento)
    {
        using (var connection = _dbContext.GetConnection())
        {
            using (var command = new OracleCommand("sp_gerenciar_tipo_pessoa", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("p_operacao", OracleDbType.Varchar2).Value = operacao;
                command.Parameters.Add("p_id_tipo_pessoa", OracleDbType.Int32).Value = idTipoPessoa;
                command.Parameters.Add("p_tipo_pessoa", OracleDbType.Char).Value = tipoPessoa;
                command.Parameters.Add("p_numero_documento", OracleDbType.Char).Value = numeroDocumento;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
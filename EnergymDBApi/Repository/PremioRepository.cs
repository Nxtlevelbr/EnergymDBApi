using System.Data;
using EnergymDBApi.Data;
using Oracle.ManagedDataAccess.Client;

namespace EnergymDBApi.Repository;

public class PremioRepository
{
    private readonly OracleDbContext _dbContext;

    public PremioRepository(OracleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void GerenciarPremio(string operacao, int idPremio, string descricao, decimal pontos, string empresa, int tipoPremioId)
    {
        using (var connection = _dbContext.GetConnection())
        {
            using (var command = new OracleCommand("sp_gerenciar_premio", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("p_operacao", OracleDbType.Varchar2).Value = operacao;
                command.Parameters.Add("p_id_premio", OracleDbType.Int32).Value = idPremio;
                command.Parameters.Add("p_descricao", OracleDbType.Varchar2).Value = descricao;
                command.Parameters.Add("p_pontos", OracleDbType.Decimal).Value = pontos;
                command.Parameters.Add("p_empresa", OracleDbType.Varchar2).Value = empresa;
                command.Parameters.Add("p_tipo_premio_id_tipo_premio", OracleDbType.Int32).Value = tipoPremioId;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
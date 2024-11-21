using System.Data;
using EnergymDBApi.Data;
using Oracle.ManagedDataAccess.Client;

public class PaisRepository
{
    private readonly OracleDbContext _dbContext;

    public PaisRepository(OracleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void GerenciarPais(string operacao, int idPais, string nomePais)
    {
        using (var connection = _dbContext.GetConnection())
        {
            using (var command = new OracleCommand("sp_gerenciar_pais", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("p_operacao", OracleDbType.Varchar2).Value = operacao;
                command.Parameters.Add("p_id_pais", OracleDbType.Int32).Value = idPais;
                command.Parameters.Add("p_nome_pais", OracleDbType.Varchar2).Value = nomePais;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
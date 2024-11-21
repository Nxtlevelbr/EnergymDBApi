using EnergymDBApi.Repository;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ResgateController : ControllerBase
{
    private readonly ResgateRepository _repository;

    public ResgateController(ResgateRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Gerencia operações de INSERT, UPDATE e DELETE na tabela Resgate.
    /// </summary>
    /// <param name="operacao">Operação a ser realizada (INSERT, UPDATE ou DELETE).</param>
    /// <param name="idResgate">ID do resgate.</param>
    /// <param name="dataHora">Data e hora do resgate.</param>
    /// <param name="usuarioId">ID do usuário.</param>
    /// <param name="premioId">ID do prêmio resgatado.</param>
    /// <returns>Resultado da operação.</returns>
    [HttpPost("gerenciar")]
    public IActionResult GerenciarResgate(string operacao, int idResgate, DateTime dataHora, int usuarioId, int premioId)
    {
        try
        {
            _repository.GerenciarResgate(operacao, idResgate, dataHora, usuarioId, premioId);
            return Ok(new { Message = "Operação realizada com sucesso!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Erro ao realizar operação.", Details = ex.Message });
        }
    }
}
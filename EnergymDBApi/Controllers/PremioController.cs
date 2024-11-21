using EnergymDBApi.Repository;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class PremioController : ControllerBase
{
    private readonly PremioRepository _repository;

    public PremioController(PremioRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Gerencia operações de INSERT, UPDATE e DELETE na tabela Premio.
    /// </summary>
    /// <param name="operacao">Operação a ser realizada (INSERT, UPDATE ou DELETE).</param>
    /// <param name="idPremio">ID do prêmio.</param>
    /// <param name="descricao">Descrição do prêmio.</param>
    /// <param name="pontos">Pontuação do prêmio.</param>
    /// <param name="empresa">Empresa responsável pelo prêmio.</param>
    /// <param name="tipoPremioId">ID do tipo de prêmio.</param>
    /// <returns>Resultado da operação.</returns>
    [HttpPost("gerenciar")]
    public IActionResult GerenciarPremio(string operacao, int idPremio, string descricao, decimal pontos, string empresa, int tipoPremioId)
    {
        try
        {
            _repository.GerenciarPremio(operacao, idPremio, descricao, pontos, empresa, tipoPremioId);
            return Ok(new { Message = "Operação realizada com sucesso!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Erro ao realizar operação.", Details = ex.Message });
        }
    }
}
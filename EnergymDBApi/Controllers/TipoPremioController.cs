using EnergymDBApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EnergymDBApi.Controllers;

/// <summary>
/// Controlador responsável por operações relacionadas à tabela TipoPremio.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TipoPremioController : ControllerBase
{
    private readonly TipoPremioRepository _repository;

    /// <summary>
    /// Inicializa uma nova instância do <see cref="TipoPremioController"/>.
    /// </summary>
    /// <param name="repository">Instância do repositório de TipoPremio.</param>
    public TipoPremioController(TipoPremioRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Gerencia operações de INSERT, UPDATE ou DELETE na tabela TipoPremio.
    /// </summary>
    /// <param name="operacao">Tipo de operação a ser realizada: "INSERT", "UPDATE" ou "DELETE".</param>
    /// <param name="idTipoPremio">O identificador único do tipo de prêmio.</param>
    /// <param name="tipoPremio">A descrição do tipo de prêmio.</param>
    /// <returns>
    /// Um objeto JSON contendo a mensagem de sucesso ou erro.
    /// </returns>
    /// <response code="200">Operação realizada com sucesso.</response>
    /// <response code="400">Os dados fornecidos são inválidos.</response>
    /// <response code="500">Erro interno do servidor ao processar a solicitação.</response>
    [HttpPost("gerenciar")]
    public IActionResult GerenciarTipoPremio(string operacao, int idTipoPremio, string tipoPremio)
    {
        try
        {
            if (string.IsNullOrEmpty(operacao) || string.IsNullOrEmpty(tipoPremio))
            {
                return BadRequest(new { Message = "Os campos 'operacao' e 'tipoPremio' são obrigatórios." });
            }

            _repository.GerenciarTipoPremio(operacao, idTipoPremio, tipoPremio);
            return Ok(new { Message = "Operação realizada com sucesso!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Erro ao realizar operação.", Details = ex.Message });
        }
    }
}

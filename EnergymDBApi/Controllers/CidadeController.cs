using EnergymDBApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EnergymDBApi.Controllers;

/// <summary>
/// Controlador responsável por operações relacionadas à tabela Cidade.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CidadeController : ControllerBase
{
    private readonly CidadeRepository _repository;

    /// <summary>
    /// Inicializa uma nova instância do <see cref="CidadeController"/>.
    /// </summary>
    /// <param name="repository">Instância do repositório de Cidade.</param>
    public CidadeController(CidadeRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Gerencia operações de INSERT, UPDATE ou DELETE na tabela Cidade.
    /// </summary>
    /// <param name="operacao">Tipo de operação a ser realizada: "INSERT", "UPDATE" ou "DELETE".</param>
    /// <param name="idCidade">O identificador único da cidade.</param>
    /// <param name="nomeCidade">O nome da cidade.</param>
    /// <param name="estadoId">O identificador do estado associado à cidade.</param>
    /// <returns>
    /// Um objeto JSON contendo a mensagem de sucesso ou erro.
    /// </returns>
    /// <response code="200">Operação realizada com sucesso.</response>
    /// <response code="400">Os dados fornecidos são inválidos.</response>
    /// <response code="500">Erro interno do servidor ao processar a solicitação.</response>
    [HttpPost("gerenciar")]
    public IActionResult GerenciarCidade(string operacao, int idCidade, string nomeCidade, int estadoId)
    {
        try
        {
            if (string.IsNullOrEmpty(operacao) || string.IsNullOrEmpty(nomeCidade))
            {
                return BadRequest(new { Message = "Os campos 'operacao' e 'nomeCidade' são obrigatórios." });
            }

            _repository.GerenciarCidade(operacao, idCidade, nomeCidade, estadoId);
            return Ok(new { Message = "Operação realizada com sucesso!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Erro ao realizar operação.", Details = ex.Message });
        }
    }
}

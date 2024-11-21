using EnergymDBApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EnergymDBApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoPessoaController : ControllerBase
{
    private readonly TipoPessoaRepository _repository;

    public TipoPessoaController(TipoPessoaRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Gerencia operações de INSERT, UPDATE e DELETE na tabela TipoPessoa.
    /// </summary>
    /// <param name="operacao">Operação a ser realizada (INSERT, UPDATE ou DELETE).</param>
    /// <param name="idTipoPessoa">ID do tipo de pessoa.</param>
    /// <param name="tipoPessoa">Descrição do tipo de pessoa.</param>
    /// <param name="numeroDocumento">Número do documento associado.</param>
    /// <returns>Resultado da operação.</returns>
    [HttpPost("gerenciar")]
    public IActionResult GerenciarTipoPessoa(string operacao, int idTipoPessoa, string tipoPessoa, string numeroDocumento)
    {
        try
        {
            _repository.GerenciarTipoPessoa(operacao, idTipoPessoa, tipoPessoa, numeroDocumento);
            return Ok(new { Message = "Operação realizada com sucesso!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Erro ao realizar operação.", Details = ex.Message });
        }
    }
}
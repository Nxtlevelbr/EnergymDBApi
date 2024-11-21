using Microsoft.AspNetCore.Mvc;

namespace EnergymDBApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaisController : ControllerBase
{
    private readonly PaisRepository _repository;

    public PaisController(PaisRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Gerencia operações de INSERT, UPDATE e DELETE na tabela Pais.
    /// </summary>
    /// <param name="operacao">Operação a ser realizada (INSERT, UPDATE ou DELETE).</param>
    /// <param name="idPais">ID do país.</param>
    /// <param name="nomePais">Nome do país.</param>
    /// <returns>Resultado da operação.</returns>
    [HttpPost("gerenciar")]
    public IActionResult GerenciarPais(string operacao, int idPais, string nomePais)
    {
        try
        {
            _repository.GerenciarPais(operacao, idPais, nomePais);
            return Ok(new { Message = "Operação realizada com sucesso!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Erro ao realizar operação.", Details = ex.Message });
        }
    }
}
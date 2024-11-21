using EnergymDBApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EnergymDBApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BairroController : ControllerBase
{
    private readonly BairroRepository _repository;

    public BairroController(BairroRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Gerencia operações de INSERT, UPDATE e DELETE na tabela Bairro.
    /// </summary>
    /// <param name="operacao">Operação a ser realizada (INSERT, UPDATE ou DELETE).</param>
    /// <param name="idBairro">ID do bairro.</param>
    /// <param name="nomeBairro">Nome do bairro.</param>
    /// <param name="cidadeId">ID da cidade associada ao bairro.</param>
    /// <returns>Resultado da operação.</returns>
    [HttpPost("gerenciar")] // Adiciona a rota "api/bairro/gerenciar"
    public IActionResult GerenciarBairro(string operacao, int idBairro, string nomeBairro, int cidadeId)
    {
        try
        {
            _repository.GerenciarBairro(operacao, idBairro, nomeBairro, cidadeId);
            return Ok(new { Message = "Operação realizada com sucesso!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Erro ao realizar operação.", Details = ex.Message });
        }
    }
}
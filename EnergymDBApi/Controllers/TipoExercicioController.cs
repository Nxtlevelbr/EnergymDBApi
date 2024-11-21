using EnergymDBApi.Repository;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class TipoExercicioController : ControllerBase
{
    private readonly TipoExercicioRepository _repository;

    public TipoExercicioController(TipoExercicioRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Gerencia operações de INSERT, UPDATE e DELETE na tabela TipoExercicio.
    /// </summary>
    /// <param name="operacao">Operação a ser realizada (INSERT, UPDATE ou DELETE).</param>
    /// <param name="idTipoExercicio">ID do tipo de exercício.</param>
    /// <param name="nomeTipoExercicio">Nome do tipo de exercício.</param>
    /// <returns>Resultado da operação.</returns>
    [HttpPost("gerenciar")]
    public IActionResult GerenciarTipoExercicio(string operacao, int idTipoExercicio, string nomeTipoExercicio)
    {
        try
        {
            _repository.GerenciarTipoExercicio(operacao, idTipoExercicio, nomeTipoExercicio);
            return Ok(new { Message = "Operação realizada com sucesso!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Erro ao realizar operação.", Details = ex.Message });
        }
    }
}
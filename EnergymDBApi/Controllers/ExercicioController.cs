using EnergymDBApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EnergymDBApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExercicioController : ControllerBase
{
    private readonly ExercicioRepository _repository;

    public ExercicioController(ExercicioRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Gerencia operações de INSERT, UPDATE e DELETE na tabela Exercicio.
    /// </summary>
    /// <param name="operacao">Operação a ser realizada (INSERT, UPDATE ou DELETE).</param>
    /// <param name="idExercicio">ID do exercício.</param>
    /// <param name="distancia">Distância percorrida.</param>
    /// <param name="usuarioId">ID do usuário.</param>
    /// <param name="academiaId">ID da academia.</param>
    /// <param name="tipoExercicioId">ID do tipo de exercício.</param>
    /// <returns>Resultado da operação.</returns>
    [HttpPost("gerenciar")]
    public IActionResult GerenciarExercicio(string operacao, int idExercicio, decimal distancia, int usuarioId, int academiaId, int tipoExercicioId)
    {
        try
        {
            _repository.GerenciarExercicio(operacao, idExercicio, distancia, usuarioId, academiaId, tipoExercicioId);
            return Ok(new { Message = "Operação realizada com sucesso!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Erro ao realizar operação.", Details = ex.Message });
        }
    }
}
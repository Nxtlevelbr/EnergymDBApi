using EnergymDBApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EnergymDBApi.Controllers;

/// <summary>
/// Controlador responsável por operações relacionadas à tabela Usuario.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly UsuarioRepository _repository;

    /// <summary>
    /// Inicializa uma nova instância do <see cref="UsuarioController"/>.
    /// </summary>
    /// <param name="repository">Instância do repositório de Usuario.</param>
    public UsuarioController(UsuarioRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Gerencia operações de INSERT, UPDATE ou DELETE na tabela Usuario.
    /// </summary>
    /// <param name="operacao">Tipo de operação a ser realizada: "INSERT", "UPDATE" ou "DELETE".</param>
    /// <param name="idUsuario">O identificador único do usuário.</param>
    /// <param name="email">O endereço de email do usuário.</param>
    /// <param name="dataNascimento">A data de nascimento do usuário.</param>
    /// <param name="sexo">O sexo do usuário (M/F).</param>
    /// <param name="pontos">A pontuação total do usuário.</param>
    /// <param name="observacao">Observações adicionais sobre o usuário.</param>
    /// <param name="tipoPessoaId">O identificador do tipo de pessoa associado ao usuário.</param>
    /// <param name="usuariosId">O identificador de referência de outro usuário (caso aplicável).</param>
    /// <returns>
    /// Um objeto JSON contendo a mensagem de sucesso ou erro.
    /// </returns>
    /// <response code="200">Operação realizada com sucesso.</response>
    /// <response code="400">Os dados fornecidos são inválidos.</response>
    /// <response code="500">Erro interno do servidor ao processar a solicitação.</response>
    [HttpPost("gerenciar")]
    public IActionResult GerenciarUsuario(string operacao, int idUsuario, string email, DateTime dataNascimento, string sexo, decimal pontos, string observacao, int tipoPessoaId, int usuariosId)
    {
        try
        {
            if (string.IsNullOrEmpty(operacao) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(sexo))
            {
                return BadRequest(new { Message = "Os campos 'operacao', 'email' e 'sexo' são obrigatórios." });
            }

            _repository.GerenciarUsuario(operacao, idUsuario, email, dataNascimento, sexo, pontos, observacao, tipoPessoaId, usuariosId);
            return Ok(new { Message = "Operação realizada com sucesso!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Erro ao realizar operação.", Details = ex.Message });
        }
    }
}

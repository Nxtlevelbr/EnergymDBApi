using EnergymDBApi.Repository;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly UsuariosRepository _repository;

    public UsuariosController(UsuariosRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Gerencia operações de INSERT, UPDATE e DELETE na tabela Usuarios.
    /// </summary>
    /// <param name="operacao">Operação a ser realizada (INSERT, UPDATE ou DELETE).</param>
    /// <param name="idUsuarios">ID do usuário.</param>
    /// <param name="usuario">Nome do usuário.</param>
    /// <param name="senha">Senha do usuário.</param>
    /// <returns>Resultado da operação.</returns>
    [HttpPost("gerenciar")]
    public IActionResult GerenciarUsuarios(string operacao, int idUsuarios, string usuario, string senha)
    {
        try
        {
            _repository.GerenciarUsuarios(operacao, idUsuarios, usuario, senha);
            return Ok(new { Message = "Operação realizada com sucesso!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Erro ao realizar operação.", Details = ex.Message });
        }
    }
}
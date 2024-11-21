using Microsoft.AspNetCore.Mvc;
using EnergymDBApi.Repository;

namespace EnergymDBApi.Controllers
{
    /// <summary>
    /// Controlador para gerenciar operações relacionadas à tabela Academia.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AcademiaController : ControllerBase
    {
        private readonly AcademiaRepository _repository;

        /// <summary>
        /// Inicializa uma nova instância do <see cref="AcademiaController"/>.
        /// </summary>
        /// <param name="repository">Instância do repositório de Academia.</param>
        public AcademiaController(AcademiaRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Gerencia operações de INSERT, UPDATE ou DELETE na tabela Academia.
        /// </summary>
        /// <param name="operacao">A operação a ser realizada: "INSERT", "UPDATE" ou "DELETE".</param>
        /// <param name="idAcademia">O identificador único da academia.</param>
        /// <param name="nome">O nome da academia.</param>
        /// <param name="observacao">Observações adicionais sobre a academia (opcional).</param>
        /// <param name="enderecoId">O identificador do endereço associado à academia.</param>
        /// <param name="tipoPessoaId">O identificador do tipo de pessoa associado à academia.</param>
        /// <param name="usuarioId">O identificador do usuário associado à academia.</param>
        /// <returns>
        /// Um objeto JSON com a mensagem de sucesso ou erro.
        /// </returns>
        /// <response code="200">Operação realizada com sucesso.</response>
        /// <response code="400">Os dados fornecidos são inválidos.</response>
        /// <response code="500">Erro interno do servidor ao processar a solicitação.</response>
        [HttpPost("gerenciar")]
        public IActionResult GerenciarAcademia(string operacao, int idAcademia, string nome, string? observacao, int enderecoId, int tipoPessoaId, int usuarioId)
        {
            try
            {
                _repository.GerenciarAcademia(operacao, idAcademia, nome, observacao, enderecoId, tipoPessoaId, usuarioId);
                return Ok(new { Message = "Operação realizada com sucesso!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro ao realizar operação.", Details = ex.Message });
            }
        }
    }
}

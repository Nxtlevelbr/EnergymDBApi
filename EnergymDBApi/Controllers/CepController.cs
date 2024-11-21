using Microsoft.AspNetCore.Mvc;
using EnergymDBApi.Repository;

namespace EnergymDBApi.Controllers
{
    /// <summary>
    /// Controlador responsável por operações de validação de CEP.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly CepValidator _validator;

        /// <summary>
        /// Inicializa uma nova instância do <see cref="CepController"/>.
        /// </summary>
        /// <param name="validator">Instância do validador de CEP.</param>
        public CepController(CepValidator validator)
        {
            _validator = validator;
        }

        /// <summary>
        /// Valida o formato do CEP fornecido.
        /// </summary>
        /// <param name="cep">O CEP a ser validado (formato esperado: XXXXX-XXX).</param>
        /// <returns>
        /// Um objeto JSON contendo o CEP fornecido e o resultado da validação (válido ou inválido).
        /// </returns>
        /// <response code="200">O CEP foi validado com sucesso.</response>
        /// <response code="400">O CEP fornecido está em um formato inválido.</response>
        /// <response code="500">Erro interno do servidor durante a validação do CEP.</response>
        [HttpGet("validar")]
        public IActionResult ValidarCep(string cep)
        {
            try
            {
                if (string.IsNullOrEmpty(cep))
                {
                    return BadRequest(new { Message = "O CEP não pode ser nulo ou vazio." });
                }

                var isValid = _validator.ValidarCep(cep);
                return Ok(new { Cep = cep, IsValid = isValid });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro ao validar CEP.", Details = ex.Message });
            }
        }
    }
}
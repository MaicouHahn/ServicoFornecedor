using Microsoft.AspNetCore.Mvc;
using ServicoFornecedor.Models;
using ServicoFornecedor.Services;

namespace ServicoFornecedor.Controllers
{
    #region DTO
    public class InserirFornecedorDTO
    {
        public string CpfCnpj { get; set; }
        public bool IsFisicaOuJuridica { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

    }
    #endregion
    [Controller]
    [Route("api/[Controller]")]
    public class FornecedorController:ControllerBase
    {
        public FornecedorService _fornecedorService { get; set; }
        public FornecedorController()
        {
            _fornecedorService = new FornecedorService();
        }

        [HttpPost]
        public IActionResult Inserir([FromBody] InserirFornecedorDTO inserirFornecedorDTO)
        {
            try
            {
                var fornecedor = new Fornecedor()
                {
                    CpfCnpj = inserirFornecedorDTO.CpfCnpj,
                    IsFisicaOuJuridica = inserirFornecedorDTO.IsFisicaOuJuridica,
                    Nome = inserirFornecedorDTO.Nome,
                    Email = inserirFornecedorDTO.Email,
                    Telefone = inserirFornecedorDTO.Telefone

                };
                _fornecedorService.InserirFornecedor(fornecedor);

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpGet]
        public IActionResult BuscarTodos()
        {
            try
            {
                var fornecedor = _fornecedorService.FindAll();

                if (fornecedor == null)
                {
                    return NotFound(new { Message = $"Nenhum fornecedor cadastrado ainda" });
                }

                return Ok(fornecedor);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }
        [HttpGet("{id:int}")]
        public IActionResult BuscarPorId([FromRoute] int id)
        {
            try
            {
                var fornecedor = _fornecedorService.FindById(id);
                if (fornecedor == null)
                {
                    return NotFound(new { Message = $"Fornecedor com ID {id} não encontrado." });
                }
                return Ok(fornecedor);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeletarPorId([FromRoute] int id)
        {
            try
            {
                var check = _fornecedorService.DeleteById(id);
                if (check == false)
                {
                    return NotFound(new { Message = $"Houve problema ao deletar o fornecedor" });
                }

                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult AtualizarFornecedor([FromRoute] int id, [FromBody] Fornecedor fornecedor)
        {
            try
            {
                var check = _fornecedorService.UpdateById(id, fornecedor);
                if (check == false)
                {
                    return NotFound(new { Message = $"Houve problema ao Editar o Fornecedor" });
                }

                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}

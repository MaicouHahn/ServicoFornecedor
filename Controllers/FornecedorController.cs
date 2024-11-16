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
    }
}

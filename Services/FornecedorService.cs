using ServicoFornecedor.Models;
using ServicoFornecedor.Repositorio;

namespace ServicoFornecedor.Services
{
    public class FornecedorService
    {
        public FornecedorRepository _fornecedorRepository { get; set; }
        public FornecedorService() { 
            _fornecedorRepository = new FornecedorRepository();
        }

        public void InserirFornecedor(Fornecedor fornecedor) { 
            _fornecedorRepository.InserirFornecedor(fornecedor);
        }
    }
}

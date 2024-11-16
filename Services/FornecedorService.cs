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
        public Fornecedor FindById(int id)
        {
            return _fornecedorRepository.FindById(id);

        }
        public List<Fornecedor> FindAll()
        {
            return _fornecedorRepository.FindAll();
        }
        public bool DeleteById(int id)
        {
            var item = _fornecedorRepository.FindById(id);
            if (item == null)
            {
                return false;
            }
            _fornecedorRepository.DeleteById(item);
            return true;
        }

    }
}

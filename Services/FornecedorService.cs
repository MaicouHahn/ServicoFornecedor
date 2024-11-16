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
            var fornecedor = _fornecedorRepository.FindById(id);
            if (fornecedor == null)
            {
                return false;
            }
            _fornecedorRepository.DeleteById(fornecedor);
            return true;
        }

        public bool UpdateById(int id, Fornecedor fornecedor)
        {

            var fornecedorDTO = _fornecedorRepository.FindById(id);
            if (fornecedorDTO == null)
            {
                return false;
            }

            fornecedorDTO.IdFornecedor = id;
            fornecedorDTO.CpfCnpj = fornecedor.CpfCnpj;
            fornecedorDTO.Nome = fornecedor.Nome;
            fornecedorDTO.Email = fornecedor.Email;
            fornecedorDTO.Telefone = fornecedor.Telefone;
            fornecedorDTO.IsFisicaOuJuridica = fornecedor.IsFisicaOuJuridica;

            _fornecedorRepository.UpdateById(fornecedorDTO);
            return true;
        }
    }
}

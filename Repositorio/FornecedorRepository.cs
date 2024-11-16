using ServicoFornecedor.Models;
using ServicoFornecedor.Repositorio.Infra;

namespace ServicoFornecedor.Repositorio
{
    public class FornecedorRepository
    {
        public DataContext _dataContext { get; set; }
        public FornecedorRepository()
        {
            _dataContext = GeradorDeServicos.CarregarContexto();
        }
        public void InserirFornecedor(Fornecedor fornecedor)
        {
            _dataContext.Add(fornecedor);
            _dataContext.SaveChanges();
        }
    }
}

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
        public Fornecedor FindById(int id)
        {
            return _dataContext.Find<Fornecedor>(id);
        }

        public List<Fornecedor> FindAll()
        {
            return _dataContext.Set<Fornecedor>().ToList();
        }

        public void DeleteById(Fornecedor item)
        {
            _dataContext.Remove(item);
            _dataContext.SaveChanges();
        }


    }
}

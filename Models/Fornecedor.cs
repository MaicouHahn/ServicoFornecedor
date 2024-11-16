namespace ServicoFornecedor.Models
{
    public class Fornecedor
    {
        public int IdFornecedor {  get; set; }
        public string CpfCnpj { get; set; } 
        public bool IsFisicaOuJuridica { get; set; }
        public string Nome {  get; set; }
        public string Email {  get; set; }
        public string Telefone {  get; set; }

    }
}

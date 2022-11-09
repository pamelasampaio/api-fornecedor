using System.ComponentModel.DataAnnotations;

namespace fornecedorApi.Models
{
    public class Fornecedor
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? CNPJ { get; set; }
        public string? Mercadoria { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }

    }

}

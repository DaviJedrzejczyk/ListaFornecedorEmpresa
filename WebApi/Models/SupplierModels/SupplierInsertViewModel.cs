using Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApi.Models.SupplierModels
{
    public class SupplierInsertViewModel
    {
        [JsonIgnore]
        public int ID { get; set; }

        [Required(ErrorMessage = "Nome deve ser preenchido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nome deve conter entre 3 a 50 caracteres")]
        public string Name { get; set; }

        public string? CPF { get; set; }

        public string? CNPJ { get; set; }

        [Required(ErrorMessage = "Telefone deve ser preenchido!")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Selecione uma empresa para este fornecedor")]
        public int CompanyId { get; set; }

        public string? RG { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}

using Entities;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.SupplierModels
{
    public class SupplierEditViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Nome deve ser preenchido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nome deve conter entre 3 a 50 caracteres")]
        public string Name { get; set; }

        public string? CPF { get; set; }

        public string? CNPJ { get; set; }
        public string? RG {  get; set; }

        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "Telefone deve ser preenchido!")]
        public string PhoneNumber { get; set; }

        public int CompanyId { get; set; }
    }
}

using Entities.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApi.Models.CompanyModels
{
    public class CompanyInsertViewModel
    {
        [Required(ErrorMessage = "Nome fantasia deve ser preenchido!")]
        [StringLength(50, MinimumLength =2, ErrorMessage = "Nome fantasia deve conter entre 2 a 50 caracteres")]
        public string FantasyName { get; set; }

        [Required(ErrorMessage = "CNPJ deve ser preenchido")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "UF deve ser selecionado!")]
        public BrasilianEstates UF { get; set; }
    }
}

using Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.CompanyModels
{
    public class CompanyListViewModel
    {
        public int ID { get; set; }

        public string FantasyName { get; set; }

        public string UF { get; set; }

        public string CNPJ { get; set; }
    }
}

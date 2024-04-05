using Entities;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.SupplierModels
{
    public class SupplierListViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string? CPF { get; set; }

        public string? CNPJ { get; set; }

        public string? RG {  get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime InsertDate { get; set; }

        public string PhoneNumber { get; set; }

        public string? FantasyName { get; set; }
        public string? UF { get; set; }
        public string? CnpjCompany { get; set; }
    }
}

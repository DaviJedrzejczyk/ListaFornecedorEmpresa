namespace Entities
{
    public class Supplier : Entity
    {
        public Supplier(int id, string cnpj) : base(id, cnpj) { }

        public Supplier()
        {
            
        }

        public string Name { get; set; }
        public string? CPF { get; set; }
        public string? RG { get; set; }
        public DateTime InsertDate { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? BirthDate { get; set; }

        public Company Company { get; set; }
        public int CompanyId { get; set; }
    }
}

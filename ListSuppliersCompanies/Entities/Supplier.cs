namespace Entities
{
    public class Supplier
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string? CPF { get; set; }
        public string? CNPJ { get; set; }
        public DateTime InsertDate { get; set; }
        public string PhoneNumber { get; set; }

        public Company Company { get; set; }
        public int CompanyId {  get; set; }
    }
}

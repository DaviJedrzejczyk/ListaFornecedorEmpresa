using Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities
{
    public class Company : Entity
    {
        public Company(int id, string cnpj) : base(id, cnpj)
        {
            
        }
        public Company()
        {
            
        }

        public string FantasyName { get; set; }
        public BrasilianEstates UF { get; set; }
    }
}

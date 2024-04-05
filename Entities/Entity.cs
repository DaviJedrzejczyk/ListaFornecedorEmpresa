using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Entity
    {
        public Entity(int id, string cnpj)
        {
            this.ID = id;
            this.CNPJ = cnpj;
        }
        public Entity()
        {
            
        }

        public int ID { get; set; }
        public string? CNPJ { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Validators.SupplierValidators
{
    internal class SupplierInsertValidator : SupplierValidator
    {
        public SupplierInsertValidator()
        {
            base.ValidateID();
            base.ValidateName();
            base.ValidatePhoneNumber();
        }
    }
}

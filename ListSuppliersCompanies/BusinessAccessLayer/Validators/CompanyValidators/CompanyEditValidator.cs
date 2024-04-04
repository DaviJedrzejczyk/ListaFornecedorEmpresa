using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Validators.CompanyValidators
{
    internal class CompanyEditValidator : CompanyValidator
    {
        public CompanyEditValidator()
        {
            base.ValidateCnpj();
            base.ValidateID();
            base.ValidateName();
            base.ValidateUF();
        }
    }
}

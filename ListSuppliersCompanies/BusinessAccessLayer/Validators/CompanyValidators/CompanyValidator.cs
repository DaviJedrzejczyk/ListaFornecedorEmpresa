using BusinessLogicalLayer.Constants.Company;
using BusinessLogicalLayer.Validators.CommonsValidators;
using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Validators.CompanyValidators
{
    internal class CompanyValidator : AbstractValidator<Company>
    {
        public void ValidateID()
        {
            RuleFor(c => c.ID).NotNull().WithMessage(CompanyConstants.ERROR_MESSAGE_INVALID_ID);
        }

        public void ValidateID(int id)
        {
            RuleFor(c => id).NotNull().WithMessage(CompanyConstants.ERROR_MESSAGE_INVALID_ID);
        }

        public void ValidateName()
        {
            RuleFor(c => c.FantasyName).NotNull().WithMessage(CompanyConstants.ERROR_MESSAGE_EMPTY_NAME)
                              .MinimumLength(3).WithMessage(CompanyConstants.ERROR_MESSAGE_SMALL_NAME)
                              .MaximumLength(50).WithMessage(CompanyConstants.ERROR_MESSAGE_LARGE_NAME);
        }

        public void ValidateUF()
        {
            RuleFor(c => c.UF).NotNull().WithMessage(CompanyConstants.ERROR_MESSAGE_INVALID_UF);
        }

        public void ValidateCnpj()
        {
            RuleFor(c => c.CNPJ).NotNull().WithMessage(CompanyConstants.ERROR_MESSAGE_INVALID_CNPJ)
                                .IsCnpjValid().WithMessage(CompanyConstants.ERROR_MESSAGE_INVALID_CNPJ);
        }
    }
}

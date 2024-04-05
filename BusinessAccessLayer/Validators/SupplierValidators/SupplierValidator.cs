using BusinessLogicalLayer.Constants.Supplier;
using BusinessLogicalLayer.Validators.CommonsValidators;
using Entities;
using Entities.Enum;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BusinessLogicalLayer.Validators.SupplierValidators
{
    internal class SupplierValidator : AbstractValidator<Supplier>
    {
        public void ValidateID()
        {
            RuleFor(s => s.ID).NotNull().WithMessage(SupplierConstants.ERROR_MESSAGE_INVALID_ID);
        }

        public void ValidateName()
        {
            RuleFor(s => s.Name).NotNull().WithMessage(SupplierConstants.ERROR_MESSAGE_EMPTY_NAME)
                              .MinimumLength(3).WithMessage(SupplierConstants.ERROR_MESSAGE_SMALL_NAME)
                              .MaximumLength(50).WithMessage(SupplierConstants.ERROR_MESSAGE_LARGE_NAME);
        }

        public void ValidatePhoneNumber()
        {
            RuleFor(s => s.PhoneNumber).NotNull().WithMessage(SupplierConstants.ERROR_MESSAGE_EMPTY_PHONE_NUMBER)
                                       .MaximumLength(11).WithMessage(SupplierConstants.ERROR_MESSAGE_INVALID_PHONE_NUMBER);
        }

       
    }
}

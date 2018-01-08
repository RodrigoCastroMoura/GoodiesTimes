using FluentValidation;
using GoodiesTime.Domain.DTO;
using GoodiesTime.Domain.Interfaces.Repository;

namespace GoodiesTime.Domain.Validators.Address
{
    public class AddressAlterarValidators : AbstractValidator<tb_addressDto>
    {
        public AddressAlterarValidators()
        {
            RuleFor(address => address.id_address)
             .NotNull()
             .NotEmpty()
             .WithMessage("id_address Field Required")
             .Must(VerificaMenorQueZero)
             .WithMessage("id_address Field Required");

            RuleFor(address => address.ds_address)
              .NotNull()
              .NotEmpty()
              .WithMessage("Address Field Required");

            RuleFor(address => address.id_partners)
               .NotNull()
               .NotEmpty()
               .WithMessage("id_partners Field Required");

            RuleFor(address => address.zipCode)
               .NotNull()
               .NotEmpty()
               .WithMessage("zipCode Field Required");

            RuleFor(address => address.city)
               .NotNull()
               .NotEmpty()
               .WithMessage("City Field Required");

            RuleFor(address => address.id_state)
               .NotNull()
               .NotEmpty()
               .WithMessage("id_state Field Required");
        }

        public bool VerificaMenorQueZero(int id)
        {
            if (id == null)
            {
                return false;
            }
            else
            {
                if (id <= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

        }
    }
}

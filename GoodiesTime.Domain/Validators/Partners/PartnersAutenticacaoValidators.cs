using FluentValidation;
using GoodiesTime.Domain.DTO;
using GoodiesTime.Domain.Interfaces.Repository;

namespace GoodiesTime.Domain.Validators.Partners
{
    public class PartnersAutenticacaoValidators : AbstractValidator<tb_partnersDto>
    {       
        public PartnersAutenticacaoValidators()
        {          
            RuleFor(partners => partners.email)
              .NotNull()
              .NotEmpty()
              .WithMessage("E-mail Field Required")
              .EmailAddress().WithMessage("invalid Email")
              .Length(3, 50).WithMessage("Email must be between 3 and 50 characters.");


            RuleFor(partners => partners.password)
              .NotNull()
              .NotEmpty()
              .WithMessage("Password Field Required")
              .Length(3, 50).WithMessage("Password must be between 3 and 50 characters.");
        }


    }
}

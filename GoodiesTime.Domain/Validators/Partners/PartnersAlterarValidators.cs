using FluentValidation;
using GoodiesTime.Domain.DTO;
using GoodiesTime.Domain.Interfaces.Repository;

namespace GoodiesTime.Domain.Validators.Partners
{
    public class PartnersAlterarValidators : AbstractValidator<tb_partnersDto>
    {
        private readonly Itb_partnersRepository itb_partnersRepository;

        public PartnersAlterarValidators(Itb_partnersRepository itb_partnersRepository)
        {
            this.itb_partnersRepository = itb_partnersRepository;

            RuleFor(partners => partners.name)
               .NotNull()
               .NotEmpty()
               .WithMessage("Name Field Required")
               .Length(3, 50).WithMessage("Name must be between 3 and 50 characters.");


            RuleFor(partners => partners.lastname)
               .NotNull()
               .NotEmpty()
               .WithMessage("Lastname Field Required")
               .Length(3, 50).WithMessage("Lastname must be between 3 and 50 characters.");


            RuleFor(partners => partners.email)
              .NotNull()
              .NotEmpty()
              .WithMessage("E-mail Field Required")
              .EmailAddress().WithMessage("invalid Email")
              //.Must(VerificaEmailJaCadastrado).WithMessage("E-mail already registered.")
              .Length(3, 50).WithMessage("Email must be between 3 and 50 characters.");


            RuleFor(partners => partners.password)
              .NotNull()
              .NotEmpty()
              .WithMessage("Password Field Required")
              .Length(3, 50).WithMessage("Password must be between 3 and 50 characters.");

        }



        private bool VerificaEmailJaCadastrado(string email)
        {
            var dto = new tb_partnersDto()
            {
                email = email
            };

            var partners = this.itb_partnersRepository.GetPartners(dto);

            if (partners == null)
                return true;
            else
                return false;
        }
    }
}

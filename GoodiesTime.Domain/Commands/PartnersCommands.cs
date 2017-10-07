using FluentValidation;
using GoodiesTime.Domain.DTO;
using GoodiesTime.Domain.Interfaces.Repository;
using GoodiesTime.Domain.Validators.Partners;

namespace GoodiesTime.Domain.Commands
{
    public static class PartnersCommands
    {
        public static void ValidaCadastro(this tb_partnersDto dto, Itb_partnersRepository itb_partnersRepository)
        {
            PartnersCadastroValidators validator = new PartnersCadastroValidators(itb_partnersRepository);
            validator.ValidateAndThrow(dto);
        }


        public static void ValidaAlterar(this tb_partnersDto dto, Itb_partnersRepository itb_partnersRepository)
        {
            PartnersAlterarValidators validator = new PartnersAlterarValidators(itb_partnersRepository);
            validator.ValidateAndThrow(dto);
        }


        public static void PartnersAutenticacaoValidators(this tb_partnersDto dto)
        {
            PartnersAutenticacaoValidators validator = new PartnersAutenticacaoValidators();
            validator.ValidateAndThrow(dto);
        }
    }
}

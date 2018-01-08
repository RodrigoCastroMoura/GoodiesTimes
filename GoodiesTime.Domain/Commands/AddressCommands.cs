using FluentValidation;
using GoodiesTime.Domain.DTO;
using GoodiesTime.Domain.Interfaces.Repository;
using GoodiesTime.Domain.Validators.Address;

namespace GoodiesTime.Domain.Commands
{
    public static class AddressCommands
    {
        public static void ValidaCadastro(this tb_addressDto dto)
        {
            AddressCadastrarValidators validator = new AddressCadastrarValidators();
            validator.ValidateAndThrow(dto);
        }

        public static void ValidaAlterar(this tb_addressDto dto)
        {
            AddressAlterarValidators validator = new AddressAlterarValidators();
            validator.ValidateAndThrow(dto);
        }
    }
}

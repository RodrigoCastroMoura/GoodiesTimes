using GoodiesTime.Domain.DTO;
using GoodiesTime.Domain.Entities;

namespace GoodiesTime.Domain.Interfaces.Services
{
    public interface Itb_partnersServices
    {
        tb_partners Cadastrar(tb_partnersDto dto);

        tb_partners Autenticaçao(string email, string senha);

        tb_partners Alterar(tb_partnersDto dto);

        tb_partners GetPartners(tb_partnersDto dto);
    }
}

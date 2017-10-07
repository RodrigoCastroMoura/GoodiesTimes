using GoodiesTime.Domain.DTO;
using GoodiesTime.Domain.Entities;

namespace GoodiesTime.Domain.Interfaces.Repository
{
    public interface Itb_partnersRepository : IRepositoryBase<tb_partners>
    {
        tb_partners Cadastrar(tb_partnersDto dto);

        tb_partners Autenticaçao(tb_partnersDto dto);

        tb_partners Alterar(tb_partnersDto dto);

        tb_partners GetPartners(tb_partnersDto dto);
    }
}

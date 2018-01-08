using GoodiesTime.Domain.Context;
using GoodiesTime.Domain.DTO;
using GoodiesTime.Domain.Entities;
using GoodiesTime.Domain.Filters;
using GoodiesTime.Domain.Interfaces.Repository;


namespace GoodiesTime.Infrastructure.Repository
{
    public class tb_partnersRepository : RepositoryBase<tb_partners>, Itb_partnersRepository
    {
        public tb_partnersRepository(IDataContext context)
            : base(context)
        {

        }

        public tb_partners Cadastrar(tb_partnersDto dto)
        {
            var partners = tb_partners.RetornoPartners(dto);

            Add(partners);

            return partners;
        }

        public tb_partners Alterar(tb_partnersDto dto)
        {
            var partners = tb_partners.RetornoPartners(dto);

            Update(partners);

            return partners;
        }

        public tb_partners Autenticaçao(tb_partnersDto dto)
        {
            var criterio = dto.CriarSpecification();

            return First(criterio);
        }

        public tb_partners GetPartners(tb_partnersDto dto)
        {
            var criterio = dto.CriarSpecification();
            return First(criterio);
        }

        public tb_partners GetPartnersId(int id_partners)
        {
            var dto = new tb_partnersDto
            {
                id_partners = id_partners
            };

            var criterio = dto.CriarSpecification();

            return First(criterio);
        }

    }
}

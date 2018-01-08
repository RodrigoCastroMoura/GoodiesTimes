using GoodiesTime.Domain.Context;
using GoodiesTime.Domain.DTO;
using GoodiesTime.Domain.Entities;
using GoodiesTime.Domain.Filters;
using GoodiesTime.Domain.Interfaces.Repository;
using System.Collections.Generic;


namespace GoodiesTime.Infrastructure.Repository
{
    public class tb_addressRepository : RepositoryBase<tb_address>, Itb_addressRepository
    {
        public tb_addressRepository(IDataContext context)
            : base(context)
        {

        }

        public tb_address Cadastrar(tb_addressDto dto)
        {
            var address = tb_address.RetornotAddress(dto);

            Add(address);

            return address;
        }

        public tb_address Alterar(tb_addressDto dto)
        {
            var address = tb_address.RetornotAddress(dto);

            Update(address);

            return address;
        }

        public IEnumerable<tb_address> GetAddress(tb_addressDto dto)
        {
            var criterio = dto.CriarSpecification();

            return Get(criterio);
        }

        public void Apagar(tb_addressDto dto)
        {
            var address = tb_address.RetornotAddress(dto);

            Remove(address);
        }

    }
}

using System;
using GoodiesTime.Domain.DTO;
using GoodiesTime.Domain.Entities;
using GoodiesTime.Library.Specifications;
using GoodiesTime.Domain.Specifications.Address;

namespace GoodiesTime.Domain.Filters
{
    public static class Address
    {
        public static ISpecification<tb_address> CriarSpecification(this tb_addressDto filtro)
        {
            if (filtro == null)
            {
                return null;
            }

            ISpecification<tb_address> criterio = null;


            if (filtro.id_address > 0)
            {

                criterio = criterio.And(new AddressIdSpecificacao(filtro.id_address));
            }



            if (filtro.id_partners > 0)
            {

                criterio = criterio.And(new AddressIdPartnersSpecificacao(filtro.id_partners));
            }

            return criterio;
        }
    }
}

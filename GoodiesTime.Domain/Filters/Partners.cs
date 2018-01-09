using System;
using GoodiesTime.Domain.DTO;
using GoodiesTime.Domain.Entities;
using GoodiesTime.Domain.Specifications.Partners;
using GoodiesTime.Library.Specifications;

namespace GoodiesTime.Domain.Filters
{
    public static class Partners 
    {
        public static ISpecification<tb_partners> CriarSpecification(this tb_partnersDto filtro)
        {
            if (filtro == null)
            {
                return null;
            }

            ISpecification<tb_partners> criterio = null;


            if (!string.IsNullOrEmpty(filtro.email))
            {

                criterio = criterio.And(new PartnersEmailSpecificacao(filtro.email));
            }



            if (!string.IsNullOrEmpty(filtro.password))
            {

                criterio = criterio.And(new PartnersPasswoerdSpecificacao(filtro.password));
            }

            if (!string.IsNullOrEmpty(filtro.hash))
            {

                criterio = criterio.And(new PartnersHashSpecificacao(filtro.hash));
            }


            if (filtro.id_partners != null)
            {
                if (filtro.id_partners > 0)
                {
                    criterio = criterio.And(new PartnersIdSpecificacao(filtro.id_partners));
                }
            }

            return criterio;

        }
    }
}

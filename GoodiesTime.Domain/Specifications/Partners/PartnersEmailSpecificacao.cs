using System;
using System.Linq.Expressions;
using GoodiesTime.Domain.Entities;
using GoodiesTime.Library.Specifications;

namespace GoodiesTime.Domain.Specifications.Partners
{
    public class PartnersIdSpecificacao : SpecificationBase<tb_partners>
    {
        private readonly int id_partners;

        public PartnersIdSpecificacao(int id_partners)
        {
            this.id_partners = id_partners;
        }

        public override Expression<Func<tb_partners, bool>> SpecExpression
        {
            get { return item => item.id_partners == this.id_partners; }
        }
    }
}

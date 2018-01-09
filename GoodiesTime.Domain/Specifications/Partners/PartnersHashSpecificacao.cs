using System;
using System.Linq.Expressions;
using GoodiesTime.Domain.Entities;
using GoodiesTime.Library.Specifications;

namespace GoodiesTime.Domain.Specifications.Partners
{
    public class PartnersHashSpecificacao : SpecificationBase<tb_partners>
    {
        private readonly string hash;

        public PartnersHashSpecificacao(string hash)
        {
            this.hash = hash;
        }

        public override Expression<Func<tb_partners, bool>> SpecExpression
        {
            get { return item => item.hash == this.hash; }
        }
    }
}

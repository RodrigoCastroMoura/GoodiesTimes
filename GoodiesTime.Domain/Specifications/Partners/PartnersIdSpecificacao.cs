using System;
using System.Linq.Expressions;
using GoodiesTime.Domain.Entities;
using GoodiesTime.Library.Specifications;

namespace GoodiesTime.Domain.Specifications.Partners
{
    public class PartnersEmailSpecificacao : SpecificationBase<tb_partners>
    {
        private readonly string email;

        public PartnersEmailSpecificacao(string email)
        {
            this.email = email;
        }

        public override Expression<Func<tb_partners, bool>> SpecExpression
        {
            get { return item => item.email == this.email; }
        }
    }
}

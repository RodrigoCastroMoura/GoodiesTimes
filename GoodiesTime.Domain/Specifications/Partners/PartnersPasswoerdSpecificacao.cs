using System;
using System.Linq.Expressions;
using GoodiesTime.Domain.Entities;
using GoodiesTime.Library.Specifications;

namespace GoodiesTime.Domain.Specifications.Partners
{
    public class PartnersPasswoerdSpecificacao : SpecificationBase<tb_partners>
    {
        private readonly string password;

        public PartnersPasswoerdSpecificacao(string password)
        {
            this.password = password;
        }

        public override Expression<Func<tb_partners, bool>> SpecExpression
        {
            get { return item => item.password == this.password; }
        }
    }
}

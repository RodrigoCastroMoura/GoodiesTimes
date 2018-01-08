using System;
using System.Linq.Expressions;
using GoodiesTime.Domain.Entities;
using GoodiesTime.Library.Specifications;

namespace GoodiesTime.Domain.Specifications.Address
{
    public class AddressIdPartnersSpecificacao : SpecificationBase<tb_address>
    {
        private readonly int id_partners;

        public AddressIdPartnersSpecificacao(int id_partners)
        {
            this.id_partners = id_partners;
        }

         public override Expression<Func<tb_address, bool>> SpecExpression
        {
            get { return item => item.id_partners == this.id_partners; }
        }
    }
}

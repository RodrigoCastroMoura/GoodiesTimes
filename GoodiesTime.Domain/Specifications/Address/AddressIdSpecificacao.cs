using System;
using System.Linq.Expressions;
using GoodiesTime.Domain.Entities;
using GoodiesTime.Library.Specifications;

namespace GoodiesTime.Domain.Specifications.Address
{
    public class AddressIdSpecificacao : SpecificationBase<tb_address>
    {
        private readonly int id_address;

         public AddressIdSpecificacao(int id_address)
        {
            this.id_address = id_address;
        }

         public override Expression<Func<tb_address, bool>> SpecExpression
        {
            get { return item => item.id_address == this.id_address; }
        }
    }
}

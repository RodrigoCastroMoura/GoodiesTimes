using GoodiesTime.Domain.Context;
using GoodiesTime.Domain.DTO;
using GoodiesTime.Domain.Entities;
using GoodiesTime.Domain.Filters;
using GoodiesTime.Domain.Interfaces.Repository;
using System.Collections.Generic;

namespace GoodiesTime.Infrastructure.Repository
{
    public class tb_businessRepository : RepositoryBase<tb_business>, Itb_businessRepository
    {
        public tb_businessRepository(IDataContext context)
            : base(context)
        {

        }
    }
}

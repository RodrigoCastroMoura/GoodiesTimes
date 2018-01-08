using GoodiesTime.Domain.Context;
using GoodiesTime.Domain.DTO;
using GoodiesTime.Domain.Entities;
using GoodiesTime.Domain.Filters;
using GoodiesTime.Domain.Interfaces.Repository;
using System.Collections.Generic;

namespace GoodiesTime.Infrastructure.Repository
{
    public class tb_statesRepository : RepositoryBase<tb_states>, Itb_statesRepository
    {
        public tb_statesRepository(IDataContext context)
            : base(context)
        {

        }
    }
}

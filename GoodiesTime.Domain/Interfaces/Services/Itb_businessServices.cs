using GoodiesTime.Domain.DTO;
using GoodiesTime.Domain.Entities;
using System.Collections.Generic;

namespace GoodiesTime.Domain.Interfaces.Services
{
    public interface Itb_businessServices
    {
        List<tb_business> GetBusiness();
    }
}

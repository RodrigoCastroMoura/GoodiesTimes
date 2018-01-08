using System.Linq;
using GoodiesTime.Domain.Commands;
using GoodiesTime.Domain.DTO;
using GoodiesTime.Domain.Entities;
using GoodiesTime.Domain.Interfaces.Repository;
using GoodiesTime.Domain.Interfaces.Services;
using GoodiesTime.Domain.Service;
using GoodiesTime.Domain.UnityOfWork;
using GoodiesTime.Library;
using System.Collections.Generic;

namespace GoodiesTime.Service.Service
{
    public class BusinessAppService : AppService, Itb_businessServices
    {
        private Itb_businessRepository itb_businessRepository;

        public BusinessAppService(
            IUnitiOfWork unitOfWork,
            Itb_businessRepository itb_businessRepository)
            : base(unitOfWork)
        {
            this.itb_businessRepository = itb_businessRepository;
        }

        public List<tb_business> GetBusiness()
        {
            return itb_businessRepository.Get().ToList();
        }

    }
}

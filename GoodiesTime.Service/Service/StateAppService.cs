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
    public class StateAppService : AppService, Itb_statesServices
    {
        private Itb_statesRepository itb_statesRepository;
        public StateAppService(
            IUnitiOfWork unitOfWork,
            Itb_statesRepository itb_statesRepository)
            : base(unitOfWork)
        {
            this.itb_statesRepository = itb_statesRepository;
        }

        public List<tb_states> GetStates()
        {
            return itb_statesRepository.Get().ToList();
        }
    }
}

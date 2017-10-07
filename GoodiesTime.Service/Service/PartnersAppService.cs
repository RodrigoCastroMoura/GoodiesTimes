using GoodiesTime.Domain.Commands;
using GoodiesTime.Domain.DTO;
using GoodiesTime.Domain.Entities;
using GoodiesTime.Domain.Interfaces.Repository;
using GoodiesTime.Domain.Interfaces.Services;
using GoodiesTime.Domain.Service;
using GoodiesTime.Domain.UnityOfWork;
using GoodiesTime.Library;

namespace GoodiesTime.Service.Service
{
    
    public class PartnersAppService : AppService, Itb_partnersServices
    {

        private readonly Itb_partnersRepository itb_partnersRepository;

        public PartnersAppService(
            IUnitiOfWork unitOfWork,
            Itb_partnersRepository itb_partnersRepository)
            : base(unitOfWork)
        {
            this.itb_partnersRepository = itb_partnersRepository;
        }

        public tb_partners Cadastrar(tb_partnersDto dto)
        {
            dto.ValidaCadastro(itb_partnersRepository);
 
            return itb_partnersRepository.Cadastrar(dto);
        }


        public tb_partners Alterar(tb_partnersDto dto)
        {
            dto.ValidaAlterar(itb_partnersRepository);

            return itb_partnersRepository.Alterar(dto);
        }


        public tb_partners Autenticaçao(string email, string senha)
        {
            var dto = new tb_partnersDto()
            {
                email = email,
                password = SecurityDb.Encrypt(senha)
            };

            return itb_partnersRepository.Autenticaçao(dto);
        }


        public tb_partners GetPartners(tb_partnersDto dto)
        {
            return itb_partnersRepository.GetPartners(dto);
        }

    }
}

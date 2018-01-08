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
    public class AddressAppService : AppService, Itb_addressServices
    {
         private readonly Itb_addressRepository itb_addressRepository;

        public AddressAppService(
            IUnitiOfWork unitOfWork,
            Itb_addressRepository itb_addressRepository)
             : base(unitOfWork)
         {
             this.itb_addressRepository = itb_addressRepository;
         }

        public tb_address Cadastrar(tb_addressDto dto)
        {
            dto.ValidaCadastro();

            var value = itb_addressRepository.Cadastrar(dto);

            SaveChanges();

            Dispose();

            return value;
        }

        public tb_address Alterar(tb_addressDto dto)
        {
            dto.ValidaAlterar();

            var value = itb_addressRepository.Alterar(dto);

            SaveChanges();

            Dispose();

            return value;
        }

        public List<tb_address> GetAddress(tb_addressDto dto)
        {
            return itb_addressRepository.GetAddress(dto).ToList();
        }

        public void Apagar(int id_address)
        {

        }
    }
}

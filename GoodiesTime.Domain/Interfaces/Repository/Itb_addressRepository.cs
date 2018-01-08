using GoodiesTime.Domain.DTO;
using GoodiesTime.Domain.Entities;
using System.Collections.Generic;

namespace GoodiesTime.Domain.Interfaces.Repository
{
    public interface Itb_addressRepository  : IRepositoryBase<tb_address>
    {
        tb_address Cadastrar(tb_addressDto dto);

        tb_address Alterar(tb_addressDto dto);

        IEnumerable<tb_address> GetAddress(tb_addressDto dto);

        void Apagar(tb_addressDto dto);
    }
}

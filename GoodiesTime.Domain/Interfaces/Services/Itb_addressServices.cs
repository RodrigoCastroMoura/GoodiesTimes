using GoodiesTime.Domain.DTO;
using GoodiesTime.Domain.Entities;
using System.Collections.Generic;

namespace GoodiesTime.Domain.Interfaces.Services
{
    public interface Itb_addressServices
    {
        tb_address Cadastrar(tb_addressDto dto);

        tb_address Alterar(tb_addressDto dto);

        IEnumerable<tb_address> GetAddress(tb_addressDto dto);

        void Apagar(int id_address);
    }
}

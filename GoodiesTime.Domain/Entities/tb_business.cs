using GoodiesTime.Domain.DTO;
using System;


namespace GoodiesTime.Domain.Entities
{
    public class tb_business
    {
        public int id_business { get; private set; }

        public string business { get; private set; }

        protected tb_business()
        {
            
        }

        private tb_business(tb_businessDto dto)
        {
            id_business = dto.id_business;

            business = dto.business;

        }

        public static tb_business RetornotBusiness(tb_businessDto dto)
        {
            return new tb_business(dto);
        }

    }
}

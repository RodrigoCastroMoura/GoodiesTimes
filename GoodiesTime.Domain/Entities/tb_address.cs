using System;
using GoodiesTime.Domain.DTO;

namespace GoodiesTime.Domain.Entities
{
    public class tb_address
    {
        public int id_address { get; private set; }

        public int id_partners { get; private set; }

        public string ds_address { get; private set; }

        public string zipCode { get; private set; }

        public string city { get; private set; }

        public int? id_state { get; private set; }

        public string state { get; private set; }

        public bool main { get; private set; }

        public virtual tb_partners tb_partners { get; private set; }

        protected tb_address()
        {
            
        }

        private tb_address(tb_addressDto dto)
        {
            id_address =dto.id_address;

            id_partners  =dto.id_partners;

            ds_address =dto.ds_address;

            zipCode =dto.zipCode;

            city =dto.city;

            id_state =dto.id_state;

            state = dto.state;

            main = dto.main;
        }

        public static tb_address RetornotAddress(tb_addressDto dto)
        {
            return new tb_address(dto);
        }
    }
}


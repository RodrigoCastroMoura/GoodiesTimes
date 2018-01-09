using System;
using GoodiesTime.Domain.DTO;
using System.Collections.Generic;

namespace GoodiesTime.Domain.Entities
{
    public class tb_partners
    {
        public int id_partners { get; private set; }

        public string hash { get; private set; }

        public string name { get; private set; }

        public string lastname { get; private set; }

        public string email { get; private set; }

        public string password { get; private set; }

        public string phone { get; private set; }

        public DateTime? ts_user_cadm { get; private set; }

        public bool? active { get; private set; }

        public int? id_business { get; private set; }

        public string changePassWord { get; private set; }

        public virtual ICollection<tb_address> tb_address { get; private set; }


        protected tb_partners()
        {
            tb_address = new HashSet<tb_address>();
        }

        private tb_partners(tb_partnersDto dto)
        {
            id_partners = dto.id_partners;

            hash = dto.hash;

            name = dto.name;

            lastname = dto.lastname;

            email = dto.email;

            password = dto.password;

            phone = dto.phone;

            ts_user_cadm = dto.ts_user_cadm;

            active = dto.active;

            id_business = dto.id_business;

            changePassWord = dto.changePassWord;
        }

        public static tb_partners RetornoPartners(tb_partnersDto dto)
        {
            return new tb_partners(dto);
        }

    }
}

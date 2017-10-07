using System;
using GoodiesTime.Domain.DTO;

namespace GoodiesTime.Domain.Entities
{
    public class tb_partners
    {
        public int id_partners { get; private set; }

        public string name { get; private set; }

        public string lastname { get; private set; }

        public DateTime? birthday { get; private set; }

        public string email { get; private set; }

        public string password { get; private set; }

        public string company { get; private set; }

        public string taxID { get; private set; }

        public string phone { get; private set; }

        public string address { get; private set; }

        public string zipCode { get; private set; }

        public string city { get; private set; }

        public int? id_state { get; private set; }

        public string state { get; private set; }

        public int? id_user_cadm { get; private set; }

        public DateTime? ts_user_cadm { get; private set; }

        public int? id_user_manu { get; private set; }

        public DateTime? ts_user_manu { get; private set; }

        public bool? active { get; private set; }

        public int? id_business { get; private set; }

        public int? id_statusPartners { get; private set; }

        public string changePassWord { get; private set; }


        protected tb_partners()
        {
            
        }


        private tb_partners(tb_partnersDto dto)
        {

            id_partners = dto.id_partners;

            name = dto.name;

            lastname = dto.lastname;

            birthday = dto.birthday;

            email = dto.email;

            password = dto.password;

            company = dto.company;

            taxID = dto.taxID;

            phone = dto.phone;

            address = dto.address;

            zipCode = dto.zipCode;

            city = dto.city;

            id_state = dto.id_state;

            state = dto.state;

            id_user_cadm = dto.id_user_cadm;

            ts_user_cadm = dto.ts_user_cadm;

            id_user_manu = dto.id_user_manu;

            ts_user_manu = dto.ts_user_manu;

            active = dto.active;

            id_business = dto.id_business;

            id_statusPartners = dto.id_statusPartners;

            changePassWord = dto.changePassWord;
        }

        public static tb_partners RetornoPartners(tb_partnersDto dto)
        {
            return new tb_partners(dto);
        }

    }
}

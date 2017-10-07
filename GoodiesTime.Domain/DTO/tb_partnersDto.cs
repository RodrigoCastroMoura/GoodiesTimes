using System;

namespace GoodiesTime.Domain.DTO
{
    public class tb_partnersDto
    {
        public int id_partners { get;  set; }

        public string name { get;  set; }

        public string lastname { get;  set; }

        public DateTime? birthday { get;  set; }

        public string email { get;  set; }

        public string password { get;  set; }

        public string company { get;  set; }

        public string taxID { get;  set; }

        public string phone { get;  set; }

        public string address { get;  set; }

        public string zipCode { get;  set; }

        public string city { get;  set; }

        public int? id_state { get;  set; }

        public string state { get;  set; }

        public int? id_user_cadm { get;  set; }

        public DateTime? ts_user_cadm { get;  set; }

        public int? id_user_manu { get;  set; }

        public DateTime? ts_user_manu { get;  set; }

        public bool? active { get;  set; }

        public int? id_business { get;  set; }

        public int? id_statusPartners { get;  set; }

        public string changePassWord { get;  set; }
    }
}

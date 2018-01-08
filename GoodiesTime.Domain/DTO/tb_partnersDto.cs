using System;

namespace GoodiesTime.Domain.DTO
{
    public class tb_partnersDto
    {
        public int id_partners { get;  set; }

        public string name { get;  set; }

        public string lastname { get;  set; }

        public string email { get;  set; }

        public string password { get;  set; }

        public string phone { get;  set; }

        public DateTime? ts_user_cadm { get;  set; }

        public bool? active { get;  set; }

        public int? id_business { get;  set; }

        public string changePassWord { get;  set; }
    }
}

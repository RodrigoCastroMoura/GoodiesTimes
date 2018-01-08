using System;

namespace GoodiesTime.Domain.DTO
{
    public class tb_addressDto
    {
        public int id_address { get;  set; }

        public int id_partners { get;  set; }

        public string ds_address { get;  set; }

        public string zipCode { get;  set; }

        public string city { get;  set; }

        public int? id_state { get;  set; }

        public string state { get;  set; }

        public bool main { get;  set; }
    }
}

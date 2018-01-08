using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoodiesTimes.Api.Models
{
    public class AddressModels
    {
        public int id_address { get; set; }

        public int id_partners { get; set; }

        public string ds_address { get; set; }

        public string zipCode { get; set; }

        public string city { get; set; }

        public int? id_state { get; set; }

        public string state { get; set; }

        public bool main { get; set; }
    }

    public class AddressEnterModels
    {
        public int id_address { get; set; }

        public int id_partners { get; set; }

  
    }
}
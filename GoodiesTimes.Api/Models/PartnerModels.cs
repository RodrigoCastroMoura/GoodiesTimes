using GoodiesTime.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoodiesTimes.Api.Models
{
    public class PartnerModels
    {
        public int id_partners { get; set; }

        public string name { get; set; }

        public string lastname { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public string phone { get; set; }

        public int? id_business { get; set; }


        public static object CreateRetorno(tb_partners partners)
        {
            if (partners == null) return null;

            return new PartnerModels
            {
                id_partners = partners.id_partners,

                name = partners.name,

                lastname = partners.lastname,

                email = partners.email,

                phone = partners.phone,

                id_business = partners.id_business,

            };
                    
        }
    }
}
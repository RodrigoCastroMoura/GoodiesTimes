using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using GoodiesTime.Domain.DTO;
using GoodiesTime.Web.Api.Models;

namespace GoodiesTime.Web.Api.Mappers
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {

            Mapper.Initialize(x =>
            {
                x.CreateMap<tb_partnersDto, PartnerModels>();

                x.CreateMap<PartnerModels, tb_partnersDto>();

            });


            Mapper.AssertConfigurationIsValid();


        }
    }
}
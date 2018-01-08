using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using GoodiesTime.Domain.DTO;
using GoodiesTimes.Api.Models;

namespace GoodiesTimes.Api.Mappers
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {

            Mapper.Initialize(x =>
            {
                x.CreateMap<PartnerModels, tb_partnersDto>()
                    .ForMember(opt => opt.ts_user_cadm, opt => opt.Ignore())
                    .ForMember(opt => opt.changePassWord, opt => opt.Ignore())
                    .ForMember(opt => opt.active, opt => opt.Ignore());


                x.CreateMap<tb_partnersDto, tb_partnersDto>();
                    
            });

            Mapper.AssertConfigurationIsValid();

        }
    }
}
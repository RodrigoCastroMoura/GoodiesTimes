using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using GoodiesTime.Domain.DTO;
using GoodiesTimes.Api.Models;
using GoodiesTime.Domain.Entities;

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

                x.CreateMap<AddressModels, tb_addressDto>();

                x.CreateMap<tb_address, AddressModels>();

                x.CreateMap<AddressEnterModels, tb_addressDto>()
                    .ForMember(opt => opt.ds_address, opt => opt.Ignore())
                    .ForMember(opt => opt.zipCode, opt => opt.Ignore())
                    .ForMember(opt => opt.city, opt => opt.Ignore())
                    .ForMember(opt => opt.id_state, opt => opt.Ignore())
                    .ForMember(opt => opt.state, opt => opt.Ignore())
                    .ForMember(opt => opt.main, opt => opt.Ignore())                    ;
                    
            });

            Mapper.AssertConfigurationIsValid();

        }
    }
}
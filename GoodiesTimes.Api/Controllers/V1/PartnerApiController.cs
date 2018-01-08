using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using GoodiesTime.Domain.DTO;
using GoodiesTime.Library;
using GoodiesTime.Domain.Interfaces.Services;
using GoodiesTimes.Api.Models;
using System.Web.Http.Description;

namespace GoodiesTimes.Api.Controllers.V1
{
    [RoutePrefix("V1/api/partner")]
    public class PartnerApiController : ApiController
    {
        private readonly Itb_partnersServices service;

        public PartnerApiController(Itb_partnersServices service)
        {
            this.service = service;
        }


        [ResponseType(typeof(PartnerModels))]
        [HttpPost]
        [Route("AddPartner")]
        public async Task<HttpResponseMessage> AddPartner(PartnerModels value)
        {
            try
            {
                var dto = Mapper.Map<PartnerModels, tb_partnersDto>(value);

                dto.ts_user_cadm = DateTime.Now;
                dto.password = SecurityDb.Encrypt(dto.password);
                dto.active = true;

                service.Cadastrar(dto);

                return Request.CreateResponse(HttpStatusCode.OK, true);
                
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [ResponseType(typeof(PartnerModels))]
        [HttpPut]
        [Route("UpdatePartner")]
        public async Task<HttpResponseMessage> UpdatePartner(PartnerModels value)
        {
            try
            {
                var dto = Mapper.Map<PartnerModels, tb_partnersDto>(value);

                var resut = service.GetPartnersId(dto.id_partners);

                if (resut == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Not found");
                else
                {
                    dto.password = resut.password;
                    dto.ts_user_cadm = resut.ts_user_cadm;
                    dto.active = resut.active;
                }

        
                service.Alterar(dto);

                return Request.CreateResponse(HttpStatusCode.OK, true);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        [HttpGet]
        [Route("GetPartner")]
        public async Task<HttpResponseMessage> GetPartner(int id_partners)
        {
            try
            {
                var resut = service.GetPartnersId(id_partners);

                if (resut == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Not found");

                var model = PartnerModels.CreateRetorno(resut);

                return Request.CreateResponse(HttpStatusCode.OK, model);
                    
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }


    }
}

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
using GoodiesTime.Domain.Entities;

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
        //[Authorize]
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
        [Route("GetPartner/{id_partners}")]
        //[Authorize]
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

        [HttpPost]
        [Route("RequestPassword")]
        [AllowAnonymous]
        public async Task<HttpResponseMessage> RequestPassword(string email)
        {
            try
            {

                var dto = new tb_partnersDto()
                {
                    email = email
                };

                var result = Mapper.Map<tb_partners, tb_partnersDto>(service.GetPartners(dto));

                if (result == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Not Found");
                }

                result.hash = Email.MD5Hash(DateTime.Now.ToString());

                service.Alterar(result);

                var resoposta = Email.Send(result.name, result.email, "Teste  - Reenvio Senha ", "<p style='font-family: Arial, Helvetica; color: #000; font-size: 14px'>Olá <strong>" + result.name + ",</strong><br /><br />Sua solicitação foi feita com sucesso!<p style='font-family: Arial, Helvetica; color: #000; font-size: 13px;'>Favor acessar o Link,  que é: <strong>" + result.hash + "<strong> </p><p style='font-family: Arial, Helvetica; color: black; font-size: 13px;'><strong>Favor não responder este e-mail!</strong></p>");

                if (resoposta != "Y")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "We're in trouble, try again later!");
                }

                return Request.CreateResponse(HttpStatusCode.OK, true);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        [Route("ChangePassword")]
        [AllowAnonymous]
        public async Task<HttpResponseMessage> ChangePassword(string password,string hash)
        {
            try
            {

                var dto = new tb_partnersDto()
                {
                    hash = hash
                };

                var result = Mapper.Map<tb_partners, tb_partnersDto>(service.GetPartners(dto));

                if (result == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Not Found");
                }

                result.hash = Email.MD5Hash(DateTime.Now.ToString());
                result.password = SecurityDb.Encrypt(password);

                service.Alterar(result);

                return Request.CreateResponse(HttpStatusCode.OK, true);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }


    }
}

using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using GoodiesTime.Domain.DTO;
using GoodiesTime.Domain.Interfaces.Services;
using GoodiesTime.Web.Api.Models;

namespace GoodiesTime.Web.Api.Controllers.V1
{
    [RoutePrefix("V1/api/partner")]
    public class PartnerApiController : ApiController
    {
        private readonly Itb_partnersServices service;

        public PartnerApiController(Itb_partnersServices service)
        {
            this.service = service;
        }


        [HttpGet]
        [Route("getPartner")]
        public async Task<HttpResponseMessage> GetPartner()
        {
            try
            {
                var dto =  new tb_partnersDto() {

                    email = "teste@teste.com"
                };

                var resposta = service.GetPartners(dto);

                if (resposta != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, true);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, false);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }


    }
}

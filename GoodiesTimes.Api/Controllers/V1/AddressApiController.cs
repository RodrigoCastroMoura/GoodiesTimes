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
using System.Collections.Generic;

namespace GoodiesTimes.Api.Controllers.V1
{
     [RoutePrefix("V1/api/Address")]
    public class AddressApiController : ApiController
    {
        private readonly Itb_addressServices service;

        public AddressApiController(Itb_addressServices service)
        {
            this.service = service;
        }

        [ResponseType(typeof(AddressModels))]
        [HttpPost]
        [Route("AddAddress")]
        //[Authorize]
        public async Task<HttpResponseMessage> AddAddress(AddressModels value)
        {
            try
            {
                var dto = Mapper.Map<AddressModels, tb_addressDto>(value);

                service.Cadastrar(dto);

                return Request.CreateResponse(HttpStatusCode.OK, true);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [ResponseType(typeof(AddressModels))]
        [HttpPut]
        [Route("UpdateAddress")]
        //[Authorize]
        public async Task<HttpResponseMessage> UpdateAddress(AddressModels value)
        {
            try
            {
                var dto = Mapper.Map<AddressModels, tb_addressDto>(value);

                service.Alterar(dto);

                return Request.CreateResponse(HttpStatusCode.OK, true);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

       
        [HttpGet]
        [Route("GetAddress")]
        //[Authorize]
        public async Task<HttpResponseMessage> GetAddress(int id_address = 0, int id_partners = 0)
        {
            try
            {
                var dto = new tb_addressDto
                {

                    id_address = id_address,

                    id_partners = id_partners

                };


                var result = service.GetAddress(dto);

                var objList = new List<Models.AddressModels>();


                for (int i = 0; i < result.Count; i++)
                {
                    objList.Add(new AddressModels
                    {
                        id_address = result[i].id_address,
                        id_partners = result[i].id_partners,
                        ds_address = result[i].ds_address,
                        zipCode = result[i].zipCode,
                        city = result[i].city,
                        id_state = result[i].id_state,
                        main = result[i].main,
                        state = result[i].state
                    });
                }

                return Request.CreateResponse(HttpStatusCode.OK, objList);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        
    }
}

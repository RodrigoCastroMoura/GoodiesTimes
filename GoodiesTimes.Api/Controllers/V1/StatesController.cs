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
    public class StatesController : ApiController
    {
        private Itb_statesServices service;

        public StatesController(Itb_statesServices service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("GetState")]
        //[Authorize]
        public async Task<HttpResponseMessage> GetState()
        {
            try
            {
                var result = service.GetStates();

                var objList = new List<Models.StateModels>();

                for (int i = 0; i < result.Count; i++)
                {
                    objList.Add(new StateModels
                    {
                        id_state = result[i].id_state,
                        ds_name = result[i].ds_name,
                        ds_cod = result[i].ds_cod,
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

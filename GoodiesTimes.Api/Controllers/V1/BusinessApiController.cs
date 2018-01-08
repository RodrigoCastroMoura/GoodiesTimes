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
     [RoutePrefix("V1/api/buniness")]
    public class BusinessApiController : ApiController
    {
         private Itb_businessServices service;
         public BusinessApiController(Itb_businessServices service)
         {
             this.service = service;
         }

         [HttpGet]
         [Route("GetBusiness")]
         //[Authorize]
         public async Task<HttpResponseMessage> GetBusiness()
         {
            try
            {
                 var result = service.GetBusiness();

                 var objList = new List<Models.BusinessModels>();

                 for (int i = 0; i < result.Count; i++)
                 {
                     objList.Add(new BusinessModels
                     {
                         id_business = result[i].id_business,
                         business = result[i].business,
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

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
    public class AddressApiController : ApiController
    {
        private readonly Itb_partnersServices service;

        public AddressApiController(Itb_partnersServices service)
        {
            this.service = service;
        }


    }
}

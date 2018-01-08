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

        //[HttpPost]
        //[Route("EnviarSenha/{cpf}")]
        //[AllowAnonymous]
        //public async Task<HttpResponseMessage> EnviarSenha(string cpf)
        //{
        //    try
        //    {

        //        string SenhaCaracteresValidos = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890@#&!?";
        //        int valormaximo = SenhaCaracteresValidos.Length;
        //        Random random = new Random(DateTime.Now.Millisecond);
        //        StringBuilder senha = new StringBuilder(6);
        //        for (int indice = 0; indice < 6; indice++)
        //        {
        //            senha.Append(SenhaCaracteresValidos[random.Next(0, valormaximo)]);
        //        }

        //        var dto = Mapper.Map<Cliente, ClienteDto>(service.GetCliente(cpf));

        //        if (dto == null)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.BadRequest, "Usuário não encontrado!");
        //        }

        //        dto.ds_senha = SecurityDb.Encrypt(senha.ToString());
        //        dto.fl_trocar_senha = true; ;

        //        service.Alterar(dto);

        //        var resoposta = Email.Send(dto.ds_nome, dto.ds_email, "Rastreio Fácil - Reenvio Senha ", "<p style='font-family: Arial, Helvetica; color: #000; font-size: 14px'>Olá <strong>" + dto.ds_nome + ",</strong><br /><br />Sua solicitação de reenvio de senha temporária foi feita com sucesso!<p style='font-family: Arial, Helvetica; color: #000; font-size: 13px;'>Favor acessar o sitema, digite o seu CPF e a nova senha,  que é: <strong>" + senha.ToString() + "<strong> </p><p style='font-family: Arial, Helvetica; color: black; font-size: 13px;'><strong>Favor não responder este e-mail!</strong></p>");

        //        if (resoposta != "Y")
        //        {
        //            return Request.CreateResponse(HttpStatusCode.BadRequest, "Estamos com  problema, tente mais tarde!");
        //        }

        //        return Request.CreateResponse(HttpStatusCode.OK, "Sua senha foi enviada para seu e-mail com sucesso!");

        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}
    }
}

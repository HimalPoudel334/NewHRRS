
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HRRS.Helpers;

namespace HRRS.Controllers.Anusuchis
{
    public class AnusuchiController : ApiController
    {

        [HttpPost]
        [Route("api/anusuchi")]
        public IHttpActionResult Create(Anusuchi model)
        {
            try
            {

                DapperHelper.ExecuteStoredProcedure("sp_InsertAnusuchi", model);

                return Ok();
            }
            catch (Exception ex)
            {
                var except = ex.Message;
                return ResponseMessage(
                    Request.CreateResponse(
                        HttpStatusCode.InternalServerError,
                            new { sucess = false, error_message = except }
                    )
                );
            }
        }

        [HttpPut]
        [Route("api/anusuchi/{anusuchiId}/update")]
        public IHttpActionResult Update(Anusuchi model)
        {
            try
            {

                DapperHelper.ExecuteStoredProcedure("sp_UpdateAnusuchi", model);

                return Ok();
            }
            catch (Exception ex)
            {
                var except = ex.Message;
                return ResponseMessage(
                    Request.CreateResponse(
                        HttpStatusCode.InternalServerError,
                            new { sucess = false, error_message = except }
                    )
                );
            }
        }



        [HttpGet]
        [Route("api/anusuchi")]
        public IHttpActionResult Index()
        {
            try
            {
                var list = DapperHelper.QueryStoredProcedure<Anusuchi>("sp_SelectFromTable", new { tableName = "Anusuchis" }).ToList();
                return Ok(new ResultDto<List<Anusuchi>>(true, list));
            }
            catch (Exception ex)
            {
                var except = ex.Message;
                return ResponseMessage(
                    Request.CreateResponse(
                        HttpStatusCode.InternalServerError,
                            new { sucess = false, error_message = except }
                    )
                );
            }
        }

        [HttpGet]
        [Route("api/anusuchi/{id}")]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var anusuchi = DapperHelper.QueryStoredProcedure<Anusuchi>("sp_SelectFromTable", new { tableName = "Anusuchis", id }).FirstOrDefault();
                return Ok(new ResultDto<Anusuchi>(true, anusuchi));
            }
            catch (Exception ex)
            {
                var except = ex.Message;
                return ResponseMessage(
                    Request.CreateResponse(
                        HttpStatusCode.InternalServerError,
                            new { sucess = false, error_message = except }
                    )
                );
            }
        }






    }
}
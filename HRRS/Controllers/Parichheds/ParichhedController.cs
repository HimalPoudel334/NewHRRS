using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HRRS.Helpers;
using HRRS.Models.Parichhed;

namespace HRRS.Controllers.Parichheds
{
    public class ParichhedController : ApiController
    {
        [HttpPost]
        [Route("api/parichhed")]
        public IHttpActionResult Create(Parichhed model)
        {
            try
            {

                DapperHelper.ExecuteStoredProcedure("sp_InsertParichhed", model);

                return Ok();
            }
            catch (Exception ex)
            {
                var except = ex.Message;
                return ResponseMessage(
                    Request.CreateResponse(
                        HttpStatusCode.InternalServerError,
                            new ResultDto<Parichhed>(false, null, except)
                    )
                );
            }
        }

        [HttpPost]
        [Route("api/parichhed/{id}/update")]
        public IHttpActionResult Update(int id, Parichhed model)
        {
            try
            {

                DapperHelper.ExecuteStoredProcedure("sp_UpdateParichhed", model);

                return Ok();
            }
            catch (Exception ex)
            {
                var except = ex.Message;
                return ResponseMessage(
                    Request.CreateResponse(
                        HttpStatusCode.InternalServerError,
                            new ResultDto<Parichhed>(false, null, except)
                    )
                );
            }
        }

        [HttpGet]
        [Route("api/parichhed")]

        public IHttpActionResult Index()
        {
            try
            {
                var list = DapperHelper.QueryStoredProcedure<Parichhed>("sp_SelectFromTable", new { tableName = "Parichheds" }).ToList();
                return Ok(new ResultDto<List<Parichhed>>(true, list, null));
            }
            catch (Exception ex)
            {
                var except = ex.Message;
                return ResponseMessage(
                    Request.CreateResponse(
                        HttpStatusCode.InternalServerError,
                            new ResultDto<List<Parichhed>>(false, null, except)
                    )
                );
            }
        }

        [HttpGet]
        [Route("api/parichhed/{id}")]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var parichhed = DapperHelper.QueryStoredProcedure<Parichhed>("sp_SelectFromTable", new { tableName = "Parichheds", id }).FirstOrDefault();
                return Ok(new ResultDto<Parichhed>(true, parichhed));
            }
            catch (Exception ex)
            {
                var except = ex.Message;
                return ResponseMessage(
                    Request.CreateResponse(
                        HttpStatusCode.InternalServerError,
                            new ResultDto<Parichhed>(false, null, except)
                    )
                );
            }
        }

        [HttpGet]
        [Route("api/parichhed/")]
        public IHttpActionResult GetParichhedOfAnusuchi(int? anusuchiId)
        {
            try
            {
                var list = DapperHelper.QueryStoredProcedure<Parichhed>("sp_GetParichhedsOfAnusuchi", new { anusuchiId }).ToList();
                return Ok(new ResultDto<List<Parichhed>>(true, list));
            }
            catch (Exception ex)
            {
                var except = ex.Message;
                return ResponseMessage(
                    Request.CreateResponse(
                        HttpStatusCode.InternalServerError,
                            new ResultDto<List<Parichhed>>(false, null, except)
                    )
                );
            }
        }
    }
}

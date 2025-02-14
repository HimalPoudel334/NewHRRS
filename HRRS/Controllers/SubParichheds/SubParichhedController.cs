using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HRRS.Dto;
using HRRS.Helpers;
using HRRS.Models.Parichhed;

namespace HRRS.Controllers.SubParichheds
{
    public class SubParichhedController : ApiController
    {
        [HttpGet]
        [Route("api/subparichhed")]
        public IHttpActionResult Index()
        {
            try
            {
                var list = DapperHelper.QueryStoredProcedure<SubParichhed>("sp_SelectFromTable", new { tableName = "SubParichheds" }).ToList();

                return Ok(new ResultDto<List<SubParichhed>>(true, list, null));
            }
            catch (Exception ex)
            {
                var except = ex.Message;
                return ResponseMessage(
                    Request.CreateResponse(
                        HttpStatusCode.InternalServerError,
                            new ResultDto<List<SubParichhed>>(false, null, except)
                    )
                );
            }


        }

        [HttpPost]
        [Route("api/subparichhed")]
        public IHttpActionResult Create(Parichhed model)
        {
            try
            {
                DapperHelper.ExecuteStoredProcedure("sp_InsertSubParichhed", model);
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

        [HttpPost]
        [Route("api/subparichhed/{id}/update")]
        public IHttpActionResult Update(Parichhed model)
        {
            try
            {
                DapperHelper.ExecuteStoredProcedure("sp_UpdateSubParichhed", model);

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
        [Route("api/subparichhed/{id}")]
        public IHttpActionResult Index(int id)
        {
            try
            {
                var subParichhed = DapperHelper.QueryStoredProcedure<SubParichhed>("sp_SelectFromTable", new { tableName = "SubParichheds", id = id }).FirstOrDefault();

                return Ok(new ResultDto<SubParichhed>(true, subParichhed, null));
            }
            catch (Exception ex)
            {
                var except = ex.Message;
                return ResponseMessage(
                    Request.CreateResponse(
                        HttpStatusCode.InternalServerError,
                            new ResultDto<List<SubParichhed>>(false, null, except)
                    )
                );
            }


        }







    }
}

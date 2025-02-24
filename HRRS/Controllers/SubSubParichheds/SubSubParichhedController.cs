using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HRRS.Helpers;
using HRRS.Models.Parichhed;

namespace HRRS.Controllers.SubSubParichheds
{
    public class SubSubParichhedController : ApiController
    {
        [HttpGet]
        [Route("api/subsubparichhed")]
        public IHttpActionResult Index()
        {
            try
            {
                var list = DapperHelper.QueryStoredProcedure<SubParichhed>("sp_SelectFromTable", new { tableName = "SubSubParichheds" }).ToList();

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
        [Route("api/subsubparichhed")]
        public IHttpActionResult Create(SubParichhed model)
        {
            try
            {
                DapperHelper.ExecuteStoredProcedure("sp_InsertSubSubParichhed", model);
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
        [Route("api/subsubparichhed/{id}/update")]
        public IHttpActionResult Update(Parichhed model)
        {
            try
            {
                DapperHelper.ExecuteStoredProcedure("sp_UpdateSubSubParichhed", model);

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
        [Route("api/subsubparichhed/{id}")]
        public IHttpActionResult Index(int id)
        {
            try
            {
                var subParichhed = DapperHelper.QueryStoredProcedure<SubParichhed>("sp_SelectFromTable", new { tableName = "SubSubParichheds", id = id }).FirstOrDefault();

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
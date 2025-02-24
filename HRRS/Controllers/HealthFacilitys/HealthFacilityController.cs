using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using HRRS.Controllers.Auth;
using HRRS.Helpers;
using HRRS.Models;

namespace HRRS.Controllers.HealthFacilitys
{
    public class HealthFacilityController : ApiController
    {
        [HttpGet]
        [Route("api/healthfacility")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var list = DapperHelper.QueryStoredProcedure<HealthFacility>("sp_SelectFromTable", new { tableName = "HealthFacilities" }).ToList();
                return Ok(new ResultDto<List<HealthFacility>>(true, list));
            }
            catch (Exception ex)
            {
                var except = ex.Message;
                return ResponseMessage(
                    Request.CreateResponse(
                        HttpStatusCode.InternalServerError,
                            new ResultDto<HealthFacility>(false, null, except)
                    )
                );
            }
        }

        [HttpGet]
        [Route("api/healthfacility/{id}")]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var list = DapperHelper.QueryStoredProcedure<HealthFacility>("sp_SelectFromTable", new { tableName = "HealthFacilities", id }).FirstOrDefault();
                return Ok(new ResultDto<HealthFacility>(true, list));
            }
            catch (Exception ex)
            {
                var except = ex.Message;
                return ResponseMessage(
                    Request.CreateResponse(
                        HttpStatusCode.InternalServerError,
                            new ResultDto<HealthFacility>(false, null, except)
                    )
                );
            }
        }


    }
}

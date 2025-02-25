using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using HRRS.Controllers.Auth;
using HRRS.Dto;
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

        [HttpPost]
        [Route("api/healthfacility/register")]
        public IHttpActionResult Register(HealthFacilityDto model)
        {
            try
            {
                model.password = GenerateHashedPassword(model.password);
                DapperHelper.ExecuteStoredProcedure("sp_InsertHealthFacility", model);

                return Ok(new ResultDto<HealthFacilityDto>(true));
            }
            catch (Exception ex)
            {
                var except = ex.Message;
                return ResponseMessage(
                    Request.CreateResponse(
                        HttpStatusCode.InternalServerError,
                            new ResultDto<HealthFacilityDto>(false, null, except)
                    )
                );
            }
        }

        [Authorize]
        [HttpPost]
        [Route("api/healthfacility/{id}")]
        public IHttpActionResult Update(int id, HealthFacility model)
        {
            try
            {
                var claims = (ClaimsIdentity)User.Identity;
                var healthFacilityId = int.Parse(claims.FindFirst("HealthFacilityId")?.Value ?? "0");
                model.id = healthFacilityId;
                DapperHelper.ExecuteStoredProcedure("sp_UpdateHealthFacility", model);

                return Ok(new ResultDto<HealthFacility>(true));
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

        private static string GenerateHashedPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, 12);
        }


    }
}

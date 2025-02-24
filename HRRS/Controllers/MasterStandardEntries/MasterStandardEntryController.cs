using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using HRRS.Dto;
using HRRS.Helpers;
using HRRS.Models;

namespace HRRS.Controllers.MasterStandardEntries
{
    public class MasterStandardEntryController : ApiController
    {
        [HttpGet]
        [Route("api/submission/hospital/{healthFacilityId}")]
        public IHttpActionResult GetByHospitalId(int healthFacilityId)
        {
            try
            {
                var entries = DapperHelper.QueryStoredProcedure<MasterStandardEntry>("sp_GetMasterStandardEntriesByHospitalId", new { healthFacilityId }).ToList();
                return Ok(new ResultDto<List<MasterStandardEntry>>(true, entries));
            }
            catch (Exception ex)
            {
                var except = ex.Message;
                return ResponseMessage(
                    Request.CreateResponse(
                        HttpStatusCode.InternalServerError,
                            new ResultDto<List<MasterStandardEntry>>(false, null, except)
                    )
                );

            }
        }

        [HttpPost]
        [Route("api/submission")]
        public IHttpActionResult Create(SubmissionTypeDto dto) 
        {
            try
            {
                var claims = (ClaimsIdentity)User.Identity;
                var healthFacilityId = int.Parse(claims.FindFirst("HealthFacilityId")?.Value ?? "0");
                
                var entry = DapperHelper.QueryStoredProcedure<MasterStandardEntry>("sp_InsertMasterStandardEntry", new {healthFacilityId, submissionType = dto.Type}).First();

                return Ok(new ResultDto<MasterStandardEntry>(true, entry));

            }
            catch (Exception ex)
            {
                var except = ex.Message;
                return ResponseMessage(
                    Request.CreateResponse(
                        HttpStatusCode.InternalServerError,
                            new ResultDto<MasterStandardEntry>(false, null, except)
                    )
                );

            }

        }

        [HttpGet]
        [Route("api/submission")]
        public IHttpActionResult GetUserSubmissions()
        {
            try
            {
                var claims = (ClaimsIdentity)User.Identity;
                var healthFacilityId = int.Parse(claims.FindFirst("HealthFacilityId")?.Value ?? "0");

                var entries = DapperHelper.QueryStoredProcedure<MasterStandardEntry>("sp_GetMasterStandardEntriesOfHospital", new { healthFacilityId }).ToList();
                return Ok(new ResultDto<List<MasterStandardEntry>>(true, entries));
            }
            catch (Exception ex)
            {
                var except = ex.Message;
                return ResponseMessage(
                    Request.CreateResponse(
                        HttpStatusCode.InternalServerError,
                            new ResultDto<List<MasterStandardEntry>>(false, null, except)
                    )
                );

            }
        }


        [HttpPost]
        [Route("api/v2/standard/status/approve/{entryId}")]
        public IHttpActionResult ApproveStandardsWithRemark(Guid entryId, StandardRemarkDto dto)
        {
            try
            {
                DapperHelper.ExecuteStoredProcedure("sp_ApproveStandardsWithRemark", new { entryId, dto.remarks});
                return Ok(new ResultDto<MasterStandardEntry>(true, null));
            }
            catch (Exception ex)
            {
                var except = ex.Message;
                return ResponseMessage(
                    Request.CreateResponse(
                        HttpStatusCode.InternalServerError,
                            new ResultDto<MasterStandardEntry>(false, null, except)
                    )
                );

            }
        }

        [HttpPost]
        [Route("api/v2/standard/status/reject/{entryId}")]
        public IHttpActionResult RejectStandardsWithRemark(Guid entryId, StandardRemarkDto dto)
        {
            try
            {
                DapperHelper.ExecuteStoredProcedure("sp_RejectStandardsWithRemark", new { entryId, dto.remarks });
                return Ok(new ResultDto<MasterStandardEntry>(true, null));
            }
            catch (Exception ex)
            {
                var except = ex.Message;
                return ResponseMessage(
                    Request.CreateResponse(
                        HttpStatusCode.InternalServerError,
                            new ResultDto<MasterStandardEntry>(false, null, except)
                    )
                );

            }
        }

        [HttpPost]
        [Route("api/v2/standard/status/pending/{entryId}")]
        public IHttpActionResult PendingStandardsWithRemark(Guid entryId, StandardRemarkDto dto)
        {
            try
            {
                var claims = (ClaimsIdentity)User.Identity;
                var facilityId = int.Parse(claims.FindFirst("HealthFacilityId")?.Value ?? "0");

                var msg = DapperHelper.QueryStoredProcedure<string>("sp_PendingHospitalStandardsEntry", new { entryId, facilityId }).First();
                if (!string.IsNullOrEmpty(msg))
                    return Ok(new ResultDto<string>(false, null, msg));

                return Ok();
            }
            catch (Exception ex)
            {
                var except = ex.Message;
                return ResponseMessage(
                    Request.CreateResponse(
                        HttpStatusCode.InternalServerError,
                            new ResultDto<MasterStandardEntry>(false, null, except)
                    )
                );

            }
        }

        [HttpGet]
        [Route("api/submission/{submissionCode}")]
        public IHttpActionResult GetById(Guid submissionCode)
        {
            try
            {
                var entry = DapperHelper.QueryStoredProcedure<MasterStandardEntry>("sp_GetMasterStandardEntryById", new { submissionCode }).FirstOrDefault();
                return Ok(new ResultDto<MasterStandardEntry>(true, entry));
            }
            catch (Exception ex)
            {
                var except = ex.Message;
                return ResponseMessage(
                    Request.CreateResponse(
                        HttpStatusCode.InternalServerError,
                            new ResultDto<MasterStandardEntry>(false, null, except)
                    )
                );
            }
        }

        [HttpGet]
        [Route("api/submission/{submissionCode}/status")]
        public IHttpActionResult GetSubmissionStatus(Guid submissionCode)
        {
            try
            {
                var entry = DapperHelper.QueryStoredProcedure<MasterStandardEntry>("sp_GetMasterStandardEntryById", new { submissionCode }).FirstOrDefault();
                return Ok(new ResultDto<MasterStandardEntry>(true, entry));
            }
            catch (Exception ex)
            {
                var except = ex.Message;
                return ResponseMessage(
                    Request.CreateResponse(
                        HttpStatusCode.InternalServerError,
                            new ResultDto<MasterStandardEntry>(false, null, except)
                    )
                );
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using HRRS.Controllers.Auth;
using HRRS.Dto.HospitalStandard;
using HRRS.Helpers;
using HRRS.Models;

namespace HRRS.Controllers.HospitalStandards
{
    [Authorize]
    public class HospitalStandardController : ApiController
    {
        [HttpGet]
        [Route("api/standard/{submissionCode}")]
        public IHttpActionResult Get(Guid submissionCode, [FromUri] int? anusuchiId, [FromUri] int? parichhedId, [FromUri] int? subParichhedId, ClaimsPrincipal user)
        {
            try
            {
                var claims = (ClaimsIdentity)User.Identity;
                var healthFacilityId = int.Parse(claims.FindFirst("HealthFacilityId")?.Value ?? "0");

                var list = DapperHelper.QueryStoredProcedure<HospitalStandardDto>("sp_GetHospitalStandardsByFilters", new { healthFacilityId, submissionCode, anusuchiId, parichhedId, subParichhedId }).ToList();

                
                var res = list
                    .GroupBy(m => m.subSubParixed)
                    .Select(m => new GroupedSubSubParichhedAndMapdanda
                    {
                        anusuchiId = m.First().anusuchiId,
                        parichhedId = m.First().parichhedId,
                        subParichhedId = m.First().subParichhedId,
                        formType = m.First().formType,
                        subSubParixed = m.Key != null ? m.Key : null,
                        list = m
                            .GroupBy(n => n.group)
                            .Select(o => new GroupedMapdandaByGroupName
                            {
                                groupName = o.Key,
                                groupedMapdanda = o.Select(p => new GroupedUserMapdanda
                                {
                                    id = p.mapdandaId,
                                    entryId = p.id,
                                    name = p.mapdandaName,
                                    serialNumber = p.serialNumber,
                                    isAvailable = p.isAvailable,
                                    filePath = p.filePath,
                                    status = p.status,
                                    isActive = p.isActive,
                                    group = p.group,
                                    value = p.value,
                                }).ToList()

                            }).ToList()
                    }).ToList();

                return Ok(new ResultDto<List<GroupedSubSubParichhedAndMapdanda>>(true, res));

            }
            catch (Exception ex)
            {
                var except = ex.Message;
                return ResponseMessage(
                    Request.CreateResponse(
                        HttpStatusCode.InternalServerError,
                            new ResultDto<List<HospitalStandard>>(false, null, except)
                    )
                );
            }
        }

        [HttpPost]
        [Route("api/v2/hospitalstandard")]
        public IHttpActionResult Create(HospitalStandardEntryDto dto)
        {
            try
            {
                DapperHelper.ExecuteStoredProcedure("sp_CreateOrUpdateHospitalStandardEntry", new { dto.submissionCode, hospitalStandardDto = dto.mapdandas });
                return Ok(new ResultDto<List<HospitalStandardEntryDto>>(true, null));
            }
            catch (Exception ex)
            {
                var except = ex.Message;
                return ResponseMessage(
                    Request.CreateResponse(
                        HttpStatusCode.InternalServerError,
                            new ResultDto<List<HospitalStandardEntryDto>>(false, null, except)
                    )
                );
            }
        }

        [HttpGet]
        [Route("api/v2/master/{submissionCode}")]
        public IHttpActionResult GetById(Guid submissionCode)
        {
            try
            {
                var entires = DapperHelper.QueryStoredProcedure<HospitalEntryDto>("sp_GetStandardEntriesForSubmission", new {submissionCode}).ToList();
                return Ok(new ResultDto<List<HospitalEntryDto>>(true, entires));
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
        [Route("api/v2/hospitalentry/{entryId}")]
        public IHttpActionResult GetById(int entryId)
        {
            try
            {
                var entry = DapperHelper.QueryStoredProcedure<HospitalEntryDto>("sp_SelectFromTable", new { tableName = "HospitalStandardEntrys", id = entryId }).FirstOrDefault();
                return Ok(new ResultDto<HospitalEntryDto>(true, entry));
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
        [Route("api/v2/standard/entry/{entryId}")]
        public IHttpActionResult AdminGetHospitalStandardForEntry(int entryId)
        {
            try
            {
                var entries = DapperHelper.QueryStoredProcedure<HospitalStandardDto>("sp_AdminGetHospitalStandardForEntry", new { entryId }).ToList();
                var res = entries.GroupBy(x => x.subSubParichhedId)
                    .Select(m => new HospitalStandardModel
                    {
                        anusuchiId = m.First().anusuchiId,
                        parichhedId = m.First().parichhedId,
                        subParichhedId = m.First().subParichhedId,
                        formType = m.First().formType,
                        list = m
                        .GroupBy(n => n.group)
                        .Select(group => new StandardGroupModel
                        {
                            groupName = group.Key,
                            groupedMapdanda = group.Select(item => new MapdandaModel
                            {
                                entryId = item.id,
                                id = item.mapdandaId,
                                name = item.mapdandaName,
                                serialNumber = item.serialNumber,
                                parimaad = item.parimaad,
                                group = item.group,
                                filePath = item.filePath,
                                isAvailable = item.isAvailable,
                            }).ToList()
                        }).ToList()
                    }).ToList();

                return Ok(new ResultDto<List<HospitalStandardModel>>(true, res));
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

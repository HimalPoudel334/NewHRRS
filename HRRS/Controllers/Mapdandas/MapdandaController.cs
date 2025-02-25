using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HRRS.Dto;
using HRRS.Helpers;
using HRRS.Models;
namespace HRRS.Controllers.Mapdandas
{
    [Authorize]
    public class MapdandaController : ApiController
    {
        [HttpPost]
        [Route("api/mapdanda")]
        public IHttpActionResult Create(Models.Mapdanda model)
        {
            try
            {

                DapperHelper.ExecuteStoredProcedure("sp_InsertMapdanda", model);

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
        [Route("api/mapdanda/{mapdandaId}/update")]
        public IHttpActionResult Update(int mapdandaId, Mapdanda model)
        {
            try
            {
                model.id = mapdandaId;
                DapperHelper.ExecuteStoredProcedure("sp_UpdateMapdanda", model);

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
        [Route("api/Mapdanda/{id}")]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var list = DapperHelper.QueryStoredProcedure<Models.Mapdanda>("sp_SelectFromTable", new { TableName = "Mapdandas", id }).FirstOrDefault();
                return Ok(new ResultDto<Models.Mapdanda>(true, list));
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
        [Route("api/mapdanda")]
        public IHttpActionResult GetAll([FromUri] int? anusuchiId, [FromUri] int? parichhedId, [FromUri] int? subParichhedId)
        {
            try
            {
                var list = DapperHelper.QueryStoredProcedure<MapdandaDto>("sp_GetFilteredMapdandas", new { anusuchiId, parichhedId, subParichhedId }).ToList();

                var res = list
                    .GroupBy(a => a.subSubParichhed)
                    .Select(b => new GroupedSubSubParichhedAndMapdanda
                    {
                        formType = b.FirstOrDefault()?.formType,
                        hasBedCount = b.FirstOrDefault()?.isAvailableDivided,
                        subSubParixed = b.Key,
                        list = b
                        .GroupBy(m => m.group)
                        .Select(c => new GroupedMapdandaByGroupName
                        {
                            formType = c.FirstOrDefault()?.formType,
                            groupName = c.Key,
                            groupedMapdanda = c.Select(m => new GroupedAdmimMapdanda
                            {
                                id = m.id,
                                name = m.name,
                                serialNumber = m.serialNumber,
                                is100Active = m.is100Active,
                                is200Active = m.is200Active,
                                is50Active = m.is50Active,
                                is25Active = m.is25Active,
                                status = m.status,
                                parimaad = m.parimaad,
                                group = m.group,
                                value25 = m.value25,
                                value50 = m.value50,
                                value100 = m.value100,
                                value200 = m.value200,
                                col5 = m.col5,
                                col6 = m.col6,
                                col7 = m.col7,
                                col8 = m.col8,
                                col9 = m.col9,
                                isCol5Active = m.isCol5Active,
                                isCol6Active = m.isCol6Active,
                                isCol7Active = m.isCol7Active,
                                isCol8Active = m.isCol8Active,
                                isCol9Active = m.isCol9Active,
                                isAvailableDivided = m.isAvailableDivided,
                            }).ToList()

                        }).ToList()
                    })
                    .ToList();


                return Ok(new ResultDto<List<GroupedSubSubParichhedAndMapdanda>>(true, res));
            }
            catch (Exception ex)
            {
                var except = ex.Message;
                return ResponseMessage(
                    Request.CreateResponse(
                        HttpStatusCode.InternalServerError,
                            new ResultDto<List<GroupedSubSubParichhedAndMapdanda>>(false, null, except)
                    )
                );
            }

        }

        [HttpGet]
        [Route("api/mapdanda/parichhed")]
        public IHttpActionResult GetMapdandasOfParichhed(int parichhedId)
        {
            try
            {
                var list = DapperHelper.QueryStoredProcedure<Models.Mapdanda>("sp_GetMapdandasOfParichhed", new { id=parichhedId }).ToList();
                return Ok(new ResultDto<List<Models.Mapdanda>>(true, list));
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
        [Route("api/mapdanda/subparichhed/{subparichhedId}")]
        public IHttpActionResult GetMapdandasOfSubParichhed(int subParichhedId)
        {
            try
            {
                var list = DapperHelper.QueryStoredProcedure<MapdandaDto>("sp_GetMapdandasBySubParichhedId", new { subParichhedId = subParichhedId }).ToList();

                var res = list
                    .GroupBy(a => a.subSubParichhed)
                    .Select(b => new GroupedSubSubParichhedAndMapdanda
                    {
                        formType = b.FirstOrDefault()?.formType,
                        hasBedCount = b.FirstOrDefault()?.isAvailableDivided,
                        subSubParixed = b.Key,
                        list = b
                        .GroupBy(m => m.group)
                        .Select(c => new GroupedMapdandaByGroupName
                        {
                            groupName = c.Key,
                            groupedMapdanda = c.Select(m => new GroupedAdmimMapdanda
                            {
                                id = m.id,
                                name = m.name,
                                serialNumber = m.serialNumber,
                                is100Active = m.is100Active,
                                is200Active = m.is200Active,
                                is50Active = m.is50Active,
                                is25Active = m.is25Active,
                                status = m.status,
                                parimaad = m.parimaad,
                                group = m.group,
                                isAvailableDivided = m.isAvailableDivided,
                            }).ToList()

                        }).ToList()
                    })
                    .ToList();


                return Ok(new ResultDto<List<GroupedSubSubParichhedAndMapdanda>>(true, res));
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

        private class MapdandaDto
        {
            public int id { get; set; }
            public string serialNumber { get; set; }
            public string name { get; set; }
            public string parimaad { get; set; } = null;
            public string group { get; set; } = null;
            public bool isAvailableDivided { get; set; }
            public bool is25Active { get; set; }
            public bool is50Active { get; set; }
            public bool is100Active { get; set; }
            public bool is200Active { get; set; }
            public string value25 { get; set; }
            public string value50 { get; set; }
            public string value100 { get; set; }
            public string value200 { get; set; }
            public string col5 { get; set; }
            public string col6 { get; set; }
            public string col7 { get; set; }
            public string col8 { get; set; }
            public string col9 { get; set; }
            public bool isCol5Active { get; set; }
            public bool isCol6Active { get; set; }
            public bool isCol7Active { get; set; }
            public bool isCol8Active { get; set; }
            public bool isCol9Active { get; set; }
            public bool status { get; set; } = true;
            public int anusuchiId { get; set; }

            public int? parichhedId { get; set; }

            public int? subParichhedId { get; set; }

            public int? subSubParichhedId { get; set; }
            public string subSubParichhed { get; set; }
            public int? formType { get; set; }
        }
    }
}

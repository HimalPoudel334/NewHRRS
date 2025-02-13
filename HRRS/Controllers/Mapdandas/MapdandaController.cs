using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HRRS.Helpers;
using HRRS.Models;
namespace HRRS.Controllers.Mapdandas
{
    public class MapdandaController : ApiController
    {
        [HttpPost]
        [Route("api/Mapdanda")]
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

        [HttpGet]
        [Route("api/Mapdanda")]

        public IHttpActionResult Index()
        {
            try
            {
                var list = DapperHelper.QueryStoredProcedure<Models.Mapdanda>("sp_SelectFromTable", new { tableName = "Mapdandas" }).ToList();
                return Ok(new ResultDto<List<Models.Mapdanda>>(true, list, null));
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
                var list = DapperHelper.QueryStoredProcedure<Models.Mapdanda>("sp_SelectFromTable", new { tableName = "Mapdandas", id }).FirstOrDefault();
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
        [Route("api/Mapdanda")]
        public IHttpActionResult GetMapdandaOfAnusuchi(int anusuchiId)
        {
            try
            {
                var list = DapperHelper.QueryStoredProcedure<Models.Mapdanda>("sp_SelectFromTable", new { tableName = "Mapdandas", id }).FirstOrDefault();
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
    }
}

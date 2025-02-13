using System;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using HRRS.Helpers;
using System.Linq;

namespace HRRS.Controllers.Anusuchi
{
    public class Anusuchi : ApiController
    {

        [HttpPost]
        [Route("api/Anusuchi")]
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

        [HttpGet]
        [Route("api/Anusuchi")]

        public IHttpActionResult Index()
        {
            try
            {
                var list = DapperHelper.QueryStoredProcedure<Anusuchi>("sp_SelectFromTable", new { tableName = "Anusuchis" }).ToList();
                return Ok(list);
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
        [Route("api/Anusuchi/{id}")]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var list = DapperHelper.QueryStoredProcedure<Anusuchi>("sp_SelectFromTable", new { tableName = "Anusuchis", id }).ToList();
                return Ok(list);
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
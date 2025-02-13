using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HRRS.Helpers;

namespace HRRS.Controllers.SubParichheds
{
    public class SubParichhedController : ApiController
    {
        public IHttpActionResult Index()
        {
            try
            {
                var list = DapperHelper.QueryStoredProcedure<Models.HealthFacility>("sp_SelectFromTable", new { tableName = "HealthFacilities" }).ToList();
                return Ok(new ResultDto<List<Models.HealthFacility>>(true, list, null));
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

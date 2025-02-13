
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;


using HRRS.Helpers;
using HRRS.Models;

public class DapperController : ApiController
{     

    [Route("GetAll")]
    [HttpGet]
    public IHttpActionResult GetAll()
    {
        string query = "SELECT * FROM HospitalStandards";

        var result = DapperHelper.QuerySqlStatment<HospitalStandard>(query).ToList();

        return Ok(new ResultDto<List<HospitalStandard>>(true, result));
    }


}


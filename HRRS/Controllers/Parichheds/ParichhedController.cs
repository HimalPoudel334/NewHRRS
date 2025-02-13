﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HRRS.Helpers;

namespace HRRS.Controllers.Parichheds
{
    public class ParichhedController : ApiController
    {
        [HttpPost]
        [Route("api/Parichhed")]
        public IHttpActionResult Create(Models.Parichhed.Parichhed model)
        {
            try
            {

                DapperHelper.ExecuteStoredProcedure("sp_InsertParichhed", model);

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
        [Route("api/Parichhed")]

        public IHttpActionResult Index()
        {
            try
            {
                var list = DapperHelper.QueryStoredProcedure<Models.Parichhed.Parichhed>("sp_SelectFromTable", new { tableName = "Parichheds" }).ToList();
                return Ok(new ResultDto<List<Models.Parichhed.Parichhed>>(true, list, null));
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
        [Route("api/Parichhed/{id}")]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var list = DapperHelper.QueryStoredProcedure<Models.Parichhed.Parichhed>("sp_SelectFromTable", new { tableName = "Parichheds", id }).FirstOrDefault();
                return Ok(new ResultDto<Models.Parichhed.Parichhed>(true, list));
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

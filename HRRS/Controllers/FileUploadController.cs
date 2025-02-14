using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using HRRS.Helpers;
using HRRS.Models;

namespace HRRS.Controllers
{
    public class FileUploadController : ApiController
    {
        [HttpPost]
        [Route("api/mapdandaupload/{standardId}")]
        public IHttpActionResult UploadFile(int standardId)
        {
            var httpRequest = HttpContext.Current.Request;

            if (httpRequest.Files.Count == 0)
            {
                return BadRequest("No file uploaded.");
            }

            HttpPostedFile file = httpRequest.Files[0];

            if (file != null && file.ContentLength > 0)
            {
                string uploadPath = HttpContext.Current.Server.MapPath("~/Uploads");

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                string fileName = Path.GetFileName(file.FileName);
                string fullPath = Path.Combine(uploadPath, fileName);
                file.SaveAs(fullPath);


                //catch (Exception ex)
                //{
                //    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error uploading file: " + ex.Message);
                //}
                return Ok(fullPath);
            }
            return InternalServerError();

            
        }

    }
}

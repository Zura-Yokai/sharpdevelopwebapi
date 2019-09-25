﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using SharpDevelopWebApi.Helpers.JWT;
using SharpDevelopWebApi.Models;

namespace SharpDevelopWebApi.Controllers
{
	/// <summary>
	/// Description of ValuesController.
	/// </summary>
	public class SampleController : ApiController
	{
        [ApiAuthorize]
		[HttpGet]
		[Route("api/sample")]
        public IHttpActionResult Get()
		{
            var products = new List<Product>()
	        {                 
	            new Product { Id = 1, Name = "Tomato Soup",Price = 1 }, 
	            new Product { Id = 2, Name = "Yo-yo", Price = 3.75M }, 
	            new Product { Id = 3, Name = "Hammer", Price = 16.99M } 
	        };
			
			return Ok(products);
		}

        [HttpPost]
        [Route("api/sample")]
        public IHttpActionResult Post(Product product)
        {
            return Ok(product);
        }

        [HttpPost]
        [FileUpload.SwaggerForm()]
        [Route("api/sample/upload")]
        public IHttpActionResult UploadFile()
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath("~/UploadedFiles/" + postedFile.FileName);
                    postedFile.SaveAs(filePath);
                    docfiles.Add(System.IO.Path.GetFileName(filePath));
                }
                return Ok(new { docfiles });
            }

            return BadRequest();
        }
        
        [HttpPost]
        [FileUpload.SwaggerForm()]
        [Route("api/sample/uploadphoto")]
        public IHttpActionResult UploadImage()
        {
        	var postedFile = HttpContext.Current.Request.Files[0];
            var filePath = postedFile.SaveAsJpegFile();
            return Ok(filePath);
        }    


        [HttpPost]
        [Route("api/sample/sendmail")]
        public IHttpActionResult SendEmail(string EmailTo, string Subject, string Message)
        {
            var success = EmailService.SendEmail(EmailTo, Subject, Message);
            if (success)
                return Ok("Successfully sent.");
            else
                return BadRequest("Sending failed.");
        }
    }



}
﻿using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using SharpDevelopWebApi.Models;

namespace SharpDevelopWebApi.Controllers
{
	/// <summary>
	/// Description of ValuesController.
	/// </summary>
	public class ValuesController : ApiController
	{
		[HttpGet]
		[Route("api/values")]
        public IHttpActionResult Get()
		{
			var products = new List<Product>()
	        { 
	            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 }, 
	            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M }, 
	            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M } 
	        };
			
			return Ok(products);
		}

        [HttpPost]
        [ImportFileParamType.SwaggerForm("ImportImage", "Upload image file")]
        [Route("api/values")]
        public IHttpActionResult Post()
        {
            return Ok();
        }
	}
}
﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace LibNetCore.Controllers
{
    /// <summary>
    /// ASP net core web API controller.
    /// </summary>
    [Route("api/[controller]")]
    public class LibNetCoreController : Controller
    {
        /// <summary>
        /// GET api/values
        /// </summary>
        /// <returns>The get.</returns>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// GET api/values/5
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="id">Identifier.</param>
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// POST api/values
        /// </summary>
        /// <returns>The post.</returns>
        /// <param name="value">Value.</param>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        /// <summary>
        /// PUT api/values/5
        /// </summary>
        /// <returns>The put.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="value">Value.</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// DELETE api/values/5
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="id">Identifier.</param>
        // 
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}


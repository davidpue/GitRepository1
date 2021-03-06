﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using EF7Demo;

namespace AspDemo2.Controllers
{
    [Route("api/[controller]")]
    public class BlogController : Controller
    {
        private static int _i = 0;

        // GET: api/values
        [HttpGet]
        public IEnumerable<Blog> Get()
        {
            var ctx = new BloggingContext();
            int id = (++_i);
            var blog = new Blog
            {
                Url = "Testurl" + id,
                BlogId = id
            };
            ctx.Add(blog);

            return ctx.Blogs.OrderByDescending(b => b.BlogId).Take(3);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using FourthExample_Customization.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourthExample_Customization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        [HttpGet("GetBlogs")]
        public IActionResult Get()
        {
            var blogs = new List<Blog>();
            var blogPosts = new List<BlogPost>();

            blogPosts.Add(new BlogPost
            {
                Title = "Content Negotiation in Web API",
                MetaDescription = "It is a process of selecting the best possible way of sharing the data in the presise format what is required for UR Apps",
                Published = true
            });

            blogs.Add(new Blog
            {
                BlogPosts = blogPosts,
                Description = "C# .NET CORE Web API Training",
                Name = "Phani's Training"
            });
            return Ok(blogs);
        }
    }
}

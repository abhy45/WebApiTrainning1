using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourthExample_Customization.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        [HttpGet]
        public ActionResult ErrorLocalDev([FromServices] IWebHostEnvironment env)
        {
            if(env.EnvironmentName == "Development")
            {
                throw new InvalidOperationException("This should not be invoked in Dev Environments");
            }
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            return Problem(
                 detail: "Something has gone wrong",
                 title: "Testing this error"
            );
        }
    }
}

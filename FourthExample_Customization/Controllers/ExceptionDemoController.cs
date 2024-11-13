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
    public class ExceptionDemoController : ControllerBase
    {
        [HttpGet("Throw")]
        public ActionResult Throw()
        {
            throw new Exception("testing Exception");
        }
    }
}

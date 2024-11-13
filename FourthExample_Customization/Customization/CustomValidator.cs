
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;

namespace FourthExample_Customization.Customization
{
    public class MyCustomValidatorFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext context)
        {
            
            if (!context.ModelState.IsValid)
            {
                context.Response = context.Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, new Exception("Data validation Failed"));
            }
        }
    }
}

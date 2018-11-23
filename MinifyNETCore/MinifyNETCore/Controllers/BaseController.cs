using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace MinifyNETCore.Controllers
{
    public abstract class BaseController : Controller
    {
        public override ViewResult View(string viewName, object model)
        {
            if (!IsDevelopment())
            {
                string action = ControllerContext.RouteData.Values["action"].ToString();

                if (string.IsNullOrEmpty(viewName))
                {
                    viewName = $"{action}.min";
                }                    
                else if (viewName == action)
                {
                    viewName += ".min";
                }
            }

            return base.View(viewName, model);
        }

        private bool IsDevelopment()
        {            
            return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == EnvironmentName.Development;
        }
    }
}
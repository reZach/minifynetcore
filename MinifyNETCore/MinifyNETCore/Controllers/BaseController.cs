using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace MinifyNETCore.Controllers
{
    /// <summary>
    ///     Is the base class that allows our controllers to load
    ///     minified files based on the ASPNETCORE_ENVIRONMENT
    /// </summary>
    public abstract class BaseController : Controller
    {
        public override ViewResult View(string viewName, object model)
        {
            if (!IsDevelopment())
            {
                string action = ControllerContext.RouteData.Values["action"].ToString();

                // This logic handles if we pass in a 
                // view name or no name when rendering
                // views in our controllers
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MinifyNETCore.Controllers
{
    public abstract class BaseController : Controller
    {
        public override ViewResult View()
        {

        }

        public override ViewResult View(string viewName, object model)
        {
            return base.View(model);
        }

        public override ViewResult View(object model)
        {
            return base.View(model);
        }

        public override ViewResult View(string viewName)
        {
            return base.View(viewName);
        }
    }
}
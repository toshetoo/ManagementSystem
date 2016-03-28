using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManagementSystem.Filters;

namespace ManagementSystem.Controllers
{
    [AuthenticationFilter]
    public class BaseController : Controller
    {
       
    }
}
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.IU.Controllers
{
    public class TagsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

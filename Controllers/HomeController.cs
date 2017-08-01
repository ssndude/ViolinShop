using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using ViolinShop.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ViolinShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/

        public IActionResult Index()
        {
            return View();
        }



        public IActionResult About()
        {    
            return View();
        }

        
   }      //public IActionResult Contact()
        //{
        //    return View();
        //}
        //public IActionResult Music()
        //{
        //    return View();
        //}

        //public IActionResult Services()
        //{
        //    return View();
        //}
}





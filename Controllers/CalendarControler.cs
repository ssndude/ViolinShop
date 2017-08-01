using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Data.SqlClient;
using ViolinShop.Models;


namespace ViolinShop.Controllers
{

    public class CalendarController : Controller
    {
        public StringStoreContext dbc;
        public CalendarController(StringStoreContext db)
        { dbc = db; }
    
        public IActionResult Calendar()
        {
            
            return View();
        }
        

        
    }
}
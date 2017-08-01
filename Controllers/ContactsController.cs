using Microsoft.AspNetCore.Mvc;

using ViolinShop.Models;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ViolinShop.Controllers
{
    public class ContactsController : Controller
    {
        // GET: /<controller>/                              
        //[HttpGet]
        public IActionResult Contacts()
        {

            return View();

        }

        //[HttpPost]
        //public IActionResult Contact(Customers customer)
        //{

        //    return View();

        //}

    }
}

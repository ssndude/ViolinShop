using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ViolinShop.Controllers
{
    public class AboutController : Controller
    {
        // GET: /<controller>/


        public IActionResult About()
        {

            return View();
        }
        
    }
}

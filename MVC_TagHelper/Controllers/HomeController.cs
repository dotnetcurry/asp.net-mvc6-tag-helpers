using Microsoft.AspNet.Mvc;
using MVC_TagHelper.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC_TagHelper.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var products = new ProductStore(); 
            return View(products);
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace SyntacticDocs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index(string keyword)
        {
            return View(keyword);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

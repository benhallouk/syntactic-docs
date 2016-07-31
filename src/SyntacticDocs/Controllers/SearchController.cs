using Microsoft.AspNetCore.Mvc;

namespace SyntacticDocs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index(string keyword)
        {
            keyword = string.IsNullOrEmpty(keyword) ? "*:*" : keyword;
            return View("Index",keyword);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

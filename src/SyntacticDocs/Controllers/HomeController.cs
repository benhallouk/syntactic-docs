using Microsoft.AspNetCore.Mvc;
using SyntacticDocs.Services;

namespace SyntacticDocs.Controllers
{
    public class HomeController : Controller
    {
        private DocumentService _documentService;
        public HomeController(DocumentService documentService)
        {
          _documentService = documentService;
        }
        public IActionResult Index()
        {
            var mainDocument = _documentService.GetDocument("main");
            return View(mainDocument);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

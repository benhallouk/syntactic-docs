using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SyntacticDocs.Services;
using SyntacticDocs.ViewModels;

namespace SyntacticDocs.Controllers
{
    public class HomeController : Controller
    {
        private DocumentService _documentService;
        public HomeController(DocumentService documentService)
        {
          _documentService = documentService;
        }
        public IActionResult Index(string path)
        {
            string[] sections=null;
            string alias = "main";
            if (!string.IsNullOrEmpty(path))
            {
                sections = path.Split(new char[] { '/' }, System.StringSplitOptions.RemoveEmptyEntries);
                alias = sections.LastOrDefault();
            }

            var mainDocument = _documentService.GetDocument("main");
            var pageDocument = _documentService.GetDocument(alias);
            var pageViewModel = new PageViewModel{
                Navigation = mainDocument.Documents,
                Doc = pageDocument
            };
            return View(pageViewModel);
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

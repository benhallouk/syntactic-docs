using Microsoft.AspNetCore.Mvc;
using SyntacticDocs.Services;

namespace SyntacticDocs.Controllers
{
    public class SearchController : Controller
    {
        private readonly SearchService _searchService;        

        public SearchController(SearchService searchService)
        {
	        _searchService =  searchService;
        }
        public IActionResult Index(string keyword)
        {
            ViewData.Add("SolrBaseUrl", _searchService.SolrBaseUrl);
            keyword = string.IsNullOrEmpty(keyword) ? "*:*" : keyword;
            return View("Index",keyword);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

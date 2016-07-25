using System.Collections.Generic;
using SyntacticDocs.Models;

namespace SyntacticDocs.ViewModels
{
    public class PageViewModel
    {        
        public Document Doc{ get; set; }
        public ICollection<Document> Navigation { get; set; }
    }
}
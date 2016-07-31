using System;

namespace SyntacticDocs.ViewModels
{
    public class AddDocumentViewModel
    {        
        public Guid ParentId{ get; set; }
        public string Alias{ get; set; }
        public string Title{ get; set; }        
    }
}
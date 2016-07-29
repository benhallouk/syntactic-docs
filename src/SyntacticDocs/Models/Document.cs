using System.Collections.Generic;

namespace SyntacticDocs.Models
{
    public class Document
    {
        public long Id { get; set; }
        public string Alias { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public ICollection<Tag> Tags { get; set; }
        public ICollection<Document> Documents { get; set; }
    }
}
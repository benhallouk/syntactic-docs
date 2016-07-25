using System.Collections.Generic;
using System.Linq;
using SyntacticDocs.Models;
using SyntacticDocs.Data;

namespace SyntacticDocs.Services
{
    public class DocumentService
    {
        private ApplicationDbContext _db;

        public DocumentService(ApplicationDbContext db)
        {
            _db = db;
        }

        public Document GetDocument(string alias)
        {
            return _db.Docs.FirstOrDefault(doc=>doc.Alias==alias);
        }

        public IEnumerable<Document> GetRelatedDocuments(Document document)
        {
            return _db.Docs.Where(doc=>doc.Tags.Any(tag=>document.Tags.Contains(tag)));
        }
    }
}
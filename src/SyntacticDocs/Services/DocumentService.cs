using System.Collections.Generic;
using System.Linq;
using SyntacticDocs.Models;
using SyntacticDocs.Data;
using Microsoft.EntityFrameworkCore;

namespace SyntacticDocs.Services
{
    public class DocumentService
    {
        private readonly ApplicationDbContext _db;

        public DocumentService(ApplicationDbContext db)
        {
            _db = db;            
            _db.SeedData();            
        }

        public Document GetDocument(string alias)
        {
            return _db.Docs
                .Include(doc => doc.Documents)
                .ThenInclude(doc => doc.Documents)
                .FirstOrDefault(doc => doc.Alias==alias);                
        }

        public IEnumerable<Document> GetRelatedDocuments(Document document)
        {
            return _db.Docs.Where(doc=>doc.Tags.Any(tag=>document.Tags.Contains(tag)));
        }

        public Document Save(Document document)
        {
            var oldDocument = _db.Docs.FirstOrDefault(doc=>doc.Id==document.Id);
            oldDocument.Content = document.Content;
            _db.SaveChanges();
            return oldDocument;
        }
    }
}
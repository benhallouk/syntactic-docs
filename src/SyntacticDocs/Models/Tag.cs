using System;
using System.ComponentModel.DataAnnotations;

namespace SyntacticDocs.Models
{
    public class Tag
    {        
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }       
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_01.Models
{
    internal class Book
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string ISBN { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int NumberOfPages { get; set; }

        public int PublishedYear { get; set; }

        public bool IsInStock { get; set; }


        // Author Relationship
        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;


        // Category Relationship
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ContosoBooks.Models
{
    public class Book
    {
        //Setting scaffold column to false means that it won't be displayed.
        //Only works when you use @Html.DisplayForModel() helper
        [ScaffoldColumn(false)]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        public int Year { get; set; }
        [Range(1, 500)]
        public decimal Price { get; set; }
        public string Genre { get; set; }

        //Foreign key to the author table
        [ScaffoldColumn(false)]
        public int AuthorID { get; set; }

        //Navigation property - One author, many books
        public virtual Author Author { get; set; }
    }
}

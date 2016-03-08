using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ContosoBooks.Models
{
    public class Author
    {
        //Setting scaffold column to false means that it won't be displayed.
        //Only works when you use @Html.DisplayForModel() helper
        [ScaffoldColumn(false)]
        public int AuthorID { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name ="First Name")]
        public string FirstMidName { get; set; }
        public virtual ICollection<Book> Books { get; set; }

    }
}

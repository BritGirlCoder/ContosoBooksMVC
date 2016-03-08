using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Entity;

namespace ContosoBooks.Models
{
    public class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            //Set context to an instance of the ApplicationDbContext
            var context = serviceProvider.GetService<ApplicationDbContext>();
            //Call the Migrate method on the database
            context.Database.Migrate();
            //If there is no data in the Book table, then populate both the Book and Author tables with the following sample data
            if (!context.Book.Any())
            {

                //Adding three authors to the Author table
                //.Add begins tracking the entity (i.e. Author table) so that when savechanges is called it inserts that entity into the database
                //.Entity tracks the entity being tracked by this entry (i.e. austen, dickens).  In this case that means the Author table

                var austen = context.Author.Add(
                    new Author { LastName = "Austen", FirstMidName = "Jane" }).Entity;
                var dickens = context.Author.Add(
                    new Author { LastName = "Dickens", FirstMidName = "Charles" }).Entity;
                var cervantes = context.Author.Add(
                    new Author { LastName = "Cervantes", FirstMidName = "Miguel" }).Entity;

                context.Book.AddRange(
                    new Book()
                    {
                        Title = "Pride and Prejudice",
                        Year = 1813,
                        Author = austen,
                        Price = 9.99M,
                        Genre = "Comedy of manners"
                    },
                    new Book()
                    {
                        Title = "Northanger Abbey",
                        Year = 1817,
                        Author = austen,
                        Price = 12.95M,
                        Genre = "Gothic parody"
                    },
                    new Book()
                    {
                        Title = "David Copperfield",
                        Year = 1850,
                        Author = dickens,
                        Price = 15M,
                        Genre = "Bildungsroman"
                    },
                    new Book()
                    {
                        Title = "Don Quixote",
                        Year = 1617,
                        Author = cervantes,
                        Price = 8.95M,
                        Genre = "Picaresque"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

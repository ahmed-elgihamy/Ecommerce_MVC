using Bookoria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using IdentityDbContext = Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext;
using Microsoft.AspNetCore.Identity;
namespace Bookoria.DataAcess.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :IdentityDbContext<IdentityUser>(options)
{
    public DbSet<Product> products { get; set; }
    public DbSet<Category> categories { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Business", DisplayOrder = 1 },
            new Category { Id = 2, Name = "Technology", DisplayOrder = 2 },
            new Category { Id = 3, Name = "Adventure", DisplayOrder = 3 },
            new Category { Id = 4, Name = "Fictional", DisplayOrder = 4 }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Title = "Journey to Happiness",
                Description = "A book exploring the path to true happiness with inspiring stories and insights.",
                ISBN = "9781234567001",
                Author = "Nizar Shawky",
                ListPrice = 100,
                Price = 95,
                Price50 = 90,
                Price100 = 85,
                CategoryId = 1,
                ImageUrl=""
            },
            new Product
            {
                Id = 2,
                Title = "Secrets of Thinking",
                Description = "An insightful guide into cognitive patterns and how to reshape your thinking.",
                ISBN = "9781234567002",
                Author = "Maysaa Alrawi",
                ListPrice = 110,
                Price = 105,
                Price50 = 100,
                Price100 = 95,
                CategoryId = 2,
                ImageUrl = ""
            },
            new Product
            {
                Id = 3,
                Title = "Philosophy of the Mind",
                Description = "Dive deep into the questions of consciousness, perception, and mental processes.",
                ISBN = "9781234567003",
                Author = "Sami Al-Tamimi",
                ListPrice = 95,
                Price = 90,
                Price50 = 85,
                Price100 = 80,
                CategoryId = 3,
                ImageUrl = ""
            },
            new Product
            {
                Id = 4,
                Title = "The Art of Creativity",
                Description = "Discover the tools, habits, and mindset that fuel innovative thinking.",
                ISBN = "9781234567004",
                Author = "Huda Al-Otaibi",
                ListPrice = 105,
                Price = 100,
                Price50 = 95,
                Price100 = 90,
                CategoryId = 3,
                ImageUrl = ""
            },
            new Product
            {
                Id = 5,
                Title = "The Tale of Time",
                Description = "A fascinating look at how humans have understood and measured time across history.",
                ISBN = "9781234567005",
                Author = "Tarek Abdullah",
                ListPrice = 90,
                Price = 85,
                Price50 = 80,
                Price100 = 75,
                CategoryId = 4,
                ImageUrl = ""
            },
            new Product
            {
                Id = 6,
                Title = "The Road to Knowledge",
                Description = "Explore the pursuit of learning, curiosity, and the power of education.",
                ISBN = "9781234567006",
                Author = "Fatima Zahra",
                ListPrice = 100,
                Price = 95,
                Price50 = 90,
                Price100 = 85,
                CategoryId = 2,
                ImageUrl = ""
            },
            new Product
            {
                Id = 7,
                Title = "Adventures in Imagination",
                Description = "A thrilling journey through fantasy worlds and the power of storytelling.",
                ISBN = "9781234567007",
                Author = "Ali Al-Hakeem",
                ListPrice = 88,
                Price = 83,
                Price50 = 78,
                Price100 = 73,
                CategoryId = 3,
                ImageUrl = ""
            },
            new Product
            {
                Id = 8,
                Title = "Night and Solitude",
                Description = "A poetic exploration of isolation, silence, and the meaning found in darkness.",
                ISBN = "9781234567008",
                Author = "Karim Yassin",
                ListPrice = 92,
                Price = 87,
                Price50 = 82,
                Price100 = 77,
                CategoryId = 4,
                ImageUrl = ""
            }
        );
    }
}

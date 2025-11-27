using MvcLibrary.Models;

namespace MvcLibrary.Data
{
    public class DbInitializer
    {
        public static void Initialize(MvcLibraryContext context)
        {
            context.Database.EnsureCreated();

            if (context.Book.Any())
            {
                return; 
            }

            var books = new Book[]
            {
                new Book
                {
                    Title = "Cien años de soledad",
                    Author = "Gabriel García Márquez",
                    PublicationDate = DateTime.Parse("1967-05-30"),
                    Available = true,
                    Thumbnail = "/images/cien_anos.jpg"
                },
                new Book
                {
                    Title = "1984",
                    Author = "George Orwell",
                    PublicationDate = DateTime.Parse("1949-06-08"),
                    Available = true,
                    Thumbnail = "/images/1984.jpg"
                },
                new Book
                {
                    Title = "Don Quijote de la Mancha",
                    Author = "Miguel de Cervantes",
                    PublicationDate = DateTime.Parse("1605-01-16"),
                    Available = false,
                    Thumbnail = "/images/quijote.jpg"
                },
                new Book
                {
                    Title = "Orgullo y prejuicio",
                    Author = "Jane Austen",
                    PublicationDate = DateTime.Parse("1813-01-28"),
                    Available = true,
                    Thumbnail = "/images/orgullo.jpg"
                },
                new Book
                {
                    Title = "El principito",
                    Author = "Antoine de Saint-Exupéry",
                    PublicationDate = DateTime.Parse("1943-04-06"),
                    Available = true,
                    Thumbnail = "/images/principito.jpg"
                },
                new Book
                {
                    Title = "Crónica de una muerte anunciada",
                    Author = "Gabriel García Márquez",
                    PublicationDate = DateTime.Parse("1981-01-01"),
                    Available = true,
                    Thumbnail = "/images/cronica.jpg"
                },
                new Book
                {
                    Title = "Harry Potter y la piedra filosofal",
                    Author = "J.K. Rowling",
                    PublicationDate = DateTime.Parse("1997-06-26"),
                    Available = false,
                    Thumbnail = "/images/harry_potter.jpg"
                },
                new Book
                {
                    Title = "El señor de los anillos",
                    Author = "J.R.R. Tolkien",
                    PublicationDate = DateTime.Parse("1954-07-29"),
                    Available = true,
                    Thumbnail = "/images/senior_anillos.jpg"
                },
                new Book
                {
                    Title = "Crimen y castigo",
                    Author = "Fiódor Dostoyevski",
                    PublicationDate = DateTime.Parse("1866-01-01"),
                    Available = true,
                    Thumbnail = "/images/crimen.jpg"
                },
                new Book
                {
                    Title = "Rayuela",
                    Author = "Julio Cortázar",
                    PublicationDate = DateTime.Parse("1963-06-28"),
                    Available = false,
                    Thumbnail = "/images/rayuela.jpg"
                },
                new Book
                {
                    Title = "La sombra del viento",
                    Author = "Carlos Ruiz Zafón",
                    PublicationDate = DateTime.Parse("2001-01-01"),
                    Available = true,
                    Thumbnail = "/images/sombra_viento.jpg"
                },
                new Book
                {
                    Title = "Los juegos del hambre",
                    Author = "Suzanne Collins",
                    PublicationDate = DateTime.Parse("2008-09-14"),
                    Available = true,
                    Thumbnail = "/images/juegos_hambre.jpg"
                },
                new Book
                {
                    Title = "It",
                    Author = "Stephen King",
                    PublicationDate = DateTime.Parse("1986-09-15"),
                    Available = false,
                    Thumbnail = "/images/it.jpg"
                },
                new Book
                {
                    Title = "El código Da Vinci",
                    Author = "Dan Brown",
                    PublicationDate = DateTime.Parse("2003-03-18"),
                    Available = true,
                    Thumbnail = "/images/codigo_davinci.jpg"
                },
                new Book
                {
                    Title = "Cumbres borrascosas",
                    Author = "Emily Brontë",
                    PublicationDate = DateTime.Parse("1847-12-01"),
                    Available = true,
                    Thumbnail = "/images/cumbres.jpg"
                },
                new Book
                {
                    Title = "Fahrenheit 451",
                    Author = "Ray Bradbury",
                    PublicationDate = DateTime.Parse("1953-10-19"),
                    Available = false,
                    Thumbnail = "/images/fahrenheit.jpg"
                },
                new Book
                {
                    Title = "El alquimista",
                    Author = "Paulo Coelho",
                    PublicationDate = DateTime.Parse("1988-01-01"),
                    Available = true,
                    Thumbnail = "/images/alquimista.jpg"
                },
                new Book
                {
                    Title = "La casa de los espíritus",
                    Author = "Isabel Allende",
                    PublicationDate = DateTime.Parse("1982-01-01"),
                    Available = true,
                    Thumbnail = "/images/casa_espiritus.jpg"
                },
                new Book
                {
                    Title = "Drácula",
                    Author = "Bram Stoker",
                    PublicationDate = DateTime.Parse("1897-05-26"),
                    Available = false,
                    Thumbnail = "/images/dracula.jpg"
                },
                new Book
                {
                    Title = "El nombre del viento",
                    Author = "Patrick Rothfuss",
                    PublicationDate = DateTime.Parse("2007-03-27"),
                    Available = true,
                    Thumbnail = "/images/nombre_viento.jpg"
                }
            };

            foreach (Book b in books)
            {
                context.Book.Add(b);
            }
            context.SaveChanges();
        }
    }
}


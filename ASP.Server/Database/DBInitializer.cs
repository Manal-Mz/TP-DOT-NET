using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASP.Server.Database
{
    public class DbInitializer
    {
        public static void Initialize(LibraryDbContext bookDbContext)
        {

            if (bookDbContext.Books.Any())
                return;

            Genre Genres, Classic, Romance, Thriller;
            bookDbContext.Genre.AddRange(
                Genres = new Genre() {Name = "Genres"},
                Classic = new Genre() { Name = "Classic" },
                Romance = new Genre() { Name = "Romance" },
                Thriller = new Genre() { Name = "Thriller" }

            );
            bookDbContext.SaveChanges();

            // Une fois les moèles complété Vous pouvez faire directement
            // new Book() { Author = "xxx", Name = "yyy", Price = n.nnf, Content = "ccc", Genres = new() { Romance, Thriller } }
            bookDbContext.Books.AddRange(
               new Book() { Author = "Author1",Name = "Nostromo", Price  =1.10, Content = "blabla1", Genres = new() { Genres, Romance}  } ,
                 new Book() { Author = "Author2", Name = "Hitch", Price = 1.10, Content = "blabla2", Genres = new() { Genres, Romance } },
                 new Book() { Author = "Author3", Name = "Don Quichotte", Price = 1.10, Content = "blabla3", Genres = new() { Genres, Romance } },
                new Book() { Author = "Author4", Name = "Rose", Price = 1.10, Content = "blabla4", Genres = new() { Genres, Romance } }
            );
            // Vous pouvez initialiser la BDD ici

            bookDbContext.SaveChanges();
        }
    }
}
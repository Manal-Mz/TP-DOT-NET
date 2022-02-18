using System.Collections.ObjectModel;
using WPF.Reader.Model;

namespace WPF.Reader.Service
{
    public class LibraryService
    {
        // A remplacer avec vos propre données !!!!!!!!!!!!!!
        // Pensé qu'il ne faut mieux ne pas réaffecter la variable Books, mais juste lui ajouer et / ou enlever des éléments
        // Donc pas de LibraryService.Instance.Books = ...
        // mais plutot LibraryService.Instance.Books.Add(...)
        // ou LibraryService.Instance.Books.Clear()
        pulic LibraryService()
        {

            var Classic = new Genre() { Name = "Classic" };
            var Romance = new Genre() { Name = "Romance" };
            var Thriller = new Genre() { Name = "Thriller" };



            Genres = new ObservableCollection<Genre>(){
            Classic,
            Romance,
            Thriller
             };



            Books = new ObservableCollection<Book>() {
                    new Book() { Author = "Author1",Name = "Nostromo", Price  =1.10, Content = "blabla1", Genres = new() { Classic, Romance}  },
                    new Book() { Author = "Author2", Name = "Hitch", Price = 1.10, Content = "blabla2", Genres = new() { Romance } },
                    new Book() { Author = "Author3", Name = "Don Quichotte", Price = 1.10, Content = "blabla3", Genres = new() {  Romance } },
                    new Book() { Author = "Author4", Name = "Rose", Price = 1.10, Content = "blabla4", Genres = new() { Thriller, Classic } }
            };
        }


        public ObservableCollection<Book> Books { get; set; }
        public ObservableCollection<Genre> Genres { get; set; }

        public async void UpdateBookList()
        {
            var httpClient = new HttpClient() { BaseAddress = new Uri("https://127.0.0.1:5001") };
            var books = await new ASP.Server.Client(httpClient).ApiBookGetBooksAsync(null, null);
            Books.Clear();
            foreach (var book in books.Select(x => new Book() { Name = x.Name }))
            {
                Books.Add(book);
            }
        }
    }
}

      

using TaskCRUDCleanDI.DTO;
using TaskCRUDCleanDI.Models;

namespace TaskCRUDCleanDI.Abstraction
{
    public interface IBookRepository
    {
        IEnumerable<BookDto> GetAllBooks(); //IEnumerable<Book> GetAllBooks();
        int AddBook(string name, string author, int price);
        int DeleteBook(string name);
        void UpdateBook(string name, string newname, string author, int price);
    }
}

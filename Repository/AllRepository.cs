using TaskCRUDCleanDI.Abstraction;
using TaskCRUDCleanDI.DTO;
using TaskCRUDCleanDI.Models;

namespace TaskCRUDCleanDI.Repository
{
    public class AllRepository
    {
        IBookRepository bookRepository;
        public AllRepository(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public IEnumerable<BookDto> GetAllPosition()
        {
            return bookRepository.GetAllBooks();
        }
        public int AddNewPosition(string name, string author, int price)
        {

            return bookRepository.AddBook(name, author, price);
        }
        public int DeletePosition(string name)
        {
            return bookRepository.DeleteBook(name);
        }
        public void UpdatePosition(string name, string newname, string author, int price) 
        {
            bookRepository.UpdateBook(name, newname, author, price);
            return ;
        }
    }
}

using AutoMapper;
using TaskCRUDCleanDI.Abstraction;
using TaskCRUDCleanDI.Data;
using TaskCRUDCleanDI.DTO;
using TaskCRUDCleanDI.Models;

namespace TaskCRUDCleanDI.Repository
{
    public class BookRepository : IBookRepository
    {
        StorageContext storageContext;
        private readonly StorageContext _storageContext;
        private readonly IMapper _mapper;

        public BookRepository(StorageContext storageContext, IMapper mapper)
        {
            this._storageContext = storageContext;
            this._mapper = mapper;
        }
        public BookRepository(StorageContext storageContext)
        {
            _storageContext = storageContext;
        } 
        public IEnumerable<BookDto> GetAllBooks() 
        {
            using (StorageContext storage = _storageContext) 
            {
                var list = storage.Books.Select(
                b => new Book { Id = b.Id, Name = b.Name, Description = b.Description, Author = b.Author, Price = b.Price })
                .ToList();                
                List<BookDto> listDto = _mapper.Map<List<BookDto>>(list);                
                return listDto;
            } 
        }
        public int AddBook(string name, string author, int price)
        {
            using (StorageContext storageContext = _storageContext)
            { 
                if (_storageContext.Books.Any(b => b.Name == name))           
                {               
                    return -1;           
                }            
                var bookDto = new BookDto() { FullName = name, Author = author, Price = price};             
                var entity = _mapper.Map<Book>(bookDto);            
                _storageContext.Books.Add(entity);            
                _storageContext.SaveChanges();            
                return entity.Id;
            }               
        }
        public void UpdateBook(string name, string newname, string author, int price) 
        {
            using (StorageContext storageContext = _storageContext) 
            {
                if (storageContext.Books.Any(b => b.Name == name))
                {
                    var bookDto = new BookDto() { FullName = newname, Author = author, Price = price };
                    Book book = storageContext.Books.Where(b => b.Name == name).FirstOrDefault();
                    _mapper.Map(bookDto, book);
                    storageContext.SaveChanges();
                    return;
                } else
                    return;
            }
        }
        public int DeleteBook(string name)
        {
            using (StorageContext storageContext = new StorageContext())
            {
                if (storageContext.Books.Any(b => b.Name == name))
                {
                    Book book = storageContext.Books.Where(b => b.Name == name).FirstOrDefault();
                    storageContext.Books.Remove(book);
                    storageContext.SaveChanges();
                }            
            return 0;
            }
        }
    }
}

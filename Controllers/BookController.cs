using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskCRUDCleanDI.Abstraction;
using TaskCRUDCleanDI.Data;
using TaskCRUDCleanDI.DTO;
using TaskCRUDCleanDI.Models;
using TaskCRUDCleanDI.Repository;

namespace TaskCRUDCleanDI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly StorageContext _context;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookController(StorageContext context, IBookRepository bookRepository, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("get_all_books")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks() 
        {
            try
            { 
                var allRepository = new AllRepository(new BookRepository(_context, _mapper));            
                var allList = allRepository.GetAllPosition();            
                return Ok(allList);
            }
            catch
            {
                return StatusCode(409);
            }
        }

        [HttpPost("create_book")]
        public ActionResult<int> AddNewBook(string name, string author, int price)
        {
            try
            {
                var allRepository = new AllRepository(new BookRepository(_context, _mapper)); 
                var book = allRepository.AddNewPosition(name, author, price);
                return Ok(book);
            }
            catch
            {
                return StatusCode(409);
            }
        }

        [HttpDelete("delete_book")]
        public ActionResult<IEnumerable<Book>> DeleteOneBook(string name)
        {
            try 
            {
                var allRepository = new AllRepository(new BookRepository(_context, _mapper));                
                var book = allRepository.DeletePosition(name);
                return Ok();
            }
            catch
            {
                return StatusCode(409);
            }
            
        }

        [HttpPost("update_book")]
        public ActionResult<int> UpdateOneBook(string name, string newname, string author, int price)
        {
            try
            {
                var allRepository = new AllRepository(new BookRepository(_context, _mapper));
                allRepository.UpdatePosition(name, newname, author, price);
                return Ok();
            }
            catch
            {
                return StatusCode(409);
            }
        }
    }
}

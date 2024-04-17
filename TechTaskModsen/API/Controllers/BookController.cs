using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechTaskModsen.DAL.Repositories.Interfaces;
using TechTaskModsen.Models;
using TechTaskModsen.Models.DTOs;

namespace TechTaskModsen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<BookController> _logger;
        public BookController(IBookRepository bookRepository, ILogger<BookController> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }
        [HttpGet("GetBooksList")]
        public async Task<IActionResult> GetBooksList()
        {
            try
            {
                var books = await _bookRepository.GetListAsync();
                return Ok(books);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting books list.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
        [HttpGet("GetBooksByAuthor")]
        public async Task<IActionResult> GetBooksByAuthor(int authorId)
        {
            try
            {
                var books = await _bookRepository.GetAsyncBooksByAuthor(authorId);
                return Ok(books);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting books list with authorId {authorId}.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
        [HttpGet("GetBookById/{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            try
            {
                var book = await _bookRepository.GetAsync(id);
                if (book == null)
                {
                    return NotFound();
                }
                return Ok(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting book with ID {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }

        }
        [HttpGet("GetBookByISBN/{ISBN}")]
        public async Task<IActionResult> GetBookByISBN(int ISBN)
        {
            try
            {
                var book = await _bookRepository.GetAsyncISBN(ISBN);
                if (book == null)
                {
                    return NotFound();
                }
                return Ok(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting book with ISBN {ISBN}.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
        [HttpPost("CreateBook")]
        public async Task<IActionResult> CreateBookAsync([FromBody] AddBookDTO addBookDTO)
        {
            try
            {
                var book = new Book
                {
                    ISBN = addBookDTO.ISBN,
                    Genre = addBookDTO.Genre,
                    Description = addBookDTO.Description,
                    ImageData = addBookDTO.ImageData,
                    AuthorId = addBookDTO.AuthorId,
                };
                await _bookRepository.AddAsync(book);
                return Ok(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating book.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
        [HttpPut("UpdateBook/{id}")]
        public async Task<IActionResult> UpdateBookAsync(int id, [FromBody] UpdBookDTO updBookDTO)
        {
            try
            {
                var book = await _bookRepository.GetAsync(id);
                if (book == null)
                {
                    return NotFound();
                }
                book.ISBN = updBookDTO.ISBN;
                book.Genre = updBookDTO.Genre;
                book.Description = updBookDTO.Description;
                book.ImageData = updBookDTO.ImageData;
                book.AuthorId = updBookDTO.AuthorId;

                await _bookRepository.UpdateAsync(book);
                return Ok(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating book with ID {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
        [HttpDelete("DeleteBook/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                var book = await _bookRepository.GetAsync(id);
                if (book == null)
                {
                    return NotFound();
                }

                await _bookRepository.DeleteAsync(book);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting book with ID {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
        /*public async Task<IActionResult> IssueBookToUser(int bookId, int userId)
        {
            var book = _bookRepository.GetAsync(bookId);
            var user = _bookRepository.Users.FirstOrDefault(u => u.Id == userId);

            if (book == null || user == null)
                return false; // Книга или пользователь не найдены

            if (book.IssueTime != null)
                return false; // Книга уже выдана

            book.IssueTime = DateTime.Now;
            book.ReturnTime = null; // Сбрасываем время возврата

            // Добавляем книгу к списку книг пользователя
            if (user.Books == null)
                user.Books = new List<Book>();
            user.Books.Add(book);

            _context.SaveChanges();
            return true; // Книга успешно выдана пользователю
        }*/
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using TechTaskModsen.Interfaces;
using TechTaskModsen.Models;
using TechTaskModsen.DTOs;
using TechTaskModsen.Repositories;

namespace TechTaskModsen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<AuthorController> _logger;

        public AuthorController(IAuthorRepository authorRepository, IBookRepository _bookRepository, ILogger<AuthorController> logger)
        {
            _authorRepository = authorRepository;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAuthorsList()
        {
            try
            {
                var actors = await _authorRepository.GetListAsync();
                return Ok(actors);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting authors list.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            try
            {
                var actor = await _authorRepository.GetAsync(id);
                if (actor == null)
                {
                    return NotFound();
                }
                return Ok(actor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting authors with ID {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
        // POST: api/Actors/CreateActor
        [HttpPost("CreateAuthor")]
        public async Task<IActionResult> CreateAuthorAsync([FromBody] AddAuthorDTO addAuthorDTO)
        {
            try
            {
                var author = new Author
                {
                    Id = addAuthorDTO.Id,
                    FirstName = addAuthorDTO.FirstName,
                    LastName = addAuthorDTO.LastName,
                    Birthdate = addAuthorDTO.Birthdate,
                    Country = addAuthorDTO.Country,
                };

                await _authorRepository.AddAsync(author);
                return Ok(author);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating author.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // PUT: api/Actors/UpdateActor/5
        [HttpPut("UpdateAuthors/{id}")]
        public async Task<IActionResult> UpdateAuthorAsync(int id, [FromBody] UpdAuthorDTO updAuthorDTO)
        {
            try
            {
                var author = await _authorRepository.GetAsync(id);
                if (author == null)
                {
                    return NotFound();
                }
                author.FirstName = updAuthorDTO.FirstName;
                author.LastName = updAuthorDTO.LastName;
                author.Birthdate = updAuthorDTO.Birthdate;
                author.Country = updAuthorDTO.Country;

                var books = new List<Book>();

                foreach (var bookId in updAuthorDTO.BookIds)
                {
                    var book = await _bookRepository.GetAsync(bookId);
                    if (book != null)
                        books.Add(book);
                }

                author.Books = books;

                await _authorRepository.UpdateAsync(author);
                return Ok(author);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating author with ID {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // DELETE: api/Actors/DeleteActor/5
        [HttpDelete("DeleteActor/{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            try
            {
                var author = await _authorRepository.GetAsync(id);
                if (author == null)
                {
                    return NotFound();
                }

                await _authorRepository.DeleteAsync(author);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting author with ID {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}

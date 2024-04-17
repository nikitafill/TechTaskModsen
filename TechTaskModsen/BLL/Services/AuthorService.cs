using TechTaskModsen.BLL.Services.Interfaces;
using TechTaskModsen.DAL.Repositories.Interfaces;
using AutoMapper;
using TechTaskModsen.DAL.Repositories;
using TechTaskModsen.DAL.Models;
using TechTaskModsen.BLL.DTOs;

namespace TechTaskModsen.BLL.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly ILogger<AuthorService> _logger ;
        private readonly IMapper _mapper ;
        private readonly IAuthorRepository _authorRepository ;
        public AuthorService(ILogger<AuthorService> logger, IMapper mapper, IAuthorRepository authorRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _authorRepository = authorRepository;
        }
        public async Task<List<Author>> GetAllAuthorsAsync()
        {
            var authorsToReturn = await _authorRepository.GetListAsync();
            _logger.LogInformation("Authors has been returned");
            return _mapper.Map<List<Author>>(authorsToReturn);
        }


        public async Task<Author> CreateAuthorAsync(AddAuthorDTO addAuthorDTO)
        {
            _logger.LogInformation("Creating new author {Name} {LastName}", addAuthorDTO.FirstName, addAuthorDTO.LastName);

            var createdAuthor = await _authorRepository.AddAsync(_mapper.Map<Author>(addAuthorDTO));

            return _mapper.Map<Author>(createdAuthor);
        }

        public async Task<Author> UpdateAuthorAsync(UpdAuthorDTO updAuthorDTO, int Id)
        {
            var author = await _authorRepository.GetAsync(Id);

            if (author is null)
            {
                _logger.LogError("Author with authorId = {Id} was not found", updAuthorDTO.Id);
                //throw new NotFoundException(Messages.authorNotFound);
            }

            var authorToUpdate = _mapper.Map<Author>(updAuthorDTO);

            _logger.LogInformation("Author with these properties: {@updAuthorDTO} has been updated", updAuthorDTO);
            return _mapper.Map<Author>(await _authorRepository.UpdateAsync(authorToUpdate));
        }

        public async Task DeleteAuthorAsync(int Id)
        {
            var authorToDelete = await _authorRepository.GetAsync(Id);
            if (authorToDelete is null)
            {
                _logger.LogError("Author with authorId = {Id} was not found", Id);
                //throw new NotFoundException(Messages.authorNotFound);
            }
            await _authorRepository.DeleteAsync(authorToDelete);
        }
    }
}

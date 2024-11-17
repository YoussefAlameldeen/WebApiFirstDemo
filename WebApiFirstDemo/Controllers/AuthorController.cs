using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiFirstDemo.Dto;
using WebApiFirstDemo.Repositories.AuthorRepository;

namespace WebApiFirstDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepo _authorRepo;

        public AuthorController(IAuthorRepo authorRepo)
        {
            _authorRepo=authorRepo;
        }

        //[HttpPost ("AddAuthor")]
        //public IActionResult AddAuthor(AuthorDto authorDto)
        //{
        //    _authorRepo.AddAuthor(authorDto);   
        //    return Ok();
        //}

        [HttpPost("AddAuthorBook")]
        public IActionResult AddAuthorBook(AuthorDto authorDto)
        {
            _authorRepo.AddAuthorBook(authorDto);
            return Ok();
        }

    }
}

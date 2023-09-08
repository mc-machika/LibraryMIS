using LibraryMIS.Services.BookAPI.Models;
using LibraryMIS.Services.BookAPI.Models.Dto;
using LibraryMIS.Services.BookAPI.Service.IService;
using LibraryMIS.Services.BookAPI.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMIS.Services.BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookApiController : ControllerBase
    {
        private readonly IBookService _bookService;
        private ResponseDto _response;
        public BookApiController(IBookService bookService)
        {
            _bookService = bookService;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDto>> GetAllBooks()
        {
            _response.Result = await _bookService.GetAllBooksAsync();

            if (_response.Result is not null)
                return Ok(_response);

            return NotFound();
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<ResponseDto>> GetBook(string id)
        {
            _response.Result = await _bookService.GetBookAsync(id);

            if (_response.Result is null)
                return NotFound();

            return Ok(_response);
        }

        [HttpPost]
        [Authorize(Roles = StaticDetails.RoleFrontOffice)]
        public async Task<ActionResult<ResponseDto>> CreateBook(Book book)
        {

            await _bookService.CreateBookAsync(book);

            _response.Result = CreatedAtAction(nameof(GetAllBooks), new { id = book.Id }, book);

            return Ok(_response);
        }

        // ah ha!!! Dizzo, let's talk
        [HttpPut("{id:length(24)}")]
        [Authorize(Roles = StaticDetails.RoleFrontOffice)]
        public async Task<ActionResult<ResponseDto>> UpdateBook(string id, Book book)
        {
            var existingBook = await _bookService.GetBookAsync(id);

            if (existingBook is null)
                return BadRequest();

            book.Id = existingBook.Id;

            await _bookService.UpdateBookAsync(book);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        [Authorize(Roles = StaticDetails.RoleFrontOffice)]
        public async Task<ActionResult<ResponseDto>> DeleteBook(string id)
        {
            var existingBook = await _bookService.GetBookAsync(id);

            if (existingBook is null)
                return BadRequest();

            await _bookService.RemoveBookAsync(id);

            return NoContent();
        }
    }
}

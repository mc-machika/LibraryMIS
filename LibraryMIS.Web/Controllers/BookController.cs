using LibraryMIS.FrontEnd.Web.Models;
using LibraryMIS.Web.Models;
using LibraryMIS.Web.Service.IService;
using LibraryMIS.Web.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LibraryMIS.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        public async Task<IActionResult> BookIndex()
        {
            List<BookDto?> list = new();

            ResponseDto? response = await _bookService.GetAllBooksAsync();

            if (response != null && response.IsSuccess) 
            {
                list = JsonConvert.DeserializeObject<List<BookDto>>(Convert.ToString(response.Result)!)!;
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(list);
        }

        [HttpGet]
        public IActionResult BookCreate()
        {
			var acquisition = new List<SelectListItem>
			{
				new SelectListItem{Text = StaticDetails.NationalFund, Value=StaticDetails.NationalFund },
				new SelectListItem{Text = StaticDetails.Donation, Value=StaticDetails.Donation }
			};

			ViewBag.AcquisitionList = acquisition;
			return View();
        }

        [HttpPost]
        public async Task<IActionResult> BookCreate(BookDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _bookService.CreateBookAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Book Created successfully";
                    return RedirectToAction(nameof(BookIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }

        public async Task<IActionResult> BookEdit(string bookId)
        {
            ResponseDto? response = await _bookService.GetBookByIdAsync(bookId);

            if (response != null && response.IsSuccess)
            {
                BookDto? model = JsonConvert.DeserializeObject<BookDto>(Convert.ToString(response.Result)!)!;
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> BookEdit(BookDto bookDto)
        {
            ResponseDto? response = await _bookService.UpdateBookAsync(bookDto);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Book Updated Successfully";
                return RedirectToAction(nameof(BookIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(bookDto);
        }

        [HttpGet]
        public async Task<IActionResult> BookDelete(string bookId)
        {
            ResponseDto? response = await _bookService.GetBookByIdAsync(bookId);

            if (response != null && response.IsSuccess)
            {
                BookDto? model = JsonConvert.DeserializeObject<BookDto>(Convert.ToString(response.Result)!)!;
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> BookDelete(BookDto bookDto)
        {
            ResponseDto? response = await _bookService.DeleteBookAsync(bookDto.Id!);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Book Deleted Successfully";
                return RedirectToAction(nameof(BookIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
                return View(bookDto);
            }

            
        }
    }
}

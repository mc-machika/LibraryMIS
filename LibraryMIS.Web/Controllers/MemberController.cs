using LibraryMIS.Web.Models;
using LibraryMIS.Web.Models.Dto;
using LibraryMIS.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LibraryMIS.Web.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        public MemberController(IMemberService bookService)
        {
            _memberService = bookService;
        }
        public async Task<IActionResult> MemberIndex()
        {
            List<MemberDto?> list = new();

            ResponseDto? response = await _memberService.GetAllMembersAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<MemberDto>>(Convert.ToString(response.Result)!)!;
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(list);
        }

		public async Task<IActionResult> MemberDetails(string memberId)
		{
			MemberDto? list = new();

			ResponseDto? response = await _memberService.GetMemberByIdAsync(memberId);

			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<MemberDto>(Convert.ToString(response.Result)!)!;
			}
			else
			{
				TempData["error"] = response?.Message;
			}

			return View(list);
		}

		[HttpGet]
        public IActionResult MemberCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MemberCreate(MemberDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _memberService.CreateMemberAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Member Created successfully";
                    return RedirectToAction(nameof(MemberIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }

        public async Task<IActionResult> MemberEdit(string memberId)
        {
            ResponseDto? response = await _memberService.GetMemberByIdAsync(memberId);

            if (response != null && response.IsSuccess)
            {
                MemberDto? model = JsonConvert.DeserializeObject<MemberDto>(Convert.ToString(response.Result)!)!;
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> MemberEdit(MemberDto memberDto)
        {
            ResponseDto? response = await _memberService.UpdateMemberAsync(memberDto);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Member Edited Successfully";
                return RedirectToAction(nameof(MemberIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
                return View(memberDto);
            }

           
        }

		public async Task<IActionResult> MemberDelete(string memberId)
		{
			ResponseDto? response = await _memberService.GetMemberByIdAsync(memberId);

			if (response != null && response.IsSuccess)
			{
				MemberDto? model = JsonConvert.DeserializeObject<MemberDto>(Convert.ToString(response.Result)!)!;
				return View(model);
			}
			else
			{
				TempData["error"] = response?.Message;
			}

			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> MemberDelete(MemberDto memberDto)
		{
			ResponseDto? response = await _memberService.DeleteMemberAsync(memberDto.Id!);

			if (response != null && response.IsSuccess)
			{
				TempData["success"] = "Member Deleted Successfully";
				return RedirectToAction(nameof(MemberIndex));
			}
			else
			{
				TempData["error"] = response?.Message;
			}

			return View(memberDto);
		}
	}
}

using LibraryMIS.Services.MemberAPI.Models;
using LibraryMIS.Services.MemberAPI.Models.Dto;
using LibraryMIS.Services.MemberAPI.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMIS.Services.MemberAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MemberApiController : ControllerBase
    {
       
        private readonly IMemberService _memberService;
        private ResponseDto _response;
        public MemberApiController(IMemberService memberService)
        {
            _memberService = memberService;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDto>> GetAllMembers()
        {
            _response.Result = await _memberService.GetAllMembersAsync();

            if (_response.Result is not null)
                return Ok(_response);

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto>> GetMember(string id)
        {
            _response.Result = await _memberService.GetMemberAsync(id);

            if (_response.Result is null)
                return NotFound();

            return Ok(_response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto>> CreateMember(Member member)
        {

            await _memberService.CreateMemberAsync(member);

            _response.Result = CreatedAtAction(nameof(GetAllMembers), new { id = member.Id }, member);

            return Ok(_response);
        }

        // ah ha!!! Dizzo, let's talk
        [HttpPut("{id:length(24)}")]
        public async Task<ActionResult<ResponseDto>> UpdateMember(string id, Member member)
        {
            var existingBook = await _memberService.GetMemberAsync(id);

            if (existingBook is null)
                return BadRequest();

            member.Id = existingBook.Id;

            await _memberService.UpdateMemberAsync(member);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<ActionResult<ResponseDto>> DeleteMember(string id)
        {
            var existingMember = await _memberService.GetMemberAsync(id);

            if (existingMember is null)
                return BadRequest();

            await _memberService.RemoveMemberAsync(id);

            return NoContent();
        }
    }
}

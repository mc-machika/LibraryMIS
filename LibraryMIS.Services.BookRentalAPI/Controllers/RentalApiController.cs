using AutoMapper;
using LibraryMIS.Services.BookRentalAPI.Data;
using LibraryMIS.Services.BookRentalAPI.Models;
using LibraryMIS.Services.BookRentalAPI.Models.Dto;
using LibraryMIS.Services.BookRentalAPI.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LibraryMIS.Services.BookRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RentalApiController : ControllerBase
    {
        private readonly ApiDbContext _context;
        private readonly ResponseDto _response;
        private readonly IMapper _mapper;
        private IMemberService _memberService;

        public RentalApiController(ApiDbContext context, IMapper mapper, IMemberService memberService)
        {
            _context = context;
            _response = new ResponseDto();
            _mapper = mapper;
            _memberService = memberService;
        }

        [HttpGet]
        public ResponseDto GetRental()
        {
            try
            {
                IEnumerable<Rental> objList = _context.rentals.ToList();
                _response.Result = _mapper.Map<IEnumerable<RentalDto>>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto GetRentalById(int id)
        {
            try
            {
                Rental obj = _context.rentals.First(u => u.id == id);
                _response.Result = _mapper.Map<RentalDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        public async Task<ResponseDto> Post([FromBody] RentalDto rentalDto)
        {
            try
            {
                Rental obj = _mapper.Map<Rental>(rentalDto);
                IEnumerable<MemberDto> memberDto = await _memberService.GetMember();
                var member = memberDto.FirstOrDefault(u => u.MemberId == rentalDto.memberid);
                if(member is not null)
                {
                    _context.rentals.Add(obj);
                    _context.SaveChanges();
                    _response.Result = _mapper.Map<RentalDto>(obj);
                } else
                {
                    _response.IsSuccess = false;
                    _response.Message = "Invalid Member";
                }
                
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


        [HttpPut]
        public ResponseDto Put([FromBody] RentalDto couponDto)
        {
            try
            {
                Rental obj = _mapper.Map<Rental>(couponDto);
                _context.rentals.Update(obj);
                _context.SaveChanges();

                _response.Result = _mapper.Map<RentalDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Rental obj = _context.rentals.First(u => u.id == id);
                _context.rentals.Remove(obj);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


    }
}

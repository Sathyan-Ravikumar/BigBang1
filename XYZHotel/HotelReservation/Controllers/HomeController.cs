using HotelReservation.Models;
using HotelReservation.Repository.Filters;
using HotelReservation.Repository.Hotels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Buffer = HotelReservation.Repository.Filters.Buffer;

namespace HotelReservation.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ISelectHotel _context;

        public HomeController(ISelectHotel context)
        {
            _context = context;
        }
        [HttpGet("See the Hotel by Location")]
        [Authorize]
        public async Task<ActionResult<List<Hotel>>> GetbyLocation(string location)
        {
            try
            {
                return Ok(await _context.GetbyLocation(location));
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);
            }
            
        }
        [HttpGet("status of the room")]
        [Authorize]
        public async Task<ActionResult<List<Buffer>>> GetbyStatus(string status)
        {
            try
            {
                return Ok(await _context.GetbyStatus(status));
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);
            }
            
        }
        [HttpGet("Enter The Minimum and Maximum Price")]
        [Authorize]
        public async Task<ActionResult<List<Buffer>>> GetbyPrice(double min, double max)
        {
            try
            {
                return Ok(await _context.GetbyPrice(min, max));
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);
            }
           
        }
        [HttpGet("Enter the Number of beds your need")]
        [Authorize]
        public async Task<ActionResult<List<Buffer>>> GetbyCapacity(int capacity)
        {
            try
            {
                return Ok(await _context.GetbyCapacity(capacity));
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);
            }
            
        }
        }
}

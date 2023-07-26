using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelReservation.Data;
using HotelReservation.Models;
using HotelReservation.Repository.Hotels;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Authorization;

namespace HotelReservation.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotels _context;

        public HotelsController(IHotels context)
        {
            _context = context;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> Gethotels()
        {
            try
            {
                return Ok(await _context.Gethotels());
            }
            catch(ArithmeticException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotels(int id)
        {

            try
            {
                return Ok( await _context.GetHotels(id));
            }
            catch(ArithmeticException ex)
            {
                return NotFound(ex.Message);
            }
        }


        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Hotel>>> PutHotels(int id, Hotel hotels)
        {

            try
            {
                 return Ok(await _context.PutHotels(id, hotels));
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);
            }
           
        }

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<List<Hotel>>> PostHotels(Hotel hotels)
        {
            try
            {
                return Ok(await _context.PostHotels(hotels));
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Hotel>>> DeleteHotels(int id)
        {
            try
            {
                return Ok(await _context.DeleteHotels(id));
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);
            }
           
        }
    }
}

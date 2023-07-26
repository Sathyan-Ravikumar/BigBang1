using HotelReservation.Data;
using HotelReservation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace HotelReservation.Repository.Hotels
{
    public class HotelServices :IHotels
    {
        private readonly ModelDbContext? _dbcontext;
        public HotelServices(ModelDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<IEnumerable<Hotel>> Gethotels()
        {

            return await _dbcontext.hotels.ToListAsync();
        }
        public async Task<Hotel> GetHotels(int id)
        {
            var obj = await _dbcontext.hotels.FindAsync(id);
            if(obj == null)
            {
                throw new ArithmeticException("No Data available");
            }
            return obj;
        }
        public async Task<List<Hotel>> PutHotels(int id, Hotel hotels)
        {
            var obj = await _dbcontext.hotels.FindAsync(id);
            obj.HotelName = hotels.HotelName;
            obj.Location = hotels.Location;
            if (obj == null)
            {
                throw new ArithmeticException("No Data Updated");
            }
            await _dbcontext.SaveChangesAsync();
            return await _dbcontext.hotels.ToListAsync();
        }

        public async Task<List<Hotel>> PostHotels(Hotel hotels)
        {
            var obj = await _dbcontext.hotels.AddAsync(hotels);
            if (obj == null)
            {
                throw new ArithmeticException("No Data Posted");
            }
            await _dbcontext.SaveChangesAsync();
            return await _dbcontext.hotels.ToListAsync();
        }
        public async Task<List<Hotel>> DeleteHotels(int id)
        {
            var obj = await _dbcontext.hotels.FindAsync(id);
            _dbcontext.hotels.Remove(obj);
            if (obj == null)
            {
                throw new ArithmeticException("No Data has been deleted");
            }
            await _dbcontext.SaveChangesAsync();
            return await _dbcontext.hotels.ToListAsync();
        }

    }
}

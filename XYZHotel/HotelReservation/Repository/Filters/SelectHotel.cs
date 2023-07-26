using HotelReservation.Data;
using HotelReservation.Models;
using HotelReservation.Repository.Hotels;
using HotelReservation.Repository.Room;
using Microsoft.EntityFrameworkCore;
using System;

namespace HotelReservation.Repository.Filters
{
    public class SelectHotel : ISelectHotel
    {
        private readonly ModelDbContext? _dbcontext;
        public SelectHotel(ModelDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<List<Hotel>> GetbyLocation(string location)
        {
            var loc = await (from h in _dbcontext.hotels
                       where h.Location == location
                       select h).ToListAsync();
            if (loc == null)
            {
                throw new ArithmeticException("No Data Found");
            }
            return loc;
        }

        public async Task<List<Buffer>> GetbyStatus(string status)
        {
            var sta = await (from h in _dbcontext.hotels
                              join r in _dbcontext.rooms on h.HotelId equals r.HotelId
                              where r.status == status
                              select new Buffer()
                              {
                                  hotel_Name = h.HotelName,
                                  location = h.Location,
                                  RoomNumber = r.RoomNumber,
                                  capacity = r.capacity,
                                  price = r.price
                              }).ToListAsync();
            if (sta == null)
            {
                throw new ArithmeticException("No Data Found");
            }
            return sta;
        }

        public async Task<List<Buffer>> GetbyPrice(double min,double max)
        {
            var pric = await (from h in _dbcontext.hotels join r in _dbcontext.rooms on h.HotelId equals r.HotelId 
                             where r.price >=min && r.price <=max && r.status == "available"
                             select new Buffer()
                             {
                                 hotel_Name=h.HotelName,
                                 location=h.Location,
                                 RoomNumber=r.RoomNumber,
                                 capacity=r.capacity,
                                 price=r.price
                             }).ToListAsync();
            if (pric == null)
            {
                throw new ArithmeticException("No Data Found");
            }
            return pric;
        }

        public async Task<List<Buffer>> GetbyCapacity(int capacity)
        {
            var cap = await (from h in _dbcontext.hotels
                             join r in _dbcontext.rooms on h.HotelId equals r.HotelId
                             where r.capacity==capacity && r.status == "available"
                             select new Buffer()
                             {
                                 hotel_Name = h.HotelName,
                                 location = h.Location,
                                 RoomNumber = r.RoomNumber,
                                 price = r.price,
                                 status=r.status
                             }).ToListAsync();
            if (cap == null)
            {
                throw new ArithmeticException("No Data Found");
            }
            return cap;
        }
    }
}

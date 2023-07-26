using HotelReservation.Data;
using HotelReservation.Models;
using HotelReservation.Repository.Hotels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Repository.Room
{
    public class RoomServices : IRoom
    {
        private readonly ModelDbContext? _dbcontext;
        public RoomServices(ModelDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<IEnumerable<Room_Details>> Getrooms()
        {
            return await _dbcontext.rooms.ToListAsync();
        }
        public async Task<Room_Details> GetRoom(int id)
        {
            var roo = await _dbcontext.rooms.FindAsync(id);
            if (roo == null)
            {
                throw new ArithmeticException("No Data available");
            }
            return roo;
        }
        public async Task<List<Room_Details>> PutRoom(int id, Room_Details room)
        {
            var roo = await _dbcontext.rooms.FindAsync(id);
            roo.RoomNumber= room.RoomNumber;
            roo.status = room.status;
            roo.capacity = room.capacity;
            roo.price = room.price;
            if (roo == null)
            {
                throw new ArithmeticException("No Data Updated");
            }
            await _dbcontext.SaveChangesAsync();
            return await _dbcontext.rooms.ToListAsync();
        }
        public async Task<List<Room_Details>> PostRoom(Room_Details room)
        {
            var roo = await _dbcontext.rooms.AddAsync(room);
            if (roo == null)
            {
                throw new ArithmeticException("No Data Posted");
            }
            await _dbcontext.SaveChangesAsync();
            return await _dbcontext.rooms.ToListAsync();
        }
        public async Task<List<Room_Details>> DeleteRoom(int id)
        {
            var obj = await _dbcontext.rooms.FindAsync(id);
            _dbcontext.rooms.Remove(obj);
            if (obj == null)
            {
                throw new ArithmeticException("No Data has been deleted");
            }
            await _dbcontext.SaveChangesAsync();
            return await _dbcontext.rooms.ToListAsync();
        }
    }
}

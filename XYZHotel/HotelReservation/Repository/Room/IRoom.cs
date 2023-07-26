using HotelReservation.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Repository.Room
{
    public interface IRoom
    {
        public  Task<IEnumerable<Room_Details>> Getrooms();
        public  Task<Room_Details> GetRoom(int id);
        public  Task<List<Room_Details>> PutRoom(int id, Room_Details room);
        public Task<List<Room_Details>> PostRoom(Room_Details room);
        public Task<List<Room_Details>> DeleteRoom(int id);
      }
}

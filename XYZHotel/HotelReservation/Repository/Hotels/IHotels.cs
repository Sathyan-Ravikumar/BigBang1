using HotelReservation.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Repository.Hotels
{
    public interface IHotels
    {
        public Task<IEnumerable<Hotel>> Gethotels();
        public Task<Hotel> GetHotels(int id);
        public Task<List<Hotel>> PutHotels(int id, Hotel hotels);
        public  Task<List<Hotel>> PostHotels(Hotel hotels);
        public  Task<List<Hotel>> DeleteHotels(int id);
     }
}

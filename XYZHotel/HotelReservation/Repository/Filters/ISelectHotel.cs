using HotelReservation.Models;

namespace HotelReservation.Repository.Filters
{
    public interface ISelectHotel
    {
        public Task<List<Hotel>> GetbyLocation(string location);
        public  Task<List<Buffer>> GetbyStatus(string status);
        public Task<List<Buffer>> GetbyPrice(double min, double max);
        public Task<List<Buffer>> GetbyCapacity(int capacity);
        
        }
}

using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Repository.counts
{
    public interface ICount
    {
        public Task<int> RoomCount(string hotelname);
        public Task<List<CountBuffer>> HotelsRoomCount(string hotelname);
    }
}

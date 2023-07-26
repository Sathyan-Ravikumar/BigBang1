using HotelReservation.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Repository.counts
{
    public class CountService : ICount
    {
        private readonly ModelDbContext? _dbcontext;
        public CountService(ModelDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<int> RoomCount(string hotelname)
        {
            var sta = (from h in _dbcontext.hotels
                             join r in _dbcontext.rooms on h.HotelId equals r.HotelId where h.HotelName==hotelname select  r.RoomId).Count();
            if (sta == 0)
            {
                throw new ArithmeticException("No Data Found");
            }
            return sta;
        }
        public async Task<List<CountBuffer>> HotelsRoomCount(string hotelname)
        {
            var sta =await (from h in _dbcontext.hotels
                       join r in _dbcontext.rooms on h.HotelId equals r.HotelId
                       select new CountBuffer()
                       {
                           hotel_Name = h.HotelName,
                           count = _dbcontext.rooms.Count(s => s.status == "Available")

                       }).ToListAsync() ;
            if (sta == null)
            {
                throw new ArithmeticException("No Data Found");
            }
            return sta;
        }
    }
}

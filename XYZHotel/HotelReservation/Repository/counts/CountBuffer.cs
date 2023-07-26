namespace HotelReservation.Repository.counts
{
    public class CountBuffer
    {
        public int Hotelid { get; set; }
        public string? hotel_Name { get; set; }
        public string? location { get; set; }
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public string? status { get; set; }
        public int capacity { get; set; }
        public double price { get; set; }
        public int count { get; set; }
    }
}

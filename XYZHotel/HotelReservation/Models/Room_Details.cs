using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Models
{
    public class Room_Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId { get; set; }

        [ForeignKey(nameof(Hotel))]
        public int HotelId { get; set; }

        public int RoomNumber { get; set; }
        public string? status { get; set; }

        public int capacity { get; set; }

        public double price { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
    }
}

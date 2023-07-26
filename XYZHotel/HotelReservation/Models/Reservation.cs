using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Models
{
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int reserId { get; set; }

        [ForeignKey(nameof(User))]
        public int userId { get; set; }

        [ForeignKey(nameof(Room_Details))]
        public int RoomId { get; set; }

        public string? Cust_address { get; set; }
        public DateFormat checkIn { get; set; }
        public DateFormat checkOut { get; set; }

    }
}

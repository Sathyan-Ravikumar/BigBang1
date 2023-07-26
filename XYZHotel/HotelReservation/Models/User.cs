using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; }

        public string? userName { get; set; }
        public string emailId { get; set; } = string.Empty;

        public string? password { get; set; }

        public ICollection<Reservation>? Reservations { get; set; }
    }
}

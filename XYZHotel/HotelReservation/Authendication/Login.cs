using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Authendication
{
    public class Login
    {
        [Key]
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string EmailId { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Roles { get; set; } = string.Empty;
    }
}

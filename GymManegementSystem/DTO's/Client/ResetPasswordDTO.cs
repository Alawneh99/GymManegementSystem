namespace TicketCoder.DTOs.Authantication
{
    public class ResetPasswordDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Phone { get; set; }
    }
}

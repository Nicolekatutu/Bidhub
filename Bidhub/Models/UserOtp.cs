namespace Bidhub.Models
{
    public class UserOtp
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string OtpCode { get; set; }
        public DateTime ExpiryTime { get; set; }
    }
}

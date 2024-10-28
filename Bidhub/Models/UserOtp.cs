namespace Bidhub.Models
{
    public class UserOtp
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string OtpCode { get; set; }
        public DateTime ExpiryTime { get; set; }
    }
}

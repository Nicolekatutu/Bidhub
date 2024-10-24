namespace Bidhub.Dto
{
    public class AddListingsDto
    {
        public string ProductName { get; set; }
        public DateTime AuctionDate { get; set; }
        public string ReasonForAuction { get; set; }
        public string Location { get; set; }
        public string PropertyOwner { get; set; }
        public double ReservePrice { get; set; }
        public List<DocumentDto> Documents { get; set; }
        public List<string> Photos { get; set; }
    }
}

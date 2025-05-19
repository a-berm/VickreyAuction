namespace VickreyAuctionKata.Models
{
    public class Bidder
    {
        public required string Name { get; set; }
        public IEnumerable<uint>? Bids { get; set; }
    }
}

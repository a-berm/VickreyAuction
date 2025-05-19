using VickreyAuctionKata.Abstract;

namespace VickreyAuctionKata.Models
{
    public class CustomAuction : Auction
    {
        public CustomAuction(Item item, IEnumerable<Bidder> bidders) : base(item, bidders)
        {
        }

        public override WinningResult GetWinningResult()
        {
            // Add your custom auction logic here
            throw new NotImplementedException("Custom auction logic not implemented.");
        }
    }
}

using VickreyAuctionKata.Models;

namespace VickreyAuctionKata.Abstract
{
    public abstract class Auction
    {
        public Item Item { get; set; }

        public IEnumerable<Bidder> Bidders { get; set; }

        public Auction(Item item, IEnumerable<Bidder> bidders)
        {
            Item = item;
            Bidders = bidders;
        }

        public abstract WinningResult GetWinningResult();

    }
}

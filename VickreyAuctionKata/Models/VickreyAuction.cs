using VickreyAuctionKata.Abstract;

namespace VickreyAuctionKata.Models
{
    public class VickreyAuction : Auction
    {
        public VickreyAuction(Item item, IEnumerable<Bidder> bidders) : base(item, bidders)
        {
        }

        public override WinningResult GetWinningResult()
        {
            if(Item == null || Item.ReservePrice == 0)
            {
                throw new InvalidOperationException("Reserve price must be provided.");
            }

            if (Bidders == null || Bidders.Count() < 2)
            {
                throw new InvalidOperationException("At least two bidders must be provided.");
            }

            // Bidders must have placed at least one bid to be considered for winning.
            var bidders = Bidders.Where(b => b.Bids != null && b.Bids.Any());

            var bids = bidders.SelectMany(b => b.Bids!);

            if (bids == null || !bids.Any())
            {
                throw new InvalidOperationException("At least one bid must be placed.");
            }

            var highestBid = bids.Max(); 

            if(highestBid < Item.ReservePrice)
            {
                throw new InvalidOperationException("No bids met the reserve price.");
            }

            // Assumes only one bidder holds the highest bid (No two or more bidders have placed the same highest bid). 
            // Selects the first bidder with the highest bid as the winner.
            var winner = bidders.First(b => b.Bids!.Max() == highestBid);

            // Using default implementation of Equals method to compare Bidder objects.
            var bidsFromNonWinners = bidders.Where(b => !b.Equals(winner)).SelectMany(b => b.Bids!);

            var winningPrice = Math.Max(
                bidsFromNonWinners.Any() ? bidsFromNonWinners.Max() : 0,
                Item.ReservePrice
            );

            var winningResult = new WinningResult
            {
                Winner = winner.Name,
                WinningPrice = winningPrice
            };

            return winningResult;
        }
    }
}

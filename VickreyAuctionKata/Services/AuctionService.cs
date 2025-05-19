using VickreyAuctionKata.Abstract;
using VickreyAuctionKata.Contract;
using VickreyAuctionKata.Models;

namespace VickreyAuctionKata.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly Auction Auction;

        public AuctionService(Auction auction)
        {
            Auction = auction;
        }

        public void StartAuction()
        {
            Console.WriteLine("Starting Auction...");
            Console.WriteLine("Simulate user entry...");

            Auction.Item = new Item { Name = "Sculpture", ReservePrice = 100 };
            Auction.Bidders = new List<Bidder>
                {
                    new Bidder { Name = "A", Bids = [110, 130] },
                    new Bidder { Name = "B", Bids = [] },
                    new Bidder { Name = "C", Bids = [125] },
                    new Bidder { Name = "D", Bids = [105, 115, 90] },
                    new Bidder { Name = "E", Bids = [132, 135, 140] },
                };

            Thread.Sleep(2000);
        }

        public void EndAuction()
        {
            Console.WriteLine("Ending Auction...");
            Thread.Sleep(2000);
            try
            {
                var result = Auction.GetWinningResult();
                Console.WriteLine(result);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }
        }
    }
}

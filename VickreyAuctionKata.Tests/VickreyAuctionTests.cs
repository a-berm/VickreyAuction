using VickreyAuctionKata.Models;

namespace VickreyAuctionKata.Tests
{
    public class VickreyAuctionTests
    {
        public static IEnumerable<object[]> GetAuctionTestCalculationData()
        {
            yield return new object[]
            {
            new VickreyAuction(
                new Item { Name = "Sculpture", ReservePrice = 100 },
                new List<Bidder>
                {
                    new Bidder { Name = "A", Bids = [110, 130] },
                    new Bidder { Name = "B", Bids = [] },
                    new Bidder { Name = "C", Bids = [125] },
                    new Bidder { Name = "D", Bids = [105, 115, 90] },
                    new Bidder { Name = "E", Bids = [132, 135, 140] },
                } 
            ) ,
            "E",
            130
            };

            yield return new object[]
            {
            new VickreyAuction(
                new Item { Name = "Sculpture", ReservePrice = 100 },
                new List<Bidder>
                {
                    new Bidder { Name = "A", Bids = [110, 130] },
                    new Bidder { Name = "B", Bids = null },
                    new Bidder { Name = "C", Bids = [125] },
                    new Bidder { Name = "D", Bids = [105, 115, 90] },
                    new Bidder { Name = "E", Bids = [132, 135, 140] },
                }
            ) ,
            "E",
            130
            };

            yield return new object[]
            {
            new VickreyAuction(
                new Item { Name = "Sculpture", ReservePrice = 100 },
                new List<Bidder>
                {
                    new Bidder { Name = "A", Bids = [120, 130] },
                    new Bidder { Name = "B", Bids = null },
                    new Bidder { Name = "C", Bids = [80, 110] },
                    new Bidder { Name = "D", Bids = [] }
                }
            ) ,
            "A",
            110
            };

            // Reserve price is the winning price
            yield return new object[]
            {
            new VickreyAuction(
                new Item { Name = "Sculpture", ReservePrice = 100 },
                new List<Bidder>
                {
                    new Bidder { Name = "A", Bids = [110, 130] },
                    new Bidder { Name = "B", Bids = null },
                    new Bidder { Name = "C", Bids = [80, 90] },
                    new Bidder { Name = "D", Bids = [] }
                }
            ) ,
            "A",
            100
            };

            // Reserve price is the winning price
            yield return new object[]
            {
            new VickreyAuction(
                new Item { Name = "Sculpture", ReservePrice = 100 },
                new List<Bidder>
                {
                    new Bidder { Name = "A", Bids = [110, 130] },
                    new Bidder { Name = "B", Bids = [] }
                }
            ) ,
            "A",
            100
            };

            // Two bidders with the same highest bid, the first one wins, winning price is the highest bid (comes from the other bidder)
            yield return new object[]
            {
            new VickreyAuction(
                new Item { Name = "Sculpture", ReservePrice = 100 },
                new List<Bidder>
                {
                    new Bidder { Name = "A", Bids = [110, 130] },
                    new Bidder { Name = "B", Bids = [110, 140] },
                    new Bidder { Name = "C", Bids = [120, 140] },
                    new Bidder { Name = "D", Bids = [] }
                }
            ) ,
            "B",
            140
            };
        }

        public static IEnumerable<object[]> GetAuctionTestErrorData()
        {
            yield return new object[]
            {
            new VickreyAuction(
                new Item { Name = "Sculpture", ReservePrice = 0 },
                new List<Bidder>
                {
                    new Bidder { Name = "A", Bids = [110, 130] },
                    new Bidder { Name = "B", Bids = [] },
                    new Bidder { Name = "C", Bids = [125] },
                    new Bidder { Name = "D", Bids = [105, 115, 90] },
                    new Bidder { Name = "E", Bids = [132, 135, 140] },
                }
            ) ,
            "Reserve price must be provided."
            };

            
            yield return new object[]
            {
            new VickreyAuction(
                new Item { Name = "Sculpture", ReservePrice = 100 },
                []
            ) ,
            "At least two bidders must be provided."
            };

            yield return new object[]
{
            new VickreyAuction(
                new Item { Name = "Sculpture", ReservePrice = 100 },
                new List<Bidder>
                {
                    new Bidder { Name = "A", Bids = [] },
                }
            ) ,
            "At least two bidders must be provided."
};

            yield return new object[]
            {
            new VickreyAuction(
                new Item { Name = "Sculpture", ReservePrice = 100 },
                new List<Bidder>
                {
                    new Bidder { Name = "A", Bids = [] },
                    new Bidder { Name = "B", Bids = null },
                }
            ) ,
            "At least one bid must be placed."
            };            
        }

        [Theory]
        [MemberData(nameof(GetAuctionTestCalculationData))]
        public void GetWinningResult_ShouldReturnCorrectWinnerAndPrice(VickreyAuction auction, string expectedWinner, uint expectedPrice)
        {
            // Act
            var result = auction.GetWinningResult();

            // Assert
            Assert.Equal(expectedWinner, result.Winner);
            Assert.Equal(expectedPrice, result.WinningPrice);
        }

        [Theory]
        [MemberData(nameof(GetAuctionTestErrorData))]
        public void GetWinningResult_ShouldThrowException_WhenInvalidInput(VickreyAuction auction, string expectedErrorMsg)
        {
            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => auction.GetWinningResult());

            // Verify the exception message
            Assert.Equal(expectedErrorMsg, exception.Message);
        }
    }
}

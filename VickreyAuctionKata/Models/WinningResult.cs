namespace VickreyAuctionKata.Models
{
    public class WinningResult
    {
        public required string Winner { get; set; }
        public uint WinningPrice { get; set; }

        public override string ToString()
        {
            return $"Winner is : {Winner} - Winning price : {WinningPrice}";
        }
    }
}

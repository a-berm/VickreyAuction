using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VickreyAuctionKata.Abstract;
using VickreyAuctionKata.Contract;
using VickreyAuctionKata.Models;
using VickreyAuctionKata.Services;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddTransient<Item, Item>();
        //Optional
        //services.AddTransient<IEnumerable<Bidder>>(sp => new List<Bidder> ());

        services.AddTransient<Auction, VickreyAuction>();
        //Uncomment the line below to use a custom auction implementation
        //services.AddTransient<Auction, CustomAuction>();

        services.AddTransient<IAuctionService, AuctionService>();
    })
    .Build();

var auctionService = host.Services.GetRequiredService<IAuctionService>();

auctionService.StartAuction();
auctionService.EndAuction();

host.Run();
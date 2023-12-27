using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using AuctionService.Protos;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Auction Client";

        using var channel = GrpcChannel.ForAddress("https://localhost:7155/");
        var client = new AuctionSystemService.AuctionSystemServiceClient(channel);
    }
}

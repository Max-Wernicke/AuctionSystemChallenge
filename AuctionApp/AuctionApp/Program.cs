using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using AuctionService.Protos;
using Grpc.Core;

class Program
{
    static async Task Main(string[] args)
    {
        Console.Title = "Auction App";

        using var channel = GrpcChannel.ForAddress("https://localhost:7155");
        var client = new AuctionSystemService.AuctionSystemServiceClient(channel);

        while (true)
        {
            Console.WriteLine("1. Start Auction");
            Console.WriteLine("2. Place Bid");
            Console.WriteLine("3. Close Auction");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await StartAuctionAsync(client);
                    break;
                case "2":
                    await PlaceBidAsync(client);
                    break;
                case "3":
                    await CloseAuctionAsync(client);
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static async Task StartAuctionAsync(AuctionSystemService.AuctionSystemServiceClient client)
    {
        //Temporary testing code

        Console.WriteLine("Set item name:");
        string? itemName = Console.ReadLine();

        Console.WriteLine("Set item price:");
        string? itemPrice = Console.ReadLine();

        Console.WriteLine("Create auction for:" + itemName + " at the price of" + itemPrice + " USDT. Do you confirm? (y/n)");
        string? confirmation = Console.ReadLine();


        //Check Ambiguity problem
        var auction = new AuctionMsg 
        {
            ItemName = itemName,
            StartingPrice = itemPrice
        };

        try
        {
            // Call the gRPC method to start the auction
            var response = await client.StartAuctionAsync(auction);

            // Handle the response
            Console.WriteLine($"Auction started successfully. Auction ID: {response.ItemId}");
        }
        catch (RpcException ex)
        {
            // Handle gRPC service error
            Console.WriteLine($"Error starting auction: {ex.Status.Detail}");
        }
    }

    static async Task PlaceBidAsync(AuctionSystemService.AuctionSystemServiceClient client)
    {
        // Collect user input and create the gRPC request
        // ...

        // Call the gRPC method
        // ...

        // Handle the response
        // ...
    }

    static async Task CloseAuctionAsync(AuctionSystemService.AuctionSystemServiceClient client)
    {
        // Collect user input and create the gRPC request
        // ...

        // Call the gRPC method
        // ...

        // Handle the response
        // ...
    }
}


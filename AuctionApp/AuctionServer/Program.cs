using System;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using AuctionService.Protos;
using Microsoft.AspNetCore.Hosting;
using Grpc.AspNetCore.Server;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Auction Server";

        var host = new HostBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddGrpc();
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureKestrel(options =>
                {
                    options.ListenLocalhost(50051, o => o.Protocols = HttpProtocols.Http2);
                });

                webBuilder.UseStartup<Startup>();
            })
            .Build();

        host.Run();
    }
}

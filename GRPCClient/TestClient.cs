using Grpc.Core;
using GrpcTest;
using System;
 
namespace grpcClient
{
    class TestClient
{
    static void Main(string[] args)
    {
        Channel channel = new Channel("127.0.0.1:8082", ChannelCredentials.Insecure);

        var client = new gRPC.gRPCClient(channel);
        var reply = client.SayHello(new TestRequest { Name = "jeno" });
        Console.WriteLine("2333 SayHello Return: " + reply.Message);

        var reply2 = client.Add(new AddTarget { V1=6,V2=7});
        Console.WriteLine("V1=6,V2=7 Add Return: " + reply2.Sum);

        channel.ShutdownAsync().Wait();
        Console.WriteLine("任意键退出...");
        Console.ReadKey();
    }
}
}

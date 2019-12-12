using Grpc.Core;
using GrpcTest;
using System;
using System.Threading.Tasks;
 
namespace grpcServer
{
    class gRPCImpl : gRPC.gRPCBase
{
    // 实现SayHello方法
    public override Task<TestReply> SayHello(TestRequest request, ServerCallContext context)
    {
        return Task.FromResult(new TestReply { Message = "Hello " + request.Name+",this is C# gRPC" });
    }
    public override Task<SumValue> Add(AddTarget target, ServerCallContext context)
    {
        return Task.FromResult(new SumValue { Sum = target.V1+target.V2});
    }
 }

class TestServer
{
    const int Port = 8082;

    public static void Main(string[] args)
    {
        Server server = new Server
        {
            Services = { gRPC.BindService(new gRPCImpl()) },
            Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
        };
        server.Start();

        Console.WriteLine("gRPC serverlistening on port " + Port);
        Console.WriteLine("任意键退出...");
        Console.ReadKey();

        server.ShutdownAsync().Wait();
    }
}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SignalR.Client;

namespace SignalR.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new Connection("http://localhost:2329/Home/echo");
            connection.Received += data =>
                {
                    Console.WriteLine(data);
                };

            connection.Start().Wait();
            connection.Send("Testing from C# Console App");

            Console.ReadLine();
        }
    }
}

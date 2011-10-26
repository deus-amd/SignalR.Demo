using System;
using System.Threading;
using NUnit.Framework;
using SignalR.Client;

namespace SignalR.UnitTests
{
    [TestFixture]
    public class ConnectionTests
    {
        AutoResetEvent _autoResetEvent;

        [Test]
        public void signalr_connection_is_alive()
        {
            this._autoResetEvent = new AutoResetEvent(false);

            var connection = new Connection("http://localhost:2329/echo");
            connection.Received += data =>
            {
                this._autoResetEvent.Set();
                Console.WriteLine(data);
                Assert.Pass();
            };

            connection.Start().Wait();
            connection.Send("Testing from C# Console App");
            this._autoResetEvent.WaitOne();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR.Demo.Connections
{
    public class EchoConnection : PersistentConnection
    {
        protected override void OnReceived(string clientId, string data)
        {
            Connection.Broadcast(
                string.Format("Received '{0}' from client '{1}'", data, clientId)
                );

            base.OnReceived(clientId, data);
        }
    }
}
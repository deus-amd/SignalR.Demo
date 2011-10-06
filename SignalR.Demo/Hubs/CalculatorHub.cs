﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR.Hubs;

namespace SignalR.Demo.Hubs
{
    public class CalculatorHub : Hub
    {
        public void Add(int x, int y)
        {
            Clients.showSum(x + y);
        }
    }
}
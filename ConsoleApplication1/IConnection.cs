using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    public interface IConnection
    {
        void Connect();
        void Disconnect();
        int? Receive();
        void Send(int value);
    }
}
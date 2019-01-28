using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace ConsoleApplication1
{
    public class DisconnectedState<T> : StateBase<T>, IConnection
    {
        private readonly CustomSocket _socket;

        public static readonly Event CONNECT = new ConnectEvent();
        public static readonly Event ERROR = new ErrorEvent();

        public DisconnectedState(T automaton, IEventEmitter eventEmitter, CustomSocket socket) : base(automaton, eventEmitter)
        {
            _socket = socket;
        }

        public void Connect()
        {
            try
            {
                _socket.Connect();
            }
            catch
            {
                Console.WriteLine("Connection error");
                EmitEvent(ERROR);
            }

            EmitEvent(CONNECT);
        }

        public void Disconnect()
        {
            Console.WriteLine("Already disconnected");
        }

        public int? Receive()
        {
            Console.WriteLine("Connection is closed");
            return 0;
        }

        public void Send(int value)
        {
            Console.WriteLine("Connection is closed");
        }
    }
}
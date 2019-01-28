using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace ConsoleApplication1
{
    public class ConnectedState<T> : StateBase<T>, IConnection
    {
        private readonly CustomSocket _socket;

        public static readonly Event DISCONNECT = new DisconnectEvent();
        public static readonly Event ERROR = new ErrorEvent();

        public ConnectedState(T automaton, IEventEmitter eventEmitter, CustomSocket socket) : base(automaton, eventEmitter)
        {
            _socket = socket;
        }

        public void Connect()
        {
            Console.WriteLine("Already connected");
        }

        public void Disconnect()
        {
            try
            {
                _socket.Disconnect();
            }
            finally
            {
                EmitEvent(DISCONNECT);
            }
        }

        public int? Receive()
        {
            try
            {
                return _socket.Receive();
            }
            catch
            {
                Console.WriteLine("Receiving error");
                EmitEvent(ERROR);
                return 0;
            }
        }

        public void Send(int value)
        {
            try
            {
                _socket.Send(value);
            }
            catch
            {
                EmitEvent(ERROR);
                Console.WriteLine("Send error");
            }
        }
    }
}
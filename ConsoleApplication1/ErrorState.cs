using System;

namespace ConsoleApplication1
{
    public class ErrorState<T> : StateBase<T>, IConnection where T : IConnection
    {
        public static readonly Event CONNECT = new ConnectEvent();
        public static readonly Event DISCONNECT = new DisconnectEvent();

        private readonly CustomSocket _socket;

        public ErrorState(T automaton, IEventEmitter eventEmitter, CustomSocket socket) : base(automaton, eventEmitter)
        {
            _socket = socket;
        }

        public void Connect()
        {
            Console.WriteLine("Reconnecting after error");
            _socket.Connect();
            EmitEvent(CONNECT);
        }

        public void Disconnect()
        {
            Console.WriteLine("Disconnecting after error");
            EmitEvent(DISCONNECT);
        }

        public int? Receive()
        {
            Console.WriteLine("Resume receiving after error");
            Connect();
            return Automaton.Receive();
        }

        public void Send(int value)
        {
            Console.WriteLine("Resume send request after error");
            Connect();
            Automaton.Send(value);
        }
    }
}
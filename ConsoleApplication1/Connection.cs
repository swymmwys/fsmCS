namespace ConsoleApplication1
{
    public class Connection : AutomatonBase<IConnection>, IConnection
    {
        private Connection()
        {
            var socket = new CustomSocket();

            IConnection connected = new ConnectedState<IConnection>(this, this, socket);
            IConnection disconnected = new DisconnectedState<IConnection>(this, this, socket);
            IConnection error = new ErrorState<IConnection>(this, this, socket);

            AddTransition(connected, ConnectedState<IConnection>.DISCONNECT, disconnected);
            AddTransition(connected, ConnectedState<IConnection>.ERROR, error);

            AddTransition(disconnected, DisconnectedState<IConnection>.CONNECT, connected);
            AddTransition(disconnected, DisconnectedState<IConnection>.ERROR, error);

            AddTransition(error, ErrorState<IConnection>.CONNECT, connected);
            AddTransition(error, ErrorState<IConnection>.DISCONNECT, disconnected);

            CurrentState = disconnected;
        }

        public static IConnection Create()
        {
            return new Connection();
        }

        public void Connect()
        {
            CurrentState?.Connect();
        }

        public void Disconnect()
        {
            CurrentState?.Disconnect();
        }

        public int? Receive()
        {
            return CurrentState?.Receive();
        }

        public void Send(int value)
        {
            CurrentState?.Send(value);
        }
    }
}
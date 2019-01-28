namespace ConsoleApplication1
{
    public class Event
    {
        public readonly string Name;

        protected Event(string name)
        {
            Name = name;
        }
    }

    public class ConnectEvent : Event
    {
        public ConnectEvent() : base("CONNECT")
        {
        }
    }

    public class DisconnectEvent : Event
    {
        public DisconnectEvent() : base("DISCONNECT")
        {
        }
    }

    public class ErrorEvent : Event
    {
        public ErrorEvent() : base("ERROR")
        {
        }
    }
}
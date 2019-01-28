namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var connection = Connection.Create();
            connection.Connect();
            connection.Receive();
            connection.Receive();
            connection.Send(123);
            connection.Send(122);
        }
    }
}
using System;

namespace ConsoleApplication1
{
    public class CustomSocket : IConnection
    {
        public void Connect()
        {
            Console.WriteLine("Connected");
        }

        public void Disconnect()
        {
            Console.WriteLine("Disconnected");
        }

        public int? Receive()
        {
            var randomValue = new Random().Next(0, 999999);

            if (randomValue % 2 == 0)
            {
                throw new Exception("Receiving exception");
            }

            Console.WriteLine($"Receive: {randomValue}");
            return randomValue;
        }

        public void Send(int value)
        {
            var randomValue = new Random().Next(0, 999999);

            if (randomValue % 2 == 0)
            {
                throw new Exception("Sending exception");
            }

            Console.WriteLine($"Send value: {value}");
        }
    }
}
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpTimeClient
{
    class Program
    {
        static void Main()
        {
            int port = 12345; 
            UdpClient udpClient = new UdpClient(port); // Слушаем входящие пакеты на этом порту

            Console.WriteLine("UDP-клиент запущен. Ожидание текущего времени...");

            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, port);

            while (true)
            {
                byte[] data = udpClient.Receive(ref remoteEndPoint); // Получаем данные от сервера
                string currentTime = Encoding.UTF8.GetString(data);

                if (currentTime == "Звонок!")
                {
                    Console.WriteLine("Сигнал.");
                    Console.Beep();
                }
                else
                {
                    Console.WriteLine($"Текущее время: {currentTime}");
                }

                Console.WriteLine($"Текущее время: {currentTime}");
            }
        }
    }
}

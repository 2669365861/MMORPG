using Net.Event;
using System;

namespace GameServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NDebug.WriteFileMode = WriteLogMode.All;
            NDebug.BindConsoleLog();

            var service = new Service();
            service.Start(9543);

            while (true)
            {
                Console.ReadLine();
            }
        }
    }
}

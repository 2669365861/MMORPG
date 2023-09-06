using Game;
using Net.Event;
using Net.System;
using System;

namespace GameServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NDebug.WriteFileMode = WriteLogMode.All;
            NDebug.BindConsoleLog();

            //加载数据库
            GameDB.I.Init(GameDB.I.OnInit);
            ThreadManager.Invoke("MysqlExecuted", 1f, GameDB.I.Executed, true);

            var service = new Service();
            service.Start(9543);

            while (true)
            {
                Console.ReadLine();
            }
        }
    }
}

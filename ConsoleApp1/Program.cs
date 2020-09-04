using Buisness.Logging;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger log = new FileLogger();
            log.Logger("sync log");
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Logging
{
    public class FileLogger : ILogger    {
        public void Logger(string message)
        {
            var path = Assembly.GetExecutingAssembly().Location.Replace(Assembly.GetExecutingAssembly().GetName().Name+".dll",string.Empty) + "log.txt";
            var stream = new FileStream(path,FileMode.OpenOrCreate);
            using (var sw = new StreamWriter(stream))
            {
                sw.WriteLine(message);
            }    
        }

        public async Task LoggerAsync(string message)
        {
            await Task.Run(()=>Logger(message));
        }
    }
}

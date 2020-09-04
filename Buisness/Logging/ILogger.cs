using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Logging
{
    public interface ILogger
    {
        void Logger(string message);
        Task LoggerAsync(string message);
    }
}

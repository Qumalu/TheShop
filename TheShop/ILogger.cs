using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop
{
    public enum LogMessageType
    {
        Info,
        Debug,
        Error
    }

    public interface ILogger
    {
        void Log(LogMessageType logMessageType, string message);
    }
}

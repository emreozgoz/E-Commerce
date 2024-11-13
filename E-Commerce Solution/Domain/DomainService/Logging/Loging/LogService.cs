using DomainService.Logging.Interface;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Logging.Loging
{
    public class LogService : ILoggerService
    {
        public void Log(Log.Log log)
        {
            var logger = LogManager.GetLogger(log.ConfigRuleLoggerName);
            var logEventInfo = new LogEventInfo(LogLevel.Trace, log.TxtLoggerName, log.TxtMessage);
            logEventInfo.TimeStamp = DateTime.Now;

            foreach (var item in log.LogProperties)
                logEventInfo.Properties.Add(item.Name, item.Value);

            logger.Log(logEventInfo);
        }
    }
}

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Logging.Log
{
    public class Log
    {
        public LogLevel LogLevel { get; private set; }
        public List<LogProp> LogProperties { get; private set; }
        public string ConfigRuleLoggerName { get; private set; }

        public string TxtLoggerName { get; private set; }
    
        public string TxtMessage { get; private set; }

        public Log(LogLevel logLevel, string configRuleLoggerName, List<LogProp> logProperties = null, string txtLoggerName = null, string txtMessage = null)
        {
            if (logProperties == null)
                logProperties = new List<LogProp>();

            if (String.IsNullOrEmpty(configRuleLoggerName))
                throw new System.Exception("ConfigRuleLoggerName can not be empty!");

            LogLevel = logLevel;
            LogProperties = logProperties;
            ConfigRuleLoggerName = configRuleLoggerName;
            TxtLoggerName = txtLoggerName;
            TxtMessage = txtMessage;
        }
    }
}


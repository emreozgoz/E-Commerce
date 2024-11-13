using DomainService.Logging.Config;
using DomainService.Logging.Interface;
using DomainService.Logging.Log;
using DomainService.Logging.Loging;
using Microsoft.Extensions.DependencyInjection;
using NLog.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DomainService.Logging.Extensions
{
    public static class AddLoggerExtension
    {
        public static IServiceCollection AddNlog(this IServiceCollection services, NLogConfig config)
        {

            if (string.IsNullOrEmpty(config.ServiceName))
                throw new System.Exception("Invalid Config Value : ServiceName");

            if (config != null && !string.IsNullOrEmpty(config.NLogConfigFileContent)) //Boş ise dosya ile çalışıyor demektir.
            {
                var xmlReader = XmlReader.Create(new StringReader(config.NLogConfigFileContent));
                NLog.LogManager.Configuration = new XmlLoggingConfiguration(xmlReader, null);
            }

            services.AddTransient<ILoggerService, LogService>();

            return services;
        }
    }
}

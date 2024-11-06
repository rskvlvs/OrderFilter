using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFilter
{
    public interface IOrderLogger
    {
        void LogError(string message, Exception ex);
        void LogInfo(string message);
    }

    public class OrderLogger : IOrderLogger
    {
        private readonly Logger Logger;
        public OrderLogger(string logFilePath)
        {
            var config = new NLog.Config.LoggingConfiguration();

            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = logFilePath };

            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            // Применяем конфигурацию
            NLog.LogManager.Configuration = config;

            Logger = LogManager.GetCurrentClassLogger();
        }
        public void LogInfo(string message)
        {
            Logger.Info(message);
        }

        public void LogError(string message, Exception ex)
        {
            Logger.Error(ex, message);
        }
    }
}

using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace SierraInteractiveEvaluation.Utilities
{
    public class Logger: ILogger
    {
        private const string outputTemplate = "{Timestamp:[yyyy-MM-dd] [HH:mm:ss]} [{Level}]: {Message} {NewLine} {NewLine}";

        private readonly Serilog.ILogger _loggerAll = new LoggerConfiguration().WriteTo.RollingFile(@"Logs\All.log", outputTemplate: outputTemplate).CreateLogger();

        private readonly Serilog.ILogger _loggerError = new LoggerConfiguration().WriteTo.RollingFile(@"Logs\Error.log", outputTemplate: outputTemplate).CreateLogger();

        public void Error(Exception exception)
        {
            Error(exception.Message);
        }

        public void Error(string message)
        {
            _loggerAll.Error(message);
            _loggerError.Error(message);
        }

        public void Information(string message)
        {
            _loggerAll.Information(message);
        }
    }
}

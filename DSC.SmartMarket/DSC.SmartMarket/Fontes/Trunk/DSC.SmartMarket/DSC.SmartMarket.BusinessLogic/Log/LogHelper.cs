using DSC.SmartMarket.Model;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;

namespace DSC.SmartMarket.BusinessLogic.Log
{
    public class LogHelper
    {
        //private LogWriterFactory CreateLogWriterFactory()
        //{
        //    return new LogWriterFactory();
        //}

        //private LogWriter CreateLogWriter()
        //{
        //    var logWriterFactory = CreateLogWriterFactory();
        //    return logWriterFactory.Create();
        //}

        //bool isLoggingEnable = false;

        //    try
        //    {
        //        isLoggingEnable = Logger.IsLoggingEnabled();
        //    }
        //    catch
        //    {
        //        var logWriter = CreateLogWriter();
        //        Logger.SetLogWriter(logWriter);
        //        isLoggingEnable = Logger.IsLoggingEnabled();
        //    }

        public static void Write(string logEntry)
        {
            Logger.Write(logEntry);
        }

        //public static void Write(LogEntry logEntry)
        //{
        //    Logger.Write(logEntry);
        //}

        public static void Write(Resultado resultado)
        {
            Logger.Write(resultado.AsLogEntry());
        }

        public static void Write(Exception ex)
        {
            Logger.Write(ex);
        }

        public static bool IsLoggingEnabled()
        {
            return Logger.IsLoggingEnabled();
        }
    }
}

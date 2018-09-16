using DSC.SmartMarket.Model;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System.Diagnostics;

namespace DSC.SmartMarket.BusinessLogic.Log
{
    public static class ResultadoLogHelper
    {
        public static LogEntry AsLogEntry(this Resultado resultado)
        {
            var logEntry = new LogEntry();
            logEntry.Categories = new string[] { "General" };
            logEntry.EventId = 9007;
            logEntry.Priority = 9;
            if (resultado.Sucesso)
            {
                logEntry.Severity = TraceEventType.Information;
            }
            else if (!resultado.ResultadoExcecao)
            {
                logEntry.Severity = TraceEventType.Warning;
            }
            else
            {
                logEntry.Severity = TraceEventType.Error;
            }
            logEntry.Title = resultado.ConsolidaMensagens(";");
            logEntry.Message = resultado.ConsolidaMensagens(";");
            return logEntry;
        }

    }
}
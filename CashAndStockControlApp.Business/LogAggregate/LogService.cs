using CashAndStockControlApp.Data.txt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CashAndStockControlApp.Business.LogAggregate
{
    public class LogService
    {
        public static List<Log> logList = new List<Log>();

        public static void WarningLog(string message)
        {
            Log warning = new Log(LogType.Warning,message);
            logList.Add(warning);
            Console.WriteLine(warning);
            Save(warning);

        }
        public static void ErrorLog(string message) 
        {
            Log error = new Log(LogType.Error,message);
            logList.Add(error);
            Console.WriteLine(error);
            Save(error);
        }
        public static void InfoLog(string message) 
        {
            Log info = new Log(LogType.Information,message);
            logList.Add(info);
            Console.WriteLine(info);
            Save(info);
        }

        public static GeneralAnswerType Save(Log log)
        {
            // v2
            if (log._logType == LogType.Error) {
                var gatErr = new GeneralAnswerType(true, log._message, log);
                var jsonErr = JsonSerializer.Serialize(gatErr, new JsonSerializerOptions { IncludeFields = true });
                FileOperations.Save(Constants.LOG_DOSYA_YOLU, jsonErr);
                return gatErr;
            }
            var gat = new GeneralAnswerType(false, log);
            var json = JsonSerializer.Serialize(gat, new JsonSerializerOptions { IncludeFields = true });
            FileOperations.Save(Constants.LOG_DOSYA_YOLU, json);

            return gat;

            /* v1
            var gat = new GeneralAnswerType(log._logType == LogType.Error ? true: false, log._message, log);

            var json = JsonSerializer.Serialize(gat, new JsonSerializerOptions { IncludeFields = true });
            FileOperations.Save(Constants.LOG_DOSYA_YOLU, json);

            return gat; */

            
        }

        public static void Read()
        {
            try
            {
                string data = FileOperations.Read(Constants.LOG_DOSYA_YOLU);
                logList = JsonSerializer.Deserialize<List<Log>>(data, new JsonSerializerOptions() { IncludeFields = true });
            }
            catch (Exception)
            {

                ErrorLog("Herhangi bir data bulunamadı");
            }
            
        }

        public static void ShowErrorLogList()
        {
            
            foreach (Log log in logList.Where((e => e._logType == LogType.Error))) 
            {
                Console.WriteLine(log);
            }

        }
        public static void ShowWarningLogList()
        {

            foreach (Log log in logList.Where((e => e._logType == LogType.Warning)))
            {
                Console.WriteLine(log);
            }

        }
        public static void ShowInfoLogList()
        {

            foreach (Log log in logList.Where((e => e._logType == LogType.Information)))
            {
                Console.WriteLine(log);
            }

        }
        public static void ShowAllLogList()
        {
            foreach (Log log in logList)
            {
                Console.WriteLine(log);
            }

        }

    }

    
}

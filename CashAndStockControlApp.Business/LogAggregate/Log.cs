using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashAndStockControlApp.Business.LogAggregate
{
    public class Log
    {
        public LogType _logType;
        public DateTime _date;
        public string _message;

        public Log(LogType logType, string message)
        {
            _logType= logType;
            _date= DateTime.Now;
            _message= message;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", _logType.ToString(), _date.ToString("dd.MM.yyyy HH:mm"), _message);
        }
    }
}

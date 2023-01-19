using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashAndStockControlApp.Business.LogAggregate
{
    public class Log
    {
        public LogType logType;
        public DateTime date;
        public string message;
    }
}

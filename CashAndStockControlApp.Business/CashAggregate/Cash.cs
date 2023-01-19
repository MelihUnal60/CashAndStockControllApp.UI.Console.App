using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashAndStockControlApp.Business.CashAggregate
{
    public class Cash
    {
        public OperationType _operationType;
        public DateTime _date;
        public string _exp;
        public double _price;

        // Yapıcı metod
        
        public Cash(OperationType type,DateTime date,string exp,double price) 
        {
               _operationType= type;
               _date = date;
               _exp = exp;
               _price = price;
        }
    }
}

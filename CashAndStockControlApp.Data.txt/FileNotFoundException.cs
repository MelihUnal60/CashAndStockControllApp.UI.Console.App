using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashAndStockControlApp.Data.txt
{
    public class FileNotFoundException : Exception
    {
        public  FileNotFoundException(string fileRoad)

            : base($"{fileRoad} yolundaki dosya okunamadı. ")
        {
            
        }
        
    }
}

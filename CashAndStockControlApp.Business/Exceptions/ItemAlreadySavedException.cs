using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashAndStockControlApp.Business.Exceptions
{
    public class ItemAlreadySavedException:Exception
    {
        public ItemAlreadySavedException(string itemName) : base($"{itemName} isimli ürün zaten kayıtlı !!")
        {

        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashAndStockControlApp.Business.Exceptions
{
    public class ThereIsNotEnoughStock:Exception
    {
        public ThereIsNotEnoughStock(string itemName,ushort itemAmount, ushort reduceItemAmount)
            :base($"{itemName} isimli üründen stokta {itemAmount} adet var. {reduceItemAmount} kadar mevcut değil!!")
        {

        }
    }
}

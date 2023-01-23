using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashAndStockControlApp.Business.ItemAggregate
{
    public class Item
    {
        public string itemName;
        public double buyPrice;
        public double sellPrice;
        public ushort itemAmount;

        public Item(string itemName, double buyPrice, double sellPrice, ushort itemAmount)
        {
            itemName.NullOrWhiteSpace(nameof(itemName));
            buyPrice.Zero(nameof(buyPrice));
            sellPrice.Zero(nameof(sellPrice));
            itemAmount.Zero(nameof(itemAmount));


            this.itemName = itemName;
            this.buyPrice = buyPrice;
            this.sellPrice = sellPrice;
            this.itemAmount = itemAmount;
        }
    }
}

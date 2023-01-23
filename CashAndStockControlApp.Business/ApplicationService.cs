using CashAndStockControlApp.Business.CashAggregate;
using CashAndStockControlApp.Business.ItemAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashAndStockControlApp.Business
{
    public class ApplicationService
    {
        private CashService cashService = new CashService();
        private ItemService itemService = new ItemService();


        public GeneralAnswerType AddItem(string itemName,double buyPrice,double sellPrice,ushort itemAmount)
        {
            var addItemResult = itemService.Save(itemName,buyPrice,sellPrice,itemAmount);
            if (addItemResult.IsFault)
                return addItemResult;

            var cashSaveResult = cashService.Save(OperationType.Expense, (buyPrice * itemAmount),$"{itemName} ürününden {itemAmount} adet alındı.");
            if(cashSaveResult.IsFault)
                return cashSaveResult;
            return new GeneralAnswerType(false);
        }

        public GeneralAnswerType SellItem(string itemName,ushort sellAmount)
        {
            var reduceStockResult = itemService.ReduceStock(itemName,sellAmount);
            if(reduceStockResult.IsFault)
                return reduceStockResult;
            var item = (Item)reduceStockResult.data;
            var cashSaveResult = cashService.Save(OperationType.Income, item.sellPrice, $"{item.itemName} isimli üründen {sellAmount} kadar satıldı!");
            if(cashSaveResult.IsFault)
                return cashSaveResult;

            return new GeneralAnswerType(false);

        }


        public double CashAmount() => cashService.Amount();

        public IReadOnlyCollection<Cash> CashList() => cashService.CashList();

    }
}

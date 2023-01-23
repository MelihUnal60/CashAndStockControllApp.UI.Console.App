using CashAndStockControlApp.Data.txt;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text;
using CashAndStockControlApp.Business.LogAggregate;
using CashAndStockControlApp.Business.Exceptions;
using System.Diagnostics;

namespace CashAndStockControlApp.Business.ItemAggregate
{
    internal class ItemService
    {
        private static List<Item> list = new List<Item>();
        static ItemService()
        {
            LoadItems();
        }

        private static void LoadItems()
        {
            string data = "[]";
            try
            {
                data = FileOperations.Read(Constants.URUN_DOSYA_YOLU);
                list = JsonSerializer.Deserialize<List<Item>>(data, new JsonSerializerOptions { IncludeFields = true });
            }
            catch (Exception ex)
            {

                LogService.WarningLog(ex.Message);
            }
        }

        public  GeneralAnswerType Save(string itemName,double buyPrice,double sellPrice,ushort itemAmount)
        {
            try
            {
                var isThereItemReturnType = IsThereItem(itemName);
                if (isThereItemReturnType.IsFault)
                    return isThereItemReturnType;

                bool isThereItem = (bool)isThereItemReturnType.data;
                if (isThereItem)
                    throw new ItemAlreadySavedException(itemName); //yeni bir exception tanımladık ve burada çağırdık.

                var item = new Item(itemName, buyPrice, sellPrice, itemAmount);
                list.Add(item);

                string json = JsonSerializer.Serialize(list,new JsonSerializerOptions { IncludeFields = true});
                FileOperations.Save(Constants.URUN_DOSYA_YOLU, json);

                return new GeneralAnswerType(false, item);
            }
            catch (Exception ex)
            {
                LogService.ErrorLog(ex.Message);
                return new GeneralAnswerType(true, ex.Message);
            }
        }

        public  IReadOnlyCollection<Item> ItemList()
        {
            LoadItems();
            return list.AsReadOnly();
        }

        public GeneralAnswerType ReduceStock(string itemName, ushort reduceItemAmount)
        {
            try
            {
                reduceItemAmount.Zero(nameof(reduceItemAmount));
            }
            catch (Exception)
            {

                return new GeneralAnswerType(true, "0 adet ürün satışı yapılamaz!!");
            }

            var searchResult = SearchItem(itemName);
            if (searchResult.IsFault)
                return searchResult;

            Item item = (Item)searchResult.data;

            try
            {
                if (item.itemAmount < reduceItemAmount)
                    throw new ThereIsNotEnoughStock(itemName, item.itemAmount, reduceItemAmount);

                list.Remove(item);
                item.itemAmount -= reduceItemAmount;
                return Save(item.itemName, item.buyPrice, item.sellPrice, item.itemAmount);
            }
            catch (Exception ex)
            {

                LogService.WarningLog(ex.Message);
                return new GeneralAnswerType(true, ex.Message);
            }
            
        }

        public GeneralAnswerType SearchItem(string itemName)
        {
            try
            {
                itemName.NullOrWhiteSpace(nameof(itemName));
                var returnType = new GeneralAnswerType(false);
                returnType.data = list.FirstOrDefault(u => u.itemName == itemName);
                if (returnType.data == null)
                    throw new ItemNotFoundException(itemName);
                return returnType;
            }
            catch (Exception ex)
            {
                LogService.ErrorLog(ex.Message);
                return new GeneralAnswerType(false, ex.Message);
            }
        }

        private  GeneralAnswerType IsThereItem(string itemName)
        {
            try
            {
                itemName.NullOrWhiteSpace(nameof(itemName));

                var returnType = new GeneralAnswerType(false);
                returnType.data = list.Any( u => u.itemName == itemName );
                return returnType;

            }
            catch (Exception ex)
            {
                LogService.ErrorLog(ex.Message);
                return new GeneralAnswerType(true, ex.Message);
            }
        }
    }
}

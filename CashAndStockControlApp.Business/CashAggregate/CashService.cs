using CashAndStockControlApp.Data.txt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.IO;

namespace CashAndStockControlApp.Business.CashAggregate
{
    internal class CashService
    {
        private static List<Cash> list = new List<Cash>();


        static CashService()
        {
            CashLoad();
        }
        private static void CashLoad()
        {
            string data = "[]";
            try
            {
                data = FileOperations.Read(Constants.KASA_DOSYA_YOLU);
                list = JsonSerializer.Deserialize<List<Cash>>(data, new JsonSerializerOptions { IncludeFields = true});
            }
            catch (Data.txt.FileNotFoundException)
            {

                var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { IncludeFields = true });
                FileOperations.Save(Constants.KASA_DOSYA_YOLU, json);
            }

        }

        public GeneralAnswerType Save(OperationType type,double price,string exp)
        {
            try
            {
                CashLoad();
                Cash k = new Cash(type,DateTime.Now,exp,price);
                list.Add(k);

                string json = JsonSerializer.Serialize(list, new JsonSerializerOptions { IncludeFields = true});
                FileOperations.Save(Constants.KASA_DOSYA_YOLU, json);

                return new GeneralAnswerType(false);
            }
            catch (Exception ex)
            {

                //todo : hatayı log sistemi loglasın
                return new GeneralAnswerType(true, "Kasa işlemi kayıt edilirken bir hata oluştu\n" + ex.Message);

            }
        }

        public IReadOnlyCollection <Cash> CashList() => list.AsReadOnly(); //tek satırda metod oluşturduk

        public IReadOnlyCollection<Cash> IncomeList() => list.Where(c => c._operationType == OperationType.Income).ToList().AsReadOnly();

        public IReadOnlyCollection<Cash> ExpenseList() => list.Where(c => c._operationType == OperationType.Expense).ToList().AsReadOnly();

        public  double Amount() => IncomeList().Sum(c => c._price) - ExpenseList().Sum(c => c._price);

    }
}

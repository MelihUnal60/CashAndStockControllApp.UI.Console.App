using CashAndStockControlApp.Business;
using CashAndStockControlApp.Business.CashAggregate;
using CashAndStockControlApp.Business.LogAggregate;

LogService.InfoLog("Program başlatıldı..");

Menu();

static void Menu()
{
    
        while (true)
        {
            var choose = TakeAnswer("1. Add İtem\n2. Sell İtem\n3. Cash Info\n4. Exit\n5. Error logs\n6.Warning logs\n7.Info logs\n8.Display all logs", false);
            switch (choose)
            {
                case "0":
                    LogService.ErrorLog("0 geçerli bir değer değildir!!");
                    break;
                case "1":
                    AddItem();
                    break;
                case "2":
                    SellItem();
                    break;
                case "3":
                    CashInfo();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                case "5":
                    LogService.ShowErrorLogList();
                    break;
                case "6":
                    LogService.ShowWarningLogList();
                    break;
                case "7":
                    LogService.ShowInfoLogList();
                    break;
                case "8":
                    LogService.ShowAllLogList();
                    break;

                default:
                    //Log warning = new Log(LogType.Warning, "Lütfen belirtilen değerlerden birini giriniz!!");
                    //Console.WriteLine(warning.ToString());
                    LogService.WarningLog("Lütfen belirtilen değerlerden birini giriniz!!");
                    //ReturnToMenu();
                    break;
            }
        }
    
    
    
}

static void ReturnToMenu(string message = "Menüye dönmek için ENTER")
{ 
    Console.WriteLine(message);
    Console.ReadLine();
    Menu();
}

static void CashInfo()
{
    ApplicationService service = new ApplicationService();

    var amount = service.CashAmount();
    var list = service.CashList();
    Console.WriteLine("Tarih \t\t\tTutar\t\tAçıklama");
    foreach(var k in list)
        Console.WriteLine($"{k._date.ToShortDateString()}\t\t{k._price}\t\t{k._exp}");

    Console.WriteLine("Güncel Kasa Bakiyesi : " + amount);
    ReturnToMenu();
}

static void SellItem()
{
    ApplicationService service = new ApplicationService();
    string itemName = TakeAnswer("Ürün adı : ");
    
    ushort amount = Convert.ToUInt16(TakeAnswer("Adet : "));

    GeneralAnswerType result = service.SellItem(itemName, amount);

    if(result.IsFault)
    {
        Console.WriteLine(result.faultMessage);
        TryAgain();
        SellItem();
        return;
    }
    ReturnToMenu();
}

static void AddItem()
{
    Console.Clear();
    string itemName = TakeAnswer("Ürün adı : ");
    double buyPrice = Convert.ToDouble(TakeAnswer("Alış fiyatı : "));
    double sellPrice = Convert.ToDouble(TakeAnswer("Satış fiyatı : "));
    ushort itemAmount = Convert.ToUInt16(TakeAnswer("Stok adedi : "));

    ApplicationService servis= new ApplicationService();
    GeneralAnswerType result = servis.AddItem(itemName,buyPrice,sellPrice,itemAmount);

    if(result.IsFault)
    {
        Console.WriteLine(result.faultMessage);
        TryAgain();
        AddItem();
        return;
    }
    ReturnToMenu();

}

static string TakeAnswer(string screenText,bool sameRow = true)
{
    if (sameRow)
        Console.Write(screenText);
    else
        Console.WriteLine(screenText);
    return Console.ReadLine();
}

static void TryAgain()
{
    Console.WriteLine("Tekrar denemek için ENTER!");
    Console.ReadLine();
}
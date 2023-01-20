using CashAndStockControlApp.Business.CashAggregate;
using CashAndStockControlApp.Business.LogAggregate;

Cash c = new Cash(OperationType.Income, DateTime.Now,"ürün satışı" , 1500);

Menu();

static void Menu()
{
    try
    {
        var choose = TakeAnswer("1. Add İtem\n2. Sell İtem\n3. Cash Info\n4. Exit\n5. Error logs\n6.Warning logs\n7.Info logs", false);
        switch (choose)
        {
            case "0":
                throw new Exception("Bu değeri asla girme!");
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
                
            default:
                //Log warning = new Log(LogType.Warning, "Lütfen belirtilen değerlerden birini giriniz!!");
                //Console.WriteLine(warning.ToString());
                LogService.WarningLog("Lütfen belirtilen değerlerden birini giriniz!!");
                ReturnToMenu();
                break;
        }
    }
    catch(Exception err)
    {
        LogService.ErrorLog("Hatalı tuşlama yaptınız!!");
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
    throw new NotImplementedException();
}

static void SellItem()
{
    throw new NotImplementedException();
}

static void AddItem()
{
    throw new NotImplementedException();
}

static string TakeAnswer(string screenText,bool sameRow = true)
{
    if (sameRow)
        Console.Write(screenText);
    else
        Console.WriteLine(screenText);
    return Console.ReadLine();
}
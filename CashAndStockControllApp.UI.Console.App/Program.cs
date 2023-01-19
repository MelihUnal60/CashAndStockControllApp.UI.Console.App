using CashAndStockControlApp.Business.CashAggregate;

Cash c = new Cash(OperationType.Income, DateTime.Now,"ürün satışı" , 1500);

Menu();

static void Menu()
{
    var choose = TakeAnswer("1. Add İtem\n2. Sell İtem\n3. Cash Info\n4. Exit",false);
    switch(choose)
    {
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
        default:
            ReturnToMenu();
            break;
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
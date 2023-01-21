using CashAndStockControlApp.Business.CashAggregate;
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

        public double CashAmount() => cashService.Amount();

        public IReadOnlyCollection<Cash> CashList() => cashService.CashList();

    }
}

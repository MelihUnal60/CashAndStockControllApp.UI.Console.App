using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashAndStockControlApp.Business
{
    public class GeneralAnswerType
    {
        public bool IsFault;
        public string faultMessage;
        public object data;

        public GeneralAnswerType(bool _isFault, string _faultMessage, object _data)
        {
            IsFault = _isFault;
            faultMessage = _faultMessage;
            data = _data;
        }
        public GeneralAnswerType(bool _isFault, string _faultMessage) : this(_isFault,_faultMessage, null)
        {
            
        }
        public GeneralAnswerType(bool _isFault, object _data) : this(_isFault, null, _data)
        {

        }
        public GeneralAnswerType(bool _isFault) : this(_isFault, null, null)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudDA
{
    public interface ICRUD: IDisposable
    {  
        List<Invoice> Search(string invoiceNum);
        List<Invoice> ShowAll();
        int Insert(string Number, string concept, string description, string total, string dateI, string dateF);
        int InsertPost(string request);
        bool Delete(string idInvoice); 

    }
}

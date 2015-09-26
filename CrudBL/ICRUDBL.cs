using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudBL
{
    public interface ICRUDBL: IDisposable
    {
        SearchResults Search(string invoiceNum);
        SearchResults ShowAll();
        IUDResults Insert(string Number, string concept, string description, string total, string dateI, string dateF);
        IUDResults InsertPost(string request);
        IUDResults Delete(string idInvoice); 
    }
}

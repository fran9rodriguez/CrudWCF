using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using CrudBL;

namespace CrudWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {      

        // TODO: Add your service operations here       
        
        [OperationContract]       
        SearchResults Search(string invoiceNum);

        [OperationContract]
        SearchResults ShowAll();

        [OperationContract]       
        IUDResults Insert(string Number, string concept, string description, string total, string dateI, string dateF);

        [OperationContract]
        IUDResults InsertPost(string request);

        [OperationContract]
        IUDResults Delete(string idInvoice); 
       
    }


    
}

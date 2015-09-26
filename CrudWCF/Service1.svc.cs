using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft.Json.Linq;
using CrudBL;
using System.Configuration;

namespace CrudWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.

    public class Service1 : IService1
    {


        #region ShowAll

        [WebInvoke(Method = "GET",
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "ShowAll")]
        public SearchResults ShowAll()
        {
            try
            {
                using (CrudBL.CrudBL bl = new CrudBL.CrudBL())
                {
                    SearchResults result = bl.ShowAll();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return new SearchResults(-1, ex.Message.ToString());
            }
        }

        #endregion

        #region Search

        /// <summary>
        /// 
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
        [WebInvoke(Method = "GET",
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "Search/{invoiceNum}")]
        public SearchResults Search(string invoiceNum)
        {
            try
            {
                using (CrudBL.CrudBL bl = new CrudBL.CrudBL())
                {
                    SearchResults result = bl.Search(invoiceNum);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return new SearchResults(-1, ex.Message.ToString());
            }
        }

        #endregion

        #region Insert

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Number"></param>
        /// <param name="concept"></param>
        /// <param name="description"></param>
        /// <param name="total"></param>
        /// <param name="dateI"></param>
        /// <param name="dateF"></param>
        /// <remarks>
        ///   http://localhost:50199/Service1.svc/Insert/2/235.61.279/fdfdfdfdfdfdfd/1345/2015-11-13/2015-11-13
        /// </remarks>
        [WebInvoke(Method = "GET",
                   ResponseFormat = WebMessageFormat.Json,
                   UriTemplate = "Insert/{Number}/{concept}/{description}/{total}/{dateI}/{dateF}")]
        public IUDResults Insert(string Number, string concept, string description, string total, string dateI, string dateF)
        {
            try
            {
                using (CrudBL.CrudBL bl = new CrudBL.CrudBL())
                {
                    IUDResults result = bl.Insert(Number, concept, description, total, dateI, dateF);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return new IUDResults(-1, ex.Message.ToString());
            }
        }

        #endregion

        #region InsertPost

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Number"></param>
        /// <param name="concept"></param>
        /// <param name="description"></param>
        /// <param name="total"></param>
        /// <param name="dateI"></param>
        /// <param name="dateF"></param>
        /// <remarks>
        ///   http://localhost:50199/Service1.svc/InsertPost
        ///   {"idInvoice":12,"Number":1,"Concept":"235.61.278","Description":"Payment Kantoor Utrecht","total":1345,"dateI":"\/Date(1443280786427+0200)\/","dateF":"\/Date(1447421394063+0100)\/","InvoiceLines":[{"idLine":4,"rIdInvoice":12,"sDesc":"Line 1","total":1345}]}
        /// </remarks>
        [WebInvoke(Method = "POST",
                   ResponseFormat = WebMessageFormat.Json,
                   RequestFormat = WebMessageFormat.Json,
                   UriTemplate = "InsertPost")]
        public IUDResults InsertPost(string request)
        {
            try
            {
                using (CrudBL.CrudBL bl = new CrudBL.CrudBL())
                {
                    IUDResults result = bl.InsertPost(request);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return new IUDResults(-1, ex.Message.ToString());
            }
        }

        #endregion

        #region Delete

        [WebInvoke(Method = "GET",
                   ResponseFormat = WebMessageFormat.Json,
                   UriTemplate = "Delete/{idInvoice}")]
        public IUDResults Delete(string idInvoice)
        {
            try
            {
                using (CrudBL.CrudBL bl = new CrudBL.CrudBL())
                {
                    IUDResults result = bl.Delete(idInvoice);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return new IUDResults(-1, ex.Message.ToString());
            }

        }

        #endregion

    }
}

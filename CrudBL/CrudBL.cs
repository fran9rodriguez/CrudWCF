using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudDA;
using System.Configuration;

namespace CrudBL
{
    public class CrudBL: ICRUDBL
    {

        //source of data
        static int idSource = Int32.Parse(ConfigurationManager.AppSettings["dataSource"].ToString());
        ICRUD crudClass = Factory.Get(idSource);

        #region ShowAll

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public SearchResults ShowAll()
        {
            SearchResults results = new SearchResults();
            try
            {
                
                List<Invoice> lInvoices = crudClass.ShowAll();
                results = new SearchResults(-1, "OK", lInvoices);

                return results;
            }
            catch (Exception e)
            {
                results = new SearchResults(1, e.Message, null);
            }

            return results;
        }

        #endregion

        #region Search

        /// <summary>
        /// 
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>

        public SearchResults Search(string invoiceNum)
        {
            SearchResults results = new SearchResults();
            try
            {

                List<Invoice> lInvoices = crudClass.Search(invoiceNum);
                results = new SearchResults(-1, "OK", lInvoices);

                return results;
            }
            catch (Exception e)
            {
                results = new SearchResults(1, e.Message, null);
            }

            return results;
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

        public IUDResults Insert(string Number, string concept, string description, string total, string dateI, string dateF)
        {
            IUDResults results = new IUDResults();
            try
            {

                int idInvoice = crudClass.Insert(Number, concept, description, total, dateI, dateF);
                results = new IUDResults(-1, "OK", idInvoice);

                return results;
            }
            catch (Exception e)
            {
                results = new IUDResults(1, e.Message);
            }

            return results;
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

        public IUDResults InsertPost(string request)
        {
            IUDResults results = new IUDResults();
            try
            {

                int idInvoice = crudClass.InsertPost(request);
                results = new IUDResults(-1, "OK", idInvoice);

                return results;
            }
            catch (Exception e)
            {
                results = new IUDResults(1, e.Message);
            }

            return results;
        }

        #endregion

        #region Delete

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idInvoice"></param>
        /// <returns></returns>
        public IUDResults Delete(string idInvoice)
        {
            IUDResults results = new IUDResults();
            try
            {

                bool bDelete = crudClass.Delete(idInvoice);

                if(bDelete) results = new IUDResults(-1, "OK", 1);
                else results = new IUDResults(2, "ID NOT FOUND", 0);

                return results;
            }
            catch (Exception e)
            {
                results = new IUDResults(1, e.Message);
            }

            return results;

        }

        #endregion

        #region IDisposable

        void IDisposable.Dispose()
        {
            Close();
        }
        public void Close()
        {
            // Do what's necessary to close the file
            System.GC.SuppressFinalize(this);
        }

        #endregion

    }
}

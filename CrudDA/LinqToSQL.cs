using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CrudDA
{
    public class LinqToSQL:ICRUD
    {

        #region ShowAll

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Invoice> ShowAll()
        {
            List<Invoice> lInvoices = new List<Invoice>();
            using (InvoiceClassesDataContext dc = new InvoiceClassesDataContext())
            {
                var dataOptions = new System.Data.Linq.DataLoadOptions();
                dataOptions.LoadWith<Invoice>(ca => ca.InvoiceLines);
                dc.LoadOptions = dataOptions;

                var rows = from myRow in dc.Invoices
                           select myRow;

                lInvoices = rows.ToList();
            }

            return lInvoices;
        }

        #endregion

        #region Search

        /// <summary>
        /// 
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
        public List<Invoice> Search(string invoiceNum)
        {
            List<Invoice> lInvoices = new List<Invoice>();
            using (InvoiceClassesDataContext dc = new InvoiceClassesDataContext())
            {
                var dataOptions = new System.Data.Linq.DataLoadOptions();
                dataOptions.LoadWith<Invoice>(ca => ca.InvoiceLines);
                dc.LoadOptions = dataOptions;

                var rows = from myRow in dc.Invoices
                           where myRow.Number == Int32.Parse(invoiceNum)
                           select myRow;

                lInvoices = rows.ToList();
            }

            return lInvoices;
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
        /// <returns></returns>
        public int Insert(string Number, string concept, string description, string total, string dateI, string dateF)
        {

            using (InvoiceClassesDataContext dc = new InvoiceClassesDataContext())
            {
                Invoice i = new Invoice();
                i.Number = Int32.Parse(Number);
                i.Concept = concept;
                i.Description = description;
                i.total = Int32.Parse(total);
                i.dateI = DateTime.Parse(dateI);
                i.dateF = DateTime.Parse(dateF);
                dc.Invoices.InsertOnSubmit(i);
                dc.SubmitChanges();
                return i.idInvoice;
            }

        }

        #endregion

        #region InsertPost

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public int InsertPost(string request)
        {
            //string auxRequest = "{\"idInvoice\":12,\"Number\":1,\"Concept\":\"235.61.278\",\"Description\":\"Payment Kantoor Utrecht\",\"total\":1345,\"dateI\":\"\\/Date(1443280786427+0200)\\/\",\"dateF\":\"\\/Date(1447421394063+0100)\\/\",\"InvoiceLines\":[{\"idLine\":4,\"rIdInvoice\":12,\"sDesc\":\"Line 1\",\"total\":1345}]}";
            //JToken jsonRequest = JToken.Parse(auxRequest);

            JToken jsonRequest = JToken.Parse(request);

            using (InvoiceClassesDataContext dc = new InvoiceClassesDataContext())
            {
                int idInvoice = -1;

                Invoice i = new Invoice();
                i.Number = Int32.Parse(jsonRequest["Number"].ToString());
                i.Concept = jsonRequest["Concept"].ToString();
                i.Description = jsonRequest["Description"].ToString();
                i.total = Int32.Parse(jsonRequest["total"].ToString());
                i.dateI = DateTime.Parse(jsonRequest["dateI"].ToString());
                i.dateF = DateTime.Parse(jsonRequest["dateF"].ToString());
                dc.Invoices.InsertOnSubmit(i);
                dc.SubmitChanges();
                idInvoice = i.idInvoice;

                JArray lines = JArray.Parse(jsonRequest["InvoiceLines"].ToString());
                foreach (var line in lines)
                {
                    InvoiceLine iLine = new InvoiceLine();
                    iLine.rIdInvoice = idInvoice;
                    iLine.sDesc = line["sDesc"].ToString();
                    iLine.total = Int32.Parse(line["total"].ToString());
                    dc.InvoiceLines.InsertOnSubmit(iLine);
                }

                try
                {
                    dc.SubmitChanges();
                    return idInvoice;
                }
                catch (Exception ex)
                {
                    bool bDelete = Delete(idInvoice.ToString());
                    return -1;
                }
            }
        }

        #endregion

        #region Delete

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idInvoice"></param>
        /// <returns></returns>
        public bool Delete(string idInvoice)
        {
            using (InvoiceClassesDataContext dc = new InvoiceClassesDataContext())
            {
                var dataOptions = new System.Data.Linq.DataLoadOptions();
                dataOptions.LoadWith<Invoice>(ca => ca.InvoiceLines);
                dc.LoadOptions = dataOptions;

                var deleteOrderDetails =
                    from details in dc.Invoices
                    where details.idInvoice == Int32.Parse(idInvoice)
                    select details;

                foreach (var invoice in deleteOrderDetails)
                {
                    dc.Invoices.DeleteOnSubmit(invoice);

                    foreach (var invoiceL in invoice.InvoiceLines)
                    {
                        dc.InvoiceLines.DeleteOnSubmit(invoiceL);
                    }
                }

                try
                {
                    dc.SubmitChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

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

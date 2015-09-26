using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudDA;

namespace CrudBL
{
    public class SearchResults
    {
        public int idError { get; set; }
        public string errorDescription { get; set; }  
        public int nResults { get; set; }
        public List<Invoice> lInvoices { get; set; }

        public SearchResults() { }

        public SearchResults(int pidError, string perrorDescription, List<Invoice> plInvoices) 
        {
            idError = pidError;
            errorDescription = perrorDescription;
            nResults = 0;
            lInvoices = new List<Invoice>();
            if (plInvoices != null)
            {
                nResults = plInvoices.Count;
                lInvoices = plInvoices;
            }
        }

        public SearchResults(int pidError, string perrorDescription)
        {
            idError = pidError;
            errorDescription = perrorDescription;
            nResults = 0;
            lInvoices = new List<Invoice>();
        }
       
    }
}

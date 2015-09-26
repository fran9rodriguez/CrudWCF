using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudBL
{
    public class IUDResults
    {

        public int idError { get; set; }
        public string errorDescription { get; set; }          
        public int idRow { get; set; }

        public IUDResults() { }

        public IUDResults(int pidError, string perrorDescription, int pidRow) 
        {
            idError = pidError;
            errorDescription = perrorDescription;
            idRow = pidRow;
           
        }

        public IUDResults(int pidError, string perrorDescription)
        {
            idError = pidError;
            errorDescription = perrorDescription;
            idRow = -1;
        }

    }
}

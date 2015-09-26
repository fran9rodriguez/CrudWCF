using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudDA
{
    public static class Factory
    {
        /// <summary>
        /// Decides which class to instantiate.
        /// </summary>
        public static ICRUD Get(int id)
        {
            switch (id)
            {
                case 1:
                    return new LinqToSQL();                              
                default:
                    return new LinqToSQL();
            }
        }
    }

}

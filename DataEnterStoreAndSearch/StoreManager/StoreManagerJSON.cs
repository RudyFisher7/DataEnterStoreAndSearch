using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEnterStoreAndSearch.StoreManager
{
    /// <summary>
    /// Manages a JSON store. Able to perform relevent searches and give back results.
    /// </summary>
    public class StoreManagerJSON : IStoreManager
    {
        /// <summary>
        /// Searches the store at the given path for the given department, and puts
        /// the results in the given ArrayList
        /// </summary>
        /// <param name="path">The path to the store to search</param>
        /// <param name="department">The department to search for</param>
        /// <param name="results">The results matching the needle</param>
        public void SearchStoreForDepartment(string path, string department, ArrayList results)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Searches the store at the given path for the given idNumber, and puts
        /// the results in the given ArrayList
        /// </summary>
        /// <param name="path">The path to the store to search</param>
        /// <param name="idNumber">The idNumber to search for</param>
        /// <param name="results">The results matching the needle</param>
        public void SearchStoreForIDNumber(string path, int idNumber, ArrayList results)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Searches the store at the given path for the given name, and puts
        /// the results in the given ArrayList
        /// </summary>
        /// <param name="path">The path to the store to search</param>
        /// <param name="name">The name to search for</param>
        /// <param name="results">The results matching the needle</param>
        public void SearchStoreForName(string path, string name, ArrayList results)
        {
            throw new NotImplementedException();
        }
    }
}

using DataEnterStoreAndSearch.StoreManager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEnterStoreAndSearch.Controller
{
    /// <summary>
    /// Controls this app.
    /// </summary>
    public class ControllerJSON : IController
    {
        private IStoreManager storeManager;

        public ControllerJSON()
        {
            storeManager = new StoreManagerJSON();
        }

        /// <summary>
        /// Searches the store at the given path for the given needle, and puts
        /// the results in the given ArrayList
        /// </summary>
        /// <param name="path">The path to the store to search</param>
        /// <param name="needle">The needle to search for</param>
        /// <param name="results">The results matching the needle</param>
        /// <see cref="IController.SearchStore(string, string, ArrayList)"/>
        public void SearchStore(string path, string needle, ArrayList results)
        {
            int idNumber = 0;
            if (int.TryParse(needle, out idNumber))
            {
                storeManager.SearchStoreForIDNumber(path, idNumber, results);
            }
            else
            {
                storeManager.SearchStoreForName(path, needle, results);

                if (results.Count == 0)
                {
                    storeManager.SearchStoreForDepartment(path, needle, results);
                }
            }
        }

        public bool WriteToStore(string path, string name, int idNumber, string department)
        {
            return storeManager.WriteToStore(path, name, idNumber, department);
        }
    }
}

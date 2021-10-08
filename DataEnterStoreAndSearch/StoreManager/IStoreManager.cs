using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEnterStoreAndSearch.StoreManager
{
    /// <summary>
    /// Defines the public abstract interface for StoreController classes
    /// </summary>
    public interface IStoreManager
    {
        /// <summary>
        /// Searches the store at the given path for the given name, and puts
        /// the results in the given ArrayList
        /// </summary>
        /// <param name="path">The path to the store to search</param>
        /// <param name="name">The name to search for</param>
        /// <param name="results">The results matching the needle</param>
        void SearchStoreForName(string path, string name, ArrayList results);

        /// <summary>
        /// Searches the store at the given path for the given idNumber, and puts
        /// the results in the given ArrayList
        /// </summary>
        /// <param name="path">The path to the store to search</param>
        /// <param name="idNumber">The idNumber to search for</param>
        /// <param name="results">The results matching the needle</param>
        void SearchStoreForIDNumber(string path, int idNumber, ArrayList results);

        /// <summary>
        /// Searches the store at the given path for the given department, and puts
        /// the results in the given ArrayList
        /// </summary>
        /// <param name="path">The path to the store to search</param>
        /// <param name="department">The department to search for</param>
        /// <param name="results">The results matching the needle</param>
        void SearchStoreForDepartment(string path, string department, ArrayList results);

        /// <summary>
        /// Adds the given information to the store.
        /// </summary>
        /// <param name="path">the store's path</param>
        /// <param name="name">The name to add</param>
        /// <param name="idNumber">The idNumber to add</param>
        /// <param name="department">the department to add</param>
        /// <returns>True if successfully added, otherwise false</returns>
        bool WriteToStore(string path, string name, int idNumber, string department);
    }
}

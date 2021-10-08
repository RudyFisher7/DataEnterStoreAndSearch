using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEnterStoreAndSearch.Controller
{
    /// <summary>
    /// Defines the public abstract interface for controller classes.
    /// </summary>
    public interface IController
    {

        /// <summary>
        /// Searches the store at the given path for the given needle, and puts
        /// the results in the given ArrayList
        /// </summary>
        /// <param name="path">The path to the store to search</param>
        /// <param name="needle">The needle to search for</param>
        /// <param name="results">The results matching the needle</param>
        void SearchStore(string path, string needle, ArrayList results);

        /// <summary>
        /// Writes to the store.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <param name="idNumber"></param>
        /// <param name="department"></param>
        bool WriteToStore(string path, string name, int idNumber, string department);
    }
}

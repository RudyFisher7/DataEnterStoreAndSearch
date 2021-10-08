using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        /// Adds the given information to the store.
        /// </summary>
        /// <param name="path">the store's path</param>
        /// <param name="name">The name to add</param>
        /// <param name="idNumber">The idNumber to add</param>
        /// <param name="department">the department to add</param>
        /// <returns>True if successfully added, otherwise false</returns>
        public bool WriteToStore(string path, string name, int idNumber, string department)
        {
            bool result = true;
            DataClass dataToAdd = new DataClass(name, idNumber, department);
            string json = string.Empty;
            Dictionary<int, DataClass> storeData = new Dictionary<int, DataClass>();

            if (StoreExists(path))
            {
                storeData = ReadDataFromStore(path);

                if (storeData.ContainsKey(idNumber))
                {
                    result = false;
                }
                else
                {
                    storeData.Add(idNumber, dataToAdd);
                }
            }
            else
            {
                storeData.Add(idNumber, dataToAdd);
            }

            WriteDataToStore(path, storeData);

            return result;
        }

        /// <summary>
        /// Searches the store at the given path for the given department, and puts
        /// the results in the given ArrayList
        /// </summary>
        /// <param name="path">The path to the store to search</param>
        /// <param name="department">The department to search for</param>
        /// <param name="results">The results matching the needle</param>
        public void SearchStoreForDepartment(string path, string department, ArrayList results)
        {
            Dictionary<int, DataClass> storeData = ReadDataFromStore(path);

            using (Dictionary<int, DataClass>.ValueCollection.Enumerator valueEnumerator = storeData.Values.GetEnumerator())
            {
                while (valueEnumerator.MoveNext())
                {
                    DataClass currentData = valueEnumerator.Current;
                    if (currentData.Department == department)
                    {
                        results.Add(currentData);
                    }
                }
            }
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
            Dictionary<int, DataClass> storeData = ReadDataFromStore(path);

            if (storeData.ContainsKey(idNumber))
            {
                results.Add(storeData[idNumber]);
            }
        }

        /// <summary>
        /// Searches the store at the given path for the given name, and puts
        /// the results in the given ArrayList. O(N) time complexity if results
        /// doesn't have to grow.
        /// </summary>
        /// <param name="path">The path to the store to search</param>
        /// <param name="name">The name to search for</param>
        /// <param name="results">The results matching the needle</param>
        public void SearchStoreForName(string path, string name, ArrayList results)
        {
            Dictionary<int, DataClass> storeData = ReadDataFromStore(path);

            using (Dictionary<int, DataClass>.ValueCollection.Enumerator valueEnumerator = storeData.Values.GetEnumerator())
            {
                while (valueEnumerator.MoveNext())
                {
                    DataClass currentData = valueEnumerator.Current;
                    if (currentData.Name == name)
                    {
                        results.Add(currentData);
                    }
                }
            }
        }

        /// <summary>
        /// Checks if the store exists at the given path.
        /// </summary>
        /// <param name="path">The path the store should exist at</param>
        /// <returns>True if it exists, otherwise false</returns>
        private bool StoreExists(string path)
        {
            return File.Exists(path);
        }

        /// <summary>
        /// Creates a store at the given path.
        /// </summary>
        /// <param name="path">The path to create the store</param>
        private void CreateStore(string path)
        {
            File.Create(path).Close();
        }

        /// <summary>
        /// Reads all the data from the store at the given path.
        /// </summary>
        /// <param name="path">The path the store is at</param>
        /// <returns>The resulting data as type Dictionary<int, DataClass></returns>
        private Dictionary<int, DataClass> ReadDataFromStore(string path)
        {
            string json = string.Empty;

            using (StreamReader reader = new StreamReader(path))
            {
                json = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<Dictionary<int, DataClass>>(json);
        }

        /// <summary>
        /// Writes the given data to the store found at the given path.
        /// </summary>
        /// <param name="path">The path the store is at</param>
        /// <param name="storeData">The data to write</param>
        private void WriteDataToStore(string path, Dictionary<int, DataClass> storeData)
        {
            string json = string.Empty;

            json = JsonConvert.SerializeObject(storeData);

            File.WriteAllText(path, json);
        }
    }
}

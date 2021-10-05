using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEnterStoreAndSearch
{
    public class DataClass
    {
        public string Name { get; set; }
        public int IDNumber { get; set; }
        public string Department { get; set; }

        public DataClass(string inName, int inIDNumber, string inDepartment)
        {
            Name = inName;
            IDNumber = inIDNumber;
            Department = inDepartment;
        }
    }
}

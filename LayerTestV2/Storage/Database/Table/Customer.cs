using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Storage.Database.Table
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Displayname { get; set; }
        public string ImgFilePath { get; set; }
        public string Password { get; set; }
    }
}

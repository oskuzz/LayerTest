using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DBLayer.Database.Tables
{
    public class Books
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }

        public int CreatorID { get; set; }

        public Creators creator { get; set; }
    }
}

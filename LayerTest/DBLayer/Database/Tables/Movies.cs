using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBLayer.Database.Tables
{
    
    public class Movies
    {
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }

        public int CreatorID { get; set; }

        public Creators creator { get; set; }

    }
}

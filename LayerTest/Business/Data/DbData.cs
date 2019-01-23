using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersistenceLayer.DBContext;

namespace Business.Data
{  
    public class DbData
    {
        public string test()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Books.ToList().ToString();

            }
        }
    }
}

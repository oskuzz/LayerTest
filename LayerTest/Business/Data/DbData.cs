using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersistenceLayer.DBContext;
using DBLayer.Database.Tables;

namespace Business.Data
{  
    public class DbData
    {
        public List<Books> test()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Books.ToList();

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistence.DBContext;
using Database.Database.Tables;

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

        public List<Movies> test2()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Movies.ToList();

            }
        }
    }
}

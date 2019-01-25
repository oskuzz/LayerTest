using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Database.Tables;
using Persistence.DBContext;

namespace Business.Logic
{
    public class UserActions
    {

        public List<Customer> getUser(string huuhtista)
        {
            using (var dog = new ApplicationDbContext())
            {
                var getUser = dog.Customer
                    .Where(c => c.UserName == huuhtista)
                    .ToList();

                return getUser;
            }
        }

    }
}

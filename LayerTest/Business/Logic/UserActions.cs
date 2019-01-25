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

        public List<Customer> getUser(string userName, string password)
        {
            using (var dog = new ApplicationDbContext())
            {
                var user = dog.Customer
                    .Where(c => c.UserName == userName & c.Password == password)
                    .ToList();

                foreach (var u in user)
                {
                    if (u.UserName.Equals(userName) && u.Password.Equals(password))
                    {
                        return user;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            return null;
        }

    }
}

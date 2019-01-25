using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Presentation.Controllers;
using Database.Database.Tables;
using Persistence.DBContext;

namespace Business.Logic
{
    public class UserActions
    {

        public List<Customer> N()
        {
            DefaultController controller = new DefaultController();

            var huuhtista = controller.asd;

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

using DataAccess.Database.AppDbContext;
using DataAccess.Database.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class CustomerActions
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        public Customer GetCustomer(string un, string pw)
        {
            var user = db.Customer
                .Where(c => c.Username == un & c.Password == pw) as Customer;
            return user;
        }

        public List<Customer> getAllCustomers()
        {
            var user = db.Customer.ToList();
            return user;
        }

        public void addCustomer(string un, string pw)
        {
            Customer customer = new Customer();

            customer.Username = un;
            customer.Password = pw;

            db.Customer.Add(customer);
            db.SaveChanges();
        }
    }
}

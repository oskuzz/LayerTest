using Business.Logic.Log;
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

        public List<Customer> GetCustomer(string un)
        {
            var user = db.Customer
                .Where(c => c.Username.Contains(un)).ToList();

            WriteLog log = new WriteLog();
            log.writeLog("Käyttäjän hakeminen onnistui");
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

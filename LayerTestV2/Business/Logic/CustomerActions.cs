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
        public WriteLog log = new WriteLog();

        public List<Customer> GetCustomer(string un)
        {
            var user = db.Customer.Select(c => new Customer
            {
                CustomerID = c.CustomerID,
                Username = c.Username,
            })
                .Where(c => c.Username.Contains(un)).ToList();

            
            log.writeLog("Käyttäjän hakeminen onnistui: " + un, "searchCustomerLog.txt");
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
            if (db.SaveChanges() > 0)
            {
                log.writeLog("Käyttäjän luonti onnistui: " + un, "newCustomerLog.txt");
            } else
            {
                log.writeLog("käyttäjän luonti epäonnistui", "newCustomerLog.txt");
            }            
        }
    }
}

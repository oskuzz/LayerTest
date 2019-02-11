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

        public List<Customer> GetCustomer(string dn)
        {
            var user = db.Customer.Select(c => new Customer
            {
                CustomerID = c.CustomerID,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Displayname = c.Displayname,
            })
                .Where(c => c.Displayname.Contains(dn)).ToList();


            log.writeLog("Käyttäjän hakeminen onnistui: " + dn, "searchCustomerLog.txt");
            return user;
        }

        public List<Customer> getAllCustomers()
        {
            var user = db.Customer.Select(c => new Customer
            {
                CustomerID = c.CustomerID,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Displayname = c.Displayname,
            }).ToList();
            return user;
        }

        public void addCustomer(string fn, string ln, string pw)
        {
            Customer customer = new Customer();

            var dn = fn + " " + ln;

            customer.FirstName = fn;
            customer.LastName = ln;
            customer.Displayname = dn;
            customer.Password = pw;

            db.Customer.Add(customer);
            if (db.SaveChanges() > 0)
            {
                log.writeLog("Käyttäjän luonti onnistui: " + dn, "newCustomerLog.txt");
            }
            else
            {
                log.writeLog("käyttäjän luonti epäonnistui", "newCustomerLog.txt");
            }
        }
    }
}

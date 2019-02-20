using Storage.Database.AppDbContext;
using Storage.Database.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Storage.Security;
using Storage.Log;


namespace Business.Logic
{
    public class CustomerActions : ICustomerService
    {
        public UserSecurity us = new UserSecurity();
        public ApplicationDbContext db = new ApplicationDbContext();
        public WriteLog log = new WriteLog();

        public List<Customer> GetCustomer(string dn)
        {
            try
            {
                var user = db.Customer.Select(c => new Customer
                {
                    CustomerID = c.CustomerID,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Displayname = c.Displayname,
                })
                    .Where(c => c.Displayname.Contains(dn)).ToList();
                log.writeLog("Käyttäjän hakeminen onnistui: " + dn);
                return user;
            }
            catch (NullReferenceException e)
            {
                log.writeLog(e.ToString());
                return null;
            }
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

        public bool login(string dn, string pw)
        {
            var user = db.Customer.ToList();

            foreach (var c in user)
            {
                if (c.Displayname.Equals(dn) && c.Password.Equals(us.MD5Hash(pw)))
                {
                    return true;
                }
            }
            return false;
        }

        public Customer addCustomer(string fn, string ln, string pw)
        {
            try
            {
                Customer customer = new Customer();

                var dn = fn + " " + ln;

                customer.FirstName = fn;
                customer.LastName = ln;
                customer.Displayname = dn;
                customer.ImgFilePath = "";
                customer.Password = us.MD5Hash(pw);

                db.Customer.Add(customer);
                db.SaveChanges();
                log.writeLog("Käyttäjän luonti onnistui: " + dn);
                return customer;
            }
            catch (NullReferenceException e)
            {
                log.writeLog("Käyttäjän luonti epäonnistui: " + e.ToString());
                return null;
            }
        }

        public bool removeCustomer(string dn)
        {
            try
            {
                var customer = GetCustomer(dn);

                db.Customer.Remove(customer[0]);
                db.SaveChanges();
                return true;
            }
            catch (NullReferenceException e)
            {
                log.writeLog("Käyttäjän poisto epäonnistui: " + e.ToString());
                return false;
            }
        }

        public string getLatestDisplayName()
        {
            try
            {
                var lastCustomer = getAllCustomers().LastOrDefault();
                Customer customer = new Customer
                {
                    Displayname = lastCustomer.Displayname,
            };
            return customer.Displayname;
            }
            catch (NullReferenceException e)
            {
                log.writeLog("Uusimman käyttäjän poisto epäonnistui: " + e.ToString());
                return null;
            }
        }
    }

    public interface ICustomerService
    {
        List<Customer> GetCustomer(string dn);
        List<Customer> getAllCustomers();
        bool login(string dn, string pw);
        Customer addCustomer(string fn, string ln, string pw);
        bool removeCustomer(string dn);
        string getLatestDisplayName();
    }
}

using Business.Logic.Log;
using DataAccess.Database.AppDbContext;
using DataAccess.Database.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

        public bool login(string dn, string pw)
        {
            var user = db.Customer.Select(c => new Customer
            {
                Displayname = c.Displayname,
                Password = c.Password,
            });

            foreach(var c in user)
            {
                if(c.Displayname.Equals(dn) && c.Password.Equals(pw))
                {
                    return true;
                }else
                {
                    return false;
                }

            }
            return false;
        }

        public void addCustomer(string fn, string ln, string pw)
        {
            Customer customer = new Customer();

            var dn = fn + " " + ln;

            customer.FirstName = fn;
            customer.LastName = ln;
            customer.Displayname = dn;
            customer.Password = MD5Hash(pw);

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

        public string MD5Hash(string input)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
                Byte[] res = md5.Hash;

                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < res.Length; i++)
                {
                    strBuilder.Append(res[i].ToString());
                }

                return strBuilder.ToString();
            }
        }
    }
}

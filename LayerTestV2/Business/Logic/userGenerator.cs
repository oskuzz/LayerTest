using Storage.Database.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class userGenerator
    {
        public CustomerActions AC = new CustomerActions();

        public void generateUsers(int value)
        {
            for (int j = 0; j < value; j++)
            {
                AC.addCustomer(random(),random(),random());
            }
        }

        public string random()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var stringChars = new char[random.Next(5, 15)];

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }
    }
}

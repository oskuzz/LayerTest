using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Security
{
    public class UserSecurity
    {
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Logic.Log
{
    public class WriteLog
    {
        public DateTime getDate()
        {
            return DateTime.Now;
        }

        public void writeLog(string logdata, string file)
        {

            Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string path = Environment.CurrentDirectory;

            System.IO.StreamWriter SW = new System.IO.StreamWriter(path + "../../../../../DataAccess/kuha_on_kala/kuha_ei_ole_kissa/" + file, true);
            SW.Write(getDate() + "\r\n" + logdata + "\r\n\r\n");
            SW.Close();
        }
    }
}
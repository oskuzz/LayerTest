using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Logic.Log
{
    public class WriteLog
    {
        public String getDate()
        {
            DateTime dateTime = DateTime.Now;

            var dateString = dateTime.ToString("dd.MM.yyyy HH.mm.ss");

            return dateString;
        }

        public void writeLog(string logdata, string file)
        {

            Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string path = Environment.CurrentDirectory;

            System.IO.StreamWriter SW = new System.IO.StreamWriter(path + "../../../../../DataAccess/Log/Logs/" + file, true);
            SW.Write(getDate() + "\r\n" + logdata + "\r\n\r\n");
            SW.Close();
        }
    }
}
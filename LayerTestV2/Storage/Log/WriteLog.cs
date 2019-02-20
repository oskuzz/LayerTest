using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Storage.Log
{
    public class WriteLog
    {
        public String getDate()
        {
            DateTime dateTime = DateTime.Now;

            var dateString = dateTime.ToString("dd.MM.yyyy HH.mm.ss");

            return dateString;
        }

        public void writeLog(string logdata)
        {

            Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string path = Environment.CurrentDirectory;

            System.IO.StreamWriter SW = new System.IO.StreamWriter(path + "../../../../../Storage/Log/Logs/LayerTester.log", true);
            SW.Write(getDate() + "\r\n" + logdata + "\r\n\r\n");
            SW.Close();
        }
    }
}
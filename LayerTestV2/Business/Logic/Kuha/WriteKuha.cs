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

        public void writeLog(string logdata)
        {

            Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string path = Environment.CurrentDirectory;

            //C:\Users\Julius Kinnarinen\Desktop\GitProjects\LayerTest\LayerTestV2\Presentation\bin\Debug\netcoreapp2.2

            System.IO.StreamWriter SW = new System.IO.StreamWriter(path + "../../../../../DataAccess/kuha_on_kala/kuha_ei_ole_kissa/searchCustomerLog.txt", true);

            //"C:/Users/Julius Kinnarinen/Desktop/GitProjects/LayerTest/LayerTestV2/DataAccess/kuha_on_kala/kuha_ei_ole_kissa/searchCustomerLog.txt"

            SW.Write(getDate() + "\r\n" + logdata + "\r\n\r\n" + path);
            SW.Close();

            //System.IO.File.WriteAllLines("C:/Users/Julius Kinnarinen/Desktop/GitProjects/LayerTest/LayerTestV2/DataAccess/kuha_on_kala/kuha_ei_ole_kissa/searchCustomerLog.txt", logdata);
            //C:\Program Files\Log\Logs\newCustomerLog.txt
        }
    }
}
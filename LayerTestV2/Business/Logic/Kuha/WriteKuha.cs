using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Logic.Log
{
    public class WriteLog
    {
        public void writeLog(string logdata)
        {
            System.IO.StreamWriter("C:/Users/osku0/Desktop/Projects/Git/LayerTest/LayerTestV2/DataAccess/Log/Logs/newCustomerLog.txt", logdata + "\n");
            //C:\Program Files\Log\Logs\newCustomerLog.txt
        }
    }
}
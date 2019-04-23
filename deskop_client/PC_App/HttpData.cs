using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_App
{
    public class HttpData
    {
        public HttpData()
        {
            confData = new List<string>();
            sensorData = new List<List<string>>();
        }
        public List<string> confData;
        public List<List<string>> sensorData;
        public void Clear()
        {
            confData.Clear();
            sensorData.Clear();
        }

    }
}

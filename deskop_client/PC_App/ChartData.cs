using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_App
{
    public class ChartData
    {
        public ChartData(int timerPeroid, int id, string name)
        {
            mValues = new List<double>();
            mId = id;
            mName = name;
            dataPerMinute = 60 * 1000 / timerPeroid;
        }
        private int dataPerMinute;
        private int mId;
        private string mName;
        private List<double> mValues;
        public void AddToList(double value)
        {
            if (mValues.Count < dataPerMinute)
            {
                mValues.Add(value);
            }
            else
            {
                mValues.RemoveAt(0);
                mValues.Add(value);
            }
        }
        public string GetName()
        {
            return mName;
        }
        public List<double> GetData()
        {
            return mValues;
        }

    }
}

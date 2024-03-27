using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    public class PKTReqLogin
    {
        public short IDLength;
        public string ID;
        public short PWLength;
        public string PW;
    }

    public class PKTArrayTest1
    {
        public short Count;
        public List<int> ValueList = new List<int>();
    }

    public class CharItem
    {
        public int ItemCode;
        public int Level;
        public float Exp;
    }
    public class PKTArrayTest2
    {
        public short Count;
        public List<CharItem> ItemList = new List<CharItem>();
    }
}

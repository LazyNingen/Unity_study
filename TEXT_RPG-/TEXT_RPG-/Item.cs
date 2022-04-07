using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    public class Item
    {
        public string name;
        public string status;
        public Item(string _name, string _status)
        {
            name = _name;
            status = _status;
        }
    }
}

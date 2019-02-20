using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaForNumbers.Machine
{
    class PlugWire
    {
        public int side1 { get; set; }
        public int side2 { get; set; }

        public PlugWire(int _side1, int _side2)
        {
            this.side1 = _side1;
            this.side2 = _side2;
        }
    }
}

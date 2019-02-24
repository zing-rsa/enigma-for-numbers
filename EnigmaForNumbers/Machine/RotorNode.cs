using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaForNumbers.Machine
{
    class RotorNode
    {
        public int Offset { get; set; }

        public string Op { get; set; }

        public RotorNode( int _offset, string _op)
        {
            this.Offset = _offset;
            this.Op = _op;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaForNumbers.Machine
{
    class Reverser
    {

        private int[][] pairs;
        public int[][] Pairs
        {
            get { return pairs; }
            set { pairs = value; }
        }

        public Reverser(int[][] rotorConfig)
        {
            this.Pairs = rotorConfig;
        }

        public int Reverseback(int input)
        {
            //If 9 is a factor of input return 9, otherwise return input % 9.
            //This is done to prevent a 0 being returned (eg. 18 % 9 = 0) as 0 
            //is in fact equal to the 9th index
            input = input % 10;
            
            foreach (var pair in pairs)
            {
                if (pair[0] == input)
                {
                    return pair[1];
                }
                else if (pair[1] == input)
                {
                    return pair[0];
                }
            }

            return -1;
        }

    }
}

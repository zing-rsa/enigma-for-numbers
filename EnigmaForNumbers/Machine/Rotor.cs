using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaForNumbers.Machine
{
    class Rotor
    {

        private int rotorId;
        public int RotorID
        {
            get { return rotorId; }
            set { rotorId = value; }
        }

        private Dictionary<int, RotorNode> pairs;
        public Dictionary<int, RotorNode> Pairs
        {
            get { return pairs; }
            set { pairs = value; }
        }
        
        private int currentIndex;
        public int CurrentIndex
        {
            get { return currentIndex; }
            set
            {
                while(value < 0)
                {
                    value += 10;
                }
                
                currentIndex = value % 10;
            }
        }

        public Rotor(int _rotorId, Dictionary<int, RotorNode> _rotorConfig, int _currentindex)
        {
            this.RotorID = _rotorId;
            this.Pairs = _rotorConfig;
            this.CurrentIndex = _currentindex;
        }


        public int getOutput(int input, bool direction)
        {

            int output = 0;

            int temp = 0;

            RotorNode offsetter;

            int index;

            if (direction)
            {
                index = (input + currentIndex) % 10;
                

                offsetter = Pairs[index];

                switch (offsetter.Op)
                {
                    case "+":
                        return (input + offsetter.Offset) % 10;
                    case "-":
                        output = input - offsetter.Offset;

                        while (output < 0 )
                        {
                            output += 10;
                        }

                        return output;
                }
                
            }
            else {

                for (int i = 0; i <= 9; i++)
                {
                    switch (pairs[(i + currentIndex) % 10].Op)
                    {
                        case "+":
                            temp = i + pairs[(i + currentIndex) % 10].Offset;
                            break;
                        case "-":
                            temp = i - pairs[(i + currentIndex) % 10].Offset;

                            while (temp < 0)
                            {
                                temp += 10;
                            }

                            break;
                    }

                    temp %= 10;

                    if (temp == input)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }



        public void Rotate()
        {
            this.CurrentIndex++;
        }

        public void RotateBack()
        {
            this.CurrentIndex--;
        }

        public void RotateXTimes(int index)
        {
            this.CurrentIndex = index;
        }

        #region old
        /*
        private int rotorId;
        public int RotorID
        {
            get { return rotorId; }
            set { rotorId = value; }
        }

        private int currentIndex;
        public int CurrentIndex
        {
            get { return currentIndex; }
            set
            {
                currentIndex = value < 0 ? 8 : value % 9;
            }
        }

        private Dictionary<int, int> pairs;
        public Dictionary<int, int> Pairs
        {
            get { return pairs; }
            set { pairs = value; }
        }

        //input is always the same index, output always changes
        //When rotating, you need to change the value of each key value pair to increment.

        public Rotor(int rotorId, Dictionary<int, int> rotorConfig, int currentindex)
        {
            this.RotorID = rotorId;
            this.Pairs = rotorConfig;
            this.CurrentIndex = currentindex;
        }

        public int getOutput(int input, bool direction)
        {
            int output = 0;

            if (direction)
            {
                //if we are going through the rotor forwards
                input = input + currentIndex;

                //If 9 is a factor of input return 9, otherwise return input % 9.
                //This is done to prevent a 0 being returned (eg. 18 % 9 = 0) as 0 
                //is in fact equal to the 9th index
                input = input % 9 == 0 ? 9 : input % 9;

                return pairs[input];
            }
            else
            {
                //When we are looping back through the machine it will be going in reverse
                for (int i = 1; i <= 9; i++)
                {
                    if (input == pairs[i])
                    {
                        output = i - currentIndex;
                        while (output <= 0)
                        {
                            output += 9;
                        }

                        //If 9 is a factor of output, return 9, not 0
                        //Same as above
                        output = output % 9 == 0 ? 9 : output % 9;

                        return output;
                    }
                }
            }
            return -1;
        }

        public void Rotate()
        {
            this.CurrentIndex++;
        }

        public void RotateBack()
        {
            this.CurrentIndex--;
        }

        public void RotateXTimes(int index)
        {
            this.CurrentIndex = index;
        }
    */
        #endregion

    }
}

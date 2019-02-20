using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaForNumbers.Machine
{
    class EnigmaMachine
    {
        public Rotor Rotor1;
        public Rotor Rotor2;
        public Rotor Rotor3;
        private Reverser Reverse;
        private Plugboard plugboard;

        private int input;

        public int Input
        {
            get { return input; }
            set { input = value; }
        }

        private int output;

        public int Output
        {
            get { return output; }
            set { output = value; }
        }

        //private readonly Dictionary<int, int> rotor1   = new Dictionary<int, int> { { 0, 9 }, { 1, 8 }, { 2, 7 }, { 3, 6 }, { 4, 5 }, { 5, 4 }, { 6, 3 }, { 7, 2 }, { 8, 1 } };
        //private readonly Dictionary<int, int> rotor2   = new Dictionary<int, int> { { 0, 2 }, { 1, 3 }, { 2, 4 }, { 3, 5 }, { 4, 6 }, { 5, 7 }, { 6, 8 }, { 7, 9 }, { 8, 1 } };
        //private readonly Dictionary<int, int> rotor3   = new Dictionary<int, int> { { 0, 5 }, { 1, 4 }, { 2, 3 }, { 3, 2 }, { 4, 1 }, { 5, 9 }, { 6, 8 }, { 7, 7 }, { 8, 6 } };
        //private readonly Dictionary<int, int> rotor4   = new Dictionary<int, int> { { 0, 8 }, { 1, 9 }, { 2, 1 }, { 3, 2 }, { 4, 3 }, { 5, 4 }, { 6, 5 }, { 7, 6 }, { 8, 7 } };
        //private readonly Dictionary<int, int> rotor5   = new Dictionary<int, int> { { 0, 6 }, { 1, 5 }, { 2, 4 }, { 3, 3 }, { 4, 2 }, { 5, 1 }, { 6, 9 }, { 7, 8 }, { 8, 7 } };
        //private readonly Dictionary<int, int> reverse  = new Dictionary<int, int> { { 0, 1 }, { 1, 8 }, { 2, 5 }, { 3, 6 }, { 4, 2 }, { 5, 3 }, { 6, 9 }, { 7, 4 }, { 8, 7 } };

        private readonly Dictionary<int, int> rotor1 = new Dictionary<int, int> { { 1, 9 }, { 2, 8 }, { 3, 7 }, { 4, 6 }, { 5, 5 }, { 6, 4 }, { 7, 3 }, { 8, 2 }, { 9, 1 } };
        private readonly Dictionary<int, int> rotor2 = new Dictionary<int, int> { { 1, 2 }, { 2, 3 }, { 3, 4 }, { 4, 5 }, { 5, 6 }, { 6, 7 }, { 7, 8 }, { 8, 9 }, { 9, 1 } };
        private readonly Dictionary<int, int> rotor3 = new Dictionary<int, int> { { 1, 5 }, { 2, 4 }, { 3, 3 }, { 4, 2 }, { 5, 1 }, { 6, 9 }, { 7, 8 }, { 8, 7 }, { 9, 6 } };
        private readonly Dictionary<int, int> rotor4 = new Dictionary<int, int> { { 1, 8 }, { 2, 9 }, { 3, 1 }, { 4, 2 }, { 5, 3 }, { 6, 4 }, { 7, 5 }, { 8, 6 }, { 9, 7 } };
        private readonly Dictionary<int, int> rotor5 = new Dictionary<int, int> { { 1, 6 }, { 2, 5 }, { 3, 4 }, { 4, 3 }, { 5, 2 }, { 6, 1 }, { 7, 9 }, { 8, 8 }, { 9, 7 } };
        private readonly Dictionary<int, int> reverse = new Dictionary<int, int> { { 1, 1 }, { 2, 8 }, { 3, 5 }, { 4, 6 }, { 5, 2 }, { 6, 3 }, { 7, 9 }, { 8, 4 }, { 9, 7 } };

        private readonly HashSet<PlugWire> plugConfig = new HashSet<PlugWire>() {
            new PlugWire(1,6),
            new PlugWire(2,7),
            new PlugWire(3,8),
            new PlugWire(4,9)
        };

        public EnigmaMachine()
        {
            this.Rotor1 = new Rotor(1, rotor2, 0);
            this.Rotor2 = new Rotor(2, rotor3, 0);
            this.Rotor3 = new Rotor(3, rotor4, 0);
            this.Reverse = new Reverser(reverse);
            this.plugboard = new Plugboard(plugConfig);
        }

        public int Run(int input)
        {
            int temp = input;

            //Run the input through the plugboard, this
            //will switch the input with another number
            temp = plugboard.getOutput(temp);


            //First the signal goes through the first 3 rotors, 
            //each one spitting out a different output.
            temp = Rotor1.getOutput(temp, true);
            temp = Rotor2.getOutput(temp, true);
            temp = Rotor3.getOutput(temp, true);


            //Run the reversal here, this turns the wires back on the 
            //rotors again, to go through the rotors backwards
            temp = Reverse.Reverseback(temp);

            //Then the signal is reversed through the same 
            temp = Rotor3.getOutput(temp, false);
            temp = Rotor2.getOutput(temp, false);
            temp = Rotor1.getOutput(temp, false);

            //Once the algorithim has completed, the number goes through 
            //one last swap with another number in the plugboard
            temp = plugboard.getOutput(temp);

            //Rotate the rotors, 
            RotateRotors();

            return temp;
        }

        public void RotateRotors()
        {
            //Rotate the rotors. Each time the first rotor does a full 
            //revolution, the second rotor rotates once. Each time the second 
            //rotor does a full rotation, the third one rotates once.

            Rotor1.Rotate();
            if (Rotor1.CurrentIndex == 0)
            {
                Rotor2.Rotate();
                if (Rotor2.CurrentIndex == 0)
                {
                    Rotor3.Rotate();
                }
            }
        }

        public int[] getRotorPositions()
        {
            return new int[] { Rotor1.CurrentIndex, Rotor2.CurrentIndex, Rotor3.CurrentIndex };
        }

    }
}

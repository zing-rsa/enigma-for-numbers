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

        private readonly int[][] reverse  = { new int[] {0, 9 }, new int[] { 1, 8 }, new int[] { 2, 7 }, new int[] { 3, 5 }, new int[] { 4, 6 } }; 

        private readonly Dictionary<int, RotorNode> rotor1 = new Dictionary<int, RotorNode> {
            { 0, new RotorNode(3, "+") }, { 1, new RotorNode(4, "+") }, { 2, new RotorNode(2, "+") }, { 3, new RotorNode(2, "-") }, { 4, new RotorNode(4, "-") },
            { 5, new RotorNode(3, "-") }, { 6, new RotorNode(1, "+") }, { 7, new RotorNode(1, "+") }, { 8, new RotorNode(2, "-") }, { 9, new RotorNode(0, "+") }
        };

        private readonly Dictionary<int, RotorNode> rotor2 = new Dictionary<int, RotorNode> {
            { 0, new RotorNode(2, "+") }, { 1, new RotorNode(4, "-") }, { 2, new RotorNode(2, "+") }, { 3, new RotorNode(8, "+") }, { 4, new RotorNode(4, "+") },
            { 5, new RotorNode(5, "-") }, { 6, new RotorNode(3, "-") }, { 7, new RotorNode(2, "-") }, { 8, new RotorNode(2, "-") }, { 9, new RotorNode(0, "+") }
        };

        private readonly Dictionary<int, RotorNode> rotor3 = new Dictionary<int, RotorNode> {
            { 0, new RotorNode(0, "+") }, { 1, new RotorNode(2, "+") }, { 2, new RotorNode(3, "-") }, { 3, new RotorNode(5, "-") }, { 4, new RotorNode(2, "+") },
            { 5, new RotorNode(2, "+") }, { 6, new RotorNode(5, "+") }, { 7, new RotorNode(2, "-") }, { 8, new RotorNode(4, "-") }, { 9, new RotorNode(3, "+") }
        };

        private readonly HashSet<PlugWire> plugConfig = new HashSet<PlugWire>() {
            new PlugWire(1,6),
            new PlugWire(2,7),
            new PlugWire(3,8),
            new PlugWire(4,9),
            new PlugWire(5,0)
        };

        public EnigmaMachine()
        {
            this.Rotor1 = new Rotor(1, rotor1, 0);
            this.Rotor2 = new Rotor(2, rotor2, 0);
            this.Rotor3 = new Rotor(3, rotor3, 0);
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

            //Rotate the rotors
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

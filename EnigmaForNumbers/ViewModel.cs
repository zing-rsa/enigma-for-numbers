using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnigmaForNumbers.Common;
using EnigmaForNumbers.Machine;

namespace EnigmaForNumbers
{
    class ViewModel : INotifyPropertyChanged
    {
        public Command One { get; private set; }
        public Command Two { get; private set; }
        public Command Three { get; private set; }
        public Command Four { get; private set; }
        public Command Five { get; private set; }
        public Command Six { get; private set; }
        public Command Seven { get; private set; }
        public Command Eight { get; private set; }
        public Command Nine { get; private set; }
        public Command Clear { get; private set; }

        public Command Rotor3Up { get; set; }
        public Command Rotor3Down { get; set; }
        public Command Rotor2Up { get; set; }
        public Command Rotor2Down { get; set; }
        public Command Rotor1Up { get; set; }
        public Command Rotor1Down { get; set; }

        private EnigmaMachine Enigma;

        private int rotor1Index;

        public int Rotor1Index
        {
            get { return rotor1Index; }
            set
            {
                rotor1Index = value;
                this.OnPropertyChanged(nameof(Rotor1Index));
            }
        }

        private int rotor2Index;

        public int Rotor2Index
        {
            get { return rotor2Index; }
            set
            {
                rotor2Index = value;
                this.OnPropertyChanged(nameof(Rotor2Index));
            }
        }

        private int rotor3Index;

        public int Rotor3Index
        {
            get { return rotor3Index; }
            set
            {
                rotor3Index = value;
                this.OnPropertyChanged(nameof(Rotor3Index));
            }
        }

        private string output;
        public string Output
        {
            get { return this.output; }
            set
            {
                this.output = value;
                this.OnPropertyChanged(nameof(Output));
            }
        }

        private int input;
        public int Input
        {
            get { return input; }
            set { input = value; }
        }



        public ViewModel()
        {
            this.Enigma = new EnigmaMachine();

            One = new Command(() => { Input = 1; RunEnigma(); }, () => { return true; });
            Two = new Command(() => { Input = 2; RunEnigma(); }, () => { return true; });
            Three = new Command(() => { Input = 3; RunEnigma(); }, () => { return true; });
            Four = new Command(() => { Input = 4; RunEnigma(); }, () => { return true; });
            Five = new Command(() => { Input = 5; RunEnigma(); }, () => { return true; });
            Six = new Command(() => { Input = 6; RunEnigma(); }, () => { return true; });
            Seven = new Command(() => { Input = 7; RunEnigma(); }, () => { return true; });
            Eight = new Command(() => { Input = 8; RunEnigma(); }, () => { return true; });
            Nine = new Command(() => { Input = 9; RunEnigma(); }, () => { return true; });

            Rotor3Up = new Command(() => { Enigma.Rotor3.Rotate(); UpdateRotors(); }, () => { return true; });
            Rotor3Down = new Command(() => { Enigma.Rotor3.RotateBack(); UpdateRotors(); }, () => { return true; });
            Rotor2Up = new Command(() => { Enigma.Rotor2.Rotate(); UpdateRotors(); }, () => { return true; });
            Rotor2Down = new Command(() => { Enigma.Rotor2.RotateBack(); UpdateRotors(); }, () => { return true; });
            Rotor1Up = new Command(() => { Enigma.Rotor1.Rotate(); UpdateRotors(); }, () => { return true; });
            Rotor1Down = new Command(() => { Enigma.Rotor1.RotateBack(); UpdateRotors(); }, () => { return true; });

            Clear = new Command(() => { this.Output = ""; }, () => { return true; });

        }

        public void UpdateRotors()
        {
            Rotor3Index = Enigma.Rotor3.CurrentIndex;
            Rotor2Index = Enigma.Rotor2.CurrentIndex;
            Rotor1Index = Enigma.Rotor1.CurrentIndex;
        }

        public void RunEnigma()
        {
            Output += Enigma.Run(Input).ToString();
            UpdateRotors();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}

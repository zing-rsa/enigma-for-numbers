using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaForNumbers.Machine
{
    class Plugboard
    {

        public HashSet<PlugWire> plugConfig;

        public HashSet<int> unplugged;


        public Plugboard()
        {

        }

        public Plugboard(HashSet<PlugWire> plugconfig)
        {
            plugConfig = new HashSet<PlugWire>();
            unplugged = new HashSet<int>();

            for (int i = 1; i < 10; i++)
            {
                unplugged.Add(i);
            }

            foreach (var i in plugconfig)
            {
                plugIn(i);
            }
        }

        public void plugIn(PlugWire toPlugin)
        {
            if (!unplugged.Contains(toPlugin.side2) || !unplugged.Contains(toPlugin.side1))
            {
                throw new Exception(message: "One of those are already plugged in");
            }
            else
            {
                unplugged.Remove(toPlugin.side1);
                unplugged.Remove(toPlugin.side2);

                plugConfig.Add(toPlugin);
            }
        }

        public void unPlug(PlugWire toUnplug)
        {

            if (plugConfig.Contains(toUnplug))
            {
                this.unplugged.Add(toUnplug.side1);
                this.unplugged.Add(toUnplug.side2);

                plugConfig.Remove(toUnplug);
            }
        }


        public int getOutput(int input)
        {

            if (unplugged.Contains(input))
            {
                return input;
            }
            else
            {
                foreach (var pw in plugConfig)
                {
                    if (pw.side1 == input)
                    {
                        return pw.side2;
                    }
                    else if (pw.side2 == input)
                    {
                        return pw.side1;
                    }
                }
            }
            return -1;
        }
    }
}

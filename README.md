# EnigmaForNumbers
An Enigma machine that will encrypt numbers in a similar way to it used to encrypt letters.

I realised that the Germans would have had no way to encrypt numbers. 
If they needed to send a time or date, it would display in plain text.
So, 80 years later I have decided to produce an Enigma Machine which will encrypt numbers, it's a pleasure.

## How it works

The enigma machine consists of:
* a plugboard at the bottom
* 3 rotors (picked out of a pool of 5)
* a crazily wired circuit

### Plugboard

Each letter(in our case - number) has it's own female input plug. There are then 5 wires, which have a male connector on each end. 
This allows the wire to be plugged in to two letters/numbers at a time. The result is that when one number receives input, the input will 
flow through the wire, causing the number on the other side of the wire to light up. The swap occurs both at the beginning and the end of the cycle. 
For instance if the user presses the "2" button, and "2" is connected to "6", it will output "6". Conversely, if the machine is going 
to output a "6", it will now produce a "2".

### Rotors

Effectively, there is a box with 5 rotors. Each rotor has a electrode for each letter/number. In our case - 10 electrodes (0 - 9) . To make the machine work you 
required 3 rotors, so you would pick any 3 and insert them into your machine. Each rotor had different wiring.
The wiring inside the rotor connected an input electrode to an output. For instance, if a single rotor received an input at index(node) 3, 
depending on the wiring, it would then output a different index. 

The rotors, obviously, rotate. After each click of a letter, the rotor will rotate one index to the right. Once the first 
rotor has completed a full revolution, the second rotor will rotate once. Once the second has compeleted a revolution, 
the 3rd will rotate once.

This results in a change of the routing of the circuit each time a new letter is clicked. 

### Circuit

In the original machine, the circuit would flow as follows:

* User input
* Into the plugboard
 - From one input, to the output side of the wire
* From plugboard to the rotors
 - The current flows into the first rotor, through the second and through the third
 - Into a reversal "mechanism" which routes the curent back through each of the rotors again, backwards.
* Back into the plugboard, to be swapped once again
* Into the output display

Ours works similarly, but instead uses code in C#. 

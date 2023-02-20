using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoshamboLab
{
    public class Validator
    {
        public bool GetYN(string input)
        {
            if (input.ToLower() == "y" || input.ToLower() == "n")
            {
                return true;
            }
            else
            {
                Console.WriteLine("I do not understand that response. Please enter a valid option.");
                return false;
            }

        }
        public bool GetOtherPlayer(string name)
        {
            if (name == "RockPlayer" || name == "RandomPlayer")
            {
                return true;
            }
            else
            {
                Console.WriteLine("There are no opponents with that name. Please choose RockPlayer or RandomPlayer");
                return false;
            }

        }
        public bool GetRoshambo(string tryThrow)
        {
            if (tryThrow.ToLower().StartsWith("r") || tryThrow.ToLower().StartsWith("p") || tryThrow.ToLower().StartsWith("s"))
            {
                return true;
            }
            else
            {
                Console.WriteLine("that is not a valid throw! Please choose [r]ock, [p]aper, or [s]cissors.");
                return false;
            }

        }
    }
}

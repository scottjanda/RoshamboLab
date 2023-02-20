using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoshamboLab
{
    public abstract class Player
    {
        public abstract string Name { get; set; }
        public abstract string Value { get; set; }

        public abstract Roshambo GenerateRoshambo();
    }
    public class RockPlayer : Player
    {
        public override string Name { get; set; }
        public override string Value { get; set; }
        public static int Wins { get; set; }
        public static int Losses { get; set; }
        public static int Ties { get; set; }

        public override Roshambo GenerateRoshambo()
        {
            return Roshambo.rock;
        }
    }
    public class RandomPlayer : Player
    {
        public override string Name { get; set; }
        public override string Value { get; set; }
        public static int Wins { get; set; }
        public static int Losses { get; set; }
        public static int Ties { get; set; }

        static Random random = new Random();

        public override Roshambo GenerateRoshambo()
        {
            return (Roshambo)random.Next(Enum.GetNames(typeof(Roshambo)).Length);
        }
    }
    public class HumanPlayer : Player
    {
        public override string Name { get; set; }
        public override string Value { get; set; }
        public static int Wins { get; set; }
        public static int Losses { get; set; }
        public static int Ties { get; set; }

        public override Roshambo GenerateRoshambo()
        {
            switch (Value[0])
            //switch (Value.Substring(0, 1).ToLower())
            {
                case 'r':
                    return Roshambo.rock;

                case 'p':
                    return Roshambo.paper;

                case 's':
                    return Roshambo.scissors;

                default:
                    return Roshambo.rock;
            }
        }
    }
}

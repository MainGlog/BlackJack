using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee_Redo
{
    
    public class Dice
    {
        Random rand = new Random();
        private int number;
        public int GetNumber() => number;
        public void Roll()
        {
            number = rand.Next(0,5);
        }
    }
}

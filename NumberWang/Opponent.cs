using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberWang
{
    class Opponent : Player
    {
        public Opponent()
        { 
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
            if (randomNumber < 50)
            {
                Name = "Julie";
            }
            else
            {
                Name = "Mark";
            }
        }
    }
}



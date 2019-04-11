using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberWang
{
    class Opponent : Player
    {
        public string PosPronoun { get; }
        public string ThirdPronoun { get; }
        public Opponent()
        { 
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
            if (randomNumber < 50)
            {
                Name = "Julie";
                PosPronoun = "her";
                ThirdPronoun = "her";
            }
            else
            {
                Name = "Mark";
                PosPronoun = "his";
                ThirdPronoun = "him";
            }
        }
    }
}



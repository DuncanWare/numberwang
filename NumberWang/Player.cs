using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberWang
{
    class Player
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                switch (value.ToLower())
                {
                    case "chicken":
                        Console.WriteLine("Chicken?! Colosson's only weakness!");
                        break;
                    case "colosson":
                        Console.WriteLine("Colosson?! But I am Colosson? You are a mere innumerate mortal!");
                        name = "Innumerate Mortal";
                        break;
                    case "haydn":
                        Console.WriteLine("Oh yeah? And I'm Mozart...");
                        name = "Not Haydn";
                        break;
                    case "beth":
                        Console.WriteLine("Ah hullo, Beth, here to forecast spend?");
                        name = value;
                        break;
                    case "dylan":
                        Console.WriteLine("Dylan? I will call you J-Dylla...");
                        name = "J-Dylla";
                        break;
                    case "jacob":
                        Console.WriteLine("*** New email from Anglian RE: All the windows, they're all broken, every last one! ***");
                        name = value;
                        break;
                    case "andrew":
                        Console.WriteLine("Penghis Khaaaaaaan!");
                        name = "Peng";
                        break;
                    case "jamie":
                        Console.WriteLine("*** New email from RS Components RE: 'Electronics are dead, long live mechanical' ***");
                        name = value;
                        break;
                    case "mack":
                        Console.WriteLine("(Return of the Mack) come on\n" + "(Return of the Mack) oh my God\n" + "(You know that I'll be back) here I am\n" + "(Return of the Mack) once again\n" + "(Return of the Mack) pump up the world\n" + "(Return of the Mack) watch my flow\n" + "(You know that I'll be back) here I go\n");
                        name = value;
                        break;
                    default:
                        name = value;
                        break;
                    }
                }
            }
        public List<float> Guesses { get; set; } = new List<float>();
        public int Age;
        public int Score { get; set; }
    }
}

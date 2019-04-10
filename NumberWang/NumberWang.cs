using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberWang
{
    class NumberWang
    {
        public void Check(float guess, Player player)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
            if (player.Guesses.Contains(guess))
            {
                player.Score -= 1;
                Console.Beep(131, 400);
                Console.WriteLine("I'm afraid you've guessed {0} already, you lose a point! {1, 10} point(s)", guess, player.Score);
            }
            else if (guess == 2)
            {
                Console.Beep(131, 400);
                Console.WriteLine($"Oh dear! Remember, everyone, the number two is poisonous to humans - {player.Name} can wang no more and loses the game!\n" +
                    $"{player.Name}'s final score was {player.Score}\n" + "Good NumberWang!");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else if (guess == 42)
            {
                Console.WriteLine("So long and thanks for all the fish.");
                Console.ReadKey();
            }
            else if (randomNumber < 70)
            {
                player.Score += 1;
                Console.WriteLine("That's NumberWang! {0, 10} point(s)", player.Score);
                Console.Beep(784, 250);
            }
            else
            {
                Console.Beep(131, 1000);
                Console.WriteLine("That's not NumberWang. {0, 10} point(s)", player.Score);
            }
            player.Guesses.Add(guess);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NumberWang
{
    class Program
    {
        static void Main(string[] args)
        {
            PrepareConsole();
            GenerateTitle();
            NumberWang numberWang = new NumberWang();
            Player player = new Player();
            SetPlayerName(player);
            Opponent opponent = new Opponent();
            IntroOpponent(opponent);
            CheckPlayerAge(player, opponent);

            RoundOne(numberWang, player, opponent);
            RoundTwo(numberWang, player, opponent);
            RoundThree(numberWang, player, opponent);
            CallWinner(player, opponent);
            DeathWang(player, opponent);
            Goodbye();
            PlayAgain();
        }

        private static void PlayAgain()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Would you like another go? <Press any key to continue>");
            Console.ReadKey(true);
            string currentDirectory = AppContext.BaseDirectory;
            System.Diagnostics.Process.Start($@"{currentDirectory}\NumberWang.exe");
        }

        private static void PrepareConsole()
        {
            Console.Title = "NumberWang - The Console Game To Turn To If You're Not Sure Whether It Is NumberWang Or Not";
            Console.WindowHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.LargestWindowWidth;
        }

        private static void DeathWang(Player player, Opponent opponent)
        {
            if (player.Score == opponent.Score)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Bring out the gas chambers!\n" + "Today the chambers are filled with the gaseous form of the number 2, which as you may remember from chemistry class is poisonous to humans.\n");
                Console.WriteLine("<Press 'b' + 'Enter' to breathe> Time is of the essence!");
                System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
                stopwatch.Start();

                for (int i = 0; i < 10; i++)
                {
                    Console.ReadLine();
                }
                stopwatch.Stop();
                Thread.Sleep(2000);
                Console.ReadKey(true);
                TimeSpan ts = stopwatch.Elapsed;
                int delay = (int)ts.TotalSeconds;
                if (delay < 20)
                {
                    Console.WriteLine($"It looks like {player.Name} has DeathWanged - {player.Name} is today's winner!\n" +
                    $"Look at {opponent.Name} vainly trying to suck up that 2 gas! Sorry {opponent.Name}, maybe next time.");
                }
                else
                {
                    Console.WriteLine($"Oh deary me, it looks like {opponent.Name} has wanged {opponent.PosPronoun} last, making {opponent.PosPronoun} today's winner!\n" +
                        $"Look at {player.Name} vainly trying to suck up that 2 gas! Sorry {player.Name}, maybe next time.");
                }
            }
        }

        private static bool NewRandom(int chance)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
            bool output = randomNumber < chance ? true : false;
            return output;
        }

        private static void Goodbye()
        {
            Console.WriteLine("That's all for today's show, so until next time, GoodNumberWang!");
        }

        private static void CallWinner(Player player, Opponent opponent)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Thread.Sleep(1000);
            Console.WriteLine("What a game of WangerNum! With the scores now tallied I can say that");
            if (player.Score > opponent.Score)
            {
                Console.WriteLine($"*** {player.Name} wins with {player.Score} point(s) versus {opponent.Name}'s {opponent.Score} - congratulations {player.Name}! ***");
            }
            else if (player.Score == opponent.Score)
            {
                Console.WriteLine($"It's neck and neck at {player.Score} point(s), and you know what that means...\n" +
                    "It's time to play DeathWang!");
            }
            else
            {
                Console.WriteLine($"*** {opponent.Name} wins with {opponent.Score} point(s) versus {player.Name}'s {player.Score} - congratulations {opponent.Name}! ***");
            }
        }

        private static void IntroOpponent(Opponent opponent)
        {
            Thread.Sleep(1000);
            Console.WriteLine($"Player 2 is {opponent.Name}, who is also from Anglesey.");
            Thread.Sleep(1000);
        }

        private static void RoundOne(NumberWang numberWang, Player player, Opponent opponent)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Okay, round one.");
            Thread.Sleep(1500);
            float q1Guess = Question(player);
            numberWang.Check(q1Guess, player);
            float q2Guess = Question(opponent);
            numberWang.Check(q2Guess, opponent);
            float q3Guess = Question(player);
            numberWang.Check(q3Guess, player);
            float q4Guess = Question(opponent);
            numberWang.Check(q4Guess, opponent);
            Console.WriteLine("\n");
        }

        private static void RoundTwo(NumberWang numberWang, Player player, Opponent opponent)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("On to round two.");
            Thread.Sleep(1500);
            float q1Guess = Question(player);
            numberWang.Check(q1Guess, player);
            float q2Guess = Question(opponent);
            numberWang.Check(q2Guess, opponent);
            float q3Guess = Question(player);
            numberWang.Check(q3Guess, player);
            float q4Guess = Question(opponent);
            numberWang.Check(q4Guess, opponent);
            Console.WriteLine("\n");
        }

        private static void RoundThree(NumberWang numberWang, Player player, Opponent opponent)
        {
            Console.ForegroundColor = ConsoleColor.White;
            int totalPoints = player.Score + opponent.Score;
            Console.WriteLine($"With {totalPoints} NumberWang(s) so far, it's time for...");
            Thread.Sleep(1500);
            GenerateWangerNumTitle();
            Thread.Sleep(1500);
            float q1Guess = Question(player);
            numberWang.Check(q1Guess, player);
            float q2Guess = Question(opponent);
            numberWang.Check(q2Guess, opponent);
            float q3Guess = Question(player);
            numberWang.Check(q3Guess, player);
            float q4Guess = Question(opponent);
            numberWang.Check(q4Guess, opponent);
            Console.WriteLine("\n");
        }

        private static void GenerateWangerNumTitle()
        {
            string[] arr = new[]
                        {
                    @" __        __                          _   _                 ",
                    @" \ \      / /_ _ _ __   __ _  ___ _ __| \ | |_   _ _ __ ___  ",
                    @"  \ \ /\ / / _` | '_ \ / _` |/ _ \ '__|  \| | | | | '_ ` _ \ ",
                    @"   \ V  V / (_| | | | | (_| |  __/ |  | |\  | |_| | | | | | |",
                    @"    \_/\_/ \__,_|_| |_|\__, |\___|_|  |_| \_|\__,_|_| |_| |_|",
                    @"                       |___/                                 ",
                    @"                                      Let's rotate the board!",

            };
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n");
            foreach (string line in arr)
            {
                Console.WriteLine(line);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Thread.Sleep(1500);
        }

        private static void GenerateTitle()
        {
            string[] arr = new[]
                        {
                    @"  _   _                 _             __        __                ",
                    @" | \ | |_   _ _ __ ___ | |__   ___ _ _\ \      / /_ _ _ __   __ _ ",
                    @" |  \| | | | | '_ ` _ \| '_ \ / _ \ '__\ \ /\ / / _` | '_ \ / _` |",
                    @" | |\  | |_| | | | | | | |_) |  __/ |   \ V  V / (_| | | | | (_| |",
                    @" |_| \_|\__,_|_| |_| |_|_.__/ \___|_|    \_/\_/ \__,_|_| |_|\__, |",
                    @"                                                            |___/ ",
                    @"                                                         By Duncan",

            };
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WindowWidth = 160;
            Console.WriteLine("\n\n");
            foreach (string line in arr)
            {
                Console.WriteLine(line);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1500);
            //Console.Beep(175, 250);
            //Console.Beep(220, 250);
            //Console.Beep(247, 500);
        }

        private static void SetPlayerName(Player player)
        {
            Console.WriteLine("Enter your name...");
            player.Name = Console.ReadLine();
        }

        private static float Question(Player player)
        {
            Console.WriteLine($"{player.Name}, give me a number, please.");
            float response = FloatValidation(Console.ReadLine(), "Numerals");
            return response;
        }

        private static float Question(Opponent opponent)
        {
            Random random = new Random();
            Console.WriteLine($"{opponent.Name}, give me a number, please.");
            float response = random.Next();
            long responseLong = (long)response;
            Thread.Sleep(1500);
            Console.WriteLine(responseLong);
            return response;
        }

        private static void CheckPlayerAge(Player player, Opponent opponent)
        {
            Console.WriteLine($"Hello {player.Name} and {opponent.Name}, and welcome to NumberWang, the numbers show that simply everyone... is talking about? Yes.");
            Thread.Sleep(1000);
            Console.WriteLine("Please state your age before proceeding...");
            player.Age = IntValidation(Console.ReadLine(), "Integers");

            if (player.Age < 8 | player.Age > 88)
            {
                Console.WriteLine("NumberWang is suitable for ages 8 to 88, are you sure you want to continue [press any key]?");
                Console.ReadKey();
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("Excellent, NumberWang is suitable for ages 8 to 88 - let's begin!\n");
                Thread.Sleep(1500);
            }
        }

        private static int IntValidation(string input, string criterion)
        {
            bool ex = true;
            int response = 0;
            while (ex)
            {
                try
                {
                    response = int.Parse(input);
                    ex = false;
                    return response;
                }
                catch (Exception)
                {
                    Console.WriteLine($"{criterion} only, punk!");
                }
            }
            return response;
        }

        private static float FloatValidation(string input, string criterion)
        {
            bool ex = true;
            float response = 0F;
            while (ex)
            {
                try
                {
                    response = float.Parse(input);
                    ex = false;
                    return response;
                }
                catch (Exception)
                {
                    Console.WriteLine($"{criterion} only, punk!");
                }
            }
            return response;
        }
    }
}


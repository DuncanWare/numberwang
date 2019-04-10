using System;
using System.Collections.Generic;
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
            Console.WriteLine($"{player.Name} is on {player.Score} point(s), so it's time for...");
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
            Thread.Sleep(1000);
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


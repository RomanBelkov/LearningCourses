using System;
using System.Collections.Generic;
using System.IO;
using System.Resources;
using World.Humans;

namespace World
{
    internal sealed class World
    {
        private const string OutputFile = "output.txt";
        public static void Main()
        {
            Console.WriteLine(Properties.Resources.Welcome);
            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                Console.WriteLine(Properties.Resources.NoSundayWork);
                return;
            }
            var isInt = true;
            var humansToCreate = 0;
            do
            {
                Console.WriteLine(Properties.Resources.HumansAmountQuestion);
                var readLine = Console.ReadLine();
                if (readLine != null) isInt = int.TryParse(readLine.Trim(), out humansToCreate);
                if (!isInt || (humansToCreate <= 0))
                {
                    Console.WriteLine(Properties.Resources.InvalidHumansAmount);
                }
            } while (!isInt || (humansToCreate <= 0));


            var god = new God();
            var createdHumans = GenerateHumans(god, humansToCreate);
            PrintHumans(createdHumans);

            Console.SetCursorPosition(0, Console.CursorTop - createdHumans.Length * 2 + 1);
            PrintPairs(GeneratePairs(god, createdHumans));
            SaveTotalMoney(god);
        }

        private static Human[] GenerateHumans(God god, int humansToCreate)
        {
            for (var i = 0; i < humansToCreate; i++)
            {
                god.CreateHuman();
            }
            return god.GetCreatedHumans();
        }

        private static void PrintHumans(IEnumerable<Human> humans)
        {
            foreach (var human in humans)
            {
                human.PrintToConsole();
                Console.WriteLine();
            }
        }

        private static void SaveTotalMoney(God god)
        {
            File.WriteAllText(OutputFile, god.GetTotalMoney().ToString());
            Console.WriteLine(string.Format(Properties.Resources.SavedMoney, OutputFile));
        }

        private static IEnumerable<Human> GeneratePairs(IGod god, IReadOnlyList<Human> humans)
        {
            var pairs = new Human[humans.Count];
            for (var i = 0; i < humans.Count; ++i)
            {
                pairs[i] = god.CreatePair(humans[i]);
            }
            return pairs;
        }

        private static void PrintPairs(IEnumerable<Human> pairs)
        {
            var background = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            foreach (var pair in pairs)
            {
                pair.PrintToConsole();
                Console.SetCursorPosition(0, Console.CursorTop + 1);
            }
            Console.BackgroundColor = background;
        }
    }
}



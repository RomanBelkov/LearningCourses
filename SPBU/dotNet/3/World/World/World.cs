using System;
using System.Collections.Generic;
using System.IO;
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
            var amounOfHumansToCreate = 0;
            Console.WriteLine(Properties.Resources.HumansAmountQuestion);
            var readLine = Console.ReadLine();
            if (readLine != null) isInt = int.TryParse(readLine.Trim(), out amounOfHumansToCreate);
            if (!isInt || (amounOfHumansToCreate <= 0))
            {
                Console.WriteLine(Properties.Resources.InvalidHumansAmount);
                return;
            }

            var god = new God();
            var humans = GenerateHumans(god, amounOfHumansToCreate);
            PrintHumans(humans);

            Console.SetCursorPosition(0, Console.CursorTop - humans.Length * 2 + 1); //to printpairs
            PrintPairs(GeneratePairs(god, humans));
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
            Console.WriteLine(Properties.Resources.SavedMoney, OutputFile);
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
            var backgroundColor = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            foreach (var pair in pairs)
            {
                pair.PrintToConsole();
                Console.SetCursorPosition(0, Console.CursorTop + 1);
            }
            Console.BackgroundColor = backgroundColor;
        }
    }
}



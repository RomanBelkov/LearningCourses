using System;
using System.Text;
using AdvancedWorld.Creatures;
using AdvancedWorld.Exceptions;
using AdvancedWorld.Properties;

namespace AdvancedWorld
{
    internal sealed class Creator
    {
        private static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine(Resources.Welcome);
            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                Console.WriteLine(Resources.NoSundayWork);
                return;
            }

            var god = new AdvancedGod();
            var exitFlag = false;

            while (!exitFlag)
            {
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        Date(god);
                        break;
                    case ConsoleKey.Q:
                    case ConsoleKey.F10:
                        exitFlag = true;
                        break;
                }
            }
        }

        private static void Date(AdvancedGod god)
        {
            var humans = god.GenerateHumansForDating();
            humans.Item1.PrintToConsole();
            humans.Item2.PrintToConsole();

            try
            {
                var child = god.DateCouple(humans);
                Console.Write(@" ");
                if (child != null)
                {
                    if (child is Book)
                    {
                        Console.WriteLine(child.ToString());
                    }
                    else
                    {
                        ((Human) child).PrintToConsole();
                    }
                }
                else
                {
                    Console.WriteLine(Resources.Couple_NoLike);
                }
            }
            catch (Exception e)
            {
                if (e is ArgumentNullException || e is WrongCoupleException)
                {
                    Console.WriteLine(e.Message);
                    return;
                }

                throw;
            }
            finally
            {
                Console.WriteLine();
            }
        }
    }
}

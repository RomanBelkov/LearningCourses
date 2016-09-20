using System;

namespace HomeworkCs
{
    public class Medved
    {
        public static string greet = "Preved from ";

        public virtual void MeetMedved()
        {
            Console.WriteLine(greet + "C#");
        }
    }
}

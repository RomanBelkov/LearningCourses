using System;

namespace Exam.Helpers
{
    internal static class Randomizer
    {
        private static readonly Random Random = new Random();

        private const int MaxSleepTime = 11;
        private const int MaxExaminationTime = 4;
        private const int MinMark = 2;
        private const int MaxMark = 6;
        private const int MaxStudentAmount = 31;

        public static string GetStudentName()
            => $"{Names.LastNames[Random.Next(Names.LastNames.Length)]} {Names.FirstNames[Random.Next(Names.FirstNames.Length)]}";

        public static int GetSleepTime()
            => Random.Next(MaxSleepTime) * 1000;

        public static int GetStudentExaminationTime()
            => Random.Next(MaxExaminationTime) * 1000;

        public static int GetStudentMark()
            => Random.Next(MinMark, MaxMark);

        public static int GetAmountStudents()
            => Random.Next(MaxStudentAmount);
    }
}
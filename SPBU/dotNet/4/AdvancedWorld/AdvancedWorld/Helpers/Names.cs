using System;
using AdvancedWorld.Creatures;

namespace AdvancedWorld.Helpers
{
    public sealed class Names
    {
        private static readonly Random Rnd = new Random();

        private static readonly string[] MaleNames = { "Александр", "Борис", "Кирилл", "Роман", "Владимир" };
        private static readonly string[] FemaleNames = { "Анна", "Вера", "Надежда", "Наталья", "Диана", "Алёна" };

        private const string ManPatronymicAddition = "ович";
        private const string WomanPatronymicAddition = "овна";

        internal static string GenerateName(Sex sex)
        {
            switch (sex)
            {
                case Sex.Male:
                    return (string)MaleNames.GetValue(Rnd.Next(MaleNames.Length));
                case Sex.Female:
                    return (string)FemaleNames.GetValue(Rnd.Next(FemaleNames.Length));
                default:
                    throw new NotSupportedException(Properties.Resources.InvalidSex);
            }

        }

        internal static string GeneratePatronymic(Sex sex)
        {
            switch (sex)
            {
                case Sex.Male:
                    return GenerateName(Sex.Male) + ManPatronymicAddition;
                case Sex.Female:
                    return GenerateName(Sex.Male) + WomanPatronymicAddition;
                default:
                    throw new NotSupportedException(Properties.Resources.InvalidSex);
            }
        }

        public static string PatronymicFromParentName(Sex sex, string parentName)
        {
            if (string.IsNullOrEmpty(parentName))
            {
                throw new ArgumentException(Properties.Resources.InvalidParentName);
            }
            switch (sex)
            {
                case Sex.Male:
                    return parentName + ManPatronymicAddition;
                case Sex.Female:
                    return parentName + WomanPatronymicAddition;
                default:
                    throw new NotSupportedException(Properties.Resources.InvalidSex);
            }
        }
    }
}

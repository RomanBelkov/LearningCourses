using System;
using World.Humans;

namespace World.Helpers
{
    internal sealed class Names
    {
        private static readonly Random Rnd = new Random();

        private static readonly string[] MaleNames = { "Александр", "Борис", "Кирилл", "Роман", "Владимир" };
        private static readonly string[] FemaleNames = { "Анна", "Вера", "Надежда", "Наталья", "Диана", "Алёна" };

        private const string ManPatronymicAddition = "ович";
        private const string WomanPatronymicAddition = "овна";
        private const int AdditionalPatronymicLength = 4;

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

        internal static string PatronymicFromParentName(Sex sex, string parentName)
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

        internal static string NameFromPatronymic(Sex sex, string patronymic)
        {
            if ((patronymic == null) || (patronymic.Length <= 4))
            {
                throw new ArgumentException(Properties.Resources.InvalidPatronymic);
            }

            var substringToRemove = patronymic.Substring(patronymic.Length - AdditionalPatronymicLength, AdditionalPatronymicLength);

            switch (sex)
            {
                case Sex.Male:
                {
                    if (!substringToRemove.Equals(ManPatronymicAddition))
                    {
                        throw new ArgumentException(Properties.Resources.InvalidParentNameFromPatronymic);
                    }
                    break;
                }
                case Sex.Female:
                {
                    if (!substringToRemove.Equals(WomanPatronymicAddition))
                    {
                        throw new ArgumentException(Properties.Resources.InvalidParentNameFromPatronymic);
                    }
                    break;
                }
                default:
                    throw new NotSupportedException(Properties.Resources.InvalidSex);
            }

            return patronymic.Substring(0, patronymic.Length - AdditionalPatronymicLength);
        }
    }
}
using System;

namespace World.Helpers
{
    internal sealed class Money
    {
        internal static int MarkToMoney(double averageMark)
        {
            return (int)Math.Pow(10.0, averageMark);
        }

        internal static double MoneyToMark(int money)
        {
            return Math.Log10(money);
        }
    }
}
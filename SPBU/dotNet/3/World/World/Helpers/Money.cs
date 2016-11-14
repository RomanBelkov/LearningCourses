using System;

namespace World.Helpers
{
    internal sealed class Money
    {
        internal static int MarkToMoney(double avgMark)
        {
            return (int)Math.Pow(10.0, avgMark);
        }

        internal static double MoneyToMark(int money)
        {
            return Math.Log10(money);
        }
    }
}
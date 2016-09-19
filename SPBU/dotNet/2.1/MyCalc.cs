using System;

class MyCalc 
{

	private static Random rnd = new Random();
	private const int minBound = 1;
	private const int maxBound = 10;

	private static int getRandomNumber() 
	{
		return rnd.Next(minBound, maxBound + 1);
	}

	static void Main() 
	{
		Console.WriteLine("Я — интеллектуальный калькулятор!");
		Console.WriteLine("Как тебя зовут?");
		var userName = Console.ReadLine();
		var a = getRandomNumber();
		var b = getRandomNumber();

		Console.WriteLine("Сколько будет {0} + {1}?", a, b);
		try
		{
	    	var answer = Int32.Parse(Console.ReadLine());
	    	if(a + b == answer)
			{
				Console.WriteLine("Верно, {0}!", userName);
			}
			else 
			{
				Console.WriteLine("{0}, ты не прав", userName);
			}
		}
		catch (FormatException e)
		{
	    	Console.WriteLine("Ответом должно быть число!");
		}
	}
}

using System;

public class Util
{
	public static Random RANDOM = new Random();

	public static int throwDice(int qnt = 3)
	{
		int result = 0;
		while (qnt > 0) {
			result += RANDOM.Next (1, 7);
			qnt--;
		}
		return result;
	}

	public static int rand100()
	{
		return RANDOM.Next (1, 101);
	}
}


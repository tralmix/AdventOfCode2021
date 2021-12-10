using System.Diagnostics;
using System.Text;

namespace AdventOfCode2021
{
	public static class Day03
	{
		public static int GetGammaRate(string[] input) => GetRate(input, RateType.Gamma);

		public static int GetEpsilonRate(string[] input) => GetRate(input, RateType.Epsilon);

		private static int GetRate(string[] input, RateType rateType)
		{
			if (input is null || input.Length == 0)
				return 0;

			var rateString = BuildRateString (input, rateType);

			Debug.WriteLine($"{RateType.GetName(rateType)}: {rateString}");

			return GetRate(rateString);
		}

		private static string BuildRateString(string[] input, RateType rateType)
		{
			var stringBuilder = new StringBuilder();
			var inputLength = input[0].Length;

			Func<string[], int, char> valueFunction = rateType == RateType.Gamma ? GammaValue : EpsilonValue;
			
			for (int i = 0; i < inputLength; i++)
				stringBuilder.Append(valueFunction(input, i));
			
			return stringBuilder.ToString();
		}

		private static char GammaValue(string[] input, int i)
		{
			return input.Count(x => x[i] == '1') > input.Length / 2 ? '1' : '0';
		}

		private static char EpsilonValue(string[] input, int i)
		{
			return input.Count(x => x[i] == '1') < input.Length / 2 ? '1' : '0';
		}

		private static int GetRate(string rateString)
		{
			var rate = 0;
			for (int i = 0; i < rateString.Length; i++)
				rate += int.Parse(rateString[i].ToString()) * (int)Math.Pow(2, rateString.Length - 1 - i);

			return rate;
		}
	}
	public enum RateType
	{
		Gamma,
		Epsilon
	}
}

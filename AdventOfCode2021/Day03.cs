using System.Diagnostics;
using System.Text;

namespace AdventOfCode2021
{
	public static class Day03
	{
		public static void Run()
		{
			var day03LinesOfInput = File.ReadAllLines("Inputs/Day03Input.txt");
			var gammaRate = Day03.GetGammaRate(day03LinesOfInput);
			var epsilonRate = Day03.GetEpsilonRate(day03LinesOfInput);
			Console.WriteLine($"Day 03 - Part 1 - Gamma {gammaRate}, Epsilon {epsilonRate}, Power Consumption {gammaRate * epsilonRate}");
			var oxygenGeneratorRating = Day03.GetOxygenGeneratorRating(day03LinesOfInput);
			var co2ScrubberRating = Day03.GetCO2ScrubberRating(day03LinesOfInput);
			Console.WriteLine($"Day 03 - Part 2 - O2 {oxygenGeneratorRating}, CO2 {co2ScrubberRating}, Life Support Rating {oxygenGeneratorRating * co2ScrubberRating}");
		}

		public static int GetGammaRate(string[] input) => GetRate(input, RateType.Gamma);

		public static int GetEpsilonRate(string[] input) => GetRate(input, RateType.Epsilon);

		private static int GetRate(string[] input, RateType rateType)
		{
			if (input is null || input.Length == 0)
				return 0;

			var rateString = BuildRateString(input, rateType);

			Debug.WriteLine($"{RateType.GetName(rateType)}: {rateString}");

			return GetValueFromBinary(rateString);
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

		private static int GetValueFromBinary(string rateString)
		{
			var rate = 0;
			for (int i = 0; i < rateString.Length; i++)
				rate += int.Parse(rateString[i].ToString()) * (int)Math.Pow(2, rateString.Length - 1 - i);

			return rate;
		}

		public static int GetOxygenGeneratorRating(string[] input) => GetRating(input.ToArray(), RatingType.OxygenGenerator);

		public static int GetCO2ScrubberRating(string[] input) => GetRating(input.ToArray(), RatingType.CO2Scrubber);

		private static int GetRating(string[] input, RatingType ratingType)
		{
			var diagnosticOutput = FindOutput(input, ratingType);
			return GetValueFromBinary(diagnosticOutput);
		}

		private static string FindOutput(string[] input, RatingType ratingType)
		{
			var index = 0;
			while (input.Length > 1)
			{
				var charToKeep = FindCharToKeep(input, index, ratingType);
				input = input.Where(i=>i[index] == charToKeep).ToArray();
				index++;
			}

			return input.First();
		}

		private static char FindCharToKeep(string[] input, int index, RatingType ratingType)
		{
			if (ratingType == RatingType.OxygenGenerator)
				return input.Count(x => x[index] == '1') >= (int) Math.Ceiling(input.Length / 2d) ? '1' : '0';
			
			return input.Count(x => x[index] == '0') <= (int) Math.Floor(input.Length / 2d) ? '0' : '1';
		}
	}
	public enum RateType
	{
		Gamma,
		Epsilon
	}

	public enum RatingType
	{
		OxygenGenerator,
		CO2Scrubber
	}
}

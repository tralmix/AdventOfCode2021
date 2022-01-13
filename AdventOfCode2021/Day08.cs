using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
	public static class Day08
	{
		private static readonly Dictionary<int, int> _digitsByUniqueSegmentCount = new()
		{
			{ 2, 1 },
			{ 3, 7 },
			{ 4, 4 },
			{ 7, 8 }
		};

		private static readonly char _segmentDelimiter = '|';

		public static void Run()
		{
			var inputLines = File.ReadAllLines("Inputs/Day08Input.txt");
			var input = ParseInputs(inputLines);

			var partOneAnswer = RunPartOne(input.ToList());

			Console.WriteLine($"Day 08 - Part 1 - Number of digits identifiable by segment count is {partOneAnswer}");

			var partTwoAnswer = RunPartTwo(input.ToList());

			Console.WriteLine($"Day 08 - Part 2 - Sum of all displays is {partTwoAnswer}");
		}

		public static int RunPartOne(List<Input> input)
		{
			foreach (var inputLine in input)
				IdentifyDigitsBySegmentCount(inputLine.Display);

			return input.Select(l => l.Display.Count(d => d.Value.HasValue)).Sum();
		}

		public static int RunPartTwo(List<Input> input)
		{
			foreach (var inputLine in input)
			{
				IdentifyDigitsBySegmentCount(inputLine.Digits);
				var dictionary = BuildSegmentDictionary(inputLine.Digits);
				SetDisplayValues(inputLine.Display, dictionary);
			}

			return input.Select(BuildNumberFromDigits).Sum();
		}

		private static void SetDisplayValues(List<Digit> display, Dictionary<string, int> dictionary)
		{
			foreach (var digit in display)
				digit.Value = dictionary.Single(d=> d.Key.Length == digit.Code.Length
					&& d.Key.All(k=>digit.Code.Contains(k))).Value;
		}

		private static int BuildNumberFromDigits(Input input)
		{
			var digits = input.Display;
			var digitString = string.Join(string.Empty, digits.Select(d => d.Value));
			_ = int.TryParse(digitString, out int digitValue);
			return digitValue;
		}

#pragma warning disable CS8629 // Nullable value type may be null.
		private static Dictionary<string, int> BuildSegmentDictionary(List<Digit> digits)
		{
			var codeDictionary = digits.Where(d => d.Value is not null).ToDictionary(d => d.Value.Value, d => d.Code);
			IdentifyNine(digits, codeDictionary);
			IdentifyZero(digits, codeDictionary);
			IdentifySix(digits, codeDictionary);
			IdentifyFive(digits, codeDictionary);
			IdentifyThree(digits, codeDictionary);
			IdentifyTwo(digits, codeDictionary);
			return codeDictionary.ToDictionary(d=>d.Value, d=>d.Key);
		}

		private static void IdentifyTwo(List<Digit> digits, Dictionary<int, string> codeDictionary)
		{
			var two = digits.Single(d => d.Value is null);

			two.Value = 2;
			codeDictionary.Add(2, two.Code);
		}

		private static void IdentifyThree(List<Digit> digits, Dictionary<int, string> codeDictionary)
		{
			var three = digits.Single(d=> d.Value is null
				&& codeDictionary[7].All(c => d.Code.Contains(c)));

			three.Value = 3;
			codeDictionary.Add(3, three.Code);
		}

		private static void IdentifyFive(List<Digit> digits, Dictionary<int, string> codeDictionary)
		{
			var five = digits.Single(d=> d.Value is null
				&& d.Code.All(c=> codeDictionary[6].Contains(c)));

			five.Value = 5;
			codeDictionary.Add(5, five.Code);
		}

		private static void IdentifySix(List<Digit> digits, Dictionary<int, string> codeDictionary)
		{
			var six = digits.Single(d => d.Code.Length == 6 && d.Value is null);

			six.Value = 6;
			codeDictionary.Add(6, six.Code);
		}

		private static void IdentifyNine(List<Digit> digits, Dictionary<int, string> codeDictionary)
		{
			var nine = digits.Single(d => d.Code.Length == 6 &&d.Value is null
				&& codeDictionary[4].All(c => d.Code.Contains(c)));

			nine.Value = 9;
			codeDictionary.Add(9, nine.Code);
		}

		private static void IdentifyZero(List<Digit> digits, Dictionary<int, string> codeDictionary)
		{
			var zero = digits.Single(d => d.Code.Length == 6 && d.Value is null
				&& codeDictionary[7].All(c => d.Code.Contains(c)));

			zero.Value = 0;
			codeDictionary.Add(0, zero.Code);
		}
#pragma warning restore CS8629 // Nullable value type may be null.

		private static void IdentifyDigitsBySegmentCount(List<Digit> digits)
		{
			foreach (var digit in digits)
				IdentifyDigitBySegmentCount(digit);
		}

		private static void IdentifyDigitBySegmentCount(Digit digit)
		{
			if (_digitsByUniqueSegmentCount.TryGetValue(digit.Code.Length, out int digitNumber))
				digit.Value = digitNumber;
		}

		public static List<Input> ParseInputs(string[] input)
		{
			return input.Select(ParseInputLine).ToList();
		}

		public static Input ParseInputLine(string input)
		{
			var halves = input.Split(_segmentDelimiter);
			var parsedInput = new Input();
			parsedInput.Digits.AddRange(halves[0].Split(' ')
				.Where(s=>!string.IsNullOrWhiteSpace(s))
				.Select(x => new Digit(x)));
			parsedInput.Display.AddRange(halves[1].Split(' ')
				.Where(s => !string.IsNullOrWhiteSpace(s))
				.Select(x => new Digit(x)));
			return parsedInput;
		}

		public class Input
		{
			public Input()
			{
				Digits = new List<Digit>();
				Display = new List<Digit> { };
			}
			public List<Digit> Digits { get; }
			public List<Digit> Display { get; }
		}

		public class Digit
		{
			public Digit(string code)
			{
				Code = code;
			}

			public string Code { get; }
			public int? Value { get; set; }
		}
	}
}

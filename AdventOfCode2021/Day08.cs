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
		}

		public static int RunPartOne(List<Input> input)
		{
			foreach (var inputLine in input)
				IdentifyDigitsBySegmentCount(inputLine.Display);

			return input.Select(l=>l.Display.Count(d=>d.Value is not null)).Sum();	
		}

		private static void IdentifyDigitsBySegmentCount(List<Digit> digits)
		{
			foreach (var digit in digits)
				IdentifyDigitBySegmentCount(digit);
		}

		private static void IdentifyDigitBySegmentCount(Digit digit)
		{
			if(_digitsByUniqueSegmentCount.TryGetValue(digit.Code.Length, out int digitNumber))
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
			parsedInput.Digits.AddRange(halves[0].Split(' ').Select(x => new Digit(x)));
			parsedInput.Display.AddRange(halves[1].Split(' ').Select(x => new Digit(x)));
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

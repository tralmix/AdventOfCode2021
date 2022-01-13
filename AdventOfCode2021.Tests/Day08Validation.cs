using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode2021.Tests
{
	public class Day08Validation
	{
		private static readonly string[] Input = new string[] {
			"be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe",
			"edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc",
			"fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg",
			"fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb",
			"aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea",
			"fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb",
			"dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe",
			"bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef",
			"egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb",
			"gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce"
		};

		private static readonly int _linesToParse = 10;
		private static readonly int _partOneDigitsIdentifiableBySegmentCount = 26;
		private static readonly int _partTwoSum = 61229;

		[Fact]
		public void VerifyParser()
		{
			var input = Day08.ParseInputs(Input);
			input.Count.ShouldBe(_linesToParse);
			input[0].Digits.Count.ShouldBe(10);
			input[0].Display.Count.ShouldBe(4);
		}

		[Fact]
		public void ValidatePartOne()
		{
			var input = Day08.ParseInputs(Input);

			var answer = Day08.RunPartOne(input);

			answer.ShouldBe(_partOneDigitsIdentifiableBySegmentCount);
		}

		[Fact]
		public void ValidatePartTwo()
		{
			var input = Day08.ParseInputs(Input);

			var answer = Day08.RunPartTwo(input);

			answer.ShouldBe(_partTwoSum);
		}
	}
}

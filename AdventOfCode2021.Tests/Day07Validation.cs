using Shouldly;
using Xunit;

namespace AdventOfCode2021.Tests
{
	public class Day07Validation
	{
		public static readonly int[] Input = { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 };

		[Fact]
		public static void PartOneValidation()
		{
			const int expectedAnswer = 37;

			var answer = Day07.RunPartOne(Input);

			answer.ShouldBe(expectedAnswer);
		}

		[Fact]
		public static void PartTwoValidation()
		{
			const int expectedAnswer = 168;

			var answer = Day07.RunPartTwo(Input);

			answer.ShouldBe(expectedAnswer);
		}
	}
}
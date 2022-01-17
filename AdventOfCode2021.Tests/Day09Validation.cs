using Shouldly;
using Xunit;

namespace AdventOfCode2021.Tests
{
	public class Day09Validation
	{
		private static readonly string[] Input = new string[] {
			"2199943210",
			"3987894921",
			"9856789892",
			"8767896789",
			"9899965678"
		};

		[Fact]
		public void ValidateParser()
		{
			var input = Day09.ParseInput(Input);

			input.GetLength(0).ShouldBe(5);
			input.GetLength(1).ShouldBe(10);
		}

		[Fact]
		public void ValidatePartOne()
		{
			var input = Day09.ParseInput(Input);

			var answer = Day09.RunPartOne(input);

			answer.ShouldBe(15);
		}
	}
}

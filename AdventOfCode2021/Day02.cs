namespace AdventOfCode2021
{
	public static class Day02
	{
		public static void Run()
		{
			var day02LinesOfInput = File.ReadAllLines("Inputs/Day02Input.txt");
			var instructions = ParseInstructions(day02LinesOfInput);
			var location = FindLocationAfterInstructions(instructions);
			Console.WriteLine($"Day 02 - Part 1 -Final location {location.Horizontal}, {location.Depth}. Product = {location.Depth * location.Horizontal}");
			var correctLocation = FindLocationAfterUpdatedInstructions(instructions);
			Console.WriteLine($"Day 02 - Part 2 -Final location {correctLocation.Horizontal}, {correctLocation.Depth}. Product = {correctLocation.Depth * correctLocation.Horizontal}");
		}

		public static IEnumerable<Instructions> ParseInstructions(params string[] input)
		{
			if (input is null) return new List<Instructions>();

			return input.Select(x =>
			{
				var parts = x.Split(' ');
				var instruction = new Instructions { Value = int.Parse(parts[1]) };
				switch (parts[0].ToLowerInvariant())
				{
					case "forward": instruction.Direction = Direction.Forward; break;
					case "down": instruction.Direction = Direction.Down; break;
					case "up": instruction.Direction = Direction.Up; break;
					default:
						break;
				}
				return instruction;
			});
		}

		public static Location FindLocationAfterInstructions(IEnumerable<Instructions> instructions)
		{
			return instructions.Aggregate(new Location(), (location, instruction) =>
			{
				switch (instruction.Direction)
				{
					case Direction.Forward: location.Horizontal += instruction.Value; break;
					case Direction.Up: location.Depth -= instruction.Value; break;
					case Direction.Down: location.Depth += instruction.Value; break;
				}

				return location;
			});
		}

		public static Location FindLocationAfterUpdatedInstructions(IEnumerable<Instructions> instructions)
		{
			return instructions.Aggregate(new LocationWithAim(), (location, instruction) =>
			{
				switch (instruction.Direction)
				{
					case Direction.Forward: 
						location.Horizontal += instruction.Value;
						location.Depth += location.Aim * instruction.Value;
						break;
					case Direction.Up: location.Aim -= instruction.Value; break;
					case Direction.Down: location.Aim += instruction.Value; break;
				}

				return location;
			});
		}
	}

	public class Location
	{
		public int Horizontal { get; set; }
		public int Depth { get; set; }
	}

	public class LocationWithAim : Location
	{
		public int Aim { get; set; }
	}

	public class Instructions
	{
		public Direction Direction { get; set; }
		public int Value { get; set; }
	}

	public enum Direction
	{
		Forward,
		Down,
		Up
	}
}

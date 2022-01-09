namespace AdventOfCode2021
{
	public class Day07
	{
		public static void Run()
		{
			// Read as text over lines since input is single line list
			var input = File.ReadAllText("Inputs/Day07Input.txt");

			var inputAsintegers = input.Split(',').Select(int.Parse).ToArray();

			var partOneFuelConsumption = RunPartOne(inputAsintegers);

			Console.WriteLine($"The total distance traveled by all is {partOneFuelConsumption}");

			var partTwoFuelConsumption = RunPartTwo(inputAsintegers);

			Console.WriteLine($"The total distance traveled by all is {partTwoFuelConsumption}");
		}

		public static long RunPartOne(int[] inputAsintegers)
		{
			var orderedInput = inputAsintegers.OrderBy(x => x).ToArray();

			var median = orderedInput[(int)Math.Round(orderedInput.Length / 2d)];
			Console.WriteLine($"Median is {median}");

			var groups = Enumerable.Repeat(0L, orderedInput.Max()).ToList();
			foreach (var number in orderedInput.Distinct())
				groups.Insert(number, orderedInput.Count(x => x == number));

			var fuelTotals = new List<long>();
			for (int index = 0; index < groups.Count; index++)
			{
				var numberAtPoint = groups[index];
				var distanceGroupMustTravel = Math.Abs(index - median) * numberAtPoint;
				fuelTotals.Add(distanceGroupMustTravel);
			}

			var totalFuelUsedByAll = fuelTotals.Sum();

			return totalFuelUsedByAll;
		}

		public static long RunPartTwo(int[] inputAsintegers)
		{
			var orderedInput = inputAsintegers.OrderBy(x => x).ToArray();

			var average = (int)Math.Round(orderedInput.Average());
			Console.WriteLine($"Average is {average}[int] {orderedInput.Average()}[double]");

			var groups = Enumerable.Repeat(0L, orderedInput.Max()).ToList();
			foreach (var number in orderedInput.Distinct())
				groups.Insert(number, orderedInput.Count(x => x == number));

			// Check +/- 1 of average to account for margin of error in actual positions of crabs
			var fuelUsed = CalulatePart2Fuel(average, groups);
			fuelUsed = Math.Min(fuelUsed, CalulatePart2Fuel(average - 1, groups));
			fuelUsed = Math.Min(fuelUsed, CalulatePart2Fuel(average + 1, groups));

			return fuelUsed;
		}

		private static long CalulatePart2Fuel(int target, List<long> groups)
		{
			var distanceTotals = new List<long>();
			for (int index = 0; index < groups.Count; index++)
			{
				if (index < target)
				{
					var foo = Enumerable.Range(index, target - index).Select(x => x - index + 1);
					//Console.WriteLine($"At position {index} with target {average} requiring fuel cost {string.Join(',', foo)} totaling {foo.Sum()}");
					distanceTotals.Add(foo.Sum() * groups[index]);
				}
				else if (index == target)
					distanceTotals.Add(0);
				else
				{
					var foo = Enumerable.Range(target, index - target).Select(x => x - target + 1);
					//Console.WriteLine($"At position {index} with target {average} requiring fuel cost {string.Join(',', foo)} totaling {foo.Sum()}");
					distanceTotals.Add(foo.Sum() * groups[index]);
				}
			}

			var fuelUsed = distanceTotals.Sum();
			return fuelUsed;
		}
	}
}

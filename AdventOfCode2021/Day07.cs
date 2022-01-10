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
			List<long> groups = GroupInputs(inputAsintegers);

			var median = inputAsintegers.OrderBy(x => x).ToArray()[(int)Math.Round(inputAsintegers.Length / 2d)];
			Console.WriteLine($"Median is {median}");

			List<long> fuelTotals = CalculatePart1Fuel(median, groups);

			var totalFuelUsedByAll = fuelTotals.Sum();

			return totalFuelUsedByAll;
		}

		private static List<long> CalculatePart1Fuel(int target, List<long> groups)
		{
			var fuelTotals = new List<long>();
			for (int index = 0; index < groups.Count; index++)
			{
				var numberAtPoint = groups[index];
				var distanceGroupMustTravel = Math.Abs(index - target) * numberAtPoint;
				fuelTotals.Add(distanceGroupMustTravel);
			}

			return fuelTotals;
		}

		public static long RunPartTwo(int[] inputAsintegers)
		{
			List<long> groups = GroupInputs(inputAsintegers);

			var average = (int)Math.Round(inputAsintegers.Average());
			Console.WriteLine($"Average is {average}[int] {inputAsintegers.Average()}[double]");

			// Check +/- 1 of average to account for margin of error in actual positions of crabs
			var fuelUsed = CalulatePart2Fuel(average, groups);
			fuelUsed = Math.Min(fuelUsed, CalulatePart2Fuel(average - 1, groups));
			fuelUsed = Math.Min(fuelUsed, CalulatePart2Fuel(average + 1, groups));

			return fuelUsed;
		}

		private static List<long> GroupInputs(int[] inputAsintegers)
		{
			var orderedInput = inputAsintegers.OrderBy(x => x).ToArray();

			var groups = Enumerable.Repeat(0L, orderedInput.Max()).ToList();

			foreach (var number in orderedInput.Distinct())
				groups.Insert(number, orderedInput.Count(x => x == number));

			return groups;
		}

		private static long CalulatePart2Fuel(int target, List<long> groups)
		{
			var distanceTotals = new List<long>();
			int fuelUsedPerCrab = 0;
			for (int index = 0; index < groups.Count; index++)
			{
				if (index < target)
					fuelUsedPerCrab = Enumerable.Range(index, target - index).Select(x => x - index + 1).Sum();
				else if (index == target)
					fuelUsedPerCrab = 0;
				else
					fuelUsedPerCrab = Enumerable.Range(target, index - target).Select(x => x - target + 1).Sum();
				distanceTotals.Add(fuelUsedPerCrab * groups[index]);
			}

			var fuelUsed = distanceTotals.Sum();
			return fuelUsed;
		}
	}
}

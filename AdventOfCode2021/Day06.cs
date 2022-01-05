namespace AdventOfCode2021
{
	public static class Day06
	{
		public static void Run()
		{
			// Read as text over lines since input is single line list
			var input = File.ReadAllText("Inputs/Day06Input.txt");

			var orderedInput = input.Split(',').Select(int.Parse).OrderBy(x=>x).ToArray();

			var groups = Enumerable.Repeat(0L, 9).ToList();
			foreach (var number in orderedInput.Distinct())
				groups.Insert(number, orderedInput.Count(x => x == number));

			for(int day = 0; day < 80; day++)
				ProcessDay(groups);

			var totalAfter80Days = groups.Sum();

			Console.WriteLine($"Day 06 - Part 1 - There are {totalAfter80Days} lanternfish after 80 days");

			for (int day = 80; day < 256; day++)
				ProcessDay(groups);

			var totalAfter256Days = groups.Sum();

			Console.WriteLine($"Day 06 - Part 2 - There are {totalAfter256Days} lanternfish after 256 days");
		}

		private static void ProcessDay(List<long> groups)
		{
			var spawning = groups.First();
			groups.RemoveAt(0);
			groups.Insert(8, spawning);
			groups[6] += spawning;
		}
	}
}

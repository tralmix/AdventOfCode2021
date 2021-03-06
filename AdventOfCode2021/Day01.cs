namespace AdventOfCode2021
{
	public static class Day01
	{
		public static void Run()
		{
			var day01LinesOfInput = File.ReadAllLines("Inputs/Day01Input.txt");
			var day01Input = day01LinesOfInput.Select(int.Parse).ToArray();
			Console.WriteLine($"Day 01 - Part 1 - {FindNumberOfIncreasesInDepth(day01Input)}");
			Console.WriteLine($"Day 01 - Part 2 - {FindDepthIncreaseCountForWindowsOfThree(day01Input)}");
		}

		public static int FindNumberOfIncreasesInDepth(params int[] depths)
		{
			if(depths is null) return 0;

			var list = depths.ToList();

			return list.GetRange(0, list.Count - 1)
				.Zip(list.GetRange(1, list.Count - 1))
				.Count((x) => x.First < x.Second);
		}

		public static int FindDepthIncreaseCountForWindowsOfThree(params int[]depths)
		{
			if (depths is null) return 0;

			var list = depths.ToList();

			Console.WriteLine($"Depths {depths.Length}, list count {list.Count}");

			var windows = list.GetRange(0, list.Count - 2)
				.Zip(list.GetRange(1, list.Count - 2))
				.Select(x => x.First + x.Second)
				.Zip(list.GetRange(2, list.Count - 2))
				.Select(x => x.First + x.Second)
				.ToList();

			return FindNumberOfIncreasesInDepth(windows.ToArray());
		}
	}
}

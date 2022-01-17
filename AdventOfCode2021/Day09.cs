namespace AdventOfCode2021
{
	public static class Day09
	{
		public static void Run()
		{
			var day09LinesOfInput = File.ReadAllLines("Inputs/Day09Input.txt");

			var parsedInput = ParseInput(day09LinesOfInput);

			var partOneAnswer = RunPartOne(parsedInput);

			Console.WriteLine($"Day 09 - Part 1 - The sum of the risk levels is {partOneAnswer}");
		}

		public static int RunPartOne(int[,] input)
		{
			var lowPointValues = GetLowPointValues(input);

			var sumOfRiskLevels = lowPointValues.Sum() + lowPointValues.Count();

			return sumOfRiskLevels;
		}

		public static IEnumerable<int> GetLowPointValues(int[,] input)
		{
			var lowPoints = new List<int>();

			var rowCount = input.GetLength(0);
			var columnCount = input.GetLength(1);

			for (var row = 0; row < rowCount; row++)
				for (var column = 0; column < columnCount; column++)
					if(IsLowerThanNeighbors(input, row, column))
						lowPoints.Add(input[row, column]);

			return lowPoints;
		}

		public static bool IsLowerThanNeighbors(int[,] input, int rowIndex, int columnIndex)
		{
			int cellValue = input[rowIndex, columnIndex];

			if (IsGreaterThanAbove(input, rowIndex, columnIndex, cellValue))
				return false;

			if (IsGreaterThanBelow(input, rowIndex, columnIndex, cellValue))
				return false;

			if (IsGreaterThanRight(input, rowIndex, columnIndex, cellValue))
				return false;

			if (IsGreaterThanLeft(input, rowIndex, columnIndex, cellValue))
				return false;

			return true;
		}

		public static bool IsGreaterThanAbove(int[,] input, int rowIndex, int columnIndex, int cellValue)
		{
			if (rowIndex == 0) return false;

			var aboveCellValue = input[rowIndex - 1, columnIndex];

			return cellValue >= aboveCellValue;
		}

		public static bool IsGreaterThanBelow(int[,] input, int rowIndex, int columnIndex, int cellValue)
		{
			if (rowIndex == input.GetLength(0) - 1) return false;

			var belowCellValue = input[rowIndex + 1, columnIndex];

			return cellValue >= belowCellValue;
		}

		public static bool IsGreaterThanRight(int[,] input, int rowIndex, int columnIndex, int cellValue)
		{
			if (columnIndex == input.GetLength(1) - 1) return false;

			var rightCellValue = input[rowIndex, columnIndex + 1];

			return cellValue >= rightCellValue;
		}

		public static bool IsGreaterThanLeft(int[,] input, int rowIndex, int columnIndex, int cellValue)
		{
			if (columnIndex == 0) return false;

			var leftCellValue = input[rowIndex, columnIndex - 1];

			return cellValue >= leftCellValue;
		}

		public static int[,] ParseInput(string[] input)
		{
			var rowCount = input.Length;
			var columnCount = input[0].Length;
			var parsedInput = new int[rowCount, columnCount];

			for(var row = 0; row < rowCount; row++)
				for(var column = 0; column < columnCount; column++)
					parsedInput[row, column] = int.Parse(input[row][column].ToString());
					
			return parsedInput;
		}

	}
}

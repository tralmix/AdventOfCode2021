using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2021
{
	public static class Day04
	{
		public static string[] GetNumberCallOrder(string[] input)
		{
			// First line of input is number call order
			return input[0].Split(',');
		}

		public static List<Board> GetBoards(string[] input)
		{
			var boards = new List<Board>();

			Board board = new();
			// Skip first 2, number call order and blank line
			foreach (var line in input.Skip(2))
			{
				if (string.IsNullOrEmpty(line))
				{
					boards.Add(board);
					board = new Board();
					continue;
				}

				board.Rows.Add(new Row
				{
					Columns = line.Split(' ')
						.Where(c => !string.IsNullOrEmpty(c))
						.Select(lineInput => new Cell { Value = lineInput })
						.ToList()
				});
			}

			// Add last board - no trailing empty line at end of file.
			boards.Add(board);

			return boards;
		}

		public static Winner FindWinningBoardAndNumber(string[] numberCallOrder, List<Board> boards)
		{
			Winner? winner = null;
			foreach( var number in numberCallOrder)
			{
				var loop = Parallel.ForEach(boards, b => b.MarkValue(number));
				while (!loop.IsCompleted) continue;
				var winningBoard = boards.FirstOrDefault(b => b.IsWinner());
				if (winningBoard is null) continue;
				winner = new Winner
				{
					Board = winningBoard,
					Number = number
				};
				break;
			}

			Debug.Assert(winner is not null);

			return winner;
		}
	}

	public class Board
	{
		public List<Row> Rows { get; set; } = new List<Row>();

		public void MarkValue(string value)
		{
			var cell = Rows.Select(r => r.Columns.FirstOrDefault(c => c.Value == value))
				.FirstOrDefault(c => c is not null);

			if(cell is not null)
				cell.Marked = true;
		}

		public bool IsWinner()
		{
			var winningRow = Rows.Any(r => r.Columns.All(c => c.Marked));
			if (winningRow)
				return true;

			for(var i = 0; i < Rows.Count; i++)
				if(Rows.All(r=>r.Columns[i].Marked))
					return true;

			return false;
		}

		private IEnumerable<string>? _winningNumbers;

		public IEnumerable<string> WinningNumbers
		{
			get
			{
				if (_winningNumbers is not null)
					return _winningNumbers;

				if (!IsWinner()) return new List<string>();

				var winningRow = Rows.FirstOrDefault(r => r.Columns.All(c => c.Marked));
				if (winningRow is not null)
				{
					_winningNumbers = winningRow.Columns.Select(c => c.Value);
					return _winningNumbers;
				}

				for (var i = 0; i < Rows.Count; i++)
					if (Rows.All(r => r.Columns[i].Marked))
					{
						_winningNumbers = Rows.Select(r => r.Columns[i].Value);
						return _winningNumbers;
					}

				return new List<string>();
			}
		}

		public int SumOfUnmarked
		{
			get
			{
				int sumOfUnmarked = 0;
				
				foreach (var row in Rows)
					sumOfUnmarked += row.Columns.Where(c=>!c.Marked)
						.Select(c=>c.Value)
						.Select(int.Parse)
						.Sum();

				return sumOfUnmarked;
			}
		}
	}

	public class Row
	{
		public List<Cell> Columns { get; set; } = new List<Cell>();
	}

	public class Cell
	{
		public string Value { get; set; } = string.Empty;
		public bool Marked { get; set; }
	}

	public class Winner
	{
		public Board Board { get; set; } =	new Board();
		public string Number { get; set; } = string.Empty;
	}

}

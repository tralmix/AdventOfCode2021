using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
	public static class Day05
	{
		public static void Run()
		{
			var inputLines = File.ReadAllLines("Inputs/Day05Input.txt");
			var input = ParseInput(inputLines);

			var pointsCrossed = Solve(input, 1);
			Console.WriteLine($"Day 05 - Part 1 - Number of overlaps {pointsCrossed.Count(p => p.Value > 1)}");

			pointsCrossed = Solve(input, 2);
			Console.WriteLine($"Day 05 - Part 2 - Number of overlaps {pointsCrossed.Count(p => p.Value > 1)}");
		}

		private static Dictionary<Point, int> Solve(List<Line> input, int part)
		{
			var pointsCrossed = new Dictionary<Point, int>();
			foreach (var line in input)
			{
				if (part == 1 && !line.IsVertical && !line.IsHorizontal) continue;
				foreach (var vertex in line.Vertices)
				{
					if (pointsCrossed.ContainsKey(vertex))
						pointsCrossed[vertex]++;
					else
						pointsCrossed.Add(vertex, 1);
				}
			}

			return pointsCrossed;
		}

		private static List<Line> ParseInput(string[] inputLines)
		{
			var lines = new List<Line>();
			foreach (var inputLine in inputLines)
			{
				var pointStrings = inputLine.Split("->").Select(x => x.Trim()).ToArray();
				var line = new Line(
					int.Parse(pointStrings[0].Split(',')[0]),
					int.Parse(pointStrings[0].Split(',')[1]),
					int.Parse(pointStrings[1].Split(',')[0]),
					int.Parse(pointStrings[1].Split(',')[1])
				);
				lines.Add(line);
			}
			return lines;
		}

		public class Point
		{
			public int X, Y;

			public Point(int x, int y)
			{
				X = x;
				Y = y;
			}

			public override bool Equals(object? obj)
			{
				if (obj is null)
					return false;

				if (obj.GetType() == typeof(Point))
					return this == (Point)obj;

				return GetHashCode() == obj.GetHashCode();
			}

			public override int GetHashCode()
			{
				return X.GetHashCode() ^ Y.GetHashCode();
			}

			public static bool operator ==(Point left, Point right)
			{
				return left.X == right.X && left.Y == right.Y;
			}

			public static bool operator !=(Point left, Point right)
			{
				return left.X != right.X || left.Y != right.Y;
			}
		}

		public class Line
		{
			private bool? isHorizontal;
			private bool? isVertical;
			private readonly List<Point> _vertices = new();

			public Line(int aX, int aY, int bX, int bY)
			{
				A = new Point(aX, aY);
				B = new Point(bX, bY);
			}

			public Point A { get; set; }
			public Point B { get; set; }

			public bool IsHorizontal
			{
				get
				{
					if (isHorizontal is not null)
						return isHorizontal.Value;

					if (A is null || B is null)
						return false;

					isHorizontal = A.Y == B.Y;

					return isHorizontal.Value;
				}
			}

			public bool IsVertical
			{
				get
				{
					if (isVertical is not null)
						return isVertical.Value;

					if (A is null || B is null)
						return false;

					isVertical = A.X == B.X;

					return isVertical.Value;
				}
			}

			public bool IsDiagonal => !IsVertical && !IsHorizontal;

			public List<Point> Vertices
			{
				get
				{
					if (_vertices.Any()) return _vertices;

					if (IsHorizontal)
						if (A.X < B.X)
							_vertices.AddRange(Enumerable.Range(A.X, B.X - A.X + 1).Select(x => new Point(x, A.Y)));
						else
							_vertices.AddRange(Enumerable.Range(B.X, A.X - B.X + 1).Select(x => new Point(x, A.Y)));

					if (IsVertical)
						if (A.Y < B.Y)
							_vertices.AddRange(Enumerable.Range(A.Y, B.Y - A.Y + 1).Select(y => new Point(A.X, y)));
						else
							_vertices.AddRange(Enumerable.Range(B.Y, A.Y - B.Y + 1).Select(y => new Point(A.X, y)));

					// Can be assumed to be diagonal given ruleset but oh well
					if (IsDiagonal)
					{
						var xValues = A.X < B.X ? Enumerable.Range(A.X, B.X - A.X + 1) : Enumerable.Range(B.X, A.X - B.X + 1).Reverse();
						var yValues = A.Y < B.Y ? Enumerable.Range(A.Y, B.Y - A.Y + 1) : Enumerable.Range(B.Y, A.Y - B.Y + 1).Reverse();

						_vertices.AddRange(xValues.Zip(yValues).Select(zip => new Point(zip.First,zip.Second)));
					}

					return _vertices;
				}
			}
		}
	}
}

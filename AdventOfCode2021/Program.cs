// See https://aka.ms/new-console-template for more information
using AdventOfCode2021;

Console.WriteLine("Advent of Code - 2021!");

foreach (var arg in args)
{
	Console.WriteLine();
	switch (int.Parse(arg))
	{
		case 1: Day01.Run(); break;
		case 2: Day02.Run(); break;
		case 3: Day03.Run(); break;
		case 4: Day04.Run(); break;
	}
}
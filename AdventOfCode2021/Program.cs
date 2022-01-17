﻿// See https://aka.ms/new-console-template for more information
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
		case 5: Day05.Run(); break;
		case 6: Day06.Run(); break;
		case 7: Day07.Run(); break;
		case 8: Day08.Run(); break;
		case 9: Day09.Run(); break;
	}
}
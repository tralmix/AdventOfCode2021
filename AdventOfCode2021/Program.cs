// See https://aka.ms/new-console-template for more information
using AdventOfCode2021;

Console.WriteLine("Advent of Code - 2021!");
Console.WriteLine();

// Day 01
var day01LinesOfInput = File.ReadAllLines("Inputs/Day01Input.txt");
var day01Input = day01LinesOfInput.Select(int.Parse).ToArray();
Console.WriteLine($"Day 01 - Part 1 - {Day01.FindNumberOfIncreasesInDepth(day01Input)}");
Console.WriteLine($"Day 01 - Part 2 - {Day01.FindDepthIncreaseCountForWindowsOfThree(day01Input)}");

Console.WriteLine();

// Day 02
var day02LinesOfInput = File.ReadAllLines("Inputs/Day02Input.txt");
var instructions = Day02.ParseInstructions(day02LinesOfInput);
var location = Day02.FindLocationAfterInstructions(instructions);
Console.WriteLine($"Final location {location.Horizontal}, {location.Depth}. Product = {location.Depth * location.Horizontal}");
var correctLocation = Day02.FindLocationAfterUpdatedInstructions(instructions);
Console.WriteLine($"Final location {correctLocation.Horizontal}, {correctLocation.Depth}. Product = {correctLocation.Depth * correctLocation.Horizontal}");

// See https://aka.ms/new-console-template for more information
using AdventOfCode2021;

Console.WriteLine("Hello, World!");


// Day 01 - part 1
var day01LinesOfInput = File.ReadAllLines("Day01Input.txt");
var day01Input = day01LinesOfInput.Select(int.Parse).ToArray();
Console.WriteLine($"Day 01 - Part 1 - {Day01.FindNumberOfIncreasesInDepth(day01Input)}");
Console.WriteLine($"Day 01 - Part 2 - {Day01.FindDepthIncreaseCountForWindowsOfThree(day01Input)}");

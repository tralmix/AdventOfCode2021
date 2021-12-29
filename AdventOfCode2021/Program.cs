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
Console.WriteLine($"Day 02 - Part 1 -Final location {location.Horizontal}, {location.Depth}. Product = {location.Depth * location.Horizontal}");
var correctLocation = Day02.FindLocationAfterUpdatedInstructions(instructions);
Console.WriteLine($"Day 02 - Part 2 -Final location {correctLocation.Horizontal}, {correctLocation.Depth}. Product = {correctLocation.Depth * correctLocation.Horizontal}");

Console.WriteLine();

// Day 03
var day03LinesOfInput = File.ReadAllLines("Inputs/Day03Input.txt");
var gammaRate = Day03.GetGammaRate(day03LinesOfInput);
var epsilonRate = Day03.GetEpsilonRate(day03LinesOfInput);
Console.WriteLine($"Day 03 - Part 1 - Gamma {gammaRate}, Epsilon {epsilonRate}, Power Consumption {gammaRate * epsilonRate}");
var oxygenGeneratorRating = Day03.GetOxygenGeneratorRating(day03LinesOfInput);
var co2ScrubberRating = Day03.GetCO2ScrubberRating(day03LinesOfInput);
Console.WriteLine($"Day 03 - Part 2 - O2 {oxygenGeneratorRating}, CO2 {co2ScrubberRating}, Life Support Rating {oxygenGeneratorRating * co2ScrubberRating}");

Console.WriteLine();

// Day 04
var day04LinesOfInput = File.ReadAllLines("Inputs/Day04Input.txt");
var numberCallOrder = Day04.GetNumberCallOrder(day04LinesOfInput);
var boards = Day04.GetBoards(day04LinesOfInput);
var winner = Day04.FindWinningBoardAndNumber(numberCallOrder, Day04.GetBoards(day04LinesOfInput));
Console.WriteLine($"Day 04 - Part 1 - Winning Numbers {string.Join(',', winner.Board.WinningNumbers)}");
Console.WriteLine($"Day 04 - Part 1 - Last Number Drawn {string.Join(',', winner.Number)}");
Console.WriteLine($"Day 04 - Part 1 - Final Score {winner.Board.SumOfUnmarked * int.Parse(winner.Number)}");
var lastWinner = Day04.FindLastWinningBoardAndNumber(numberCallOrder, Day04.GetBoards(day04LinesOfInput));
Console.WriteLine($"Day 04 - Part 2 - Winning Numbers {string.Join(',', lastWinner.Board.WinningNumbers)}");
Console.WriteLine($"Day 04 - Part 2 - Last Number Drawn {string.Join(',', lastWinner.Number)}");
Console.WriteLine($"Day 04 - Part 2 - Final Score {lastWinner.Board.SumOfUnmarked * int.Parse(lastWinner.Number)}");

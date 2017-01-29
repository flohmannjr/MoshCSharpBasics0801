using System;
using System.Text;
using System.Text.RegularExpressions;

namespace MoshCSharpBasics0801
{
    class Program
    {
        const int Consecutive = 1;
        const int Duplicate = 2;
        const int WorldHour = 3;
        const int PascalCase = 4;
        const int Vowels = 5;
        const int Exit = 9;

        static void Main(string[] args)
        {
            var options = new StringBuilder();
            var exercise = 0;

            options
                .AppendLine()
                .Append('-', 20)
                .AppendLine()
                .Append("1 - Consecutive")
                .AppendLine()
                .Append("2 - Duplicate")
                .AppendLine()
                .Append("3 - World Hour")
                .AppendLine()
                .Append("4 - Pascal Case")
                .AppendLine()
                .Append("5 - Vowels")
                .AppendLine()
                .Append("9 - Exit")
                .AppendLine()
                .Append('-', 20)
                .AppendLine()
                .AppendLine()
                .Append("Choose an exercise: ");

            while (true)
            {
                Console.Write(options);
                exercise = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                if (exercise == Exit)
                    break;

                switch (exercise)
                {
                    case Consecutive:
                        Console.Write("Enter a few numbers separated by a hyphen: ");
                        var hyphened = Console.ReadLine();
                        var hyphenedNumbers = hyphened.Trim().Split('-');
                        var hyphenedInt = Array.ConvertAll(hyphenedNumbers, h => Convert.ToInt32(h));

                        var consecutive = false;

                        if(hyphenedInt[1] == hyphenedInt[0] + 1)
                        {
                            for (var c = 1; c < hyphenedInt.Length; c++)
                                if (hyphenedInt[c] == hyphenedInt[c - 1] + 1)
                                    consecutive = true;
                                else
                                {
                                    consecutive = false;
                                    break;
                                }
                        }
                        else if(hyphenedInt[1] == hyphenedInt[0] - 1)
                        {
                            for (var c = 1; c < hyphenedInt.Length; c++)
                                if (hyphenedInt[c] == hyphenedInt[c - 1] - 1)
                                    consecutive = true;
                                else
                                {
                                    consecutive = false;
                                    break;
                                }
                        }

                        Console.WriteLine(consecutive ? "Consecutive" : "Not Consecutive");

                        break;
                    case Duplicate:
                        Console.Write("Enter a few numbers separated by a hyphen: ");
                        var hyphened2 = Console.ReadLine();

                        if (String.IsNullOrEmpty(hyphened2))
                            break;

                        var hyphened2Int = Array.ConvertAll(hyphened2.Trim().Split('-'), h => Convert.ToInt32(h));
                        var duplicate = false;

                        for (var h = 0; h < hyphened2Int.Length; h++)
                            for (var d = h + 1; d < hyphened2Int.Length; d++)
                                if(hyphened2Int[h] == hyphened2Int[d])
                                    duplicate = true;

                        if(duplicate)
                            Console.WriteLine("Duplicate");

                        break;
                    case WorldHour:
                        Console.Write("Enter a time value in the 24-hour time format: ");
                        var time = Console.ReadLine();
                        var pattern = "([01][0-9]|2[0-3]):[0-5][0-9]";
                        Console.WriteLine(Regex.IsMatch(time, pattern) ? "Ok" : "Invalid Time");
                        break;
                    case PascalCase:
                        Console.Write("Enter a few words separated by a space: ");
                        var words = Console.ReadLine().Trim().ToLower().Split(' ');
                        var variableName = new StringBuilder();

                        foreach(var word in words)
                            variableName
                                .Append(word[0].ToString().ToUpper())
                                .Append(word.Substring(1));

                        Console.WriteLine("Variable name: " + variableName);

                        break;
                    case Vowels:
                        Console.Write("Enter an English word: ");
                        var englishWord = Console.ReadLine().Trim().ToLower();
                        var vowels = "aeiou";
                        var vowelsCount = 0;

                        for (var v = 0; v < englishWord.Length; v++)
                            if (vowels.IndexOf(englishWord[v]) >= 0)
                                vowelsCount++;

                        Console.WriteLine("Number of vowels: " + vowelsCount);

                        break;
                    default:
                        Console.WriteLine("Invalid exercise.");
                        break;
                }
            }
        }
    }
}

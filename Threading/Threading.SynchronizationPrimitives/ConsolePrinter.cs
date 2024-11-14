using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Threading.SynchronizationPrimitives
{
    public class ConsolePrinter : IPrinter
    {
        private readonly StringBuilder _output = new();

        public void Append(string text)
        {
            _output.Append(text);
        }

        public void Append(char value)
        {
            _output.Append(value);
        }

        public void AppendLine()
        {
            _output.AppendLine();
        }

        public void AppendLine(string text)
        {
            _output.AppendLine(text);
        }
        
        public void DisplayInfo(
            DeliveryDepartment deliveryDepartment, 
            OperatorDepartment operatorDepartment,
            Warehouse warehouse,
            Logger logger)
        {
            Console.CursorVisible = false;
            Console.ResetColor();
            Console.Clear();
            
            const string keyInfo = "D - add deliveryman (+shift to remove), O - add operator (+shift to remove), ESC - exit ";

            _output.Clear();

            _output.AppendLine(keyInfo);
            _output.AppendLine();

            warehouse.PrintInfo(this);
            _output.AppendLine();
            
            deliveryDepartment.PrintInfo(this);
            _output.AppendLine();
            
            operatorDepartment.PrintInfo(this);
            _output.AppendLine();
            
            logger.PrintMessages(this);

            var input = _output.ToString();
            
            var matches = Regex.Matches(input, @"\[(?<params>[^|\]\[]*)[|](?<content>[^|\[\]]*)\]",
                RegexOptions.Compiled);

            if (matches.Count == 0)
            {
                Console.WriteLine(input);
            }
            else
            {
                var printGroups = new List<(int startIndex, int lastIndex, Match match)>();

                var lastIndex = 0;

                foreach (Match match in matches)
                {
                    var @params = match.Groups.GetValueOrDefault("params", null);

                    if (@params is null)
                    {
                        continue;
                    }
                    
                    var content = match.Groups.GetValueOrDefault("content", null);

                    if (content is null)
                    {
                        continue;
                    }

                    var last = printGroups.LastOrDefault(x => x.lastIndex <= match.Index);

                    if (printGroups.Count == 0 || (last != default && last.lastIndex != match.Index)) 
                    {
                        printGroups.Add((last.lastIndex, match.Index, null));
                    }

                    lastIndex = match.Index + match.Length;
                    printGroups.Add((match.Index, lastIndex, match));
                }

                if (lastIndex < input.Length)
                {
                    printGroups.Add((lastIndex, input.Length, null));
                }

                foreach (var printGroup in printGroups)
                {
                    if (printGroup.match is null)
                    {
                        Console.Write(input.Substring(printGroup.startIndex, printGroup.lastIndex - printGroup.startIndex));
                        continue;
                    }
                    
                    var param = printGroup.match.Groups["params"];
                    var content = printGroup.match.Groups["content"];

                    var paramMatches = Regex.Matches(param.Value, @"(?<name>[^=;]+)=(?<value>[^=;]+)", 
                        RegexOptions.Compiled);

                    foreach (Match paramMatch in paramMatches)
                    {
                        var nameGroup = paramMatch.Groups.GetValueOrDefault("name", null);
                        var valueGroup = paramMatch.Groups.GetValueOrDefault("value", null);

                        if (nameGroup is null || valueGroup is null)
                        {
                            continue;
                        }

                        if (nameGroup.Value is "color" && Enum.TryParse<ConsoleColor>(valueGroup.Value, out var consoleColor))
                        {
                            Console.ForegroundColor = consoleColor;
                        }
                    }

                    Console.Write(content);
                    Console.ResetColor();
                }
            }
        }
    }
}
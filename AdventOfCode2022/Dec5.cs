using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Dec5
    {
        public async Task RunProblem()
        {
            var path = @"C:\Users\Matthew Park\source\repos\AdventOfCode2022\AdventOfCode2022\inputs\dec5.txt";
            var lines = (await System.IO.File.ReadAllLinesAsync(path)).ToList();
            lines.RemoveRange(0, 10);
            var stacks = new List<Stack<string>>()
            {
                new Stack<string>(new string[]{"H", "T", "Z", "D"}),
                new Stack<string>(new string[]{ "Q", "R", "W", "T", "G", "C", "S" }),
                new Stack<string>(new string[]{ "P", "B", "F", "Q", "N", "R", "C", "H" }),
                new Stack<string>(new string[]{ "L", "C", "N", "F", "H", "Z" }),
                new Stack<string>(new string[]{ "G", "L", "F", "Q", "S" }),
                new Stack<string>(new string[]{ "V", "P", "W", "Z", "B", "R", "C", "S" }),
                new Stack<string>(new string[]{ "Z", "F", "J" }),
                new Stack<string>(new string[]{ "D", "L", "V", "Z", "R", "H", "Q" }),
                new Stack<string>(new string[]{ "B", "H", "G", "N", "F", "Z", "L", "D" })
            };
            var finalStopStack = "";

            foreach (var move in lines)
            {
                var moves = move.Split(" ");
                var totalPops = int.Parse(moves[1]);
                var moveFrom = int.Parse(moves[3]);
                var moveTo = int.Parse(moves[5]);
                var pops = new List<string>();
                for (var i = 0; i < totalPops; i++)
                {
                    pops.Add(stacks[moveFrom - 1].Pop());
                }

                pops.Reverse();
                foreach (var thePop in pops)
                {
                    stacks[moveTo - 1].Push(thePop);
                }
            }

            foreach (var stack in stacks)
            {
                finalStopStack += stack.Pop();
            }

            Console.WriteLine("The Final Stop Stack is: " + finalStopStack);
        }
    }
}

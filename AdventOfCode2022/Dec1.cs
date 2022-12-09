using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Dec1
    {
        public async Task RunProblem()
        {
            var path = @"C:\Users\Matthew Park\source\repos\AdventOfCode2022\AdventOfCode2022\inputs\dec1.txt";
            var lines = await System.IO.File.ReadAllLinesAsync(path);
            long topThreeElvesTotalCalories = 0;
            long currentTotalCalories = 0;
            var elveCalories = new List<long>();

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    elveCalories.Add(currentTotalCalories);
                    currentTotalCalories = 0;
                }
                else
                {
                    currentTotalCalories += long.Parse(line);
                }
            }

            elveCalories.Sort();
            elveCalories.Reverse();
            topThreeElvesTotalCalories = elveCalories[0] + elveCalories[1] + elveCalories[2];

            Console.WriteLine($@"Highest Calories is {topThreeElvesTotalCalories}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Dec2
    {
        public async Task RunProblem()
        {
            var path = @"C:\Users\Matthew Park\source\repos\AdventOfCode2022\AdventOfCode2022\inputs\dec2.txt";
            var lines = await System.IO.File.ReadAllLinesAsync(path);
            var tournamentRounds = new List<Round>();

            foreach (var line in lines)
            {
                var plays = line.Split(' ');
                tournamentRounds.Add(new Round(ParseOpponentHand(plays[0]), ParseRoundEnd(plays[1])));
            }

            Console.WriteLine("My Total Score: " + tournamentRounds.Select(x => x.RoundScore).Sum());
        }

        private Shape ParseOpponentHand(string opponentHand)
        {
            if (opponentHand == "A")
            {
                return Shape.Rock;
            }
            else if (opponentHand == "B")
            {
                return Shape.Paper;
            }
            else
            {
                return Shape.Scissors;
            }
        }

        private RoundEnd ParseRoundEnd(string roundEnd)
        {
            if (roundEnd == "X")
            {
                return RoundEnd.Lose;
            }
            else if (roundEnd == "Y")
            {
                return RoundEnd.Draw;
            }
            else
            {
                return RoundEnd.Win;
            }
        }
    }

    internal class Round
    {
        public Round(Shape opponentPlay, RoundEnd roundEnd)
        {
            OpponentPlay = opponentPlay;
            RoundEnd = roundEnd;
        }

        public Shape OpponentPlay { get; }
        public RoundEnd RoundEnd { get; }
        public int ShapeScore {
            get
            {
                return OpponentPlay switch
                {
                    Shape.Rock when RoundEnd == RoundEnd.Win => 2,
                    Shape.Rock when RoundEnd == RoundEnd.Lose => 3,
                    Shape.Rock when RoundEnd == RoundEnd.Draw => 1,
                    Shape.Paper when RoundEnd == RoundEnd.Win => 3,
                    Shape.Paper when RoundEnd == RoundEnd.Lose => 1,
                    Shape.Paper when RoundEnd == RoundEnd.Draw => 2,
                    Shape.Scissors when RoundEnd == RoundEnd.Win => 1,
                    Shape.Scissors when RoundEnd == RoundEnd.Lose => 2,
                    _ => 3,
                };
            }
        }

        public int OutcomeScore
        {
            get
            {
                return RoundEnd switch
                {
                    RoundEnd.Draw => 3,
                    RoundEnd.Win => 6,
                    _ => 0
                };
            }
        }
        public int RoundScore => ShapeScore + OutcomeScore;
    }

    internal enum Shape
    {
        Rock,
        Paper,
        Scissors
    }

    internal enum RoundEnd
    {
        Win,
        Lose,
        Draw
    }
}

using FootballSimulator.Models.Contracts;
using System;

namespace FootballSimulator.Models
{
    public class Match
    {
        private IResultCalculator resultCalculator;

        public Match(IResultCalculator resultCalculator, ITeam firstTeam, ITeam secondTeam)
        {
            this.resultCalculator = resultCalculator;
            this.wasPlayed = false;
            this.firstTeam = firstTeam;
            this.secondTeam = secondTeam;
        }

        public bool wasPlayed { get; set; }
        public ITeam firstTeam { get; set; }
        public ITeam secondTeam { get; set; }

        public Result Play()
        {
            string scoreString = this.resultCalculator.Calculate(this.firstTeam.Overall, this.secondTeam.Overall);

            var score = scoreString.Split(':');
            var result = new Result(this.firstTeam, this.secondTeam, int.Parse(score[0]), int.Parse(score[1]));

            this.wasPlayed = true;
            this.Print(this.firstTeam.Name, this.secondTeam.Name, result.ToString());
            return result;
        }

        private void Print(string firstTeam, string secondTeam, string result)
        {
            Console.WriteLine("{0} {1} {2}", firstTeam, result, secondTeam);
        }
    }
}

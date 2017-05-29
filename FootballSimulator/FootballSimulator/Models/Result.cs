using FootballSimulator.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSimulator.Models
{
    public class Result
    {
        public Result(ITeam homeTeam, ITeam awayTeam, int homeTeamGoals, int awayTeamGoals)
        {
            this.HomeTeam = homeTeam;
            this.AwayTeam = awayTeam;
            this.HomeTeamGoals = homeTeamGoals;
            this.AwayTeamGoals = awayTeamGoals;
        }

        public ITeam HomeTeam { get; set; }
        public ITeam AwayTeam { get; set; }
        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }

        public override string ToString()
        {
            return $"{this.HomeTeamGoals} : {this.AwayTeamGoals}";
        }
    }
}

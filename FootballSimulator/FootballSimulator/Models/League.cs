using FootballSimulator.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSimulator.Models
{
    public class League
    {
        private IList<Match> leagueMatches;
        public League(string name, string country, IList<ITeam> teams)
        {
            this.Name = name;
            this.Country = country;
            this.Teams = teams;
            this.leagueMatches = new List<Match>();
        }

        public string Name { get; set; }
        public string Country { get; set; }
        public IList<ITeam> Teams { get; set; }

        public void CreateFixures(ResultCalculator resultCalculator)
        {
            for (int i = 0; i < this.Teams.Count - 1; i++)
            {
                for (int j = i + 1; j < this.Teams.Count; j++)
                {
                    Match match = new Match(resultCalculator, this.Teams[i], this.Teams[j]);
                    this.leagueMatches.Add(match);
                }
            }
        }

        public void PlayMatches()
        {
            for (int i = 0; i < this.leagueMatches.Count; i++)
            {
                var result = leagueMatches[i].Play();
                if (result.HomeTeamGoals > result.AwayTeamGoals)
                {
                    result.HomeTeam.LeaguePoints += 3;
                }
                else if (result.HomeTeamGoals < result.AwayTeamGoals)
                {
                    result.AwayTeam.LeaguePoints += 3;
                }
                else
                {
                    result.HomeTeam.LeaguePoints += 1;
                    result.AwayTeam.LeaguePoints += 1;
                }

                result.HomeTeam.GoalsScored += result.HomeTeamGoals;
                result.HomeTeam.GoalsConceeded += result.AwayTeamGoals;
                result.AwayTeam.GoalsScored += result.AwayTeamGoals;
                result.AwayTeam.GoalsConceeded += result.HomeTeamGoals;

            }
        }

        public void ShowTable()
        {
            Console.WriteLine($"---{this.Name}---");
            var orderedTeams = this.Teams.OrderByDescending(p => p.LeaguePoints).ThenByDescending(gd => gd.GoalDifference);
            foreach (var team in orderedTeams)
            {
                Console.WriteLine(team.ShowTableInformation());
            }
            Console.WriteLine();
        }
    }
}

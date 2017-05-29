using System;
using FootballSimulator.Models.Contracts;

namespace FootballSimulator.Models
{
    public class Club : ITeam
    {
        private string name;
        private int overall;

        public Club(string name, int overall)
        {
            this.Name = name;
            this.Overall = overall;
            this.LeaguePoints = 0;
            this.GoalsScored = 0;
            this.GoalsConceeded = 0;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                this.name = value;
            }
        }

        public int Overall
        {
            get
            {
                return this.overall;
            }

            private set
            {
                this.overall = value;
            }
        }

        public int LeaguePoints { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsConceeded { get; set; }

        public int GoalDifference
        {
            get
            {
                return this.GoalsScored - this.GoalsConceeded;
            }
        }

        public string ShowTableInformation()
        {
            return $"{this.Name,20}| - {this.LeaguePoints}p = {this.GoalDifference}";
        }
    }
}

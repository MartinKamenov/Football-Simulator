namespace FootballSimulator.Models.Contracts
{
    public interface ITeam
    {
        string Name { get; }

        int Overall { get; }

        int LeaguePoints { get; set; }

        int GoalsScored { get; set; }

        int GoalsConceeded { get; set; }

        int GoalDifference { get; }

        string ShowTableInformation();
    }
}

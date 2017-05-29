using System;
using FootballSimulator.Models.Contracts;

namespace FootballSimulator.Models
{
    public class ResultCalculator : IResultCalculator
    {
        public const float HomeConstant = 1.9f;
        public const float AwayConstant = 2f;

        public string Calculate(int firstTeamOverall, int secondTeamOverall)
        {
            var chanceChangerResults = this.ChanceChanger(firstTeamOverall, secondTeamOverall);
            float chanceForScoringTeam1 = chanceChangerResults[0];
            float chanceForScoringTeam2 = chanceChangerResults[1];
            bool firstTeamStopped = false;
            bool secondTeamStopped = false;

            int firstTeamGoals = 0;
            int secondTeamGoals = 0;
            
            do
            {
                int number = Guid.NewGuid().GetHashCode() % 100;
                number = number > 0 ? number : -number;

                if (number <= chanceForScoringTeam1)
                {
                    firstTeamGoals++;
                    chanceForScoringTeam1 /= HomeConstant;
                }
                else
                {
                    firstTeamStopped = true;
                }
            }
            while (!firstTeamStopped);

            do
            {
                int number = Guid.NewGuid().GetHashCode() % 100;
                number = number > 0 ? number : -number;

                if (number <= chanceForScoringTeam2)
                {
                    secondTeamGoals++;
                    chanceForScoringTeam2 /= AwayConstant;
                }
                else
                {
                    secondTeamStopped = true;
                }
            }
            while (!secondTeamStopped);

            string result = string.Format("{0} : {1}", firstTeamGoals, secondTeamGoals);

            return result;
        }

        private float[] ChanceChanger(float chanceForScoringTeam1, float chanceForScoringTeam2)
        {
            if (chanceForScoringTeam1 - chanceForScoringTeam2 >= 20)
            {
                chanceForScoringTeam1 *= 2;
            }

            else if (chanceForScoringTeam2 - chanceForScoringTeam1 >= 20)
            {
                chanceForScoringTeam2 *= 2;
            }

            else if (chanceForScoringTeam1 - chanceForScoringTeam2 >= 10)
            {
                chanceForScoringTeam1 *= 1.5f;
            }

            else if (chanceForScoringTeam2 - chanceForScoringTeam1 >= 10)
            {
                chanceForScoringTeam2 *= 1.5f;
            }

            else if (chanceForScoringTeam1 - chanceForScoringTeam2 >= 5)
            {
                chanceForScoringTeam1 += 30f;
            }

            else if (chanceForScoringTeam2 - chanceForScoringTeam1 >= 5)
            {
                chanceForScoringTeam2 += 30f;
            }

            float[] result = new float[2] {
                chanceForScoringTeam1,
                chanceForScoringTeam2
            };
            return result;
        }
    }
}

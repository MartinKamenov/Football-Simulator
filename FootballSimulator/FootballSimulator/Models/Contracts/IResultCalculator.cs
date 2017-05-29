using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSimulator.Models.Contracts
{
    public interface IResultCalculator
    {
        string Calculate(int firstTeamOverall, int secondTeamOverall);
    }
}

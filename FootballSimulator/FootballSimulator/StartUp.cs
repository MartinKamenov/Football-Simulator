using FootballSimulator.Models;
using System.Collections.Generic;

namespace FootballSimulator
{
    public class StartUp
    {
        public static void Main()
        {
            var clubs = new Club[] {
                new Club("Chelsea", 85),
                new Club("Manchester United", 84),
                new Club("Liverpool", 80),
                new Club("Manchester City", 84),
                new Club("Tottenham", 82),
                new Club("Arsenal", 81),
                new Club("Everton", 77),
                new Club("Southampton", 76),
                new Club("Bournemouth", 74),
                new Club("West Brom", 75),
                new Club("West Ham", 75),
                new Club("Leicester City", 79),
                new Club("Stoke City", 72),
                new Club("Crystal Palace", 76),
                new Club("Swansea", 72),
                new Club("Burnley", 69),
                new Club("Watford", 68),
                new Club("Hull City", 67),
                new Club("Middlesbrough", 68),
                new Club("Sunderland", 65)
        };
            var clubs2 = new Club[] {
                new Club("Barcelona", 90),
                new Club("Real Madrid", 89),
                new Club("Atlético Madrid", 84),
                new Club("Sevilla FC", 82),
                new Club("Villarreal", 81),
                new Club("Real Sociedad", 78),
                new Club("Athletic Bilbao", 77),
                new Club("Espanyol", 76),
                new Club("Alavés", 72),
                new Club("Eibar", 73),
                new Club("Málaga", 76),
                new Club("Valencia", 79),
                new Club("Celta Vigo", 75),
                new Club("Las Palmas", 74),
                new Club("Real Betis", 69),
                new Club("Deportivo La Coruña", 70),
                new Club("Leganes", 65),
                new Club("Sporting Gijón", 69),
                new Club("Osasuna", 68),
                new Club("Granada", 65)
        };
            League barclaysLeague = new League("Barclays Premium League", "England", clubs);
            League laLiga = new League("La Liga", "Spain", clubs2);
            barclaysLeague.CreateFixures(new ResultCalculator());
            laLiga.CreateFixures(new ResultCalculator());
            barclaysLeague.PlayMatches();
            laLiga.PlayMatches();
            barclaysLeague.ShowTable();
            laLiga.ShowTable();
        }
    }
}

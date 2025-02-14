using ADO.NET.WorkTables.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET._5
{
    internal class MenuManager
    {
        private readonly DatabaseManager dbManager;

        public MenuManager(DatabaseManager databaseManager)
        {
            dbManager = databaseManager;
        }

        public void ShowMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add a command");
                Console.WriteLine("2. List all commands");
                Console.WriteLine("3. Search for a command by name");
                Console.WriteLine("4. Search for commands by city");
                Console.WriteLine("5. Search for a team by name and city");
                Console.WriteLine("6. Team with the most wins");
                Console.WriteLine("7. Team with the most losses");
                Console.WriteLine("8. Team with the most draws");
                Console.WriteLine("9. Team with the most goals scored");
                Console.WriteLine("10. Team with the most goals conceded");
                Console.WriteLine("11. Add new command (with validation)");
                Console.WriteLine("12. Change existing team data");
                Console.WriteLine("13. Delete team");
                Console.WriteLine("14. Add player");
                Console.WriteLine("15. Add match");
                Console.WriteLine("16. Show the difference between goals scored and goals conceded for each team");
                Console.WriteLine("17. Show full match information");
                Console.WriteLine("18. Show matches for a specific date");
                Console.WriteLine("19. Show all matches of a specific team");
                Console.WriteLine("20. Show all players who scored goals on a specific date");
                Console.WriteLine("21. Add new match (with verification)");
                Console.WriteLine("22. Change existing match data");
                Console.WriteLine("23. Delete match");
                Console.WriteLine("24. Exit");
                Console.Write("Your choice: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Team name: ");
                        string name = Console.ReadLine();
                        Console.Write("Team city: ");
                        string city = Console.ReadLine();
                        Console.Write("Wins: ");
                        int wins = int.Parse(Console.ReadLine());
                        Console.Write("Loss: ");
                        int losses = int.Parse(Console.ReadLine());
                        Console.Write("Draws: ");
                        int draws = int.Parse(Console.ReadLine());
                        Console.Write("Goals scored: ");
                        int goalsScored = int.Parse(Console.ReadLine());
                        Console.Write("Goals conceded: ");
                        int goalsConceded = int.Parse(Console.ReadLine());

                        dbManager.AddTeam(new SoccerComandModel { Name = name, City = city, Wins = wins, Losses = losses, Draws = draws, GoalsScored = goalsScored, GoalsConceded = goalsConceded });
                        break;
                    case "2":
                        dbManager.GetAllTeams();
                        break;
                    case "3":
                        Console.Write("Enter the team name: ");
                        string teamName = Console.ReadLine();
                        dbManager.SearchTeamByName(teamName);
                        break;
                    case "4":
                        Console.Write("Enter the city: ");
                        string cityName = Console.ReadLine();
                        dbManager.SearchTeamsByCity(cityName);
                        break;
                    case "5":
                        Console.Write("Enter the team name: ");
                        string teamNameCity = Console.ReadLine();
                        Console.Write("Enter city: ");
                        string teamCityName = Console.ReadLine();
                        dbManager.SearchTeamByNameAndCity(teamNameCity, teamCityName);
                        break;
                    case "6":
                        dbManager.GetTeamWithMostWins();
                        break;
                    case "7":
                        dbManager.GetTeamWithMostLosses();
                        break;
                    case "8":
                        dbManager.GetTeamWithMostDraws();
                        break;
                    case "9":
                        dbManager.GetTeamWithMostGoalsScored();
                        break;
                    case "10":
                        dbManager.GetTeamWithMostGoalsConceded();
                        break;
                    case "11":
                        Console.Write("Team name: ");
                        string newNameCheck = Console.ReadLine();
                        Console.Write("Team city: ");
                        string newCityCheck = Console.ReadLine();
                        Console.Write("Victories: ");
                        int winsCheck = int.Parse(Console.ReadLine());
                        Console.Write("Defeats: ");
                        int lossesCheck = int.Parse(Console.ReadLine());
                        Console.Write("Draws: ");
                        int drawsCheck = int.Parse(Console.ReadLine());
                        Console.Write("Goals scored: ");
                        int goalsScoredCheck = int.Parse(Console.ReadLine());
                        Console.Write("Goals conceded: ");
                        int goalsConcededCheck = int.Parse(Console.ReadLine());

                        dbManager.AddTeamWithCheck(new SoccerComandModel
                        {
                            Name = newNameCheck,
                            City = newCityCheck,
                            Wins = winsCheck,
                            Losses = lossesCheck,
                            Draws = drawsCheck,
                            GoalsScored = goalsScoredCheck,
                            GoalsConceded = goalsConcededCheck
                        });
                        break;

                    case "12":
                        Console.Write("Enter the name of the command to edit: ");
                        string updateName = Console.ReadLine();
                        Console.Write("Enter the team city to edit: ");
                        string updateCity = Console.ReadLine();
                        dbManager.UpdateTeam(updateName, updateCity);
                        break;
                    case "13":
                        Console.Write("Enter the name of the command to delete: ");
                        string deleteName = Console.ReadLine();
                        Console.Write("Enter the city of the command to delete: ");
                        string deleteCity = Console.ReadLine();
                        dbManager.DeleteTeam(deleteName, deleteCity);
                        break;
                    case "14":
                        Console.Write("Player's full name: ");
                        string fullName = Console.ReadLine();
                        Console.Write("Country: ");
                        string country = Console.ReadLine();
                        Console.Write("Player number: ");
                        int number = int.Parse(Console.ReadLine());
                        Console.Write("Position: ");
                        string position = Console.ReadLine();
                        Console.Write("Team ID: ");
                        int teamId = int.Parse(Console.ReadLine());

                        dbManager.AddPlayer(new Player
                        {
                            FullName = fullName,
                            Country = country,
                            Number = number,
                            Position = position,
                            TeamId = teamId
                        });
                        break;
                    case "15":
                        Console.Write("Team ID 1: ");
                        int team1Id = int.Parse(Console.ReadLine());
                        Console.Write("Team ID 2: ");
                        int team2Id = int.Parse(Console.ReadLine());
                        Console.Write("Number of goals Team 1: ");
                        int team1Goals = int.Parse(Console.ReadLine());
                        Console.Write("Number of goals Team 2: ");
                        int team2Goals = int.Parse(Console.ReadLine());
                        Console.Write("Goal Scorer ID: ");
                        int scorerId = int.Parse(Console.ReadLine());
                        Console.Write("Match date (yyyy-mm-dd): ");
                        DateTime matchDate = DateTime.Parse(Console.ReadLine());
                        dbManager.AddMatch(team1Id, team2Id, team1Goals, team2Goals, scorerId, matchDate);
                        break;
                    case "16":
                        dbManager.ShowGoalDifferenceForEachTeam();
                        break;
                    case "17":
                        Console.Write("Enter match ID: ");
                        int matchId = int.Parse(Console.ReadLine());
                        dbManager.ShowFullMatchInfo(matchId);
                        break;
                    case "18":
                        Console.Write("Enter the date (yyyy-mm-dd): ");
                        DateTime date = DateTime.Parse(Console.ReadLine());
                        dbManager.ShowMatchesByDate(date);
                        break;
                    case "19":
                        Console.Write("Enter the team name: ");
                        string teamName2 = Console.ReadLine();
                        dbManager.ShowMatchesByTeam(teamName2);
                        break;
                    case "20":
                        Console.Write("Enter the date (yyyy-mm-dd): ");
                        DateTime scorerDate = DateTime.Parse(Console.ReadLine());
                        dbManager.ShowScorersByDate(scorerDate);
                        break;
                    case "21":
                        Console.Write("Team ID 1: ");
                        int team1Id2 = int.Parse(Console.ReadLine());
                        Console.Write("Team ID 2: ");
                        int team2Id2 = int.Parse(Console.ReadLine());
                        Console.Write("Number of goals Team 1: ");
                        int team1Goals2 = int.Parse(Console.ReadLine());
                        Console.Write("Number of goals Team 2: ");
                        int team2Goals2 = int.Parse(Console.ReadLine());
                        Console.Write("Goal Scorer ID: ");
                        int scorerId2 = int.Parse(Console.ReadLine());
                        Console.Write("Match date (yyyy-mm-dd): ");
                        DateTime matchDate2 = DateTime.Parse(Console.ReadLine());

                        dbManager.AddMatchWithCheck(team1Id2, team2Id2, team1Goals2, team2Goals2, scorerId2, matchDate2);
                        break;

                    case "22":
                        Console.Write("Enter the match ID to edit: ");
                        int matchId2 = int.Parse(Console.ReadLine());
                        dbManager.UpdateMatch(matchId2);
                        break;

                    case "23":
                        Console.Write("Enter the name of Team 1: ");
                        string deleteTeam1 = Console.ReadLine();
                        Console.Write("Enter the name of Team 2: ");
                        string deleteTeam2 = Console.ReadLine();
                        Console.Write("Enter the date of the match (yyyy-mm-dd): ");
                        DateTime deleteDate = DateTime.Parse(Console.ReadLine());
                        dbManager.DeleteMatch(deleteTeam1, deleteTeam2, deleteDate);
                        break;
                    case "24":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}

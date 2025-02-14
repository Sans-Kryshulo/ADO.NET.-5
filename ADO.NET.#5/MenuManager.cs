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
                Console.WriteLine("14. Exit");
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

using ADO.NET._5.WorkTables;
using ADO.NET.WorkTables.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ADO.NET._5
{
    public class DatabaseManager
    {
        private SqlConnection connection;
        private readonly string connectionString;

        public DatabaseManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Connect()
        {
            if (connection == null)
            {
                connection = new SqlConnection(connectionString);
            }
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Successfully connected to the database!");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Connection failed: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Already connected.");
            }
        }

        public void Disconnect()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                Console.WriteLine("Disconnected from database.");
            }
        }
        public void AddTeam(SoccerComandModel team)
        {
            var context = new ANDbContext();
            context.SoccerComandModels.Add(team);
            context.SaveChanges();
            Console.WriteLine("The team has been added to the database.");
        }

        public void GetAllTeams()
        {
            var context = new ANDbContext();
            var Teams = context.SoccerComandModels.ToList();

            foreach (var item in Teams)
            {
                Console.WriteLine($"Id: {item.Id} " +
                    $"\n Name: {item.Name}  " +
                    $"\n City: {item.City} " +
                    $"\n Wins: {item.Wins}" +
                    $"\n Losses: {item.Losses}" +
                    $"\n Draws: {item.Draws}" +
                    $"\n GoalsScored: {item.GoalsScored}" +
                    $"\n GoalsConceded: {item.GoalsConceded}" +
                    $"\n ---------------");
            }
        }
        public void SearchTeamByName(string name)
        {
            var context = new ANDbContext();
            var team = context.SoccerComandModels.FirstOrDefault(t => t.Name == name);
            if (team != null)
                Console.WriteLine($"Знайдено: {team.Name} ({team.City}) - W:{team.Wins} L:{team.Losses} D:{team.Draws} GF:{team.GoalsScored} GA:{team.GoalsConceded}");
            else
                Console.WriteLine("Команду не знайдено.");
        }
        public void SearchTeamsByCity(string city)
        {
            var context = new ANDbContext();
            var teams = context.SoccerComandModels.Where(t => t.City == city).ToList();

            if (teams.Any())
            {
                Console.WriteLine($"Teams from the city {city}:");
                foreach (var team in teams)
                {
                    Console.WriteLine($"- {team.Name} (W:{team.Wins} L:{team.Losses} D:{team.Draws} GF:{team.GoalsScored} GA:{team.GoalsConceded})");
                }
            }
            else
            {
                Console.WriteLine($"No teams found in {city}.");
            }
        }
        public void SearchTeamByNameAndCity(string name, string city)
        {
            var context = new ANDbContext();
            var team = context.SoccerComandModels.FirstOrDefault(t => t.Name == name && t.City == city);

            if (team != null)
            {
                Console.WriteLine($"Team found: {team.Name} ({team.City})");
                Console.WriteLine($"- Wins: {team.Wins}, Losses: {team.Losses}, Draws: {team.Draws}");
                Console.WriteLine($"- Goals Scored: {team.GoalsScored}, Goals Conceded: {team.GoalsConceded}");
            }
            else
            {
                Console.WriteLine($"Team '{name}' not found in city '{city}'.");
            }
        }
        public void GetTeamWithMostWins()
        {
            var context = new ANDbContext();
            var team = context.SoccerComandModels.OrderByDescending(t => t.Wins).FirstOrDefault();

            if (team != null)
            {
                Console.WriteLine($"Team with the most wins: {team.Name} ({team.City}) - {team.Wins} wins");
            }
            else
            {
                Console.WriteLine("There is no data on the teams.");
            }
        }

        public void GetTeamWithMostLosses()
        {
            var context = new ANDbContext();
            var team = context.SoccerComandModels.OrderByDescending(t => t.Losses).FirstOrDefault();

            if (team != null)
            {
                Console.WriteLine($"Team with the most losses: {team.Name} ({team.City}) - {team.Losses} losses");
            }
            else
            {
                Console.WriteLine("There is no data on the teams.");
            }
        }

        public void GetTeamWithMostDraws()
        {
            var context = new ANDbContext();
            var team = context.SoccerComandModels.OrderByDescending(t => t.Draws).FirstOrDefault();

            if (team != null)
            {
                Console.WriteLine($"Team with the most draws: {team.Name} ({team.City}) - {team.Draws} draws");
            }
            else
            {
                Console.WriteLine("There is no data on the teams.");
            }
        }

        public void GetTeamWithMostGoalsScored()
        {
            var context = new ANDbContext();
            var team = context.SoccerComandModels.OrderByDescending(t => t.GoalsScored).FirstOrDefault();

            if (team != null)
            {
                Console.WriteLine($"Team with the most goals scored: {team.Name} ({team.City}) - {team.GoalsScored} goals");
            }
            else
            {
                Console.WriteLine("There is no data on the teams.");
            }
        }

        public void GetTeamWithMostGoalsConceded()
        {
            var context = new ANDbContext();
            var team = context.SoccerComandModels.OrderByDescending(t => t.GoalsConceded).FirstOrDefault();

            if (team != null)
            {
                Console.WriteLine($"Team with the most goals conceded: {team.Name} ({team.City}) - {team.GoalsConceded} goals");
            }
            else
            {
                Console.WriteLine("There is no data on the teams.");
            }
        }
        public void AddTeamWithCheck(SoccerComandModel team)
        {
            var context = new ANDbContext();
            var existingTeam = context.SoccerComandModels.FirstOrDefault(t => t.Name == team.Name && t.City == team.City);

            if (existingTeam != null)
            {
                Console.WriteLine("This command already exists in the database!");
                return;
            }

            context.SoccerComandModels.Add(team);
            context.SaveChanges();
            Console.WriteLine("Team successfully added!");
        }

        public void UpdateTeam(string name, string city)
        {
            var context = new ANDbContext();
            var team = context.SoccerComandModels.FirstOrDefault(t => t.Name == name && t.City == city);

            if (team == null)
            {
                Console.WriteLine("Team not found!");
                return;
            }

            Console.WriteLine($"Editing team {team.Name} ({team.City})");

            Console.Write("New name (or press Enter to leave unchanged): ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName))
                team.Name = newName;

            Console.Write("New garden (or press Enter to leave unchanged): ");
            string newCity = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newCity))
                team.City = newCity;

            Console.Write("New victories: ");
            if (int.TryParse(Console.ReadLine(), out int newWins))
                team.Wins = newWins;

            Console.Write("New defeats: ");
            if (int.TryParse(Console.ReadLine(), out int newLosses))
                team.Losses = newLosses;

            Console.Write("New draws: ");
            if (int.TryParse(Console.ReadLine(), out int newDraws))
                team.Draws = newDraws;

            Console.Write("New goals scored: ");
            if (int.TryParse(Console.ReadLine(), out int newGoalsScored))
                team.GoalsScored = newGoalsScored;

            Console.Write("New goals conceded: ");
            if (int.TryParse(Console.ReadLine(), out int newGoalsConceded))
                team.GoalsConceded = newGoalsConceded;

            context.SaveChanges();
            Console.WriteLine("Team data updated!");
        }

        public void DeleteTeam(string name, string city)
        {
            var context = new ANDbContext();
            var team = context.SoccerComandModels.FirstOrDefault(t => t.Name == name && t.City == city);

            if (team == null)
            {
                Console.WriteLine("Team not found!");
                return;
            }

            Console.Write($"Are you sure you want to delete the team {team.Name} ({team.City})? (Y/N): ");
            string confirmation = Console.ReadLine().Trim().ToLower();

            if (confirmation == "Y")
            {
                context.SoccerComandModels.Remove(team);
                context.SaveChanges();
                Console.WriteLine("Team successfully deleted!");
            }
            else
            {
                Console.WriteLine("The deletion has been canceled.");
            }
        }
    }
}

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
        public void AddPlayer(Player player)
        {
            var context = new ANDbContext();
            context.Players.Add(player);
            context.SaveChanges();
            Console.WriteLine("Player added to the team!");
        }
        public void AddMatch(int team1Id, int team2Id, int team1Goals, int team2Goals, int scorerId, DateTime matchDate)
        {
            var context = new ANDbContext();

            var match = new Match
            {
                Team1Id = team1Id,
                Team2Id = team2Id,
                Team1Goals = team1Goals,
                Team2Goals = team2Goals,
                ScorerId = scorerId,
                MatchDate = matchDate
            };

            context.Matches.Add(match);
            context.SaveChanges();
            Console.WriteLine("Match added to the database!");
        }
        public void ShowGoalDifferenceForEachTeam()
        {
            var context = new ANDbContext();
            var teams = context.SoccerComandModels.ToList();

            Console.WriteLine("Goal difference for each team:");
            foreach (var team in teams)
            {
                int goalDifference = team.GoalsScored - team.GoalsConceded;
                Console.WriteLine($"{team.Name} ({team.City}): {goalDifference} goals");
            }
        }
        public void ShowFullMatchInfo(int matchId)
        {
            var context = new ANDbContext();
            var match = context.Matches
                .Include(m => m.Team1)
                .Include(m => m.Team2)
                .Include(m => m.Scorer)
                .FirstOrDefault(m => m.Id == matchId);

            if (match != null)
            {
                Console.WriteLine("Match information:");
                Console.WriteLine($"Date: {match.MatchDate}");
                Console.WriteLine($"{match.Team1.Name} ({match.Team1.City}) [{match.Team1Goals}] - [{match.Team2Goals}] {match.Team2.Name} ({match.Team2.City})");
                Console.WriteLine($"Player who scored: {match.Scorer.FullName} ({match.Scorer.Team.Name})");
            }
            else
            {
                Console.WriteLine("No match found.");
            }
        }
        public void ShowMatchesByDate(DateTime date)
        {
            var context = new ANDbContext();
            var matches = context.Matches
                .Include(m => m.Team1)
                .Include(m => m.Team2)
                .Where(m => m.MatchDate.Date == date.Date)
                .ToList();

            if (matches.Any())
            {
                Console.WriteLine($"Matches for {date.ToShortDateString()}:");
                foreach (var match in matches)
                {
                    Console.WriteLine($"{match.Team1.Name} ({match.Team1.City}) [{match.Team1Goals}] - [{match.Team2Goals}] {match.Team2.Name} ({match.Team2.City})");
                }
            }
            else
            {
                Console.WriteLine("There are no matches on this date.");
            }
        }
        public void ShowMatchesByTeam(string teamName)
        {
            var context = new ANDbContext();
            var matches = context.Matches
                .Include(m => m.Team1)
                .Include(m => m.Team2)
                .Where(m => m.Team1.Name == teamName || m.Team2.Name == teamName)
                .ToList();

            if (matches.Any())
            {
                Console.WriteLine($"All matches of the team {teamName}:");
                foreach (var match in matches)
                {
                    Console.WriteLine($"{match.MatchDate}: {match.Team1.Name} [{match.Team1Goals}] - [{match.Team2Goals}] {match.Team2.Name}");
                }
            }
            else
            {
                Console.WriteLine("This team has no matches.");
            }
        }
        public void ShowScorersByDate(DateTime date)
        {
            var context = new ANDbContext();
            var matches = context.Matches
                .Include(m => m.Scorer)
                .Where(m => m.MatchDate.Date == date.Date)
                .ToList();

            if (matches.Any())
            {
                Console.WriteLine($"Players who scored goals {date.ToShortDateString()}:");
                foreach (var match in matches)
                {
                    Console.WriteLine($"{match.Scorer.FullName} ({match.Scorer.Team.Name})");
                }
            }
            else
            {
                Console.WriteLine("No goals were scored on this day.");
            }
        }
        public void AddMatchWithCheck(int team1Id, int team2Id, int team1Goals, int team2Goals, int scorerId, DateTime matchDate)
        {
            var context = new ANDbContext();
            var existingMatch = context.Matches.FirstOrDefault(m =>
                ((m.Team1Id == team1Id && m.Team2Id == team2Id) || (m.Team1Id == team2Id && m.Team2Id == team1Id))
                && m.MatchDate.Date == matchDate.Date);

            if (existingMatch != null)
            {
                Console.WriteLine("A match between these teams already exists on this date!");
                return;
            }

            var match = new Match
            {
                Team1Id = team1Id,
                Team2Id = team2Id,
                Team1Goals = team1Goals,
                Team2Goals = team2Goals,
                ScorerId = scorerId,
                MatchDate = matchDate
            };

            context.Matches.Add(match);
            context.SaveChanges();
            Console.WriteLine("Match successfully added!");
        }
        public void UpdateMatch(int matchId)
        {
            var context = new ANDbContext();
            var match = context.Matches.FirstOrDefault(m => m.Id == matchId);

            if (match == null)
            {
                Console.WriteLine("No match found!");
                return;
            }

            Console.WriteLine($"Editing match {match.MatchDate} between {match.Team1Id} and {match.Team2Id}");

            Console.Write("New score for Team 1: ");
            if (int.TryParse(Console.ReadLine(), out int newTeam1Goals))
                match.Team1Goals = newTeam1Goals;

            Console.Write("New score for Team 2: ");
            if (int.TryParse(Console.ReadLine(), out int newTeam2Goals))
                match.Team2Goals = newTeam2Goals;

            Console.Write("ID of the new goal scorer (or leave unchanged): ");
            if (int.TryParse(Console.ReadLine(), out int newScorerId))
                match.ScorerId = newScorerId;

            Console.Write("New match date (yyyy-mm-dd): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime newMatchDate))
                match.MatchDate = newMatchDate;

            context.SaveChanges();
            Console.WriteLine("Match data updated!");
        }
        public void DeleteMatch(string team1Name, string team2Name, DateTime matchDate)
        {
            var context = new ANDbContext();

            // Пошук команд за іменем
            var team1 = context.SoccerComandModels.FirstOrDefault(t => t.Name == team1Name);
            var team2 = context.SoccerComandModels.FirstOrDefault(t => t.Name == team2Name);

            if (team1 == null || team2 == null)
            {
                Console.WriteLine("One of the commands was not found!");
                return;
            }

            var match = context.Matches.FirstOrDefault(m =>
                ((m.Team1Id == team1.Id && m.Team2Id == team2.Id) || (m.Team1Id == team2.Id && m.Team2Id == team1.Id))
                && m.MatchDate.Date == matchDate.Date);

            if (match == null)
            {
                Console.WriteLine("One of the commands was not found!");
                return;
            }

            Console.Write($"Are you sure you want to delete the match {team1.Name} vs {team2.Name} ({match.MatchDate})? (Y/N):");
            string confirmation = Console.ReadLine().Trim().ToLower();

            if (confirmation == "Y")
            {
                context.Matches.Remove(match);
                context.SaveChanges();
                Console.WriteLine("Match successfully deleted!");
            }
            else
            {
                Console.WriteLine("The deletion has been canceled.");
            }
        }
    }

}

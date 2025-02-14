using ADO;
using ADO.NET._5;
using ADO.NET._5.WorkTables;
using ADO.NET.WorkTables;
using ADO.NET.WorkTables.Entities;
using Microsoft.EntityFrameworkCore;
namespace ADO.NET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            var Team = new SoccerComandModel()
            {
                Name = "Oleg",
                City = "Zhitomyr",
                Wins = 5,
                Losses = 2,
                Draws = 0
            };
            */
            /*
            var Team2 = new SoccerComandModel()
            {
                Name = "Real",
                City = "Madrid",
                Wins = 25,
                Losses = 5,
                Draws = 8,
                GoalsScored = 75,
                GoalsConceded = 20
            };
            
            var context = new ANDbContext();
            
            context.SoccerComandModels.Add(Team2);
            context.SaveChanges();
            
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
            */
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=Soccer;Integrated Security=True;";
            DatabaseManager databaseManager = new DatabaseManager(connectionString);
            MenuManager menuManager = new MenuManager(databaseManager);
            
            menuManager.ShowMenu();
            
        }
    }
}
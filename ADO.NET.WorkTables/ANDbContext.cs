using ADO.NET.WorkTables.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET._5.WorkTables
{
    public class ANDbContext : DbContext
    {
        private string connectionString => @"Server=(localdb)\MSSQLLocalDB;Database=Soccer;Integrated Security=True;";
        public DbSet<SoccerComandModel> SoccerComandModels { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
            //base.OnConfiguring(optionsBuilder);
        }
    }
}

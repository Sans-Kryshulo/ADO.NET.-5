using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADO.NET.WorkTables.Migrations
{
    /// <inheritdoc />
    public partial class AddGoalsFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GoalsConceded",
                table: "SoccerComandModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GoalsScored",
                table: "SoccerComandModels",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoalsConceded",
                table: "SoccerComandModels");

            migrationBuilder.DropColumn(
                name: "GoalsScored",
                table: "SoccerComandModels");
        }
    }
}

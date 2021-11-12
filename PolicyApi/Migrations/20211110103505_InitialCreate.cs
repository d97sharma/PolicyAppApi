using Microsoft.EntityFrameworkCore.Migrations;

namespace PolicyApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PolicyDetails",
                columns: table => new
                {
                    Policy_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfPurchase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer_Id = table.Column<int>(type: "int", nullable: false),
                    Fuel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleSegment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Premium = table.Column<int>(type: "int", nullable: false),
                    InjuryLiability = table.Column<bool>(type: "bit", nullable: false),
                    Personal = table.Column<bool>(type: "bit", nullable: false),
                    Property = table.Column<bool>(type: "bit", nullable: false),
                    Collision = table.Column<bool>(type: "bit", nullable: false),
                    Comprehensive = table.Column<bool>(type: "bit", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncomeGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerRegion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyDetails", x => x.Policy_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PolicyDetails");
        }
    }
}

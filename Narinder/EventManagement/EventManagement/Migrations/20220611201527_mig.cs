using Microsoft.EntityFrameworkCore.Migrations;

namespace EventManagement.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Venue",
                columns: table => new
                {
                    Event_Place = table.Column<string>(nullable: false),
                    Event_Type = table.Column<string>(nullable: false),
                    Guest_Capability = table.Column<int>(nullable: false),
                    Per_Guest_Cost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venue", x => x.Event_Place);
                });

            migrationBuilder.CreateTable(
                name: "VenueAllDetails",
                columns: table => new
                {
                    Event_Place = table.Column<string>(nullable: false),
                    Event_Type = table.Column<string>(nullable: false),
                    Guest_Capability = table.Column<int>(nullable: false),
                    Per_Guest_Cost = table.Column<int>(nullable: false),
                    DJ_Cost = table.Column<int>(nullable: false),
                    Stage_Cost = table.Column<int>(nullable: false),
                    Mike_Speaker_Cost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenueAllDetails", x => x.Event_Place);
                });

            migrationBuilder.CreateTable(
                name: "VenueDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Event_Place = table.Column<string>(nullable: true),
                    DJ_Cost = table.Column<int>(nullable: false),
                    Stage_Cost = table.Column<int>(nullable: false),
                    Mike_Speaker_Cost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenueDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VenueDetail_Venue_Event_Place",
                        column: x => x.Event_Place,
                        principalTable: "Venue",
                        principalColumn: "Event_Place",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VenueDetail_Event_Place",
                table: "VenueDetail",
                column: "Event_Place");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VenueAllDetails");

            migrationBuilder.DropTable(
                name: "VenueDetail");

            migrationBuilder.DropTable(
                name: "Venue");
        }
    }
}

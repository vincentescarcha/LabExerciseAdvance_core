using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LabExerciseAdvance.Migrations
{
    public partial class AddRegistration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegistrationID",
                table: "Persons",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_RegistrationID",
                table: "Persons",
                column: "RegistrationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Registration_RegistrationID",
                table: "Persons",
                column: "RegistrationID",
                principalTable: "Registration",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Registration_RegistrationID",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropIndex(
                name: "IX_Persons_RegistrationID",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "RegistrationID",
                table: "Persons");
        }
    }
}

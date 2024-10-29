using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace examen_backend_alexis.Migrations
{
    /// <inheritdoc />
    public partial class InitialUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Crear la tabla Users
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false).Annotation("MySQL:ValueGenerationStrategy", MySql.EntityFrameworkCore.Metadata.MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

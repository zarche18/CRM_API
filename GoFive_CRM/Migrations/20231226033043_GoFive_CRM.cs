using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GoFive_CRM.Migrations
{
    /// <inheritdoc />
    public partial class GoFive_CRM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "ID", "Address", "Email", "Name", "Notes", "Phone" },
                values: new object[,]
                {
                    { 1, "Yangon, Myanmar", "alex@gmail.com", "Alex", "Alex is a Developer!", "9598888888" },
                    { 2, "Yangon, Myanmar", "Jhon@gmail.com", "Jhon", "Alex is a Developer!", "9597777777" },
                    { 3, "Yangon, Myanmar", "Eddie@gmail.com", "Eddie", "Alex is a Product Develiry Manager!", "9596666666" },
                    { 4, "Yangon, Myanmar", "Sampar@gmail.com", "Sampar", "Sampar is a QA!", "9595555555" },
                    { 5, "Yangon, Myanmar", "Aaron@gmail.com", "Aaron", "Sampar is a Operation Manager!", "9594444444" },
                    { 6, "Yangon, Myanmar", "Doraalex@gmail.com", "Doraalex", "Doraalex is a Project Manager!", "9593333333" },
                    { 7, "Yangon, Myanmar", "Kelvin@gmail.com", "Kelvin", "Kelvin is a Support Lead!", "9592222222" },
                    { 8, "Yangon, Myanmar", "Andrew@gmail.com", "Andrew", "Andrew is a API Developer!", "9591111111" },
                    { 9, "Yangon, Myanmar", "Mark@gmail.com", "Mark", "Mark is a API Developer!", "9599999999" },
                    { 10, "Yangon, Myanmar", "Kusshi@gmail.com", "Kusshi", "Kusshi is a support!", "9598888888" },
                    { 11, "Yangon, Myanmar", "Penny@gmail.com", "Penny", "Penny is a support!", "9597777777" },
                    { 12, "Yangon, Myanmar", "Maria@gmail.com", "Maria", "Maria is a support!", "9597777777" },
                    { 13, "Yangon, Myanmar", "Izi@gmail.com", "Izi", "Maria is a QA!", "9597777777" },
                    { 14, "Yangon, Myanmar", "Chriatian@gmail.com", "Chriatian", "Maria is a QA!", "9597777777" },
                    { 15, "Yangon, Myanmar", "Hwaimin@gmail.com", "Hwaimin", "Hwaimin is a QA!", "9597777777" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customers");
        }
    }
}

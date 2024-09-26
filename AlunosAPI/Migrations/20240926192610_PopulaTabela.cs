using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlunosAPI.Migrations
{
    /// <inheritdoc />
    public partial class PopulaTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Email", "Idade", "Nome" },
                values: new object[,]
                {
                    { 1, "proines_ariel@hotmail.com", 50, "Maria Inês Toledo Leme Ramalho" },
                    { 2, "geraldoapramalho@gmail.com", 53, "Geraldo Aparecido Ramalho" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

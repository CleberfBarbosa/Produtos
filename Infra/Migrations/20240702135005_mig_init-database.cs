using Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class mig_initdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_Codigo",
                table: "Produto",
                column: "Codigo",
                unique: true);


            migrationBuilder.InsertData("Produto",
                columns: new[] { nameof(Produto.Codigo), nameof(Produto.Nome), nameof(Produto.Descricao), nameof(Produto.Preco), nameof(Produto.Ativo) },
                values: new object[,]
                {
                    {"1", "Creme dental", "Pasta de dente menta", 2.50m, true },
                    {"2", "Fita 3m", "Fita dupla face", 4.43m, true },
                    {"3", "Havaianas", "Chinelo havaianas", 20.19m, true },
                    {"4", "Lenço umedecido", "Lenços umedeciados 50 un", 19.00m, true },
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}

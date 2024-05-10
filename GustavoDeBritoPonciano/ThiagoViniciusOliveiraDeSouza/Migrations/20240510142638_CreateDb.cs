using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThiagoViniciusOliveiraDeSouza.Migrations
{
    /// <inheritdoc />
    public partial class CreateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Cpf = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Folha",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FuncionarioId = table.Column<int>(type: "INTEGER", nullable: true),
                    Ano = table.Column<int>(type: "INTEGER", nullable: true),
                    Quantidade = table.Column<double>(type: "REAL", nullable: true),
                    Valor = table.Column<double>(type: "REAL", nullable: true),
                    Mes = table.Column<int>(type: "INTEGER", nullable: true),
                    SalarioBruto = table.Column<double>(type: "REAL", nullable: true),
                    ImpostoIrrf = table.Column<double>(type: "REAL", nullable: true),
                    ImpostoInss = table.Column<double>(type: "REAL", nullable: true),
                    ImpostoFgts = table.Column<double>(type: "REAL", nullable: true),
                    SalarioLiquido = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folha", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Folha_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Folha_FuncionarioId",
                table: "Folha",
                column: "FuncionarioId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Folha");

            migrationBuilder.DropTable(
                name: "Funcionario");
        }
    }
}

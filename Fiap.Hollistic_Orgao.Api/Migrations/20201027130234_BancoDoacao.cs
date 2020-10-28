using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.Hollistic_Orgao.Api.Migrations
{
    public partial class BancoDoacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_ENDERECO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rua = table.Column<string>(nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Cep = table.Column<string>(nullable: false),
                    Estado = table.Column<int>(nullable: false),
                    Cidade = table.Column<string>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ENDERECO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_HOSPITAL",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnderecoId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Cnpj = table.Column<string>(maxLength: 19, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_HOSPITAL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_HOSPITAL_TB_ENDERECO_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "TB_ENDERECO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_PACIENTE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnderecoId = table.Column<int>(nullable: false),
                    HospitalId = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Cpf = table.Column<string>(maxLength: 13, nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    TipoSanguineo = table.Column<string>(nullable: false),
                    Peso = table.Column<double>(nullable: false),
                    Altura = table.Column<double>(nullable: false),
                    Gravidade = table.Column<string>(nullable: false),
                    Doador = table.Column<bool>(nullable: false),
                    Receptor = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PACIENTE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_PACIENTE_TB_ENDERECO_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "TB_ENDERECO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PACIENTE_TB_HOSPITAL_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "TB_HOSPITAL",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_USUARIO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HospitalId = table.Column<int>(nullable: false),
                    Tipo = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: false),
                    Senha = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_USUARIO_TB_HOSPITAL_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "TB_HOSPITAL",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_EXAME",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(nullable: false),
                    Tipo = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    DataExame = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_EXAME", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_EXAME_TB_PACIENTE_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "TB_PACIENTE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_ORGAO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(nullable: false),
                    TipoOrgao = table.Column<int>(nullable: false),
                    Condicao = table.Column<string>(nullable: false),
                    Isquemia = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ORGAO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_ORGAO_TB_PACIENTE_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "TB_PACIENTE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_EXAME_PacienteId",
                table: "TB_EXAME",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_HOSPITAL_EnderecoId",
                table: "TB_HOSPITAL",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ORGAO_PacienteId",
                table: "TB_ORGAO",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PACIENTE_EnderecoId",
                table: "TB_PACIENTE",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PACIENTE_HospitalId",
                table: "TB_PACIENTE",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USUARIO_HospitalId",
                table: "TB_USUARIO",
                column: "HospitalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_EXAME");

            migrationBuilder.DropTable(
                name: "TB_ORGAO");

            migrationBuilder.DropTable(
                name: "TB_USUARIO");

            migrationBuilder.DropTable(
                name: "TB_PACIENTE");

            migrationBuilder.DropTable(
                name: "TB_HOSPITAL");

            migrationBuilder.DropTable(
                name: "TB_ENDERECO");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaOn.Infra.Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_USUARIO",
                columns: table => new
                {
                    ID_USUARIO = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ID_IDENTITY = table.Column<string>(type: "TEXT", nullable: false),
                    NOME = table.Column<string>(type: "TEXT", unicode: false, maxLength: 100, nullable: false),
                    EMAIL = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIO", x => x.ID_USUARIO);
                });

            migrationBuilder.CreateTable(
                name: "TB_ADMINISTRADOR",
                columns: table => new
                {
                    ID_ADMINISTRADOR = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ID_USUARIO = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ADMINISTRADOR", x => x.ID_ADMINISTRADOR);
                    table.ForeignKey(
                        name: "FK_TB_ADMINISTRADOR_TB_USUARIO_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "TB_USUARIO",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_CLIENTE",
                columns: table => new
                {
                    ID_CLIENTE = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ID_USUARIO = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CLIENTE", x => x.ID_CLIENTE);
                    table.ForeignKey(
                        name: "FK_TB_CLIENTE_TB_USUARIO_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "TB_USUARIO",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_PRESTADOR",
                columns: table => new
                {
                    ID_PRESTADOR = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ID_USUARIO = table.Column<int>(type: "INTEGER", nullable: false),
                    PRECO = table.Column<decimal>(type: "TEXT", nullable: false, defaultValue: 100m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRESTADOR", x => x.ID_PRESTADOR);
                    table.ForeignKey(
                        name: "FK_TB_PRESTADOR_TB_USUARIO_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "TB_USUARIO",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_HORARIO",
                columns: table => new
                {
                    ID_HORARIO = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HORA_INICIO = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    HORA_FIM = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    ID_PRESTADOR = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_HORARIO", x => x.ID_HORARIO);
                    table.ForeignKey(
                        name: "FK_TB_HORARIO_TB_PRESTADOR_ID_PRESTADOR",
                        column: x => x.ID_PRESTADOR,
                        principalTable: "TB_PRESTADOR",
                        principalColumn: "ID_PRESTADOR",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_PERFIL",
                columns: table => new
                {
                    ID_PERFIL = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DESCRICAO = table.Column<string>(type: "TEXT", unicode: false, nullable: false),
                    ID_PRESTADOR = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERFIL", x => x.ID_PERFIL);
                    table.ForeignKey(
                        name: "FK_TB_PERFIL_TB_PRESTADOR_ID_PRESTADOR",
                        column: x => x.ID_PRESTADOR,
                        principalTable: "TB_PRESTADOR",
                        principalColumn: "ID_PRESTADOR");
                });

            migrationBuilder.CreateTable(
                name: "TB_AGENDAMENTO",
                columns: table => new
                {
                    ID_AGENDAMENTO = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ID_CLIENTE = table.Column<int>(type: "INTEGER", nullable: false),
                    ID_PRESTADOR = table.Column<int>(type: "INTEGER", nullable: false),
                    ID_HORARIO = table.Column<int>(type: "INTEGER", nullable: false),
                    DT_AGENDAMENTO = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DT_CANCELAMENTO = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_AGENDAMENTO", x => x.ID_AGENDAMENTO);
                    table.ForeignKey(
                        name: "FK_TB_AGENDAMENTO_TB_CLIENTE_ID_CLIENTE",
                        column: x => x.ID_CLIENTE,
                        principalTable: "TB_CLIENTE",
                        principalColumn: "ID_CLIENTE");
                    table.ForeignKey(
                        name: "FK_TB_AGENDAMENTO_TB_HORARIO_ID_HORARIO",
                        column: x => x.ID_HORARIO,
                        principalTable: "TB_HORARIO",
                        principalColumn: "ID_HORARIO");
                    table.ForeignKey(
                        name: "FK_TB_AGENDAMENTO_TB_PRESTADOR_ID_PRESTADOR",
                        column: x => x.ID_PRESTADOR,
                        principalTable: "TB_PRESTADOR",
                        principalColumn: "ID_PRESTADOR");
                });

            migrationBuilder.CreateTable(
                name: "TB_AVALIACAO",
                columns: table => new
                {
                    ID_AVALIACAO = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NOTA = table.Column<int>(type: "INTEGER", nullable: false),
                    DESC_AVALIACAO = table.Column<string>(type: "TEXT", unicode: false, maxLength: 100, nullable: true),
                    ID_PERFIL = table.Column<int>(type: "INTEGER", nullable: false),
                    ID_CLIENTE = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_AVALIACAO", x => x.ID_AVALIACAO);
                    table.ForeignKey(
                        name: "FK_TB_AVALIACAO_TB_CLIENTE_ID_CLIENTE",
                        column: x => x.ID_CLIENTE,
                        principalTable: "TB_CLIENTE",
                        principalColumn: "ID_CLIENTE");
                    table.ForeignKey(
                        name: "FK_TB_AVALIACAO_TB_PERFIL_ID_PERFIL",
                        column: x => x.ID_PERFIL,
                        principalTable: "TB_PERFIL",
                        principalColumn: "ID_PERFIL");
                });

            migrationBuilder.CreateTable(
                name: "TB_FOTO",
                columns: table => new
                {
                    ID_FOTO = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PATH = table.Column<string>(type: "TEXT", unicode: false, nullable: false),
                    ID_PERFIL = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_FOTO", x => x.ID_FOTO);
                    table.ForeignKey(
                        name: "FK_TB_FOTO_TB_PERFIL_ID_PERFIL",
                        column: x => x.ID_PERFIL,
                        principalTable: "TB_PERFIL",
                        principalColumn: "ID_PERFIL");
                });

            migrationBuilder.CreateTable(
                name: "TB_REDE_SOCIAL",
                columns: table => new
                {
                    ID_REDE_SOCIAL = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NOME_REDE = table.Column<string>(type: "TEXT", unicode: false, nullable: false),
                    LINK = table.Column<string>(type: "TEXT", unicode: false, nullable: false),
                    ID_PERFIL = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_REDE_SOCIAL", x => x.ID_REDE_SOCIAL);
                    table.ForeignKey(
                        name: "FK_TB_REDE_SOCIAL_TB_PERFIL_ID_PERFIL",
                        column: x => x.ID_PERFIL,
                        principalTable: "TB_PERFIL",
                        principalColumn: "ID_PERFIL");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ADMINISTRADOR_ID_USUARIO",
                table: "TB_ADMINISTRADOR",
                column: "ID_USUARIO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_AGENDAMENTO_ID_CLIENTE",
                table: "TB_AGENDAMENTO",
                column: "ID_CLIENTE");

            migrationBuilder.CreateIndex(
                name: "IX_TB_AGENDAMENTO_ID_HORARIO",
                table: "TB_AGENDAMENTO",
                column: "ID_HORARIO");

            migrationBuilder.CreateIndex(
                name: "IX_TB_AGENDAMENTO_ID_PRESTADOR",
                table: "TB_AGENDAMENTO",
                column: "ID_PRESTADOR");

            migrationBuilder.CreateIndex(
                name: "IX_TB_AVALIACAO_ID_CLIENTE",
                table: "TB_AVALIACAO",
                column: "ID_CLIENTE");

            migrationBuilder.CreateIndex(
                name: "IX_TB_AVALIACAO_ID_PERFIL",
                table: "TB_AVALIACAO",
                column: "ID_PERFIL");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CLIENTE_ID_USUARIO",
                table: "TB_CLIENTE",
                column: "ID_USUARIO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_FOTO_ID_PERFIL",
                table: "TB_FOTO",
                column: "ID_PERFIL");

            migrationBuilder.CreateIndex(
                name: "IX_TB_HORARIO_ID_PRESTADOR",
                table: "TB_HORARIO",
                column: "ID_PRESTADOR");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERFIL_ID_PRESTADOR",
                table: "TB_PERFIL",
                column: "ID_PRESTADOR",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_PRESTADOR_ID_USUARIO",
                table: "TB_PRESTADOR",
                column: "ID_USUARIO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_REDE_SOCIAL_ID_PERFIL",
                table: "TB_REDE_SOCIAL",
                column: "ID_PERFIL");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USUARIO_ID_IDENTITY",
                table: "TB_USUARIO",
                column: "ID_IDENTITY",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ADMINISTRADOR");

            migrationBuilder.DropTable(
                name: "TB_AGENDAMENTO");

            migrationBuilder.DropTable(
                name: "TB_AVALIACAO");

            migrationBuilder.DropTable(
                name: "TB_FOTO");

            migrationBuilder.DropTable(
                name: "TB_REDE_SOCIAL");

            migrationBuilder.DropTable(
                name: "TB_HORARIO");

            migrationBuilder.DropTable(
                name: "TB_CLIENTE");

            migrationBuilder.DropTable(
                name: "TB_PERFIL");

            migrationBuilder.DropTable(
                name: "TB_PRESTADOR");

            migrationBuilder.DropTable(
                name: "TB_USUARIO");
        }
    }
}

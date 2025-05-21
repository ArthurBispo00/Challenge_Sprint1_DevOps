using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChallengeMuttuApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_BOX",
                columns: table => new
                {
                    ID_BOX = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    STATUS = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DATA_ENTRADA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DATA_SAIDA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    OBSERVACAO = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_BOX", x => x.ID_BOX);
                });

            migrationBuilder.CreateTable(
                name: "TB_CONTATO",
                columns: table => new
                {
                    ID_CONTATO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EMAIL = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DDD = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DDI = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TELEFONE1 = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    TELEFONE2 = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: true),
                    TELEFONE3 = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: true),
                    CELULAR = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    OUTRO = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    OBSERVACAO = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CONTATO", x => x.ID_CONTATO);
                });

            migrationBuilder.CreateTable(
                name: "TB_ENDERECO",
                columns: table => new
                {
                    ID_ENDERECO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CEP = table.Column<string>(type: "NVARCHAR2(9)", maxLength: 9, nullable: false),
                    NUMERO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LOGRADOURO = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    BAIRRO = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    CIDADE = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    ESTADO = table.Column<string>(type: "NVARCHAR2(2)", maxLength: 2, nullable: false),
                    PAIS = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    COMPLEMENTO = table.Column<string>(type: "NVARCHAR2(60)", maxLength: 60, nullable: true),
                    OBSERVACAO = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ENDERECO", x => x.ID_ENDERECO);
                });

            migrationBuilder.CreateTable(
                name: "TB_PATIO",
                columns: table => new
                {
                    ID_PATIO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME_PATIO = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    DATA_ENTRADA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DATA_SAIDA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    OBSERVACAO = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PATIO", x => x.ID_PATIO);
                });

            migrationBuilder.CreateTable(
                name: "TB_RASTREAMENTO",
                columns: table => new
                {
                    ID_RASTREAMENTO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    IPS_X = table.Column<decimal>(type: "NUMBER(38,8)", nullable: false),
                    IPS_Y = table.Column<decimal>(type: "NUMBER(38,8)", nullable: false),
                    IPS_Z = table.Column<decimal>(type: "NUMBER(38,8)", nullable: false),
                    GPRS_LATITUDE = table.Column<decimal>(type: "NUMBER(38,8)", nullable: false),
                    GPRS_LONGITUDE = table.Column<decimal>(type: "NUMBER(38,8)", nullable: false),
                    GPRS_ALTITUDE = table.Column<decimal>(type: "NUMBER(38,8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_RASTREAMENTO", x => x.ID_RASTREAMENTO);
                });

            migrationBuilder.CreateTable(
                name: "TB_VEICULO",
                columns: table => new
                {
                    ID_VEICULO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PLACA = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    RENAVAM = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false),
                    CHASSI = table.Column<string>(type: "NVARCHAR2(17)", maxLength: 17, nullable: false),
                    FABRICANTE = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    MODELO = table.Column<string>(type: "NVARCHAR2(60)", maxLength: 60, nullable: false),
                    MOTOR = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: true),
                    ANO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    COMBUSTIVEL = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_VEICULO", x => x.ID_VEICULO);
                });

            migrationBuilder.CreateTable(
                name: "TB_ZONA",
                columns: table => new
                {
                    ID_ZONA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    DATA_ENTRADA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DATA_SAIDA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    OBSERVACAO = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ZONA", x => x.ID_ZONA);
                });

            migrationBuilder.CreateTable(
                name: "TB_CLIENTE",
                columns: table => new
                {
                    ID_CLIENTE = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DATA_CADASTRO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    SEXO = table.Column<string>(type: "NVARCHAR2(2)", maxLength: 2, nullable: false),
                    NOME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    SOBRENOME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DATA_NASCIMENTO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CPF = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false),
                    PROFISSAO = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    ESTADO_CIVIL = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    TB_ENDERECO_ID_ENDERECO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TB_CONTATO_ID_CONTATO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CLIENTE", x => x.ID_CLIENTE);
                    table.ForeignKey(
                        name: "FK_TB_CLIENTE_TB_CONTATO_TB_CONTATO_ID_CONTATO",
                        column: x => x.TB_CONTATO_ID_CONTATO,
                        principalTable: "TB_CONTATO",
                        principalColumn: "ID_CONTATO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_CLIENTE_TB_ENDERECO_TB_ENDERECO_ID_ENDERECO",
                        column: x => x.TB_ENDERECO_ID_ENDERECO,
                        principalTable: "TB_ENDERECO",
                        principalColumn: "ID_ENDERECO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_CONTATOPATIO",
                columns: table => new
                {
                    TB_PATIO_ID_PATIO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TB_CONTATO_ID_CONTATO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CONTATOPATIO", x => new { x.TB_PATIO_ID_PATIO, x.TB_CONTATO_ID_CONTATO });
                    table.ForeignKey(
                        name: "FK_TB_CONTATOPATIO_TB_CONTATO_TB_CONTATO_ID_CONTATO",
                        column: x => x.TB_CONTATO_ID_CONTATO,
                        principalTable: "TB_CONTATO",
                        principalColumn: "ID_CONTATO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_CONTATOPATIO_TB_PATIO_TB_PATIO_ID_PATIO",
                        column: x => x.TB_PATIO_ID_PATIO,
                        principalTable: "TB_PATIO",
                        principalColumn: "ID_PATIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_ENDERECIOPATIO",
                columns: table => new
                {
                    TB_ENDERECO_ID_ENDERECO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TB_PATIO_ID_PATIO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ENDERECIOPATIO", x => new { x.TB_ENDERECO_ID_ENDERECO, x.TB_PATIO_ID_PATIO });
                    table.ForeignKey(
                        name: "FK_TB_ENDERECIOPATIO_TB_ENDERECO_TB_ENDERECO_ID_ENDERECO",
                        column: x => x.TB_ENDERECO_ID_ENDERECO,
                        principalTable: "TB_ENDERECO",
                        principalColumn: "ID_ENDERECO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_ENDERECIOPATIO_TB_PATIO_TB_PATIO_ID_PATIO",
                        column: x => x.TB_PATIO_ID_PATIO,
                        principalTable: "TB_PATIO",
                        principalColumn: "ID_PATIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_PATIOBOX",
                columns: table => new
                {
                    TB_PATIO_ID_PATIO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TB_BOX_ID_BOX = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PATIOBOX", x => new { x.TB_PATIO_ID_PATIO, x.TB_BOX_ID_BOX });
                    table.ForeignKey(
                        name: "FK_TB_PATIOBOX_TB_BOX_TB_BOX_ID_BOX",
                        column: x => x.TB_BOX_ID_BOX,
                        principalTable: "TB_BOX",
                        principalColumn: "ID_BOX",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PATIOBOX_TB_PATIO_TB_PATIO_ID_PATIO",
                        column: x => x.TB_PATIO_ID_PATIO,
                        principalTable: "TB_PATIO",
                        principalColumn: "ID_PATIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_VEICULOBOX",
                columns: table => new
                {
                    TB_VEICULO_ID_VEICULO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TB_BOX_ID_BOX = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_VEICULOBOX", x => new { x.TB_VEICULO_ID_VEICULO, x.TB_BOX_ID_BOX });
                    table.ForeignKey(
                        name: "FK_TB_VEICULOBOX_TB_BOX_TB_BOX_ID_BOX",
                        column: x => x.TB_BOX_ID_BOX,
                        principalTable: "TB_BOX",
                        principalColumn: "ID_BOX",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_VEICULOBOX_TB_VEICULO_TB_VEICULO_ID_VEICULO",
                        column: x => x.TB_VEICULO_ID_VEICULO,
                        principalTable: "TB_VEICULO",
                        principalColumn: "ID_VEICULO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_VEICULOPATIO",
                columns: table => new
                {
                    TB_VEICULO_ID_VEICULO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TB_PATIO_ID_PATIO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_VEICULOPATIO", x => new { x.TB_VEICULO_ID_VEICULO, x.TB_PATIO_ID_PATIO });
                    table.ForeignKey(
                        name: "FK_TB_VEICULOPATIO_TB_PATIO_TB_PATIO_ID_PATIO",
                        column: x => x.TB_PATIO_ID_PATIO,
                        principalTable: "TB_PATIO",
                        principalColumn: "ID_PATIO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_VEICULOPATIO_TB_VEICULO_TB_VEICULO_ID_VEICULO",
                        column: x => x.TB_VEICULO_ID_VEICULO,
                        principalTable: "TB_VEICULO",
                        principalColumn: "ID_VEICULO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_VEICULORASTREAMENTO",
                columns: table => new
                {
                    TB_VEICULO_ID_VEICULO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TB_RASTREAMENTO_ID_RASTREAMENTO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_VEICULORASTREAMENTO", x => new { x.TB_VEICULO_ID_VEICULO, x.TB_RASTREAMENTO_ID_RASTREAMENTO });
                    table.ForeignKey(
                        name: "FK_TB_VEICULORASTREAMENTO_TB_RASTREAMENTO_TB_RASTREAMENTO_ID_RASTREAMENTO",
                        column: x => x.TB_RASTREAMENTO_ID_RASTREAMENTO,
                        principalTable: "TB_RASTREAMENTO",
                        principalColumn: "ID_RASTREAMENTO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_VEICULORASTREAMENTO_TB_VEICULO_TB_VEICULO_ID_VEICULO",
                        column: x => x.TB_VEICULO_ID_VEICULO,
                        principalTable: "TB_VEICULO",
                        principalColumn: "ID_VEICULO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_VEICULOZONA",
                columns: table => new
                {
                    TB_VEICULO_ID_VEICULO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TB_ZONA_ID_ZONA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_VEICULOZONA", x => new { x.TB_VEICULO_ID_VEICULO, x.TB_ZONA_ID_ZONA });
                    table.ForeignKey(
                        name: "FK_TB_VEICULOZONA_TB_VEICULO_TB_VEICULO_ID_VEICULO",
                        column: x => x.TB_VEICULO_ID_VEICULO,
                        principalTable: "TB_VEICULO",
                        principalColumn: "ID_VEICULO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_VEICULOZONA_TB_ZONA_TB_ZONA_ID_ZONA",
                        column: x => x.TB_ZONA_ID_ZONA,
                        principalTable: "TB_ZONA",
                        principalColumn: "ID_ZONA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_ZONABOX",
                columns: table => new
                {
                    TB_ZONA_ID_ZONA = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TB_BOX_ID_BOX = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ZONABOX", x => new { x.TB_ZONA_ID_ZONA, x.TB_BOX_ID_BOX });
                    table.ForeignKey(
                        name: "FK_TB_ZONABOX_TB_BOX_TB_BOX_ID_BOX",
                        column: x => x.TB_BOX_ID_BOX,
                        principalTable: "TB_BOX",
                        principalColumn: "ID_BOX",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_ZONABOX_TB_ZONA_TB_ZONA_ID_ZONA",
                        column: x => x.TB_ZONA_ID_ZONA,
                        principalTable: "TB_ZONA",
                        principalColumn: "ID_ZONA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_ZONAPATIO",
                columns: table => new
                {
                    TB_PATIO_ID_PATIO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TB_ZONA_ID_ZONA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ZONAPATIO", x => new { x.TB_PATIO_ID_PATIO, x.TB_ZONA_ID_ZONA });
                    table.ForeignKey(
                        name: "FK_TB_ZONAPATIO_TB_PATIO_TB_PATIO_ID_PATIO",
                        column: x => x.TB_PATIO_ID_PATIO,
                        principalTable: "TB_PATIO",
                        principalColumn: "ID_PATIO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_ZONAPATIO_TB_ZONA_TB_ZONA_ID_ZONA",
                        column: x => x.TB_ZONA_ID_ZONA,
                        principalTable: "TB_ZONA",
                        principalColumn: "ID_ZONA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_CLIENTEVEICULO",
                columns: table => new
                {
                    TB_CLIENTE_ID_CLIENTE = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TB_CLIENTE_TB_ENDERECO_ID_ENDERECO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TB_CLIENTE_TB_CONTATO_ID_CONTATO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TB_VEICULO_ID_VEICULO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CLIENTEVEICULO", x => new { x.TB_CLIENTE_ID_CLIENTE, x.TB_CLIENTE_TB_ENDERECO_ID_ENDERECO, x.TB_CLIENTE_TB_CONTATO_ID_CONTATO, x.TB_VEICULO_ID_VEICULO });
                    table.ForeignKey(
                        name: "FK_TB_CLIENTEVEICULO_TB_CLIENTE_TB_CLIENTE_ID_CLIENTE",
                        column: x => x.TB_CLIENTE_ID_CLIENTE,
                        principalTable: "TB_CLIENTE",
                        principalColumn: "ID_CLIENTE",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_CLIENTEVEICULO_TB_VEICULO_TB_VEICULO_ID_VEICULO",
                        column: x => x.TB_VEICULO_ID_VEICULO,
                        principalTable: "TB_VEICULO",
                        principalColumn: "ID_VEICULO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_CLIENTE_CPF",
                table: "TB_CLIENTE",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_CLIENTE_TB_CONTATO_ID_CONTATO",
                table: "TB_CLIENTE",
                column: "TB_CONTATO_ID_CONTATO");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CLIENTE_TB_ENDERECO_ID_ENDERECO",
                table: "TB_CLIENTE",
                column: "TB_ENDERECO_ID_ENDERECO");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CLIENTEVEICULO_TB_VEICULO_ID_VEICULO",
                table: "TB_CLIENTEVEICULO",
                column: "TB_VEICULO_ID_VEICULO");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CONTATOPATIO_TB_CONTATO_ID_CONTATO",
                table: "TB_CONTATOPATIO",
                column: "TB_CONTATO_ID_CONTATO");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ENDERECIOPATIO_TB_PATIO_ID_PATIO",
                table: "TB_ENDERECIOPATIO",
                column: "TB_PATIO_ID_PATIO");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PATIOBOX_TB_BOX_ID_BOX",
                table: "TB_PATIOBOX",
                column: "TB_BOX_ID_BOX");

            migrationBuilder.CreateIndex(
                name: "IX_TB_VEICULO_CHASSI",
                table: "TB_VEICULO",
                column: "CHASSI",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_VEICULO_PLACA",
                table: "TB_VEICULO",
                column: "PLACA",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_VEICULO_RENAVAM",
                table: "TB_VEICULO",
                column: "RENAVAM",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_VEICULOBOX_TB_BOX_ID_BOX",
                table: "TB_VEICULOBOX",
                column: "TB_BOX_ID_BOX");

            migrationBuilder.CreateIndex(
                name: "IX_TB_VEICULOPATIO_TB_PATIO_ID_PATIO",
                table: "TB_VEICULOPATIO",
                column: "TB_PATIO_ID_PATIO");

            migrationBuilder.CreateIndex(
                name: "IX_TB_VEICULORASTREAMENTO_TB_RASTREAMENTO_ID_RASTREAMENTO",
                table: "TB_VEICULORASTREAMENTO",
                column: "TB_RASTREAMENTO_ID_RASTREAMENTO");

            migrationBuilder.CreateIndex(
                name: "IX_TB_VEICULOZONA_TB_ZONA_ID_ZONA",
                table: "TB_VEICULOZONA",
                column: "TB_ZONA_ID_ZONA");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ZONABOX_TB_BOX_ID_BOX",
                table: "TB_ZONABOX",
                column: "TB_BOX_ID_BOX");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ZONAPATIO_TB_ZONA_ID_ZONA",
                table: "TB_ZONAPATIO",
                column: "TB_ZONA_ID_ZONA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CLIENTEVEICULO");

            migrationBuilder.DropTable(
                name: "TB_CONTATOPATIO");

            migrationBuilder.DropTable(
                name: "TB_ENDERECIOPATIO");

            migrationBuilder.DropTable(
                name: "TB_PATIOBOX");

            migrationBuilder.DropTable(
                name: "TB_VEICULOBOX");

            migrationBuilder.DropTable(
                name: "TB_VEICULOPATIO");

            migrationBuilder.DropTable(
                name: "TB_VEICULORASTREAMENTO");

            migrationBuilder.DropTable(
                name: "TB_VEICULOZONA");

            migrationBuilder.DropTable(
                name: "TB_ZONABOX");

            migrationBuilder.DropTable(
                name: "TB_ZONAPATIO");

            migrationBuilder.DropTable(
                name: "TB_CLIENTE");

            migrationBuilder.DropTable(
                name: "TB_RASTREAMENTO");

            migrationBuilder.DropTable(
                name: "TB_VEICULO");

            migrationBuilder.DropTable(
                name: "TB_BOX");

            migrationBuilder.DropTable(
                name: "TB_PATIO");

            migrationBuilder.DropTable(
                name: "TB_ZONA");

            migrationBuilder.DropTable(
                name: "TB_CONTATO");

            migrationBuilder.DropTable(
                name: "TB_ENDERECO");
        }
    }
}

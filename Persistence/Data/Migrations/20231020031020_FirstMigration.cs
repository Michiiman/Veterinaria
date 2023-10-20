using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "especie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_especie", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "laboratorio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_laboratorio", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "propietario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_propietario", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "proveedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proveedor", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipoMovimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoMovimiento", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "veterinario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Especialidad = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veterinario", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "raza",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EspecieIdFk = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_raza", x => x.Id);
                    table.ForeignKey(
                        name: "FK_raza_especie_EspecieIdFk",
                        column: x => x.EspecieIdFk,
                        principalTable: "especie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medicamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CantidadDisponible = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    Precio = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    LaboratorioIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicamento_laboratorio_LaboratorioIdFk",
                        column: x => x.LaboratorioIdFk,
                        principalTable: "laboratorio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "movimientoMedicamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cantidad = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", maxLength: 30, nullable: false),
                    TipoMovimientoIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movimientoMedicamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_movimientoMedicamento_tipoMovimiento_TipoMovimientoIdFk",
                        column: x => x.TipoMovimientoIdFk,
                        principalTable: "tipoMovimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdUsuarioFk = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    Token = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expires = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_user_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "user",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "userRol",
                columns: table => new
                {
                    UsuarioIdFk = table.Column<int>(type: "int", nullable: false),
                    RolIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRol", x => new { x.UsuarioIdFk, x.RolIdFk });
                    table.ForeignKey(
                        name: "FK_userRol_rol_RolIdFk",
                        column: x => x.RolIdFk,
                        principalTable: "rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userRol_user_UsuarioIdFk",
                        column: x => x.UsuarioIdFk,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "mascota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PropietarioIdFk = table.Column<int>(type: "int", nullable: false),
                    RazaIdFk = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaNacimiento = table.Column<DateOnly>(type: "date", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mascota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mascota_propietario_PropietarioIdFk",
                        column: x => x.PropietarioIdFk,
                        principalTable: "propietario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mascota_raza_RazaIdFk",
                        column: x => x.RazaIdFk,
                        principalTable: "raza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medicamentosProveedor",
                columns: table => new
                {
                    MedicamentoIdFk = table.Column<int>(type: "int", nullable: false),
                    ProveedorIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicamentosProveedor", x => new { x.ProveedorIdFk, x.MedicamentoIdFk });
                    table.ForeignKey(
                        name: "FK_medicamentosProveedor_medicamento_MedicamentoIdFk",
                        column: x => x.MedicamentoIdFk,
                        principalTable: "medicamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medicamentosProveedor_proveedor_ProveedorIdFk",
                        column: x => x.ProveedorIdFk,
                        principalTable: "proveedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "detalleMovimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MedicamentoIdFk = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    MovimientoMedicamentoIdFk = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalleMovimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detalleMovimiento_medicamento_MedicamentoIdFk",
                        column: x => x.MedicamentoIdFk,
                        principalTable: "medicamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalleMovimiento_movimientoMedicamento_MovimientoMedicament~",
                        column: x => x.MovimientoMedicamentoIdFk,
                        principalTable: "movimientoMedicamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MascotaIdFk = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", maxLength: 45, nullable: false),
                    Hora = table.Column<TimeOnly>(type: "time(6)", maxLength: 20, nullable: false),
                    Motivo = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VeterinarioIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cita_mascota_MascotaIdFk",
                        column: x => x.MascotaIdFk,
                        principalTable: "mascota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cita_veterinario_VeterinarioIdFk",
                        column: x => x.VeterinarioIdFk,
                        principalTable: "veterinario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tratamientoMedico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CitaIdFk = table.Column<int>(type: "int", nullable: false),
                    MedicamentoIdFk = table.Column<int>(type: "int", nullable: false),
                    Dosis = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaAdministracion = table.Column<DateOnly>(type: "date", maxLength: 30, nullable: false),
                    Observacion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tratamientoMedico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tratamientoMedico_cita_CitaIdFk",
                        column: x => x.CitaIdFk,
                        principalTable: "cita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tratamientoMedico_medicamento_MedicamentoIdFk",
                        column: x => x.MedicamentoIdFk,
                        principalTable: "medicamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_cita_MascotaIdFk",
                table: "cita",
                column: "MascotaIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_cita_VeterinarioIdFk",
                table: "cita",
                column: "VeterinarioIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_detalleMovimiento_MedicamentoIdFk",
                table: "detalleMovimiento",
                column: "MedicamentoIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_detalleMovimiento_MovimientoMedicamentoIdFk",
                table: "detalleMovimiento",
                column: "MovimientoMedicamentoIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_mascota_PropietarioIdFk",
                table: "mascota",
                column: "PropietarioIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_mascota_RazaIdFk",
                table: "mascota",
                column: "RazaIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_medicamento_LaboratorioIdFk",
                table: "medicamento",
                column: "LaboratorioIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_medicamentosProveedor_MedicamentoIdFk",
                table: "medicamentosProveedor",
                column: "MedicamentoIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_movimientoMedicamento_TipoMovimientoIdFk",
                table: "movimientoMedicamento",
                column: "TipoMovimientoIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_raza_EspecieIdFk",
                table: "raza",
                column: "EspecieIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UsuarioId",
                table: "RefreshToken",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tratamientoMedico_CitaIdFk",
                table: "tratamientoMedico",
                column: "CitaIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_tratamientoMedico_MedicamentoIdFk",
                table: "tratamientoMedico",
                column: "MedicamentoIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_userRol_RolIdFk",
                table: "userRol",
                column: "RolIdFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalleMovimiento");

            migrationBuilder.DropTable(
                name: "medicamentosProveedor");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "tratamientoMedico");

            migrationBuilder.DropTable(
                name: "userRol");

            migrationBuilder.DropTable(
                name: "movimientoMedicamento");

            migrationBuilder.DropTable(
                name: "proveedor");

            migrationBuilder.DropTable(
                name: "cita");

            migrationBuilder.DropTable(
                name: "medicamento");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "tipoMovimiento");

            migrationBuilder.DropTable(
                name: "mascota");

            migrationBuilder.DropTable(
                name: "veterinario");

            migrationBuilder.DropTable(
                name: "laboratorio");

            migrationBuilder.DropTable(
                name: "propietario");

            migrationBuilder.DropTable(
                name: "raza");

            migrationBuilder.DropTable(
                name: "especie");
        }
    }
}

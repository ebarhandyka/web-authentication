using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_M_Employees",
                columns: table => new
                {
                    nik = table.Column<string>(type: "CHAR(5)", nullable: false),
                    first_name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    last_name = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    birth_date = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    hiring_date = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    email = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    phone_number = table.Column<string>(type: "VARCHAR(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Employees", x => x.nik);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Universities",
                columns: table => new
                {
                    id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Universities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Account",
                columns: table => new
                {
                    employee_nik = table.Column<string>(type: "CHAR (5)", nullable: false),
                    password = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Account", x => x.employee_nik);
                    table.ForeignKey(
                        name: "FK_TB_M_Account_TB_M_Employees_employee_nik",
                        column: x => x.employee_nik,
                        principalTable: "TB_M_Employees",
                        principalColumn: "nik");
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Educations",
                columns: table => new
                {
                    id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    major = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    degree = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    gpa = table.Column<decimal>(type: "DECIMAL(3,2)", nullable: false),
                    university_id = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Educations", x => x.id);
                    table.ForeignKey(
                        name: "FK_TB_M_Educations_TB_M_Universities_university_id",
                        column: x => x.university_id,
                        principalTable: "TB_M_Universities",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "TB_TR_Account_Roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_nik = table.Column<string>(type: "CHAR(5)", nullable: false),
                    role_id = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TR_Account_Roles", x => x.id);
                    table.ForeignKey(
                        name: "FK_TB_TR_Account_Roles_TB_M_Account_account_nik",
                        column: x => x.account_nik,
                        principalTable: "TB_M_Account",
                        principalColumn: "employee_nik");
                    table.ForeignKey(
                        name: "FK_TB_TR_Account_Roles_TB_M_Roles_role_id",
                        column: x => x.role_id,
                        principalTable: "TB_M_Roles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "TB_TR_Profilings",
                columns: table => new
                {
                    employee_nik = table.Column<string>(type: "CHAR (5)", nullable: false),
                    education_id = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TR_Profilings", x => x.employee_nik);
                    table.ForeignKey(
                        name: "FK_TB_TR_Profilings_TB_M_Educations_education_id",
                        column: x => x.education_id,
                        principalTable: "TB_M_Educations",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TB_TR_Profilings_TB_M_Employees_employee_nik",
                        column: x => x.employee_nik,
                        principalTable: "TB_M_Employees",
                        principalColumn: "nik");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Educations_university_id",
                table: "TB_M_Educations",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Employees_email",
                table: "TB_M_Employees",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_TR_Account_Roles_account_nik",
                table: "TB_TR_Account_Roles",
                column: "account_nik");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TR_Account_Roles_role_id",
                table: "TB_TR_Account_Roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TR_Profilings_education_id",
                table: "TB_TR_Profilings",
                column: "education_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_TR_Account_Roles");

            migrationBuilder.DropTable(
                name: "TB_TR_Profilings");

            migrationBuilder.DropTable(
                name: "TB_M_Account");

            migrationBuilder.DropTable(
                name: "TB_M_Roles");

            migrationBuilder.DropTable(
                name: "TB_M_Educations");

            migrationBuilder.DropTable(
                name: "TB_M_Employees");

            migrationBuilder.DropTable(
                name: "TB_M_Universities");
        }
    }
}

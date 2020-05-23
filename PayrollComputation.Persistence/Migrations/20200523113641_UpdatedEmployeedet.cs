using Microsoft.EntityFrameworkCore.Migrations;

namespace PayrollComputation.Persistence.Migrations
{
    public partial class UpdatedEmployeedet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Fullname",
                table: "EmployeeDets",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "EmployeeDets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "EmployeeDets");

            migrationBuilder.AlterColumn<string>(
                name: "Fullname",
                table: "EmployeeDets",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

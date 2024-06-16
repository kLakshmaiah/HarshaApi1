using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HarshaApi1.Migrations
{
    /// <inheritdoc />
    public partial class GetStudents_SP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MobileNumber",
                table: "StudentTbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);
            //Creating the GetStudents_SP
            string GetStudents_SP = @"CREATE PROCEDURE [dbo].[GetStudents_SP]
                   AS
                   BEGIN
                    SELECT * FROM [dbo].[StudentTbl]
                    END
                ";
            migrationBuilder.Sql(GetStudents_SP);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MobileNumber",
                table: "StudentTbl",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
            string GetStudents_SP = @"DROP PROCEDURE [dbo].[GetStudents_SP]";
            migrationBuilder.Sql(GetStudents_SP);
        }
    }
}

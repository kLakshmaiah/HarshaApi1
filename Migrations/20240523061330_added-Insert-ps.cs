using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HarshaApi1.Migrations
{
    /// <inheritdoc />
    public partial class addedInsertps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string DeleteStudent_Sp = @"
                CREATE PROCEDURE [dbo].[DeleteStudent_Sp]
                @StudentId int
                   AS
                    BEGIN
                    DELETE FROM [dbo].[StudentTbl] WHERE Id=@StudentId
                    END
                ";
            string InsertStudent_Sp = @"
                CREATE PROCEDURE [dbo].[InsertStudent_Sp]
                @Name VARCHAR(256),@RollNo VARCHAR(256),@Class VARCHAR(256),@Section VARCHAR(256),@MobileNumber VARCHAR(256)
                   AS
                    BEGIN
                    INSERT INTO [dbo].[StudentTbl](Name,RollNo,Class,Section,MobileNumber) VALUES(@Name,@RollNo,@Class,@Section,@MobileNumber)
                    END
                ";
            migrationBuilder.Sql(DeleteStudent_Sp);
            migrationBuilder.Sql(InsertStudent_Sp);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string DeleteStudent_Sp = "DROP PROCEDURE [dbo].[DeleteStudent_Sp]";
            string InsertStudent_Sp = "DROP PROCEDURE [dbo].[DeleteStudent_Sp]";
            migrationBuilder.Sql(DeleteStudent_Sp);
            migrationBuilder.Sql(InsertStudent_Sp);
        }  /// <inheritdoc />
      
    }
}

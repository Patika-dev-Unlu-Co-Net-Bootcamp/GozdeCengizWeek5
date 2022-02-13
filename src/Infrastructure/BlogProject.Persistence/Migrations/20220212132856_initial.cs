using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogProject.Persistence.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Context = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Context", "CreatedDate", "Title", "UpdatedDate" },
                values: new object[] { new Guid("5fdd6819-0fa5-4667-abc1-161d88ee1e9e"), 1, "context1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "post1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Context", "CreatedDate", "Title", "UpdatedDate" },
                values: new object[] { new Guid("4ddb0c6c-42ff-46b9-ab1c-7d9ed5c76aff"), 2, "context2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "post2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Context", "CreatedDate", "Title", "UpdatedDate" },
                values: new object[] { new Guid("8e7e2d8a-00b0-4760-96c3-866236789721"), 1, "context3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "post3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}

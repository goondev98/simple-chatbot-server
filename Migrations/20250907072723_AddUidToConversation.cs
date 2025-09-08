using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace simple_netcore_chatbot.Migrations
{
    /// <inheritdoc />
    public partial class AddUidToConversation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Uid",
                table: "Conversations",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uid",
                table: "Conversations");
        }
    }
}

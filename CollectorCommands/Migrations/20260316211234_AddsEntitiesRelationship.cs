using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectorCommands.Migrations
{
    /// <inheritdoc />
    public partial class AddsEntitiesRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Commands_CommandModelId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_CommandModelId",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "CommandModelId",
                table: "Articles",
                newName: "UserId");

            migrationBuilder.AddColumn<Guid>(
                name: "BuyerId",
                table: "Commands",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SellerId",
                table: "Commands",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Commands",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "CommandId",
                table: "Articles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CommandId",
                table: "Articles",
                column: "CommandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Commands_CommandId",
                table: "Articles",
                column: "CommandId",
                principalTable: "Commands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Commands_CommandId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_CommandId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "Commands");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Commands");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Commands");

            migrationBuilder.DropColumn(
                name: "CommandId",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Articles",
                newName: "CommandModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CommandModelId",
                table: "Articles",
                column: "CommandModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Commands_CommandModelId",
                table: "Articles",
                column: "CommandModelId",
                principalTable: "Commands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

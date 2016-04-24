using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace PublicNewsPaper.Migrations
{
    public partial class MakeTableNamesPlural : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Story_Category_CategoryId", table: "Story");
            migrationBuilder.RenameTable(
                name: "Story",
                newName: "Stories");
            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");
            migrationBuilder.AddForeignKey(
                name: "FK_Story_Category_CategoryId",
                table: "Stories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Story_Category_CategoryId", table: "Stories");
            migrationBuilder.AddForeignKey(
                name: "FK_Story_Category_CategoryId",
                table: "Story",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.RenameTable(
                name: "Stories",
                newName: "Story");
            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");
        }
    }
}

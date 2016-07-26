using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class testmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Pages_PageId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "PageId",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Pages_PageId",
                table: "Comments",
                column: "PageId",
                principalTable: "Pages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Pages_PageId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "PageId",
                table: "Comments",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Pages_PageId",
                table: "Comments",
                column: "PageId",
                principalTable: "Pages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

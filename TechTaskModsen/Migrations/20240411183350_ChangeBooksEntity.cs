﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechTaskModsen.Migrations
{
    /// <inheritdoc />
    public partial class ChangeBooksEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Books",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Books");
        }
    }
}

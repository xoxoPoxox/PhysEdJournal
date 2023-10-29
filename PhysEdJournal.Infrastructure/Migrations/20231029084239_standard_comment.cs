﻿// <auto-generated/>
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

namespace PhysEdJournal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class standardcomment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "StandardsStudentsHistory",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "StandardsStudentsHistory");
        }
    }
}

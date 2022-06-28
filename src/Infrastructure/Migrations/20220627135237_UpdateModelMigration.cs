using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CleanArchitecture.Infrastructure.Migrations
{
    public partial class UpdateModelMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImdbId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "OriginalLanguage",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "Emotions");

            migrationBuilder.AddColumn<string>(
                name: "backdrop_path",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "budget",
                table: "Movies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "homepage",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "imdb_id",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "original_language",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "original_title",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "overview",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "popularity",
                table: "Movies",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "release_date",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "revenue",
                table: "Movies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "runtime",
                table: "Movies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tagline",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "video",
                table: "Movies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "vote_average",
                table: "Movies",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "vote_count",
                table: "Movies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MovieEmotions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    MovieId = table.Column<int>(nullable: false),
                    EmotionId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieEmotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieEmotions_Emotions_EmotionId",
                        column: x => x.EmotionId,
                        principalTable: "Emotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieEmotions_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieEmotions_MovieUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "MovieUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieEmotions_EmotionId",
                table: "MovieEmotions",
                column: "EmotionId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieEmotions_MovieId",
                table: "MovieEmotions",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieEmotions_UserId",
                table: "MovieEmotions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieEmotions");

            migrationBuilder.DropColumn(
                name: "backdrop_path",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "budget",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "homepage",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "imdb_id",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "original_language",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "original_title",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "overview",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "popularity",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "release_date",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "revenue",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "runtime",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "tagline",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "video",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "vote_average",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "vote_count",
                table: "Movies");

            migrationBuilder.AddColumn<string>(
                name: "ImdbId",
                table: "Movies",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginalLanguage",
                table: "Movies",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Emotions",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}

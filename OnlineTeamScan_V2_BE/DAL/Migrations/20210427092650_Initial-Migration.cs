using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_dysfunctions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_dysfunctions", x => x.id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "tbl_languages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(30)", nullable: false),
                    code = table.Column<string>(type: "varchar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_languages", x => x.id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "tbl_levels",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lower_limit = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    upper_limit = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    color = table.Column<string>(type: "char(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_levels", x => x.id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "tbl_roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(30)", nullable: false),
                    display_label = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_questions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dysfunction_id = table.Column<int>(type: "int", nullable: false),
                    number = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_questions", x => x.id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_tbl_questions_tbl_dysfunctions_dysfunction_id",
                        column: x => x.dysfunction_id,
                        principalTable: "tbl_dysfunctions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_recommendations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dysfunction_id = table.Column<int>(type: "int", nullable: false),
                    link = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_recommendations", x => x.id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_tbl_recommendations_tbl_dysfunctions_dysfunction_id",
                        column: x => x.dysfunction_id,
                        principalTable: "tbl_dysfunctions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_dysfunction_translations",
                columns: table => new
                {
                    language_id = table.Column<int>(type: "int", nullable: false),
                    dysfunction_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_dysfunction_translations", x => new { x.dysfunction_id, x.language_id });
                    table.ForeignKey(
                        name: "FK_tbl_dysfunction_translations_tbl_dysfunctions_dysfunction_id",
                        column: x => x.dysfunction_id,
                        principalTable: "tbl_dysfunctions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_dysfunction_translations_tbl_languages_language_id",
                        column: x => x.language_id,
                        principalTable: "tbl_languages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    preferred_language_id = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    firstname = table.Column<string>(type: "varchar(70)", nullable: false),
                    lastname = table.Column<string>(type: "varchar(70)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "varchar(100)", nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_users_tbl_languages_preferred_language_id",
                        column: x => x.preferred_language_id,
                        principalTable: "tbl_languages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_interpretations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dysfunction_id = table.Column<int>(type: "int", nullable: false),
                    level_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_interpretations", x => x.id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_tbl_interpretations_tbl_dysfunctions_dysfunction_id",
                        column: x => x.dysfunction_id,
                        principalTable: "tbl_dysfunctions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_interpretations_tbl_levels_level_id",
                        column: x => x.level_id,
                        principalTable: "tbl_levels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_level_translations",
                columns: table => new
                {
                    language_id = table.Column<int>(type: "int", nullable: false),
                    level_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_level_translations", x => new { x.level_id, x.language_id });
                    table.ForeignKey(
                        name: "FK_tbl_level_translations_tbl_languages_language_id",
                        column: x => x.language_id,
                        principalTable: "tbl_languages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_level_translations_tbl_levels_level_id",
                        column: x => x.level_id,
                        principalTable: "tbl_levels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_role_translations",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false),
                    language_id = table.Column<int>(type: "int", nullable: false),
                    translation = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_role_translations", x => new { x.role_id, x.language_id });
                    table.ForeignKey(
                        name: "FK_tbl_role_translations_tbl_languages_language_id",
                        column: x => x.language_id,
                        principalTable: "tbl_languages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_role_translations_tbl_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "tbl_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_question_translations",
                columns: table => new
                {
                    language_id = table.Column<int>(type: "int", nullable: false),
                    question_id = table.Column<int>(type: "int", nullable: false),
                    text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_question_translations", x => new { x.question_id, x.language_id });
                    table.ForeignKey(
                        name: "FK_tbl_question_translations_tbl_languages_language_id",
                        column: x => x.language_id,
                        principalTable: "tbl_languages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_question_translations_tbl_questions_question_id",
                        column: x => x.question_id,
                        principalTable: "tbl_questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_recommendation_translations",
                columns: table => new
                {
                    language_id = table.Column<int>(type: "int", nullable: false),
                    recommendation_id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "varchar(100)", nullable: false),
                    text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_recommendation_translations", x => new { x.recommendation_id, x.language_id });
                    table.ForeignKey(
                        name: "FK_tbl_recommendation_translations_tbl_languages_language_id",
                        column: x => x.language_id,
                        principalTable: "tbl_languages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_recommendation_translations_tbl_recommendations_recommendation_id",
                        column: x => x.recommendation_id,
                        principalTable: "tbl_recommendations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_teams",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    teamleader_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", nullable: false),
                    last_teamscan = table.Column<DateTime>(type: "date", nullable: true),
                    is_teamscan_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_teams", x => x.id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_tbl_teams_tbl_users_teamleader_id",
                        column: x => x.teamleader_id,
                        principalTable: "tbl_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user_roles",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "FK_tbl_user_roles_tbl_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "tbl_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_user_roles_tbl_users_user_id",
                        column: x => x.user_id,
                        principalTable: "tbl_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_interpretation_translations",
                columns: table => new
                {
                    language_id = table.Column<int>(type: "int", nullable: false),
                    interpretation_id = table.Column<int>(type: "int", nullable: false),
                    text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_interpretation_translations", x => new { x.interpretation_id, x.language_id });
                    table.ForeignKey(
                        name: "FK_tbl_interpretation_translations_tbl_interpretations_interpretation_id",
                        column: x => x.interpretation_id,
                        principalTable: "tbl_interpretations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_interpretation_translations_tbl_languages_language_id",
                        column: x => x.language_id,
                        principalTable: "tbl_languages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_teammembers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    team_id = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "varchar(100)", nullable: false),
                    firstname = table.Column<string>(type: "varchar(70)", nullable: false),
                    lastname = table.Column<string>(type: "varchar(70)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_teammembers", x => x.id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_tbl_teammembers_tbl_teams_team_id",
                        column: x => x.team_id,
                        principalTable: "tbl_teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_teamscans",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    startedby_id = table.Column<int>(type: "int", nullable: false),
                    team_id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "varchar(50)", nullable: false),
                    number = table.Column<int>(type: "int", nullable: false),
                    start_date = table.Column<DateTime>(type: "date", nullable: false),
                    end_date = table.Column<DateTime>(type: "date", nullable: true),
                    score_trust = table.Column<decimal>(type: "decimal(3,2)", nullable: false, defaultValue: 0m),
                    score_conflict = table.Column<decimal>(type: "decimal(3,2)", nullable: false, defaultValue: 0m),
                    score_commitment = table.Column<decimal>(type: "decimal(3,2)", nullable: false, defaultValue: 0m),
                    score_accountability = table.Column<decimal>(type: "decimal(3,2)", nullable: false, defaultValue: 0m),
                    score_results = table.Column<decimal>(type: "decimal(3,2)", nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_teamscans", x => x.id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_tbl_teamscans_tbl_teams_team_id",
                        column: x => x.team_id,
                        principalTable: "tbl_teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_teamscans_tbl_users_startedby_id",
                        column: x => x.startedby_id,
                        principalTable: "tbl_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_individualscores",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    teammember_id = table.Column<int>(type: "int", nullable: false),
                    teamscan_id = table.Column<int>(type: "int", nullable: false),
                    score_trust = table.Column<decimal>(type: "decimal(3,2)", nullable: false, defaultValue: 0m),
                    score_conflict = table.Column<decimal>(type: "decimal(3,2)", nullable: false, defaultValue: 0m),
                    score_commitment = table.Column<decimal>(type: "decimal(3,2)", nullable: false, defaultValue: 0m),
                    score_accountability = table.Column<decimal>(type: "decimal(3,2)", nullable: false, defaultValue: 0m),
                    score_results = table.Column<decimal>(type: "decimal(3,2)", nullable: false, defaultValue: 0m),
                    has_answered = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_individualscores", x => x.id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_tbl_individualscores_tbl_teammembers_teammember_id",
                        column: x => x.teammember_id,
                        principalTable: "tbl_teammembers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_individualscores_tbl_teamscans_teamscan_id",
                        column: x => x.teamscan_id,
                        principalTable: "tbl_teamscans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "tbl_dysfunctions",
                column: "id",
                values: new object[]
                {
                    1,
                    2,
                    3,
                    4,
                    5
                });

            migrationBuilder.InsertData(
                table: "tbl_languages",
                columns: new[] { "id", "code", "name" },
                values: new object[,]
                {
                    { 1, "nl", "Nederlands" },
                    { 2, "en", "English" },
                    { 3, "fr", "Français" }
                });

            migrationBuilder.InsertData(
                table: "tbl_levels",
                columns: new[] { "id", "color", "lower_limit", "upper_limit" },
                values: new object[,]
                {
                    { 1, "#F95656", 1m, 3.24m },
                    { 2, "#FFD54A", 3.25m, 3.74m },
                    { 3, "#93EB5F", 3.75m, 5m },
                    { 4, "#D8D8D8", 0m, 0m }
                });

            migrationBuilder.InsertData(
                table: "tbl_roles",
                columns: new[] { "id", "display_label", "name" },
                values: new object[] { 1, "Teamleader", "Teamleader" });

            migrationBuilder.InsertData(
                table: "tbl_dysfunction_translations",
                columns: new[] { "dysfunction_id", "language_id", "name" },
                values: new object[,]
                {
                    { 5, 2, "Results" },
                    { 3, 2, "Commitment" },
                    { 2, 2, "Conflict" },
                    { 1, 2, "Trust" },
                    { 5, 1, "Resultaat" },
                    { 4, 1, "Aanspreekbaarheid" },
                    { 3, 1, "Commitment" },
                    { 2, 1, "Conflict" },
                    { 1, 1, "Vertrouwen" },
                    { 4, 2, "Accountability" }
                });

            migrationBuilder.InsertData(
                table: "tbl_interpretations",
                columns: new[] { "id", "dysfunction_id", "level_id" },
                values: new object[,]
                {
                    { 11, 4, 2 },
                    { 8, 3, 2 },
                    { 2, 1, 2 },
                    { 1, 1, 1 },
                    { 10, 4, 1 },
                    { 7, 3, 1 },
                    { 4, 2, 1 },
                    { 14, 5, 2 },
                    { 13, 5, 1 },
                    { 3, 1, 3 },
                    { 5, 2, 2 },
                    { 12, 4, 3 },
                    { 9, 3, 3 },
                    { 15, 5, 3 },
                    { 6, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "tbl_level_translations",
                columns: new[] { "language_id", "level_id", "name" },
                values: new object[,]
                {
                    { 1, 3, "Hoog" },
                    { 1, 2, "Gemiddeld" },
                    { 2, 3, "High" },
                    { 2, 2, "Medium" },
                    { 2, 1, "Low" },
                    { 1, 1, "Laag" }
                });

            migrationBuilder.InsertData(
                table: "tbl_questions",
                columns: new[] { "id", "dysfunction_id", "number" },
                values: new object[,]
                {
                    { 10, 1, (byte)10 },
                    { 3, 5, (byte)3 },
                    { 9, 5, (byte)9 },
                    { 14, 5, (byte)14 },
                    { 15, 5, (byte)15 },
                    { 25, 5, (byte)25 },
                    { 29, 5, (byte)29 },
                    { 37, 5, (byte)37 },
                    { 6, 1, (byte)6 },
                    { 33, 1, (byte)33 },
                    { 32, 1, (byte)32 }
                });

            migrationBuilder.InsertData(
                table: "tbl_questions",
                columns: new[] { "id", "dysfunction_id", "number" },
                values: new object[,]
                {
                    { 22, 1, (byte)22 },
                    { 17, 1, (byte)17 },
                    { 13, 1, (byte)13 },
                    { 31, 5, (byte)31 },
                    { 23, 2, (byte)23 },
                    { 36, 4, (byte)36 },
                    { 27, 2, (byte)27 },
                    { 18, 2, (byte)18 },
                    { 12, 2, (byte)12 },
                    { 11, 3, (byte)11 },
                    { 19, 3, (byte)19 },
                    { 24, 3, (byte)24 },
                    { 28, 3, (byte)28 },
                    { 30, 3, (byte)30 },
                    { 34, 3, (byte)34 },
                    { 2, 2, (byte)2 },
                    { 38, 3, (byte)38 },
                    { 5, 2, (byte)5 },
                    { 4, 2, (byte)4 },
                    { 8, 4, (byte)8 },
                    { 16, 4, (byte)16 },
                    { 20, 4, (byte)20 },
                    { 21, 4, (byte)21 },
                    { 26, 4, (byte)26 },
                    { 35, 4, (byte)35 },
                    { 7, 2, (byte)7 },
                    { 1, 1, (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "tbl_recommendations",
                columns: new[] { "id", "dysfunction_id", "link" },
                values: new object[,]
                {
                    { 16, 4, "https://www.tablegroup.com/download/team-effectiveness-exercise/" },
                    { 20, 5, null },
                    { 1, 1, "https://www.tablegroup.com/download/personal-histories-exercise/" },
                    { 2, 1, null },
                    { 3, 1, "https://www.tablegroup.com/hub/post/the-fundamental-attribution-error" },
                    { 4, 1, "https://www.tablegroup.com/download/itp-self-ranking-exercise/" },
                    { 5, 1, null },
                    { 6, 2, "https://www.tablegroup.com/hub/post/real-time-permission-video" },
                    { 7, 2, null },
                    { 8, 2, null },
                    { 21, 5, null },
                    { 9, 2, null },
                    { 11, 3, null },
                    { 12, 3, "https://www.tablegroup.com/download/silos-model/" },
                    { 13, 3, null }
                });

            migrationBuilder.InsertData(
                table: "tbl_recommendations",
                columns: new[] { "id", "dysfunction_id", "link" },
                values: new object[,]
                {
                    { 14, 3, null },
                    { 15, 3, null },
                    { 17, 4, null },
                    { 18, 4, null },
                    { 19, 5, "https://www.tablegroup.com/hub/post/team-1" },
                    { 10, 2, "https://www.tablegroup.com/hub/post/conflict-continuum" }
                });

            migrationBuilder.InsertData(
                table: "tbl_role_translations",
                columns: new[] { "language_id", "role_id", "translation" },
                values: new object[] { 1, 1, "Teamleider" });

            migrationBuilder.InsertData(
                table: "tbl_interpretation_translations",
                columns: new[] { "interpretation_id", "language_id", "text" },
                values: new object[,]
                {
                    { 15, 1, "Je team schat het bereiken van het collectief resultaat hoger in dan het bereiken van individueel gewin, erkenning en status." },
                    { 12, 1, "Je team aarzelt niet om elkaar aan te spreken op gemaakte afspraken, gedrag en prestatie." },
                    { 1, 1, "Je team heeft een duidelijk gebrek aan de noodzakelijke openheid en kwetsbaarheid rond elkaars zwakheden, twijfels, fouten, uitdagingen en nood aan hulp die leden van elkaar verwachten om goed te kunnen samenwerken." },
                    { 4, 1, "Je team voelt zich niet comfortabel om conflicten te bespreken en houdt meningsverschillen voor zichzelf of misbruikt ze tegen elkaar." },
                    { 7, 1, "Je team is niet in staat om zich volledig achter genomen beslissingen te scharen, waardoor dubbelzinnigheid en veronderstellingen eerder regel zijn dan uitzondering." },
                    { 13, 1, "Je team hecht duidelijk te weinig waarde aan het collectieve resultaat en is vooral bezig met individueel gewin, erkenning en status." },
                    { 2, 1, "Je team zou moeten leren om zich kwetsbaarder en opener op te stellen naar elkaar toe i.v.m. elkaars zwakheden, twijfels, fouten, uitdagingen en nood aan hulp." },
                    { 10, 1, "Je team aarzelt of vermijdt om elkaar aan te spreken op gemaakte afspraken, gedrag en prestatie." },
                    { 8, 1, "Je team heeft het soms moeilijk om zich volledig achter genomen beslissingen te scharen, waardoor dubbelzinnigheid en veronderstellingen mogelijks de kop op steken." },
                    { 11, 1, "Je team aarzelt soms om elkaar aan te spreken op gemaakte afspraken, gedrag en prestatie." },
                    { 14, 1, "Je team hecht mogelijks teveel waarde aan individueel/departementeel gewin, erkenning en status in het nadeel van het collectieve resultaat." },
                    { 3, 1, "Je team heeft een omgeving gecreëerd waar kwetsbaarheid en openheid de norm zijn." },
                    { 6, 1, "Je team durft makkelijk conflicten bespreken en verschillende meningen uiten." },
                    { 9, 1, "Je team is in staat om zich volledig achter genomen beslissingen te scharen, zodat dubbelzinnigheid en veronderstellingen geen kans krijgen." },
                    { 5, 1, "Je team zou moeten leren om conflicten sneller te bespreken en rond belangrijke meningsverschillen openlijk in discussie te gaan." }
                });

            migrationBuilder.InsertData(
                table: "tbl_question_translations",
                columns: new[] { "language_id", "question_id", "text" },
                values: new object[,]
                {
                    { 1, 35, "Teamleden houden steeds aan hun beloften en afspraken naar elkaar." },
                    { 1, 8, "Teamleden durven elkaar aanspreken op elkaars mindere prestaties." },
                    { 1, 16, "Teamleden zijn snel met het elkaar confronteren van problemen in mekaars verantwoordelijkheidsdomeinen." },
                    { 1, 20, "Teamleden bevragen elkaar rond hun huidige manieren van werken en gebruikte methoden(‘best practices’)." },
                    { 1, 21, "Het team zorgt ervoor dat de minder presterende teamleden extra druk en een verhoogde verwachting tot presteren voelen." },
                    { 1, 26, "Alle leden van het team hebben dezelfde hoge kwaliteitsnormen over hun werk." },
                    { 1, 36, "Teamleden geven elkaar eerlijke, constructieve en niet manipulerende feedback aan elkaar." },
                    { 1, 31, "Teamleden waarderen collectief succes hoger dan individuele prestaties." },
                    { 1, 9, "Het team heeft een reputatie van hoge prestaties." },
                    { 1, 14, "Als het team zijn collectieve resultaten niet haalt gaat elk teamlid spontaan zijn verantwoordelijkheid opnemen om het algemene teamresultaat te verbeteren." },
                    { 1, 15, "Teamleden doen gemakkelijk toegevingen in hun eigen verantwoordelijkheidsgebied ten gunste van de goede werking van het team." },
                    { 1, 25, "Teamleden gaan eerder op zoek naar waardering en erkenning voor de teamprestaties dan voor hun persoonlijke prestaties." },
                    { 1, 29, "Het team bereikt consistent zijn doelstellingen." },
                    { 1, 37, "Teamleden hechten weinig belang aan titels, status en aanzien." },
                    { 1, 3, "Teamleden zijn snel in het benoemen van de bijdragen en de successen van de anderen." },
                    { 1, 38, "Teamleden steunen groepsbeslissingen, zelfs als dat indruist tegen hun eigen persoonlijke mening." },
                    { 1, 1, "Teamleden geven hun fouten toe." },
                    { 1, 30, "Het team neemt makkelijk beslissingen, zelfs als niet alle informatie voor handen is." },
                    { 1, 6, "Teamleden geven hun eigen zwakheden aan elkaar toe." },
                    { 1, 10, "Teamleden vragen elkaar makkelijk om hulp." },
                    { 1, 13, "Teamleden vragen snel en makkelijk naar input over hun verantwoordelijkheidsdomein." },
                    { 1, 17, "Teamleden (h)erkennen en maken gebruik van elkaars competenties en ervaring." },
                    { 1, 22, "Teamleden gaan zich spontaan verontschuldigen naar elkaar toe." },
                    { 1, 32, "Teamleden zijn onbevooroordeeld en oprecht met elkaar." },
                    { 1, 33, "Teamleden kunnen makkelijk en spontaan privé zaken met elkaar bespreken." },
                    { 1, 2, "Teamleden zijn gepassioneerd en open in het bespreken van hun uitdagingen." },
                    { 1, 4, "Team vergaderingen zijn boeiend en inspirerend." }
                });

            migrationBuilder.InsertData(
                table: "tbl_question_translations",
                columns: new[] { "language_id", "question_id", "text" },
                values: new object[,]
                {
                    { 1, 5, "Tijdens team vergaderingen worden de belangrijkste en moeilijkste onderwerpen aangekaart." },
                    { 1, 7, "Teamleden durven hun mening zeggen, ook als het mogelijks tot onenigheid leidt." },
                    { 1, 34, "Het team houdt zich aan genomen beslissingen." },
                    { 1, 18, "Teamleden vragen actief naar elkaars meningen tijdens vergaderingen." },
                    { 1, 23, "Teamleden communiceren makkelijk onpopulaire meningen in de groep." },
                    { 1, 27, "Als er zich een conflict voordoet gaat het team dat eerst oplossen alvorens een ander onderwerp aan te pakken." },
                    { 1, 12, "Tijdens discussies vragen teamleden door over hoe ze tot hun mening en besluiten komen." },
                    { 1, 28, "Het team heeft gezamenlijke doelstellingen en heeft de neus in dezelfde richting." },
                    { 1, 24, "In het team is het duidelijk welke de prioriteiten zijn en welke richting men uit wil." },
                    { 1, 19, "Teamleden eindigen discussies en vergaderingen altijd met duidelijke, eenduidige en specifieke besluiten en actiepunten." },
                    { 1, 11, "Teamleden verlaten de team vergaderingen met de overtuiging dat iedereen volledig achter de genomen beslissingen staat." }
                });

            migrationBuilder.InsertData(
                table: "tbl_recommendation_translations",
                columns: new[] { "language_id", "recommendation_id", "text", "title" },
                values: new object[,]
                {
                    { 2, 18, "During every weekly meeting, review progress on the team’s agreed upon thematic goal. When a team ensures deviations from plans are identified quickly, they make it more likely that performance issues of team members will be highlighted and addressed. The Meeting Advantage is an online tool that can help a team measure progress on shared goals and hold one another accountable to their commitments.", "The Thematic Goal—Meetings" },
                    { 2, 11, "A team cannot achieve commitment without conflict. Team members will not actively commit to a decision if they have not had the opportunity to provide input, ask questions, and understand the rationale behind it. If people don’t weigh-in, they can’t buy-in. It is the job of the leader to solicit the input of each team member during meetings and discussions.", "Weigh-in to Buy-in" },
                    { 2, 12, "With a foundation of trust and a good dose of healthy conflict, a team needs to agree upon their most important near-term priority, a thematic goal, and how they are going to go about achieving it. Agreeing on a top priority and reviewing progress towards it during weekly meetings reinforces commitment.", "Thematic Goal" },
                    { 2, 13, "The Meeting Advantage is an online tool designed to help a team focus on their most important priorities by using the thematic goal to guide weekly meetings.", "Meetings" },
                    { 2, 15, "Force the team to achieve clarity and closure. Leaders of teams who commit to decisions demand that their people eliminate ambiguity and leave meetings and discussions clear about what they are agreeing to do. Do the hard work of wrestling issues to the ground. Be sure not to shy away from lively, often lengthy discussion around big strategic topics or to move on to new agenda items too early for the sake of time.", "Clarity and Closure" },
                    { 2, 1, "One of the simplest and most effective ways to build vulnerability on a team is to use the Personal Histories Exercise. This exercise consists of three simple questions, takes no more than 25 minutes and without fail, team members walk away with a deeper knowledge of one another’s stories. This is a great place to start building vulnerability and trust on the team.", "Personal Histories Exercise" },
                    { 2, 2, "All team members are wired differently. Personality instruments (i.e., Myers-Briggs, DiSC or Social Styles) help team members understand one another’s different preferences, skills and attitudes, and identify collective strengths and potential blind spots of the team. This will help team members avoid making unproductive judgments about one another and instead leverage the diverse approaches and perspectives of the team.", "Personality Instrument" },
                    { 2, 3, "The fundamental attribution error occurs when human beings falsely attribute the negative behaviors of others to their character (an internal attribution), while they attribute their own negative behaviors to their environment (an external attribution). View the video on the Fundamental Attribution Error and discuss how using a personality instrument can help team members avoid making bad judgments about one another’s character and intentions.", "Fundamental Attribution Error" },
                    { 2, 4, "In Pat’s related book The Ideal Team Player, he looks at the individual team member and identifies three essential virtues of real team players. When individuals on a team are humble, hungry, and smart, it makes overcoming the five dysfunctions of a team much more attainable. This self-ranking exercise is a great way for team members to assess themselves against the three virtues and build trust by sharing with the team.", "Self-Ranking Exercise" },
                    { 2, 5, "Virtual teams need to commit to spending face-to-face time together, as much and as often as possible, and to use that time wisely. That means working hard to build vulnerability-based trust with one another. It’s hard enough for people who work in the same office every day and who look at each other in the face during meetings to do this well. Teams who don’t have that luxury are going to have to be much more intentional about getting to know one another during their virtual meetings and when they are together.", "An Important Note for Virtual Teams..." },
                    { 2, 21, "Ensure that team-based rewards form the basis for most compensation and recognition programs. When team members have incentives to focus on their individual performance objectives and not those of the team, it becomes easy for results to take a back seat to personal financial goals and career development.", "Team-based Rewards" },
                    { 2, 20, "During every weekly meeting, a team should focus on its thematic goal. This is a way of reinforcing collective results in a public way, and team members are much more likely to follow through and less likely to let personal needs take precedence. The Meetings Advantage is an online tool that can help a team measure progress on shared goals and hold one another accountable to their commitments, which ultimately leads to team-based results.", "The Thematic Goal—Meetings" },
                    { 2, 19, "Getting all members of the team to value and emphasize the collective success of the group over their own personal needs or departmental goals is essential for effective teams. Results suffer when team members put a higher priority on the activities of their own departments or divisions. Review the video and ensure each individual commits to the team goals/results as his/her top priority.", "Team #1" },
                    { 2, 10, "The conflict continuum is a spectrum depicting the full range of conflict, from artificial harmony (zero conflict) to aggressive and destructive politics (extreme conflict). At the middle of the continuum is the point where conflict changes from constructive and ideological to destructive and personal. View the video on the conflict continuum and discuss where the team might fall on the scale. Discuss ways artificial harmony shows up and identify how to introduce more healthy conflict into team meetings and discussions.", "Conflict Continuum" },
                    { 2, 9, "Establish rules of engagement for dealing with conflict within the team (e.g., behaviors, displays of emotion, language, process). Having clear standards of behavior allows a team to focus on the discussion of issues without having to slow down to think about what is and is not appropriate. Capture the team conflict norms and refer to them in meetings.", "Conflict Norms" },
                    { 2, 8, "Many personality instruments include an analysis of how each style or type deals with conflict. Explore and discuss how different team members naturally engage in conflict.", "Personality Instrument" },
                    { 2, 7, "If team members remain hesitant to engage in conflict or avoid sharing dissenting opinions, it is the leader’s job to provoke team conflict. We call this “mining for conflict.” It is important that a team member, most often the leader, is responsible for drawing out any potential unresolved issues and forcing the team to confront them.", "Mine for Conflict" },
                    { 2, 16, "The Team Effectiveness Exercise provides a forum for quick and effective exchange of feedback. Ask team members to identify and communicate one another’s positive and negative actions/behaviors. By doing so, teams can quickly and constructively surface issues that might take months to address using a more formal, politically divisive 360- degree program.", "Team Effectiveness Exercise" },
                    { 2, 17, "While a sense of accountability should pervade virtually every aspect of organizational life at a great company, the place where it must be demonstrated and addressed most clearly is meetings. Start a weekly meeting with a lightning round. A lightning round allows each team members 30 seconds to share what they are working on in the coming week. When team members keep one another informed about what they are doing, it allows peers to provide feedback and advice on whether team members are focused on the right things as well as ensure those things are moving toward completion.", "The Lightning Round—Meetings" },
                    { 2, 6, "For most teams, conflict can feel foreign and uncomfortable. Real-time permission is when the leader interrupts team members who are in the midst of an uncustomary debate, to remind them that what they are doing is okay. It is the role of the leader to provide real-time permission when healthy conflict is occurring, encouraging the team to continue to passionately debate in pursuit of the best answer.", "Real-time Permission" },
                    { 2, 14, "At the end of every meeting, a team should explicitly review the key decisions made and agree on what needs to be communicated to employees and other constituents. The use of this simple exercise, called cascading communication, demonstrates a public commitment to agreements and aligns employees throughout the organization around common objectives. Even naturally hesitant team members commit to decisions when they have communicated them to their direct reports.", "Cascading Communication" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_dysfunction_translations_language_id",
                table: "tbl_dysfunction_translations",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_individualscores_teammember_id_teamscan_id",
                table: "tbl_individualscores",
                columns: new[] { "teammember_id", "teamscan_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_individualscores_teamscan_id",
                table: "tbl_individualscores",
                column: "teamscan_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_interpretation_translations_language_id",
                table: "tbl_interpretation_translations",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_interpretations_dysfunction_id",
                table: "tbl_interpretations",
                column: "dysfunction_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_interpretations_level_id",
                table: "tbl_interpretations",
                column: "level_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_languages_name_code",
                table: "tbl_languages",
                columns: new[] { "name", "code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_level_translations_language_id",
                table: "tbl_level_translations",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_question_translations_language_id",
                table: "tbl_question_translations",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_questions_dysfunction_id",
                table: "tbl_questions",
                column: "dysfunction_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_recommendation_translations_language_id",
                table: "tbl_recommendation_translations",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_recommendations_dysfunction_id",
                table: "tbl_recommendations",
                column: "dysfunction_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_role_translations_language_id",
                table: "tbl_role_translations",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_roles_name",
                table: "tbl_roles",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_teammembers_team_id_email",
                table: "tbl_teammembers",
                columns: new[] { "team_id", "email" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_teams_name",
                table: "tbl_teams",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_teams_teamleader_id",
                table: "tbl_teams",
                column: "teamleader_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_teamscans_startedby_id",
                table: "tbl_teamscans",
                column: "startedby_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_teamscans_team_id_title_number",
                table: "tbl_teamscans",
                columns: new[] { "team_id", "title", "number" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_roles_role_id",
                table: "tbl_user_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_email",
                table: "tbl_users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_preferred_language_id",
                table: "tbl_users",
                column: "preferred_language_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_dysfunction_translations");

            migrationBuilder.DropTable(
                name: "tbl_individualscores");

            migrationBuilder.DropTable(
                name: "tbl_interpretation_translations");

            migrationBuilder.DropTable(
                name: "tbl_level_translations");

            migrationBuilder.DropTable(
                name: "tbl_question_translations");

            migrationBuilder.DropTable(
                name: "tbl_recommendation_translations");

            migrationBuilder.DropTable(
                name: "tbl_role_translations");

            migrationBuilder.DropTable(
                name: "tbl_user_roles");

            migrationBuilder.DropTable(
                name: "tbl_teammembers");

            migrationBuilder.DropTable(
                name: "tbl_teamscans");

            migrationBuilder.DropTable(
                name: "tbl_interpretations");

            migrationBuilder.DropTable(
                name: "tbl_questions");

            migrationBuilder.DropTable(
                name: "tbl_recommendations");

            migrationBuilder.DropTable(
                name: "tbl_roles");

            migrationBuilder.DropTable(
                name: "tbl_teams");

            migrationBuilder.DropTable(
                name: "tbl_levels");

            migrationBuilder.DropTable(
                name: "tbl_dysfunctions");

            migrationBuilder.DropTable(
                name: "tbl_users");

            migrationBuilder.DropTable(
                name: "tbl_languages");
        }
    }
}

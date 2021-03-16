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
                    upper_limit = table.Column<decimal>(type: "decimal(3,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_levels", x => x.id)
                        .Annotation("SqlServer:Clustered", true);
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
                    preferred_language_id = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "varchar(100)", nullable: false),
                    firstname = table.Column<string>(type: "varchar(70)", nullable: false),
                    lastname = table.Column<string>(type: "varchar(70)", nullable: false),
                    password = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_users", x => x.id)
                        .Annotation("SqlServer:Clustered", true);
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
                name: "tbl_teams",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    teamleader_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", nullable: false),
                    last_teamscan = table.Column<DateTime>(type: "date", nullable: true)
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
                    start_date = table.Column<DateTime>(type: "date", nullable: false),
                    end_date = table.Column<DateTime>(type: "date", nullable: true),
                    score_trust = table.Column<decimal>(type: "decimal(3,2)", nullable: false, defaultValue: 0m),
                    score_conflict = table.Column<decimal>(type: "decimal(3,2)", nullable: false, defaultValue: 0m),
                    score_commitment = table.Column<decimal>(type: "decimal(3,2)", nullable: false, defaultValue: 0m),
                    score_accountability = table.Column<decimal>(type: "decimal(3,2)", nullable: false, defaultValue: 0m),
                    score_results = table.Column<decimal>(type: "decimal(3,2)", nullable: false, defaultValue: 0m),
                    TeamId1 = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_tbl_teamscans_tbl_teams_TeamId1",
                        column: x => x.TeamId1,
                        principalTable: "tbl_teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    teammember_id = table.Column<int>(type: "int", nullable: false),
                    teamscan_id = table.Column<int>(type: "int", nullable: false),
                    score_trust = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    score_conflict = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    score_commitment = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    score_accountability = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    score_results = table.Column<decimal>(type: "decimal(3,2)", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "tbl_teamscan_members",
                columns: table => new
                {
                    teammember_id = table.Column<int>(type: "int", nullable: false),
                    teamscan_id = table.Column<int>(type: "int", nullable: false),
                    has_answered = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_teamscan_members", x => new { x.teammember_id, x.teamscan_id });
                    table.ForeignKey(
                        name: "FK_tbl_teamscan_members_tbl_teammembers_teammember_id",
                        column: x => x.teammember_id,
                        principalTable: "tbl_teammembers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_teamscan_members_tbl_teamscans_teamscan_id",
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
                columns: new[] { "id", "lower_limit", "upper_limit" },
                values: new object[,]
                {
                    { 1, 1m, 3.24m },
                    { 2, 3.25m, 3.74m },
                    { 3, 3.75m, 5m }
                });

            migrationBuilder.InsertData(
                table: "tbl_dysfunction_translations",
                columns: new[] { "dysfunction_id", "language_id", "name" },
                values: new object[,]
                {
                    { 1, 2, "Trust" },
                    { 3, 2, "Commitment" },
                    { 4, 2, "Accountability" },
                    { 5, 2, "Results" },
                    { 1, 1, "Vertrouwen" },
                    { 2, 1, "Conflict" },
                    { 5, 1, "Resultaat" },
                    { 4, 1, "Aanspreekbaarheid" },
                    { 2, 2, "Conflict" },
                    { 3, 1, "Commitment" }
                });

            migrationBuilder.InsertData(
                table: "tbl_interpretations",
                columns: new[] { "id", "dysfunction_id", "level_id" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 4, 2, 1 },
                    { 7, 3, 1 },
                    { 13, 5, 1 },
                    { 2, 1, 2 },
                    { 8, 3, 2 },
                    { 11, 4, 2 },
                    { 14, 5, 2 },
                    { 3, 1, 3 },
                    { 6, 2, 3 },
                    { 9, 3, 3 },
                    { 12, 4, 3 },
                    { 15, 5, 3 },
                    { 5, 2, 2 },
                    { 10, 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "tbl_level_translations",
                columns: new[] { "language_id", "level_id", "name" },
                values: new object[,]
                {
                    { 2, 3, "High" },
                    { 1, 1, "Laag" },
                    { 2, 1, "Low" },
                    { 1, 2, "Gemiddeld" },
                    { 2, 2, "Medium" },
                    { 1, 3, "Hoog" }
                });

            migrationBuilder.InsertData(
                table: "tbl_questions",
                columns: new[] { "id", "dysfunction_id", "number" },
                values: new object[,]
                {
                    { 37, 5, (byte)37 },
                    { 31, 5, (byte)31 },
                    { 29, 5, (byte)29 },
                    { 25, 5, (byte)25 },
                    { 14, 5, (byte)14 },
                    { 6, 1, (byte)6 },
                    { 10, 1, (byte)10 },
                    { 13, 1, (byte)13 },
                    { 17, 1, (byte)17 },
                    { 22, 1, (byte)22 },
                    { 32, 1, (byte)32 }
                });

            migrationBuilder.InsertData(
                table: "tbl_questions",
                columns: new[] { "id", "dysfunction_id", "number" },
                values: new object[,]
                {
                    { 33, 1, (byte)33 },
                    { 2, 2, (byte)2 },
                    { 4, 2, (byte)4 },
                    { 5, 2, (byte)5 },
                    { 7, 2, (byte)7 },
                    { 12, 2, (byte)12 },
                    { 18, 2, (byte)18 },
                    { 23, 2, (byte)23 },
                    { 27, 2, (byte)27 },
                    { 11, 3, (byte)11 },
                    { 19, 3, (byte)19 },
                    { 9, 5, (byte)9 },
                    { 3, 5, (byte)3 },
                    { 36, 4, (byte)36 },
                    { 35, 4, (byte)35 },
                    { 26, 4, (byte)26 },
                    { 21, 4, (byte)21 },
                    { 15, 5, (byte)15 },
                    { 20, 4, (byte)20 },
                    { 8, 4, (byte)8 },
                    { 38, 3, (byte)38 },
                    { 34, 3, (byte)34 },
                    { 30, 3, (byte)30 },
                    { 28, 3, (byte)28 },
                    { 24, 3, (byte)24 },
                    { 16, 4, (byte)16 },
                    { 1, 1, (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "tbl_interpretation_translations",
                columns: new[] { "interpretation_id", "language_id", "text" },
                values: new object[,]
                {
                    { 15, 1, "Je team schat het bereiken van het collectief resultaat hoger in dan het bereiken van individueel gewin, erkenning en status." },
                    { 1, 1, "Je team heeft een duidelijk gebrek aan de noodzakelijke openheid en kwetsbaarheid rond elkaars zwakheden, twijfels, fouten, uitdagingen en nood aan hulp die leden van elkaar verwachten om goed te kunnen samenwerken." },
                    { 7, 1, "Je team is niet in staat om zich volledig achter genomen beslissingen te scharen, waardoor dubbelzinnigheid en veronderstellingen eerder regel zijn dan uitzondering." },
                    { 10, 1, "Je team aarzelt of vermijdt om elkaar aan te spreken op gemaakte afspraken, gedrag en prestatie." },
                    { 13, 1, "Je team hecht duidelijk te weinig waarde aan het collectieve resultaat en is vooral bezig met individueel gewin, erkenning en status." },
                    { 2, 1, "Je team zou moeten leren om zich kwetsbaarder en opener op te stellen naar elkaar toe i.v.m. elkaars zwakheden, twijfels, fouten, uitdagingen en nood aan hulp." },
                    { 5, 1, "Je team zou moeten leren om conflicten sneller te bespreken en rond belangrijke meningsverschillen openlijk in discussie te gaan." },
                    { 4, 1, "Je team voelt zich niet comfortabel om conflicten te bespreken en houdt meningsverschillen voor zichzelf of misbruikt ze tegen elkaar." },
                    { 11, 1, "Je team aarzelt soms om elkaar aan te spreken op gemaakte afspraken, gedrag en prestatie." },
                    { 8, 1, "Je team heeft het soms moeilijk om zich volledig achter genomen beslissingen te scharen, waardoor dubbelzinnigheid en veronderstellingen mogelijks de kop op steken." },
                    { 9, 1, "Je team is in staat om zich volledig achter genomen beslissingen te scharen, zodat dubbelzinnigheid en veronderstellingen geen kans krijgen." },
                    { 12, 1, "Je team aarzelt niet om elkaar aan te spreken op gemaakte afspraken, gedrag en prestatie." },
                    { 3, 1, "Je team heeft een omgeving gecreëerd waar kwetsbaarheid en openheid de norm zijn." },
                    { 14, 1, "Je team hecht mogelijks teveel waarde aan individueel/departementeel gewin, erkenning en status in het nadeel van het collectieve resultaat." },
                    { 6, 1, "Je team durft makkelijk conflicten bespreken en verschillende meningen uiten." }
                });

            migrationBuilder.InsertData(
                table: "tbl_question_translations",
                columns: new[] { "language_id", "question_id", "text" },
                values: new object[,]
                {
                    { 1, 26, "Alle leden van het team hebben dezelfde hoge kwaliteitsnormen over hun werk." },
                    { 1, 37, "Teamleden hechten weinig belang aan titels, status en aanzien." },
                    { 1, 31, "Teamleden waarderen collectief succes hoger dan individuele prestaties." },
                    { 1, 25, "Teamleden gaan eerder op zoek naar waardering en erkenning voor de teamprestaties dan voor hun persoonlijke prestaties." },
                    { 1, 15, "Teamleden doen gemakkelijk toegevingen in hun eigen verantwoordelijkheidsgebied ten gunste van de goede werking van het team." },
                    { 1, 14, "Als het team zijn collectieve resultaten niet haalt gaat elk teamlid spontaan zijn verantwoordelijkheid opnemen om het algemene teamresultaat te verbeteren." },
                    { 1, 9, "Het team heeft een reputatie van hoge prestaties." },
                    { 1, 3, "Teamleden zijn snel in het benoemen van de bijdragen en de successen van de anderen." },
                    { 1, 36, "eden geven elkaar eerlijke, constructieve en niet manipulerende feedback aan elkaar." },
                    { 1, 35, "Teamleden houden steeds aan hun beloften en afspraken naar elkaar." },
                    { 1, 29, "Het team bereikt consistent zijn doelstellingen." },
                    { 1, 21, "Het team zorgt ervoor dat de minder presterende teamleden extra druk en een verhoogde verwachting tot presteren voelen." },
                    { 1, 16, "Teamleden zijn snel met het elkaar confronteren van problemen in mekaars verantwoordelijkheidsdomeinen." },
                    { 1, 6, "Teamleden geven hun eigen zwakheden aan elkaar toe." },
                    { 1, 10, "Teamleden vragen elkaar makkelijk om hulp." },
                    { 1, 13, "Teamleden vragen snel en makkelijk naar input over hun verantwoordelijkheidsdomein." },
                    { 1, 17, "Teamleden (h)erkennen en maken gebruik van elkaars competenties en ervaring." },
                    { 1, 22, "Teamleden gaan zich spontaan verontschuldigen naar elkaar toe." },
                    { 1, 32, "Teamleden zijn onbevooroordeeld en oprecht met elkaar." },
                    { 1, 33, "Teamleden kunnen makkelijk en spontaan privé zaken met elkaar bespreken." },
                    { 1, 2, "Teamleden zijn gepassioneerd en open in het bespreken van hun uitdagingen." },
                    { 1, 4, "Team vergaderingen zijn boeiend en inspirerend." },
                    { 1, 5, "Tijdens team vergaderingen worden de belangrijkste en moeilijkste onderwerpen aangekaart." },
                    { 1, 7, "Teamleden durven hun mening zeggen, ook als het mogelijks tot onenigheid leidt." },
                    { 1, 12, "Tijdens discussies vragen teamleden door over hoe ze tot hun mening en besluiten komen." },
                    { 1, 18, "Teamleden vragen actief naar elkaars meningen tijdens vergaderingen." },
                    { 1, 23, "Teamleden communiceren makkelijk onpopulaire meningen in de groep." }
                });

            migrationBuilder.InsertData(
                table: "tbl_question_translations",
                columns: new[] { "language_id", "question_id", "text" },
                values: new object[,]
                {
                    { 1, 27, "Als er zich een conflict voordoet gaat het team dat eerst oplossen alvorens een ander onderwerp aan te pakken." },
                    { 1, 11, "Teamleden verlaten de team vergaderingen met de overtuiging dat iedereen volledig achter de genomen beslissingen staat." },
                    { 1, 19, "Teamleden eindigen discussies en vergaderingen altijd met duidelijke, eenduidige en specifieke besluiten en actiepunten." },
                    { 1, 24, "In het team is het duidelijk welke de prioriteiten zijn en welke richting men uit wil." },
                    { 1, 28, "Het team heeft gezamenlijke doelstellingen en heeft de neus in dezelfde richting." },
                    { 1, 30, "Het team neemt makkelijk beslissingen, zelfs als niet alle informatie voor handen is." },
                    { 1, 34, "Het team houdt zich aan genomen beslissingen." },
                    { 1, 38, "Teamleden steunen groepsbeslissingen, zelfs als dat indruist tegen hun eigen persoonlijke mening." },
                    { 1, 8, "Teamleden durven elkaar aanspreken op elkaars mindere prestaties." },
                    { 1, 20, "Teamleden bevragen elkaar rond hun huidige manieren van werken en gebruikte methoden(‘best practices’)." },
                    { 1, 1, "Teamleden geven hun fouten toe." }
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
                name: "IX_tbl_teamscan_members_teamscan_id",
                table: "tbl_teamscan_members",
                column: "teamscan_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_teamscans_startedby_id",
                table: "tbl_teamscans",
                column: "startedby_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_teamscans_team_id_title",
                table: "tbl_teamscans",
                columns: new[] { "team_id", "title" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_teamscans_TeamId1",
                table: "tbl_teamscans",
                column: "TeamId1");

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
                name: "tbl_teamscan_members");

            migrationBuilder.DropTable(
                name: "tbl_interpretations");

            migrationBuilder.DropTable(
                name: "tbl_questions");

            migrationBuilder.DropTable(
                name: "tbl_teammembers");

            migrationBuilder.DropTable(
                name: "tbl_teamscans");

            migrationBuilder.DropTable(
                name: "tbl_levels");

            migrationBuilder.DropTable(
                name: "tbl_dysfunctions");

            migrationBuilder.DropTable(
                name: "tbl_teams");

            migrationBuilder.DropTable(
                name: "tbl_users");

            migrationBuilder.DropTable(
                name: "tbl_languages");
        }
    }
}

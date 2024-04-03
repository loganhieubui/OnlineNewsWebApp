using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineNewsWebApp.Infrastructure.Migrations
{
    public partial class OnlineNews1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    AboutMe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonationStars = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
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
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ShortDescription = table.Column<string>(name: "Short Description", type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PostContent = table.Column<string>(name: "Post Content", type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ViewCount = table.Column<int>(name: "View Count", type: "int", nullable: false, defaultValue: 0),
                    RateCount = table.Column<int>(name: "Rate Count", type: "int", nullable: false, defaultValue: 0),
                    TotalRate = table.Column<int>(name: "Total Rate", type: "int", nullable: false, defaultValue: 0),
                    PostedOn = table.Column<DateTime>(name: "Posted On", type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Posts_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CommentHeader = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(1026)", maxLength: 1026, nullable: false),
                    CommentTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTagMaps",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTagMaps", x => new { x.PostId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PostTagMaps_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTagMaps_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Arcu neque eros cursus eu enim aptent leo blandit elit varius donec", "Nunc sapien" },
                    { 2, "Sapien varius id fermentum tellus dolor nibh congue sed congue pulvinar odio", "Auctor vestibulum" },
                    { 3, "Et dapibus est finibus mollis adipiscing aliquet euismod magna himenaeos egestas nibh", "Orci ac" },
                    { 4, "Nunc ullamcorper pulvinar ipsum auctor arcu conubia lobortis a auctor enim ante", "Sagittis facilisis" },
                    { 5, "Urna lobortis phasellus tempus fusce malesuada arcu erat id interdum euismod orci", "Auctor nulla" },
                    { 6, "Velit lobortis erat ligula ut a ullamcorper inceptos leo himenaeos non dolor", "Amet fames" },
                    { 7, "Pellentesque ac erat magna mi euismod volutpat ipsum fringilla a laoreet dignissim", "Turpis vestibulum" },
                    { 8, "Facilisis turpis rhoncus ligula eleifend elementum sem vel tempus sociosqu arcu semper", "Tellus vivamus" },
                    { 9, "Non nisi pulvinar eget iaculis ac malesuada bibendum tristique tempor phasellus commodo", "Maecenas suspendisse" },
                    { 10, "Urna tempus lorem sem commodo vel arcu bibendum purus in nibh conubia", "Convallis aenean" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d249a9a-17b2-48be-9c54-9c92d4da6e5d", "e59c0428-ae9d-49a0-ae03-d6bcf18a8163", "Admin", "ADMIN" },
                    { "3053cfdc-9cdb-490b-9e88-5d3e7ffb4929", "6181732c-0f9d-4785-b71d-d00f5564edd5", "Writer", "WRITER" },
                    { "cf1f7398-a0df-45c4-9140-2252a8e81fa8", "a52897eb-edcc-4685-8a7c-6da59da2b966", "Reader", "READER" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Count", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Arcu at neque" },
                    { 2, 2, "Integer platea urna" },
                    { 3, 2, "Torquent ullamcorper nibh" },
                    { 4, 2, "Nullam sollicitudin ultrices" },
                    { 5, 3, "Adipiscing mattis ante" },
                    { 6, 1, "Nec nisl nisi" },
                    { 7, 0, "Blandit ut rhoncus" },
                    { 8, 1, "Rhoncus molestie odio" },
                    { 9, 3, "Porta dictumst volutpat" },
                    { 10, 1, "Tortor tempor ligula" },
                    { 11, 0, "Sollicitudin placerat neque" },
                    { 12, 3, "Id aptent vehicula" },
                    { 13, 1, "Imperdiet adipiscing porttitor" },
                    { 14, 0, "Rutrum porttitor maecenas" },
                    { 15, 2, "Vulputate rhoncus magna" },
                    { 16, 3, "Sem sodales aenean" },
                    { 17, 1, "Volutpat placerat arcu" },
                    { 18, 3, "Quis venenatis lectus" },
                    { 19, 0, "Nulla etiam rhoncus" },
                    { 20, 1, "Eleifend amet nulla" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AboutMe", "AccessFailedCount", "Age", "ConcurrencyStamp", "DonationStars", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "207cc129-c8c5-4979-b7e2-b50a7b281bfc", "Sociosqu malesuada duis id pharetra mattis vestibulum eros litora condimentum", 0, 31, "fbf3c54a-9021-4287-b3af-87b5aff7a82c", 0, "buitrunghieu_t65@hus.edu.vn", true, "Jimmy", "Carter", false, null, "BUITRUNGHIEU_T65@HUS.EDU.VN", "JIMMYCARTER", "AQAAAAEAACcQAAAAEGzukAYkWWhmvS3KPCURo4tHAdQFQLAPE8xclZCl9xgcRicaQWJ9t35L555Ozvr/lA==", null, false, "294686ca-6a56-47b0-8806-377ec53730b9", false, "jimmycarter" },
                    { "896f381a-107f-4451-bcec-41e655640a49", "Mattis posuere non nec ullamcorper nulla ante ipsum vel interdum", 0, 24, "36ff18bd-f746-41d2-a0d3-899521001591", 0, "buihieu.211202@gmail.com", true, "Ricardo", "MyLord", false, null, "BUIHIEU.211202@GMAIL.COM", "RICARDO", "AQAAAAEAACcQAAAAEE26cMEN4MkwDed/ap5yrtzwED87IFyI08qvA6fWA+s5nTiH2NtmYIQlULgl1RDi6A==", null, false, "01855741-0623-4385-a459-2b1a69ba8331", false, "ricardo" },
                    { "a8959e1f-6d3a-4423-91b7-6358bd639bf7", "Vulputate volutpat sagittis nunc nam iaculis bibendum mauris eleifend dictum", 0, 31, "aa00f591-eccf-4c06-9bc8-17763cecb1d7", 0, "trunghieusuper@gmail.com", true, "Logan", "HieuBui", false, null, "TRUNGHIEUSUPER@GMAIL.COM", "LOGANHIEUBUI", "AQAAAAEAACcQAAAAEJ2ilb+r9AWlvvX/MOUAnc2uR5aoPz4ZGXYBNrwpY/4tQQFcGHk+r+bf/yDdvsFn8w==", null, false, "7c253a90-6e85-4962-85c5-59ea7c9e4c32", false, "loganhieubui" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "CategoryId", "Modified", "Post Content", "Posted On", "Published", "Rate Count", "Short Description", "Title", "Total Rate", "UrlSlug", "View Count" },
                values: new object[,]
                {
                    { 1, "207cc129-c8c5-4979-b7e2-b50a7b281bfc", 7, null, "Pulvinar, suspendisse vitae, interdum, ante, vel dictumst adipiscing tellus, eu, vivamus sem. Curabitur sed semper mollis elit, egestas amet, proin ultrices, risus. Mi, eros, phasellus consectetur commodo, pharetra lacus non quam quisque placerat nullam interdum, odio, venenatis tristique. In, lacinia, elit neque, tortor metus mauris per vitae risus nulla praesent massa, quis nibh turpis rhoncus, dolor.", new DateTime(2024, 3, 28, 18, 29, 50, 551, DateTimeKind.Local).AddTicks(2284), true, 27, "Lectus mattis placerat quam interdum urna purus suspendisse turpis nisi amet habitasse hendrerit", "Auctor lectus consequat", 167, "cursus-eleifend-magna", 108 },
                    { 2, "207cc129-c8c5-4979-b7e2-b50a7b281bfc", 8, null, "Facilisis nisi, ultrices quam, vivamus suscipit felis varius, laoreet turpis sem, mollis convallis molestie. Ex, aptent vulputate ligula maximus tortor vel, habitasse libero elit tempor, eu, aliquam porttitor, proin fringilla, tortor, venenatis. Id sit porta, praesent leo massa, sed sed, aliquam sodales sapien dui. Ligula sapien magna taciti eros, facilisis nec, ac, eu, metus phasellus turpis quisque massa aliquam nam quis, elementum auctor. Hendrerit rutrum laoreet, eu tellus, ipsum ultricies praesent volutpat, pretium nulla, taciti. Pellentesque venenatis vehicula maximus dignissim porttitor, justo curabitur interdum eleifend, litora sodales vestibulum, consectetur etiam ultricies magna.", new DateTime(2024, 3, 27, 14, 43, 50, 551, DateTimeKind.Local).AddTicks(4812), true, 24, "Sem orci scelerisque consectetur mattis ut interdum vestibulum in mi odio erat euismod", "Suspendisse dictum ad", 195, "nisi-ex-integer", 244 },
                    { 3, "a8959e1f-6d3a-4423-91b7-6358bd639bf7", 6, null, "Nunc ex lectus, nullam porta cursus purus vulputate posuere fermentum lobortis tempor lorem, nunc. Porta mattis, nullam blandit, nulla, faucibus leo, varius, non, phasellus rhoncus. Ac, per auctor, laoreet massa facilisis efficitur suscipit in, dolor adipiscing eu, mollis eros, urna, blandit. Ad viverra metus tempor ultrices lorem, laoreet, placerat, orci, neque leo, sagittis vel mi, mattis, consequat sed. Adipiscing pulvinar eu lorem pulvinar, enim, neque, posuere egestas tellus.", new DateTime(2024, 3, 27, 14, 48, 50, 551, DateTimeKind.Local).AddTicks(6814), true, 21, "Fusce commodo tristique praesent pharetra lorem fames scelerisque justo phasellus sed pellentesque dui", "Maecenas euismod dictumst", 283, "cras-libero-adipiscing", 142 },
                    { 4, "207cc129-c8c5-4979-b7e2-b50a7b281bfc", 8, null, "Dictumst dictum rutrum himenaeos laoreet, neque, vel, eleifend torquent metus vel nec aptent tincidunt habitasse. Ut aliquam maecenas cursus, sollicitudin eros feugiat habitasse vel morbi quam, interdum gravida rhoncus, bibendum, praesent sem adipiscing. Porta, consectetur sed, fames vel hendrerit pellentesque primis laoreet nisi auctor massa, facilisis non, orci, aliquet per rhoncus, ornare. Sapien consectetur dui, placerat, eros, interdum efficitur leo, elementum massa condimentum arcu laoreet, vitae, tellus. Diam orci, convallis in, posuere varius ultrices porttitor, suscipit arcu, lectus, non.", new DateTime(2024, 3, 28, 9, 29, 50, 551, DateTimeKind.Local).AddTicks(9452), true, 20, "Donec ex laoreet arcu cursus quisque ullamcorper sodales mauris aenean dolor lacinia ex", "Inceptos commodo placerat", 147, "at-primis-tortor", 299 },
                    { 5, "a8959e1f-6d3a-4423-91b7-6358bd639bf7", 5, null, "Morbi ligula, finibus rutrum amet, ornare per finibus, in, habitasse cursus, lorem arcu, in ex feugiat, sollicitudin placerat, augue. Enim sit interdum, et, libero vestibulum quis, pharetra euismod erat semper ac finibus, porttitor, hac lorem. Hac consectetur turpis sit eleifend sed ac maximus cras ante, commodo. Sociosqu iaculis pharetra interdum, eros, ultricies mi, feugiat vivamus gravida metus malesuada porttitor erat habitasse vulputate arcu. Mi, in, bibendum ante, dui nisi, et, ullamcorper ligula elit, tortor, enim ac.", new DateTime(2024, 3, 27, 9, 41, 50, 552, DateTimeKind.Local).AddTicks(2106), true, 29, "Finibus lacinia maecenas suscipit sit eros duis diam libero faucibus feugiat vestibulum ornare", "Posuere non iaculis", 190, "viverra-nec-amet", 284 },
                    { 6, "207cc129-c8c5-4979-b7e2-b50a7b281bfc", 9, null, "Torquent dui condimentum quis class ac justo hac euismod, per sem, sagittis, dolor nibh tempor, porta. Pharetra mattis, platea a leo quis, suspendisse augue vehicula vestibulum, ligula, feugiat nullam nec. Commodo quis sodales tellus, eget placerat bibendum, tincidunt ut interdum. Finibus varius varius, nam nunc, bibendum, massa facilisis mattis pulvinar, nibh, porttitor quisque placerat, ante, lorem. Est vulputate hendrerit ante elit primis nibh, maecenas quam aliquam phasellus maximus.", new DateTime(2024, 4, 1, 23, 55, 50, 552, DateTimeKind.Local).AddTicks(4717), true, 16, "Malesuada maximus interdum congue tincidunt quam amet eros nostra pharetra taciti erat orci", "In magna leo", 108, "pretium-ex-vestibulum", 174 },
                    { 7, "a8959e1f-6d3a-4423-91b7-6358bd639bf7", 9, null, "Himenaeos hac accumsan est fringilla mattis, ultrices, nam eleifend, lectus, dui feugiat vestibulum, diam mi, a, porta, erat fusce. Placerat, pulvinar, rutrum eleifend, vestibulum, porta, egestas in, conubia nulla, finibus, tempor lorem, eu sapien malesuada. Facilisis commodo, lorem, nullam ornare cras amet, sit condimentum pulvinar. Tellus dapibus fringilla luctus in vitae, amet ad nulla habitasse laoreet. Tempor tellus, primis duis ligula, fringilla eleifend cursus fames quam, porta torquent eu, volutpat, fermentum est imperdiet sed.", new DateTime(2024, 3, 27, 10, 35, 50, 552, DateTimeKind.Local).AddTicks(7459), true, 17, "Elit sodales ad placerat nullam pulvinar mauris eleifend quam eros euismod mattis sagittis", "Integer urna aliquam", 271, "donec-tellus-quis", 250 },
                    { 8, "207cc129-c8c5-4979-b7e2-b50a7b281bfc", 7, null, "Sollicitudin auctor lectus, massa, blandit, praesent risus ultrices, vel lorem, sapien pellentesque nunc nibh. Arcu vel, nisi adipiscing nullam fermentum mauris feugiat felis vel luctus orci. Vulputate lorem consequat ante, lacus sed placerat lectus, sociosqu platea aenean massa maecenas quam, taciti semper. Quis, convallis orci, praesent curabitur id, tempor taciti platea integer lacinia.", new DateTime(2024, 3, 30, 12, 44, 50, 552, DateTimeKind.Local).AddTicks(9737), true, 20, "Tempus per fringilla faucibus tincidunt fames molestie adipiscing mauris arcu duis fusce dapibus", "Ligula proin augue", 112, "aenean-mauris-cras", 173 },
                    { 9, "a8959e1f-6d3a-4423-91b7-6358bd639bf7", 8, null, "Maximus fermentum vitae in sodales orci, odio nisi, diam vestibulum imperdiet sed, enim ipsum. Mauris commodo, sociosqu fusce arcu, vel, scelerisque ac vel quis leo lorem, id justo. Platea ornare eu felis quisque commodo, auctor, mi, vestibulum, eros vitae. Justo sem gravida accumsan vestibulum, placerat, nunc congue arcu hendrerit mattis, phasellus. Varius, etiam est porta, morbi amet fermentum imperdiet iaculis ex, venenatis.", new DateTime(2024, 4, 1, 21, 21, 50, 553, DateTimeKind.Local).AddTicks(1745), true, 10, "Habitasse facilisis duis fringilla sit risus sagittis velit sem dignissim viverra dolor suscipit", "Magna rhoncus tortor", 269, "euismod-ligula-phasellus", 185 },
                    { 10, "207cc129-c8c5-4979-b7e2-b50a7b281bfc", 7, null, "Ullamcorper volutpat gravida elementum in, tempor duis varius, laoreet, cras elit phasellus nunc venenatis ut tincidunt lectus. Laoreet porta magna non luctus nulla pharetra tempor, auctor, orci, amet, hac ex. Varius facilisis mauris, tortor euismod, est enim, turpis morbi sem, id, odio, risus eu, lectus, praesent. Imperdiet volutpat, fringilla, varius massa platea accumsan convallis orci, fringilla sodales purus dolor phasellus pretium ex. Non praesent nisi nunc ultrices, semper posuere vehicula molestie arcu interdum, conubia enim, eu. Erat, duis ornare amet ultricies mollis congue vitae, nisi laoreet, a, et. Metus vitae justo dapibus vitae, consequat nibh venenatis finibus luctus, interdum ante vulputate nunc nam congue proin ad id.", new DateTime(2024, 3, 31, 23, 37, 50, 553, DateTimeKind.Local).AddTicks(4481), true, 19, "Arcu erat sagittis leo porta cursus finibus sit curabitur ligula orci commodo placerat", "Donec ipsum placerat", 260, "conubia-congue-orci", 279 },
                    { 11, "a8959e1f-6d3a-4423-91b7-6358bd639bf7", 6, null, "Posuere cras ex molestie arcu, risus eu, fermentum sed dui tortor neque. Per urna, leo praesent bibendum, bibendum blandit inceptos vehicula viverra nam. Nec, amet ullamcorper arcu sapien faucibus ligula, purus etiam non eu. Volutpat, mollis nisl auctor, nulla, convallis enim malesuada nostra, maecenas cras aenean ex, velit non nisi. Sit lacinia fringilla semper congue himenaeos interdum proin pretium maecenas tempor.", new DateTime(2024, 3, 25, 19, 22, 50, 553, DateTimeKind.Local).AddTicks(7136), true, 23, "Urna nunc morbi etiam lectus finibus consectetur ultricies nulla feugiat enim sociosqu tortor", "Ultricies massa et", 223, "tortor-ornare-malesuada", 205 },
                    { 12, "207cc129-c8c5-4979-b7e2-b50a7b281bfc", 7, null, "Est in, auctor, etiam feugiat, nec, nulla, aptent orci feugiat hendrerit ullamcorper vehicula. Suscipit quis, euismod, porttitor turpis lectus, porta nibh, himenaeos in, quam, at non vel, velit commodo fames. Ultrices commodo, pellentesque porttitor et, nisi dolor, nam rhoncus quam non aliquet condimentum sed blandit. Nam dolor, mauris, massa blandit eleifend posuere commodo, pulvinar, luctus, tellus, lectus. Ultrices, neque interdum, luctus, commodo ornare pharetra faucibus imperdiet tristique lacus dui, rhoncus justo. Risus interdum, dictum ultricies rutrum nisi, odio, curabitur odio ut class amet, velit lacinia.", new DateTime(2024, 3, 27, 19, 10, 50, 554, DateTimeKind.Local).AddTicks(181), true, 19, "Lacus a enim taciti pharetra dictumst elit dignissim sagittis accumsan pretium commodo mollis", "Nibh tempus nec", 161, "per-cras-elementum", 271 },
                    { 13, "a8959e1f-6d3a-4423-91b7-6358bd639bf7", 1, null, "Sodales porta urna, molestie laoreet cras non, neque, sem lacus tempor ex, rhoncus, id, cursus sit tempus. Orci, ad faucibus eros, est nisl himenaeos ultricies nibh, libero feugiat aliquet blandit porta, ut. Facilisis quisque elit, pulvinar, in, lectus feugiat mattis, nisi, lectus, dictumst sodales litora luctus, orci. Pulvinar hendrerit fusce euismod, pulvinar, rhoncus vitae, ex vestibulum, eu inceptos eros magna. Euismod sociosqu venenatis maecenas tempus sapien tincidunt egestas mollis varius, quam, duis bibendum a lorem.", new DateTime(2024, 3, 31, 3, 18, 50, 554, DateTimeKind.Local).AddTicks(3006), true, 11, "Et euismod suscipit scelerisque vestibulum odio tempor consequat eu at id nulla fusce", "Non neque pellentesque", 219, "facilisis-nibh-dui", 219 },
                    { 14, "207cc129-c8c5-4979-b7e2-b50a7b281bfc", 7, null, "Torquent hac ornare ultricies fringilla, himenaeos massa, nec, erat semper odio, commodo, tempus ligula, proin conubia accumsan. Auctor ante iaculis posuere tellus, nostra, rutrum facilisis vitae, venenatis enim sollicitudin elit. Urna, primis ex blandit, massa elit, proin rhoncus, a placerat. Magna, purus primis in fames quis, rutrum sem, ante, adipiscing. Consectetur eget facilisis id suspendisse laoreet placerat, eu mauris, accumsan. Dui nisl sollicitudin laoreet, nostra, taciti nunc eleifend, blandit, fames ante, semper posuere.", new DateTime(2024, 4, 3, 15, 26, 50, 554, DateTimeKind.Local).AddTicks(5984), true, 23, "Porta platea mauris amet dolor mi nullam massa risus arcu eros id neque", "Nulla ligula dictum", 195, "ornare-mauris-phasellus", 216 },
                    { 15, "a8959e1f-6d3a-4423-91b7-6358bd639bf7", 4, null, "Feugiat, a urna, volutpat, tempus primis faucibus conubia pulvinar ac nisl congue, leo, velit suscipit quam. Et, enim, augue quam, bibendum risus vitae placerat finibus ultricies torquent laoreet litora taciti quisque sit cras ligula. Et, lacinia ornare convallis orci faucibus ipsum torquent ultrices, vel, feugiat, lectus, lobortis adipiscing nisl. Condimentum tellus, mi inceptos ac tellus sodales sapien est volutpat lacinia, fringilla. Ut sem, congue, odio, lorem class dui, consectetur congue tempor, sagittis, augue.", new DateTime(2024, 3, 27, 3, 53, 50, 554, DateTimeKind.Local).AddTicks(7948), true, 16, "Scelerisque euismod finibus ultrices primis ex amet porta luctus aenean commodo eros laoreet", "Placerat quam torquent", 210, "lorem-massa-maecenas", 167 },
                    { 16, "207cc129-c8c5-4979-b7e2-b50a7b281bfc", 7, null, "Aptent nostra, nisi a lorem morbi sed tempor, et euismod, volutpat rhoncus, dictumst massa, orci, ex, auctor, ornare vivamus. Suspendisse varius litora viverra consequat finibus vehicula eu, cras lobortis nisi tempus condimentum habitasse ad. Dignissim nisl ultricies fermentum nostra, congue nulla duis sed, at ullamcorper tellus, in quam, posuere vulputate nec. Amet mi, scelerisque eleifend etiam lacus vivamus diam metus proin ullamcorper vulputate orci, elit tempor, nunc in, consequat porttitor.", new DateTime(2024, 4, 1, 9, 48, 50, 554, DateTimeKind.Local).AddTicks(9741), true, 12, "Varius sociosqu quam eu feugiat enim arcu eget convallis fermentum amet lectus erat", "Placerat eleifend condimentum", 252, "nisi-nostra-id", 159 },
                    { 17, "a8959e1f-6d3a-4423-91b7-6358bd639bf7", 9, null, "Massa, erat, lacus molestie curabitur torquent nunc, proin neque eget sodales placerat id cras dignissim consectetur. Mauris orci ante, dolor nam odio, velit sollicitudin condimentum ac, sagittis vel, congue at, feugiat fermentum quam. Eros maximus mauris, aliquet porttitor aenean ad taciti id dolor, porttitor, arcu tempus quam. Phasellus laoreet nulla, ultricies auctor, purus egestas interdum, metus hac ornare etiam proin praesent quis quisque ultrices donec ipsum. Finibus, lacinia non eros, pharetra mollis ornare nunc donec ligula amet, tincidunt lobortis justo est ante. Ex nostra, id mauris ipsum metus est purus duis eros. At commodo euismod, sodales mattis non habitasse quam, leo arcu, tempor.", new DateTime(2024, 3, 26, 9, 54, 50, 555, DateTimeKind.Local).AddTicks(2213), true, 19, "Porta convallis luctus ad sodales aliquam dui tempor at et eros integer finibus", "Condimentum tempus neque", 219, "torquent-mauris-lacus", 265 },
                    { 18, "207cc129-c8c5-4979-b7e2-b50a7b281bfc", 6, null, "Neque eget feugiat ligula a, amet, porta fermentum mauris nunc commodo lorem pharetra luctus, urna mi, suspendisse porta. Accumsan dolor sed dolor, ante, enim nam aptent semper dapibus varius, arcu. Pharetra ac, consectetur magna, luctus vel, nisi eros velit amet, nisl ligula, mollis. Nulla diam scelerisque vestibulum, sem, leo finibus convallis feugiat, ultrices, placerat.", new DateTime(2024, 3, 29, 7, 28, 50, 555, DateTimeKind.Local).AddTicks(4156), true, 10, "Diam non ultricies vivamus ac ultrices nulla sagittis pulvinar velit ex euismod tellus", "Ante eget litora", 163, "massa-tristique-et", 175 },
                    { 19, "207cc129-c8c5-4979-b7e2-b50a7b281bfc", 2, null, "Lacinia nulla mauris class ligula cursus, non, elit amet suscipit quam, ultricies pellentesque sagittis, sagittis tellus, efficitur a euismod. A, quam semper nisi conubia bibendum nibh bibendum, erat, mauris, posuere, sem dui, fermentum taciti per nunc duis. Augue nulla fringilla, odio auctor, inceptos feugiat nulla, libero pellentesque in, mattis quam aenean quisque. Metus leo, aenean viverra erat bibendum, ad amet, hac sit placerat, lorem rutrum sem primis dolor duis quis.", new DateTime(2024, 3, 30, 15, 39, 50, 555, DateTimeKind.Local).AddTicks(6523), true, 21, "Praesent vestibulum euismod id mauris efficitur aptent nec litora felis etiam venenatis vitae", "Dignissim neque suspendisse", 108, "iaculis-taciti-class", 186 },
                    { 20, "a8959e1f-6d3a-4423-91b7-6358bd639bf7", 6, null, "A, placerat urna, id, vulputate molestie morbi mollis sem, integer. Volutpat, sodales tempor suspendisse pulvinar, est ornare pulvinar pharetra mi efficitur amet leo, eget rhoncus enim, fermentum taciti quam. Elementum bibendum, ornare varius, sed, finibus at condimentum non lectus. Ac, nibh, metus massa integer commodo sem, felis congue fringilla, accumsan torquent vitae. Mattis, nec, ac, fames a, consequat euismod, semper erat et sit et. Tristique vitae, at at, eget massa pretium mollis rutrum dui, vel erat dictumst urna, lectus, massa, mattis.", new DateTime(2024, 3, 30, 20, 40, 50, 555, DateTimeKind.Local).AddTicks(9443), true, 19, "Pulvinar conubia placerat erat nec luctus elit sem habitasse sit ex nibh efficitur", "Non class lectus", 236, "sagittis-sapien-at", 230 },
                    { 21, "207cc129-c8c5-4979-b7e2-b50a7b281bfc", 5, null, "Massa, est posuere, eget eleifend, semper luctus, orci, phasellus sapien enim sit. Convallis commodo leo massa velit vitae erat eleifend, magna, lacinia, sem, mauris donec ligula, porta. Elit ex, aliquam augue ligula, condimentum quam dui, dolor, quam, sagittis erat at, orci litora eros blandit himenaeos fusce. Auctor, ac laoreet a, non, accumsan et, sit morbi consectetur magna lacus ligula tempor volutpat. Interdum ultrices, bibendum, proin elementum in imperdiet tortor, sem odio.", new DateTime(2024, 4, 3, 1, 58, 50, 556, DateTimeKind.Local).AddTicks(2417), true, 10, "Diam ultrices arcu ornare conubia vulputate molestie scelerisque in per libero congue leo", "Ex sit quam", 280, "ut-lorem-lacinia", 187 },
                    { 22, "207cc129-c8c5-4979-b7e2-b50a7b281bfc", 2, null, "Augue bibendum gravida dictumst litora consectetur ultrices, curabitur feugiat neque dolor, lectus malesuada nulla accumsan. Amet eget molestie conubia eros, ante pulvinar, gravida sollicitudin elementum sit sapien et. Habitasse tellus, ultrices tristique quis, himenaeos morbi feugiat, lorem arcu eleifend ante, diam lacinia, feugiat malesuada sodales vel, iaculis. Vel, etiam at, donec venenatis nullam pulvinar ac, ante, quam laoreet, vitae posuere, ligula sapien aliquet. Sed, taciti molestie proin auctor, ultrices maecenas primis varius, libero auctor nibh, velit ex sem, aliquam lacinia. Tellus, varius, vel, lectus ultrices eu, auctor nulla pulvinar, felis nibh ornare lobortis.", new DateTime(2024, 4, 2, 3, 26, 50, 556, DateTimeKind.Local).AddTicks(5503), true, 21, "Dolor mi metus hac nulla nec varius ad felis suspendisse urna fringilla amet", "Mi conubia consectetur", 213, "finibus-urna-varius", 281 },
                    { 23, "a8959e1f-6d3a-4423-91b7-6358bd639bf7", 2, null, "Vulputate himenaeos eu, ut nunc, dui pulvinar et, congue, aenean non, habitasse. Turpis sem, cursus proin mauris sociosqu mi ex hendrerit mattis, rhoncus. Laoreet vel, id, leo, phasellus donec tempus aliquam nunc augue placerat, nibh, metus sem. Dolor, taciti sem, nulla, dictumst ultricies purus primis conubia eu.", new DateTime(2024, 3, 25, 2, 10, 50, 556, DateTimeKind.Local).AddTicks(7838), true, 13, "Eleifend erat massa sem praesent nibh ac lacus elementum sociosqu molestie ornare congue", "Pulvinar amet sem", 214, "sed-cursus-curabitur", 289 },
                    { 24, "207cc129-c8c5-4979-b7e2-b50a7b281bfc", 2, null, "Pulvinar efficitur nunc mi lectus imperdiet pellentesque malesuada cursus, class tortor, dapibus fusce tempus proin lectus. Pharetra tristique cras at, a, dui etiam massa egestas nunc, ex, sodales sagittis. Suscipit mattis primis leo platea vestibulum, erat mauris amet sed, urna tincidunt non pharetra urna, felis lacinia torquent. Nostra, ac, maximus finibus, finibus velit odio, platea volutpat, dolor dictum. Viverra ac efficitur varius finibus nulla imperdiet feugiat tortor inceptos finibus, iaculis accumsan magna, dignissim varius. Sit non et tortor adipiscing nam nunc dui, varius nostra, placerat. Sem, sed tempor, ac rhoncus dui nisi mi lorem, nunc finibus elementum.", new DateTime(2024, 3, 31, 14, 46, 50, 557, DateTimeKind.Local).AddTicks(1247), true, 24, "Metus enim ante nisl eros fusce ultrices elit consectetur finibus vitae ultricies efficitur", "Nisl dignissim vestibulum", 156, "fringilla-ut-porta", 229 },
                    { 25, "207cc129-c8c5-4979-b7e2-b50a7b281bfc", 5, null, "Faucibus feugiat laoreet lacinia, lorem placerat rhoncus in, aenean mollis orci, purus vel, conubia ipsum. Class erat enim magna ex, himenaeos etiam ipsum rutrum lacinia eget pulvinar, a, feugiat. Pellentesque et, nunc, per himenaeos eu lacus tempor lobortis eleifend cras. Efficitur vivamus in, bibendum nisi, ex donec quam, libero bibendum, finibus ut congue. Nibh euismod porta lectus torquent suscipit egestas elit sapien pretium quam, luctus, primis quam porta, in at semper tortor. Lacinia nisi massa hac sociosqu ligula dictumst feugiat mi sagittis, pharetra nunc porttitor torquent proin rhoncus, neque vel. Neque, cursus, ex, est hendrerit lacus pulvinar nam luctus, nulla, elementum.", new DateTime(2024, 3, 25, 15, 11, 50, 557, DateTimeKind.Local).AddTicks(4608), true, 17, "Nulla ligula elit nostra viverra massa magna ac nisl ex hac eleifend leo", "Justo himenaeos sit", 186, "cursus-orci-donec", 158 },
                    { 26, "207cc129-c8c5-4979-b7e2-b50a7b281bfc", 1, null, "Etiam quisque fames imperdiet at, vestibulum, molestie sociosqu lacinia nisi vel sit. Fringilla, commodo, mattis, praesent consequat urna, dolor nibh vestibulum, mattis. Purus phasellus eros dictum porttitor, praesent sem, ad ullamcorper conubia congue, lorem, lobortis laoreet porttitor fames feugiat nec, nam. Integer duis nullam ex, ligula condimentum rhoncus amet placerat, dapibus curabitur nibh, magna, placerat volutpat. Elit erat, purus porttitor, congue sed, varius, per malesuada erat in, nisl odio ultrices, fermentum tellus.", new DateTime(2024, 3, 29, 10, 7, 50, 557, DateTimeKind.Local).AddTicks(7188), true, 27, "Maecenas bibendum sociosqu eu eget congue litora ligula posuere donec dolor metus nunc", "Magna pulvinar ipsum", 232, "felis-massa-dui", 293 },
                    { 27, "207cc129-c8c5-4979-b7e2-b50a7b281bfc", 9, null, "Congue, suscipit ultricies varius, a vel feugiat, ligula, neque, eros, euismod neque enim et, sem, rhoncus duis pulvinar. Pulvinar a, morbi orci ac tellus vivamus lorem, urna, arcu, ac, blandit, himenaeos turpis odio, lacinia, libero at nibh. Sit id sed eros ornare mi maecenas ligula semper mauris, nulla, aenean conubia venenatis ut. Conubia mollis sem, nisi amet justo ac vitae, commodo et, venenatis.", new DateTime(2024, 3, 30, 15, 6, 50, 557, DateTimeKind.Local).AddTicks(9518), true, 24, "Congue amet tellus vitae aliquet varius nisi consectetur dui curabitur id rhoncus nullam", "Eu eleifend commodo", 165, "risus-ex-congue", 125 },
                    { 28, "a8959e1f-6d3a-4423-91b7-6358bd639bf7", 2, null, "Tellus, erat, condimentum commodo vel, auctor posuere, cursus malesuada auctor, mauris, varius, rhoncus, dignissim nullam dui eleifend lobortis porta. Sagittis, dapibus platea interdum, placerat, fusce rhoncus, diam vel suscipit luctus ipsum risus. Massa, neque, rutrum litora vivamus semper ex sed vestibulum justo mattis, himenaeos lectus aenean. Sed pretium metus nisi, lacus proin commodo fermentum consequat cras condimentum magna pharetra. Augue dolor, arcu placerat pulvinar duis nec, congue, sit maecenas euismod, vitae proin rhoncus. Libero integer ornare porttitor, quam, viverra ante diam cursus, tellus dictum lectus, fames arcu tortor, etiam elit.", new DateTime(2024, 3, 26, 4, 58, 50, 558, DateTimeKind.Local).AddTicks(2528), true, 25, "Laoreet dui tempus luctus posuere porttitor tellus porta vestibulum eu arcu vivamus massa", "Neque tincidunt congue", 109, "enim-varius-pretium", 117 },
                    { 29, "a8959e1f-6d3a-4423-91b7-6358bd639bf7", 6, null, "Quam volutpat gravida blandit hac eleifend, consectetur mollis mi, ullamcorper interdum, class posuere id aptent ultrices neque. Ex, ornare tellus cursus, faucibus posuere volutpat, congue ultrices, nisi, curabitur odio turpis inceptos. Class luctus torquent morbi dictumst bibendum ipsum porttitor, malesuada tellus. Vivamus ligula, libero tortor, sed bibendum nibh, mattis nunc ut proin integer sociosqu diam nibh auctor justo. Urna, molestie magna non, et massa dui id, ante condimentum erat platea egestas nulla, at, iaculis nisi, est orci. Cursus phasellus adipiscing justo maecenas suspendisse lectus, hac blandit, eros.", new DateTime(2024, 4, 2, 18, 11, 50, 558, DateTimeKind.Local).AddTicks(5722), true, 28, "Fames at mauris dignissim feugiat iaculis ante rhoncus sed elementum phasellus dapibus vitae", "Varius aliquet at", 288, "molestie-aenean-sem", 126 },
                    { 30, "207cc129-c8c5-4979-b7e2-b50a7b281bfc", 3, null, "Semper volutpat, volutpat dignissim commodo ad aliquam erat, inceptos iaculis platea nisl laoreet, vitae, sodales phasellus accumsan a. Laoreet velit libero feugiat, efficitur placerat inceptos tortor, sem, praesent nunc mattis. Luctus, ac, magna scelerisque rhoncus auctor, litora quam, hendrerit eu. Ex congue arcu, tempor elementum vel, nec habitasse taciti nisl sagittis, ac non ligula. Maecenas habitasse imperdiet nulla, torquent hac convallis orci, sit lacinia. Et vel, euismod, duis neque, ultrices, sagittis, amet taciti mi, posuere, vel vehicula eros, mattis, dolor.", new DateTime(2024, 3, 26, 19, 48, 50, 558, DateTimeKind.Local).AddTicks(8691), true, 22, "Id porta morbi odio ultrices duis nunc varius bibendum consectetur orci lectus ac", "Id luctus nisi", 107, "blandit-ligula-faucibus", 291 },
                    { 31, "207cc129-c8c5-4979-b7e2-b50a7b281bfc", 5, null, "Eros elit consectetur malesuada orci blandit, luctus, et vitae, mi eleifend tempor, in, cursus, nec, laoreet, mollis. Consequat elit, lacus pulvinar, urna a, id ex sagittis tortor quis interdum justo faucibus porttitor tristique in, quisque. Enim pulvinar, feugiat neque commodo, urna, porta, massa lobortis sollicitudin a, nec nisl. Luctus quam, varius ipsum rhoncus, et, cursus, sagittis aptent dolor, in cursus.", new DateTime(2024, 4, 1, 23, 58, 50, 559, DateTimeKind.Local).AddTicks(1170), true, 21, "Pulvinar proin torquent posuere accumsan porta cras odio metus mattis erat fusce congue", "At nisl lectus", 152, "eros-volutpat-eu", 134 },
                    { 32, "207cc129-c8c5-4979-b7e2-b50a7b281bfc", 7, null, "Finibus dignissim blandit mattis laoreet, velit fames dui porta vitae, non, libero fringilla, fringilla faucibus. Praesent posuere, dolor amet feugiat, scelerisque massa hac lorem, eleifend phasellus enim, malesuada euismod elementum. Porttitor quam massa per sagittis, accumsan porta, malesuada fringilla tellus ad eleifend varius lectus. Ex a conubia in ornare euismod augue amet, lectus, varius eleifend orci finibus, sociosqu. Fermentum porttitor, ornare eget lobortis lacus accumsan blandit, interdum, auctor, posuere himenaeos congue primis ex, mauris. Vehicula arcu in, etiam rhoncus, vestibulum eget nisi sit lobortis. Vestibulum sed quisque lacinia neque, a, elit, risus litora dui nunc.", new DateTime(2024, 3, 31, 18, 25, 50, 559, DateTimeKind.Local).AddTicks(4499), true, 19, "Vivamus nisi etiam porta fringilla in at posuere orci semper fusce porttitor nibh", "Consequat per sociosqu", 209, "taciti-dignissim-sociosqu", 196 },
                    { 33, "a8959e1f-6d3a-4423-91b7-6358bd639bf7", 3, null, "Porta, iaculis conubia vel eros, felis placerat, luctus hac sed, amet, placerat massa, sem praesent vestibulum, enim. Nisl interdum, tempus fringilla, tempor primis id enim, maximus porta, et laoreet euismod bibendum, purus lectus. Quis, id eleifend, ante nisi, quis sagittis, placerat, urna, tortor, posuere, ligula, et, sem, primis a imperdiet varius, euismod. Eros finibus, placerat id fusce dictumst elit, tristique erat mi, accumsan scelerisque.", new DateTime(2024, 3, 30, 7, 9, 50, 559, DateTimeKind.Local).AddTicks(6913), true, 24, "Imperdiet tristique litora interdum vestibulum donec a platea tempor sociosqu nibh metus efficitur", "Eleifend himenaeos justo", 130, "mi-eleifend-vivamus", 110 },
                    { 34, "a8959e1f-6d3a-4423-91b7-6358bd639bf7", 6, null, "Accumsan lorem, dui, quis metus augue commodo, id arcu, sem, blandit, est dictum massa ut. Gravida lobortis rhoncus, et, mollis placerat orci luctus tempus nisi, ultricies eleifend, mauris, non, lectus. Vel, fusce primis et, dui, blandit nec, ligula sed, convallis. Vivamus eget sit purus dui curabitur pulvinar ultrices, tellus commodo ullamcorper quis lorem, neque sapien venenatis nibh, felis maecenas. Vestibulum, enim lacinia blandit libero placerat sem, pretium odio, feugiat auctor, euismod. Molestie eu nec, duis mauris, finibus nisi, lorem nibh orci in, elementum venenatis porttitor. Ligula, id pharetra feugiat odio vel phasellus nam nisl rutrum ornare facilisis nunc lectus.", new DateTime(2024, 4, 2, 10, 34, 50, 560, DateTimeKind.Local).AddTicks(266), true, 17, "Vivamus erat malesuada commodo sodales tempor sem porttitor varius lorem semper neque cursus", "Cras nec ac", 285, "vestibulum-nisl-nec", 288 },
                    { 35, "207cc129-c8c5-4979-b7e2-b50a7b281bfc", 2, null, "Metus urna, nec, torquent bibendum, pretium nisi sociosqu efficitur laoreet tempor, leo, amet, quam, id. Nisl nostra, curabitur euismod, luctus, orci, litora etiam class ullamcorper taciti laoreet. Luctus velit mauris, elementum tortor, dolor, dolor cursus, eu consequat erat, morbi turpis nibh sociosqu porttitor. Lobortis leo vivamus tristique urna, dolor ligula, taciti posuere ad porttitor, quis egestas. Rutrum commodo, sit congue nostra, sem, quis, vehicula volutpat, eget nunc, quam sagittis scelerisque blandit rhoncus, euismod, laoreet adipiscing.", new DateTime(2024, 3, 29, 7, 38, 50, 560, DateTimeKind.Local).AddTicks(2901), true, 29, "Lacus amet ex non nullam finibus nec cras quam mauris nam mauris torquent", "Aliquam ipsum congue", 178, "laoreet-class-hendrerit", 270 },
                    { 36, "a8959e1f-6d3a-4423-91b7-6358bd639bf7", 3, null, "Nostra, sagittis aliquet neque, sed dignissim vestibulum, fames varius, finibus, pulvinar, pulvinar platea hac sem primis efficitur justo tempor. Malesuada commodo lectus orci, quis, diam odio, at vulputate rhoncus, scelerisque sagittis sed, tempus. Aenean tempor, iaculis id, dapibus justo himenaeos orci, vel, massa, feugiat, euismod, a, maecenas habitasse fames dignissim blandit velit. Nulla, faucibus purus luctus, torquent a, id interdum, imperdiet lacus porttitor nunc nullam laoreet ut.", new DateTime(2024, 3, 31, 1, 30, 50, 560, DateTimeKind.Local).AddTicks(5345), true, 28, "Ullamcorper neque interdum tincidunt conubia congue ante consequat purus sollicitudin vestibulum velit turpis", "Taciti suscipit vel", 224, "luctus-bibendum-tortor", 223 },
                    { 37, "207cc129-c8c5-4979-b7e2-b50a7b281bfc", 7, null, "Sociosqu feugiat, tristique orci turpis laoreet nunc, a, dolor, sem auctor, ligula, commodo maecenas habitasse et. Orci, tempor, velit tortor ante nulla morbi id varius, arcu, purus risus. Amet mattis ligula, euismod consequat placerat, pellentesque massa velit purus vitae, placerat praesent egestas ad scelerisque sed. Aliquam mattis, metus sodales est nisi venenatis sem enim, quam mi, tristique.", new DateTime(2024, 3, 31, 7, 8, 50, 560, DateTimeKind.Local).AddTicks(7682), true, 10, "Sem egestas congue laoreet nam a duis massa per tortor commodo urna ante", "Torquent iaculis himenaeos", 285, "quisque-lacinia-eleifend", 179 },
                    { 38, "207cc129-c8c5-4979-b7e2-b50a7b281bfc", 7, null, "Interdum amet cras tristique euismod vel, nisl finibus sem, vitae elit torquent interdum, quisque efficitur ullamcorper sollicitudin dui. Vulputate rhoncus tellus, feugiat, lobortis sed sed, euismod vestibulum, erat litora amet, enim phasellus. Nec, praesent rhoncus lectus, at dictumst est fusce ac, tincidunt orci, fermentum vestibulum. Efficitur mi libero vivamus aliquet varius taciti class sagittis auctor. Erat, congue, pharetra porttitor eu finibus commodo, mattis mattis, congue pulvinar risus auctor arcu, quisque nisi.", new DateTime(2024, 3, 25, 17, 12, 50, 561, DateTimeKind.Local).AddTicks(244), true, 28, "Quis laoreet venenatis accumsan ac sodales quis lacinia class hendrerit arcu fusce eros", "Quis iaculis nunc", 162, "sociosqu-dolor-neque", 262 },
                    { 39, "a8959e1f-6d3a-4423-91b7-6358bd639bf7", 8, null, "Leo posuere, facilisis gravida porttitor, non mi, ultrices, consectetur justo neque, himenaeos aenean nam auctor class. Finibus, ultrices, nam at, magna bibendum, amet, et, fringilla cras. Tempus turpis varius, adipiscing vitae ex nulla convallis magna odio. Arcu, aptent fermentum consectetur sit congue ac pulvinar vivamus et, faucibus placerat.", new DateTime(2024, 3, 28, 18, 51, 50, 561, DateTimeKind.Local).AddTicks(2047), true, 14, "Quam commodo amet dolor suscipit augue eu cursus curabitur feugiat metus dapibus per", "Nec auctor mauris", 230, "leo-dui-varius", 210 },
                    { 40, "a8959e1f-6d3a-4423-91b7-6358bd639bf7", 5, null, "Nisi, mauris, a, posuere, nec, condimentum pulvinar, habitasse mauris suscipit porta in odio, cursus, in, commodo, ultricies. In enim, finibus ex turpis lacinia, sodales rhoncus porta varius scelerisque porttitor, torquent nibh. Ac, convallis tincidunt porta eros, maecenas molestie ultrices, sagittis, semper vel, commodo elit feugiat, ex, metus laoreet, mollis cursus. Suspendisse pulvinar fusce inceptos mollis mi iaculis facilisis enim placerat. Iaculis ex elementum sem nam dictum ante, lobortis porttitor pulvinar. In, sem, pretium proin justo mauris, nisi eleifend, finibus, vestibulum, augue ultricies lorem orci fringilla praesent bibendum.", new DateTime(2024, 3, 25, 11, 49, 50, 561, DateTimeKind.Local).AddTicks(4825), true, 11, "Eleifend non posuere ante nisi diam ligula arcu sed turpis tellus rutrum dapibus", "Est porttitor mi", 186, "aliquam-sit-magna", 282 },
                    { 41, "a8959e1f-6d3a-4423-91b7-6358bd639bf7", 9, null, "Nulla, sodales condimentum odio turpis vivamus rhoncus sagittis, tortor ornare tincidunt scelerisque interdum, porttitor tempor at, molestie venenatis sociosqu. Feugiat lacus finibus, interdum, pellentesque mi phasellus ultricies lorem per posuere, ipsum nibh habitasse gravida. Amet vehicula pharetra proin dapibus ornare ante arcu laoreet, libero id. Ex, consequat lobortis quam, vitae, maecenas taciti mi inceptos porttitor ante lectus, vestibulum, orci nunc.", new DateTime(2024, 3, 27, 9, 7, 50, 561, DateTimeKind.Local).AddTicks(7216), true, 10, "Aenean interdum lectus mollis lectus placerat malesuada vehicula mattis phasellus proin ac eros", "Faucibus magna porta", 274, "imperdiet-posuere-lacus", 259 },
                    { 42, "a8959e1f-6d3a-4423-91b7-6358bd639bf7", 1, null, "Arcu conubia semper sagittis, tortor, blandit vulputate ipsum porttitor, at. Pellentesque habitasse feugiat condimentum suspendisse arcu, varius nam taciti justo auctor, placerat nulla dui sit elementum. Ultricies quam arcu, magna, maecenas fermentum volutpat, rhoncus augue nibh, mi vitae felis lectus. Sociosqu ut finibus, tincidunt laoreet, torquent ultricies amet, gravida porta, mattis nam mauris euismod sit sollicitudin massa.", new DateTime(2024, 3, 30, 1, 25, 50, 561, DateTimeKind.Local).AddTicks(9587), true, 15, "Erat nisi lacinia blandit sed massa erat habitasse quam nec commodo maximus lobortis", "Quam orci blandit", 202, "fusce-tempor-pulvinar", 182 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "CategoryId", "Modified", "Post Content", "Posted On", "Published", "Rate Count", "Short Description", "Title", "Total Rate", "UrlSlug", "View Count" },
                values: new object[,]
                {
                    { 43, "a8959e1f-6d3a-4423-91b7-6358bd639bf7", 1, null, "Nulla interdum, convallis neque, himenaeos at, nibh, ipsum ullamcorper porttitor. Luctus vehicula urna laoreet quis dolor finibus, orci, orci nulla, dapibus volutpat, nunc ultricies porttitor neque. Nisl dignissim sociosqu hac erat vivamus feugiat, purus ex vulputate rutrum ligula fusce nunc nunc, nibh. In metus luctus, in, ac pellentesque quis, nisi hendrerit fermentum elit enim, eros, a. Cursus nunc odio mi, tristique mauris, blandit sed eu, venenatis vestibulum. Vel litora nostra, enim mauris, at, class nibh, vitae, porttitor ligula fames feugiat vitae purus.", new DateTime(2024, 3, 29, 22, 31, 50, 562, DateTimeKind.Local).AddTicks(2492), true, 25, "Nullam ipsum varius ante sapien morbi maecenas fringilla odio felis per a mi", "Venenatis fringilla sem", 294, "lectus-nunc-fringilla", 225 },
                    { 44, "a8959e1f-6d3a-4423-91b7-6358bd639bf7", 6, null, "Justo venenatis lacinia, mattis aliquet in blandit interdum, augue quisque nec lectus, laoreet nisi erat. Elit nibh, lacus vestibulum sem ligula neque, leo, nisi, risus nec dolor, consequat ligula, nulla. Feugiat nibh lectus torquent sem eleifend feugiat, nunc, dolor, in, ultrices risus eros, congue integer nulla duis mattis, tempor. Suscipit litora iaculis sed, quis finibus ad ullamcorper magna, volutpat, rutrum vestibulum. Pharetra laoreet, enim, condimentum proin habitasse arcu, consectetur pellentesque auctor a vestibulum, quam velit vulputate. Finibus odio mi, fusce urna, leo, lacus risus id neque non, et. Tellus gravida id, cursus, orci arcu et, commodo non, congue.", new DateTime(2024, 4, 3, 6, 17, 50, 562, DateTimeKind.Local).AddTicks(5882), true, 23, "Tincidunt quis auctor dapibus ullamcorper lectus elit at vestibulum commodo placerat arcu eget", "Class amet bibendum", 239, "nec-at-dictum", 201 },
                    { 45, "a8959e1f-6d3a-4423-91b7-6358bd639bf7", 8, null, "Adipiscing ac id, non cras himenaeos tristique sapien egestas massa, lacus enim. Molestie placerat, vivamus integer tempus lacus elit rhoncus, luctus, congue, sem, torquent id quam nisi fusce diam finibus at. Nisl felis imperdiet non, in, laoreet euismod, auctor, ad nunc, ligula erat sit. Quis, at libero sollicitudin quis hac urna litora nam vitae, erat pulvinar. Ad posuere platea ligula per class turpis sem, erat congue. Finibus, metus sem nulla magna, tellus, himenaeos aliquet blandit, iaculis ipsum. Non, porttitor amet primis lorem proin duis vitae, vivamus pretium morbi efficitur lacus dolor, maecenas blandit, risus.", new DateTime(2024, 3, 27, 9, 33, 50, 562, DateTimeKind.Local).AddTicks(9187), true, 29, "Elit erat lectus id vivamus orci tortor sem cursus dui commodo tempor enim", "Sapien ultrices odio", 270, "magna-vivamus-lacus", 290 },
                    { 46, "207cc129-c8c5-4979-b7e2-b50a7b281bfc", 3, null, "Eros, turpis aliquet scelerisque orci, fames maximus rhoncus, elit laoreet porttitor consectetur mollis primis. Integer purus nam litora bibendum enim, volutpat, lobortis vitae, porttitor, sit himenaeos sollicitudin vivamus urna. Laoreet habitasse laoreet, finibus, eu, semper justo lacus dictumst vestibulum nullam dapibus id, interdum. Aptent volutpat, est malesuada tincidunt eleifend nunc purus quam vestibulum, pulvinar a.", new DateTime(2024, 3, 31, 14, 41, 50, 563, DateTimeKind.Local).AddTicks(1608), true, 14, "Leo luctus elementum orci maecenas congue erat inceptos est ornare vitae odio enim", "Nostra ultrices vulputate", 184, "pretium-nisi-tellus", 131 },
                    { 47, "a8959e1f-6d3a-4423-91b7-6358bd639bf7", 9, null, "Cursus, egestas nullam euismod, ac, neque taciti bibendum, iaculis proin tellus dolor massa, congue inceptos sociosqu hac viverra. Sem leo, varius ornare semper non iaculis porttitor, gravida nibh vestibulum nam efficitur conubia phasellus a, sem, dui orci. Vestibulum nec pharetra hendrerit arcu eu nunc, iaculis suspendisse donec. A, dui tellus amet, ultricies sodales in, vehicula egestas bibendum, torquent congue, dolor, consectetur erat, ad posuere rhoncus sollicitudin. A, placerat, aptent eu arcu, sagittis ac augue libero sed, tellus tellus, erat non, inceptos dictum. Lacinia suspendisse varius luctus faucibus arcu leo ultrices, dui finibus, massa ac, risus lorem leo, sagittis, libero fringilla. Mollis ac, dictumst inceptos interdum sit tristique urna, consequat ad et scelerisque dolor sagittis, massa pulvinar, consectetur.", new DateTime(2024, 3, 30, 22, 38, 50, 563, DateTimeKind.Local).AddTicks(4880), true, 28, "Sociosqu amet fusce tortor blandit porta interdum mattis magna taciti faucibus hac volutpat", "Sollicitudin ligula dapibus", 234, "gravida-fringilla-sit", 276 },
                    { 48, "207cc129-c8c5-4979-b7e2-b50a7b281bfc", 2, null, "Ex elit praesent eros donec in luctus dolor volutpat per orci, ac pellentesque consequat auctor, odio, eleifend. Porta, malesuada vehicula id, mattis, ligula, platea orci, eros ultricies. Tortor, eros nec blandit efficitur suscipit laoreet interdum nec, porta, felis. Tempor, urna tristique dui finibus per lorem lobortis fermentum sollicitudin pulvinar, sed proin pharetra quisque.", new DateTime(2024, 4, 3, 21, 29, 50, 563, DateTimeKind.Local).AddTicks(7254), true, 15, "Ac lorem rhoncus dictumst sollicitudin ut accumsan volutpat erat lobortis massa nec nisi", "Bibendum ad torquent", 135, "magna-porta-ex", 212 },
                    { 49, "207cc129-c8c5-4979-b7e2-b50a7b281bfc", 3, null, "Rhoncus dolor, commodo, sagittis non sed, lectus ornare eget fermentum urna, diam varius fringilla, pulvinar, odio. Nec quam, sem quam lacus congue ad ipsum vitae, consequat. Auctor, luctus egestas dui massa cursus tortor, volutpat, dictum ad tempor, in, platea. Volutpat, neque, pulvinar ante leo dictumst mi non venenatis nibh nisl. Dapibus quam, hac scelerisque vel, rhoncus, efficitur condimentum aliquam curabitur erat ex, interdum felis. Lacinia, cursus arcu, ultrices, lacinia odio, convallis fringilla dolor, vestibulum, eros, ullamcorper eros massa, bibendum. Volutpat arcu tellus, fringilla, condimentum convallis volutpat, cursus, dolor, ligula, pulvinar pretium congue, tellus enim consequat egestas.", new DateTime(2024, 4, 2, 2, 8, 50, 564, DateTimeKind.Local).AddTicks(575), true, 13, "Facilisis convallis non pulvinar per vestibulum placerat mi dapibus odio vitae integer fusce", "Ultricies sociosqu turpis", 205, "tempus-cras-litora", 258 },
                    { 50, "a8959e1f-6d3a-4423-91b7-6358bd639bf7", 2, null, "Vestibulum, dictum feugiat, venenatis ultricies malesuada at, ac ac, cras. Sagittis ultrices ipsum ante, malesuada proin neque non commodo hendrerit ligula, eget suscipit ac. Dictum vivamus fringilla ex ultrices, mi platea interdum, porttitor curabitur molestie orci. Suspendisse semper viverra hendrerit conubia dignissim neque, efficitur class molestie non tortor nisi, maximus ante sagittis, aliquam nullam. Libero ante a, vulputate elit, commodo, velit quam est venenatis lectus mollis elit amet, laoreet, adipiscing porta, amet magna.", new DateTime(2024, 3, 31, 5, 19, 50, 564, DateTimeKind.Local).AddTicks(3421), true, 28, "Vel arcu quisque dolor neque sem metus sed gravida ornare mi a ullamcorper", "Commodo taciti orci", 191, "enim-rhoncus-habitasse", 115 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "3053cfdc-9cdb-490b-9e88-5d3e7ffb4929", "207cc129-c8c5-4979-b7e2-b50a7b281bfc" },
                    { "cf1f7398-a0df-45c4-9140-2252a8e81fa8", "896f381a-107f-4451-bcec-41e655640a49" },
                    { "1d249a9a-17b2-48be-9c54-9c92d4da6e5d", "a8959e1f-6d3a-4423-91b7-6358bd639bf7" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentHeader", "CommentText", "CommentTime", "Email", "Name", "PostId" },
                values: new object[,]
                {
                    { 1, "Nunc eget ac", "Justo ut suscipit volutpat, dictum ultrices placerat, fringilla felis massa, dolor, sodales curabitur. Molestie lectus, finibus congue lacus rhoncus, mauris nibh aliquet platea tortor magna, luctus ligula porttitor, faucibus placerat, neque laoreet.", new DateTime(2024, 4, 2, 7, 15, 50, 565, DateTimeKind.Local).AddTicks(1390), "sed@placerat.com", "Ultrices auctor", 12 },
                    { 2, "Rhoncus imperdiet congue", "Massa, placerat porttitor augue conubia amet, tortor pulvinar rutrum odio aliquam bibendum, vel semper enim, aliquet eu.", new DateTime(2024, 3, 28, 3, 51, 50, 565, DateTimeKind.Local).AddTicks(3042), "gravida@vitae.com", "Nec est", 4 },
                    { 3, "Placerat sociosqu velit", "Volutpat, donec convallis porta, luctus, ultrices, mi at, sed, tellus, pellentesque placerat malesuada sapien suspendisse risus. Scelerisque vivamus nam non fames aliquam hac sem, eget mauris congue, nisl turpis sapien amet fringilla nullam.", new DateTime(2024, 3, 28, 12, 1, 50, 565, DateTimeKind.Local).AddTicks(4978), "ex@sed.com", "Eleifend vehicula", 17 },
                    { 4, "Nullam eu vestibulum", "Magna, mauris, interdum maecenas odio orci semper cras nibh, luctus, sed, varius, eleifend.", new DateTime(2024, 3, 28, 11, 15, 50, 565, DateTimeKind.Local).AddTicks(6575), "mauris@placerat.com", "Nunc sem", 3 },
                    { 5, "Placerat sollicitudin varius", "Lorem donec tempus venenatis sociosqu orci cursus blandit, faucibus aenean viverra placerat.", new DateTime(2024, 3, 29, 0, 18, 50, 565, DateTimeKind.Local).AddTicks(8206), "sed@nunc.com", "Enim elementum", 43 },
                    { 6, "Sagittis lacus fames", "Erat orci, lacinia luctus, pulvinar, rhoncus, mauris, congue, aptent tortor, tempor scelerisque in, ex maximus nisl urna. Euismod, finibus eleifend porta proin rhoncus, ante, odio, pharetra aptent bibendum, nibh arcu ultricies cursus vulputate per eu.", new DateTime(2024, 3, 29, 17, 47, 50, 566, DateTimeKind.Local).AddTicks(167), "lobortis@augue.com", "Erat tempus", 42 },
                    { 7, "Ut gravida ultricies", "Quam, per porta, accumsan nec convallis orci tincidunt vulputate dui varius risus laoreet, id, mauris gravida ligula.", new DateTime(2024, 4, 1, 21, 42, 50, 566, DateTimeKind.Local).AddTicks(1851), "ligula@condimentum.com", "Congue tortor", 3 },
                    { 8, "Ante interdum tortor", "Euismod, lobortis bibendum interdum posuere, mi, accumsan ante, enim, eleifend, mi ultricies varius, dapibus est vulputate duis. Enim himenaeos hendrerit erat risus auctor, proin mi vitae torquent leo maximus nam eleifend, ante, porttitor, odio.", new DateTime(2024, 3, 25, 16, 2, 50, 566, DateTimeKind.Local).AddTicks(3830), "vivamus@tincidunt.com", "Bibendum pulvinar", 13 },
                    { 9, "Ut integer laoreet", "Etiam ligula duis aenean rhoncus eleifend risus dolor sodales lorem, sagittis ante sit. Pulvinar, magna vitae cras at cursus, dui nulla, mattis magna, justo fermentum viverra placerat in, eleifend ipsum.", new DateTime(2024, 3, 29, 19, 59, 50, 566, DateTimeKind.Local).AddTicks(5846), "vulputate@dapibus.com", "Vehicula lectus", 12 },
                    { 10, "Euismod et feugiat", "Nostra, mauris cursus, rhoncus nullam sagittis, molestie odio dictum turpis fringilla ultricies congue, volutpat, quisque.", new DateTime(2024, 3, 31, 19, 18, 50, 566, DateTimeKind.Local).AddTicks(7515), "arcu@vivamus.com", "Eu torquent", 14 },
                    { 11, "Amet urna massa", "Tellus hac dictumst turpis ullamcorper ultricies non leo lectus, aliquet fusce dignissim.", new DateTime(2024, 4, 2, 0, 26, 50, 566, DateTimeKind.Local).AddTicks(9148), "metus@hendrerit.com", "Magna a", 18 },
                    { 12, "Blandit blandit etiam", "Urna, sed, interdum egestas porttitor, commodo at dignissim erat, metus laoreet ornare elit nibh, risus placerat, a vitae.", new DateTime(2024, 3, 30, 19, 49, 50, 567, DateTimeKind.Local).AddTicks(834), "tellus@eleifend.com", "Nisi dictum", 48 },
                    { 13, "Fringilla justo convallis", "Interdum mauris, sem, nunc vivamus condimentum et, fermentum at blandit taciti enim, cras dignissim facilisis primis sagittis, nam cursus.", new DateTime(2024, 3, 27, 23, 56, 50, 567, DateTimeKind.Local).AddTicks(2532), "varius@massa.com", "Vehicula class", 15 },
                    { 14, "Lectus erat feugiat", "Mauris eros, eget massa, enim, lacinia, lobortis arcu, id, sodales egestas.", new DateTime(2024, 4, 1, 13, 8, 50, 567, DateTimeKind.Local).AddTicks(4198), "ac@elit.com", "Ex interdum", 47 },
                    { 15, "Dapibus vivamus augue", "Fringilla, sed nec finibus, vitae, euismod diam erat, ultrices, condimentum lorem fames a quam, morbi. Aliquam primis risus viverra mattis mollis augue litora purus in interdum posuere, placerat, fermentum volutpat, congue, odio nunc, vitae.", new DateTime(2024, 4, 1, 14, 24, 50, 567, DateTimeKind.Local).AddTicks(6243), "nunc@varius.com", "Condimentum massa", 4 },
                    { 16, "Tortor enim condimentum", "Maecenas molestie aenean sagittis lacinia dui vehicula cursus maximus fringilla. Placerat, dolor consequat eros arcu, finibus dictumst enim ipsum non, blandit quis, dui, vivamus pulvinar primis tortor, volutpat.", new DateTime(2024, 3, 30, 10, 18, 50, 567, DateTimeKind.Local).AddTicks(8291), "lacinia@et.com", "Arcu id", 9 },
                    { 17, "Massa felis quisque", "Magna, volutpat arcu, mauris torquent bibendum, ornare in, aenean ullamcorper ut pretium pulvinar, orci, lacinia class fringilla.", new DateTime(2024, 4, 3, 19, 27, 50, 567, DateTimeKind.Local).AddTicks(9938), "semper@euismod.com", "Ante tincidunt", 29 },
                    { 18, "Class luctus ultricies", "Nulla, dictum class et nam bibendum quam, nullam nulla ut ligula nec.", new DateTime(2024, 3, 26, 19, 52, 50, 568, DateTimeKind.Local).AddTicks(1568), "felis@purus.com", "Tellus tincidunt", 21 },
                    { 19, "Tortor bibendum amet", "Posuere, tincidunt pulvinar, sed non nec, eros, odio volutpat, orci, dignissim dictumst dictum mauris mi, id, libero.", new DateTime(2024, 3, 26, 22, 20, 50, 568, DateTimeKind.Local).AddTicks(3169), "massa@curabitur.com", "Rhoncus posuere", 15 },
                    { 20, "Duis tristique hac", "Augue per nam ut tempor suspendisse vel, ex feugiat, auctor ac.", new DateTime(2024, 4, 1, 21, 53, 50, 568, DateTimeKind.Local).AddTicks(4806), "luctus@vestibulum.com", "Mattis enim", 17 }
                });

            migrationBuilder.InsertData(
                table: "PostTagMaps",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 2, 9 },
                    { 4, 16 },
                    { 7, 18 },
                    { 9, 18 },
                    { 11, 1 },
                    { 14, 10 },
                    { 15, 17 },
                    { 16, 13 },
                    { 16, 18 },
                    { 18, 2 },
                    { 18, 12 },
                    { 19, 15 },
                    { 21, 12 },
                    { 26, 5 },
                    { 27, 15 },
                    { 29, 3 },
                    { 32, 4 },
                    { 36, 8 },
                    { 36, 20 },
                    { 38, 5 },
                    { 38, 16 }
                });

            migrationBuilder.InsertData(
                table: "PostTagMaps",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { 39, 9 },
                    { 40, 5 },
                    { 42, 4 },
                    { 43, 3 },
                    { 44, 6 },
                    { 44, 12 },
                    { 44, 16 },
                    { 46, 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTagMaps_TagId",
                table: "PostTagMaps",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "PostTagMaps");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

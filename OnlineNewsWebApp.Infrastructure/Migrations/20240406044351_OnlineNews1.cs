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
                    { 1, "Dictumst maecenas scelerisque nisi congue diam risus inceptos felis quam eros praesent", "Sodales vitae" },
                    { 2, "Enim ullamcorper tempus nibh nisi suscipit arcu volutpat ac mi dolor maximus", "Vulputate nec" },
                    { 3, "Justo laoreet massa sed eleifend elit lacus cursus etiam leo aptent a", "Euismod blandit" },
                    { 4, "Aptent accumsan lacinia non inceptos nec suscipit nisi erat finibus porta nec", "Luctus aenean" },
                    { 5, "Id sociosqu dui tempus venenatis porta eleifend nam eleifend luctus ad vehicula", "Neque condimentum" },
                    { 6, "Tellus laoreet turpis in interdum bibendum auctor in id adipiscing volutpat quisque", "Nunc a" },
                    { 7, "Commodo erat sapien porttitor sed platea vestibulum scelerisque hendrerit nulla facilisis aliquet", "Ligula feugiat" },
                    { 8, "Donec nisi eleifend litora tortor volutpat scelerisque non sagittis vitae felis placerat", "Morbi euismod" },
                    { 9, "Nec lectus semper orci sit mattis felis egestas nullam platea consequat nisi", "Ultrices massa" },
                    { 10, "Amet ultrices iaculis congue neque nam a in interdum elit lobortis volutpat", "Non nec" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d6e9646-489c-4abd-8e80-d2a9d7cf96f6", "099ad3d7-8858-43f2-a7ed-e3dd3df6783f", "Writer", "WRITER" },
                    { "4f5ba271-c697-4175-855d-ee8896e668ef", "011a6441-6ff6-462a-8fc5-333f166069ee", "Reader", "READER" },
                    { "e469389c-f466-4f50-b93d-3e3a60e8ed5f", "9c3ff349-7105-40d8-999a-001125b4ecb1", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Count", "Name" },
                values: new object[,]
                {
                    { 1, 8, "Nulla morbi aenean" },
                    { 2, 13, "Ultrices sollicitudin nulla" },
                    { 3, 9, "Dolor etiam viverra" },
                    { 4, 5, "A nulla torquent" },
                    { 5, 6, "Bibendum feugiat a" },
                    { 6, 8, "Convallis tristique bibendum" },
                    { 7, 7, "Magna felis nullam" },
                    { 8, 13, "Habitasse etiam dictumst" },
                    { 9, 7, "Euismod sit sagittis" },
                    { 10, 14, "Rhoncus vulputate inceptos" },
                    { 11, 4, "Cras ipsum quisque" },
                    { 12, 10, "Vel adipiscing blandit" },
                    { 13, 7, "Leo morbi scelerisque" },
                    { 14, 6, "Et nam dui" },
                    { 15, 7, "Bibendum blandit dolor" },
                    { 16, 5, "Aliquam odio platea" },
                    { 17, 4, "Posuere ut litora" },
                    { 18, 6, "Commodo eleifend nec" },
                    { 19, 6, "Congue vel ipsum" },
                    { 20, 5, "Interdum habitasse curabitur" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AboutMe", "AccessFailedCount", "Age", "ConcurrencyStamp", "DonationStars", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "39fff519-b448-49d4-8f12-bc0843137e3c", "Volutpat tellus mauris luctus lorem justo cursus leo ad metus", 0, 59, "90189119-2d43-4bba-95ee-f4a6cc5c4781", 0, "trunghieusuper@gmail.com", true, "Logan", "HieuBui", false, null, "TRUNGHIEUSUPER@GMAIL.COM", "LOGANHIEUBUI", "AQAAAAEAACcQAAAAEIsKfOlwEI6aErMsFq65P4yc5CauutCxc8nx1a9d3lMY1cYXkWSw1E4OL6DOowZk/Q==", null, false, "4745d04d-fb69-41e7-b155-2a698402f793", false, "loganhieubui" },
                    { "98b052ec-1de5-45f8-95c6-9bf3beecda40", "Duis porttitor himenaeos sed lacinia ad vulputate ultrices euismod pulvinar", 0, 36, "5e8133e0-bcb7-4a10-a346-4ba02fbb1a90", 0, "buitrunghieu_t65@hus.edu.vn", true, "Jimmy", "Carter", false, null, "BUITRUNGHIEU_T65@HUS.EDU.VN", "JIMMYCARTER", "AQAAAAEAACcQAAAAELwgG7aMthvWhoHteEpdOSEgFW48npzI+Z2LdiNGs7s9psumbhTqRu2zaiXJpjzi4g==", null, false, "37986b98-4bce-472a-9e41-93978fcc741e", false, "jimmycarter" },
                    { "b5ed2179-74c5-4406-b679-9268517256c9", "Proin vivamus odio cursus pulvinar gravida non quis pretium dignissim", 0, 33, "dbb2ca69-05fd-49e9-9470-251eb09ad9ba", 0, "buihieu.211202@gmail.com", true, "Ricardo", "MyLord", false, null, "BUIHIEU.211202@GMAIL.COM", "RICARDO", "AQAAAAEAACcQAAAAEITUCd+A3xvPuqPQOaLOnK3gr5BAmcoy6uRj59qgrBZ4tVijQr6+y8PmpWvmUDTlIQ==", null, false, "e8369854-d6df-48c3-9aaf-a2d435cedb2b", false, "ricardo" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "CategoryId", "Modified", "Post Content", "Posted On", "Published", "Rate Count", "Short Description", "Title", "Total Rate", "UrlSlug", "View Count" },
                values: new object[,]
                {
                    { 1, "39fff519-b448-49d4-8f12-bc0843137e3c", 5, null, "Tellus, interdum, erat, posuere dapibus et elit nulla, litora sagittis rhoncus, mattis, rhoncus lacus est urna. Mi semper porta sagittis, laoreet, leo elit, nunc dui sit malesuada sagittis eros eu, lorem varius, nulla duis. Ligula, nec, eros habitasse dapibus pharetra vitae, tempus quam quisque. Nibh elit eleifend, mi, nunc at elit, odio, accumsan ante, aenean suscipit quam commodo, scelerisque nunc, proin.", new DateTime(2024, 4, 3, 8, 31, 50, 214, DateTimeKind.Local).AddTicks(1385), true, 13, "Dolor odio morbi sed lectus rutrum elit mi justo commodo sit nisi aliquet", "Curabitur posuere ornare", 198, "urna-justo-mi", 284 },
                    { 2, "98b052ec-1de5-45f8-95c6-9bf3beecda40", 7, null, "Nam arcu pretium iaculis fringilla aptent ac efficitur elit phasellus lectus. Ultrices finibus ac quam, viverra habitasse hac aliquam semper placerat, eu tortor, efficitur maecenas. Tellus leo mi aliquam ac non, euismod, pretium nec nostra. Neque, neque duis nulla, mauris tincidunt praesent lorem ultricies quis, lacus erat aliquam vestibulum diam sollicitudin odio magna dignissim. Integer turpis elit, condimentum mi enim, elementum varius, porttitor per at adipiscing faucibus nulla, elit. Eget arcu, feugiat, gravida donec accumsan non, venenatis efficitur nunc, augue amet, bibendum. Euismod purus sagittis nam volutpat suscipit in pulvinar, dapibus eros dolor metus nisl ut.", new DateTime(2024, 3, 28, 12, 0, 50, 214, DateTimeKind.Local).AddTicks(6710), true, 12, "Sem ipsum commodo ornare urna dignissim scelerisque suspendisse quisque nec quis libero eros", "A risus condimentum", 223, "varius-venenatis-dolor", 255 },
                    { 3, "98b052ec-1de5-45f8-95c6-9bf3beecda40", 5, null, "Neque curabitur auctor, erat himenaeos luctus primis arcu congue, odio. Quam, porttitor maximus sem eu, magna, ac, lacinia malesuada nibh fusce. Eu amet vel, donec sem, litora sed mi mattis lectus tellus. Cras ipsum neque varius, fames dui tristique varius nunc, fringilla vehicula aliquam pellentesque bibendum. Platea lacinia nibh semper leo, quisque est nunc, arcu, ut. Pretium nibh proin nostra, conubia venenatis urna, ipsum placerat donec aliquet nisi, dolor, maecenas fames at sagittis litora.", new DateTime(2024, 4, 5, 20, 10, 50, 215, DateTimeKind.Local).AddTicks(1318), true, 27, "Eget vivamus varius eleifend libero venenatis mattis consequat nulla praesent eros lectus dui", "Feugiat et vestibulum", 188, "diam-litora-semper", 260 },
                    { 4, "98b052ec-1de5-45f8-95c6-9bf3beecda40", 2, null, "Urna, vestibulum, pretium placerat congue, eros, pulvinar, dignissim class est suspendisse venenatis rhoncus, sagittis. Inceptos ultricies vitae proin vel lacinia nibh imperdiet lacinia, quam aptent lorem. Fringilla, suspendisse varius eleifend lorem, duis porttitor, habitasse auctor, a, cras volutpat, arcu, posuere varius, felis maximus. Augue nulla, aenean enim, faucibus consectetur at, vivamus euismod, sagittis, phasellus id, pharetra nibh, neque vitae. Risus commodo, nam euismod, lorem, quisque aptent orci quam placerat aliquet habitasse. Vitae nunc, hendrerit quis, mattis placerat justo fames auctor, porta, accumsan leo. Commodo, nulla a hac etiam porta, conubia magna nibh, volutpat, augue tellus.", new DateTime(2024, 3, 31, 20, 50, 50, 215, DateTimeKind.Local).AddTicks(6556), true, 28, "Tellus dui purus fringilla aliquam ut at ante quis auctor laoreet tortor auctor", "Ipsum mi torquent", 254, "habitasse-sed-conubia", 125 },
                    { 5, "98b052ec-1de5-45f8-95c6-9bf3beecda40", 9, null, "Rutrum ad enim dictumst efficitur rhoncus ipsum pharetra odio ante, consectetur. Vitae conubia iaculis tortor condimentum tristique erat per amet aptent volutpat arcu, interdum at. Proin dapibus eleifend, et congue lorem per nam fusce eget est felis quam. Odio taciti in eu turpis tortor tempor, leo, amet ullamcorper donec. Nunc commodo, quis, risus habitasse in, ex aptent lectus lorem, tincidunt libero tellus mi rhoncus, orci, a hac rhoncus. Commodo, non, varius, ad nunc fringilla, rhoncus, duis nibh ante. Leo, sed, a, porta, etiam elit vel, class primis odio.", new DateTime(2024, 4, 3, 8, 8, 50, 216, DateTimeKind.Local).AddTicks(6126), true, 17, "Urna orci mollis est et finibus vulputate taciti suscipit tempus dui vehicula fusce", "Elit turpis suscipit", 139, "eget-lacus-himenaeos", 247 },
                    { 6, "39fff519-b448-49d4-8f12-bc0843137e3c", 2, null, "Velit et, tortor euismod integer id praesent ad finibus malesuada class a, pulvinar nullam cursus tortor. Quam sociosqu bibendum posuere, dignissim conubia vitae, est ex, nisi, mauris, ultrices commodo leo himenaeos facilisis. Aliquet porta, nisi, aptent tincidunt himenaeos quam, nisi iaculis neque ex. Leo erat id, vivamus dui, malesuada blandit, nulla, rutrum tellus, congue, posuere, facilisis finibus, massa, duis curabitur. In, eleifend a, cursus, gravida aliquet torquent tellus tortor eu. Vulputate placerat lectus sem, diam ac pellentesque mi, quis, consequat nulla eleifend, blandit curabitur tortor.", new DateTime(2024, 4, 3, 11, 29, 50, 217, DateTimeKind.Local).AddTicks(985), true, 24, "Dui nulla justo ac varius sed fermentum tempus interdum nulla commodo dolor neque", "Interdum velit congue", 217, "volutpat-erat-leo", 191 },
                    { 7, "39fff519-b448-49d4-8f12-bc0843137e3c", 6, null, "Nam lorem, fermentum auctor, consectetur sem, lobortis tortor, at, gravida urna, luctus lectus, laoreet volutpat duis amet, ad. Dapibus blandit, lacinia, volutpat nec eleifend cras tellus quis, eros vitae felis vulputate pretium nisi nam. Primis ex, nunc amet, pellentesque mauris nisi, mi lorem, augue urna cursus, luctus, turpis rutrum euismod congue, lacinia. Nisi, consectetur morbi ultricies ex a, ex, quisque ante, augue sagittis ad. Orci amet scelerisque nullam feugiat dictumst lacus sollicitudin phasellus ultrices, conubia augue hendrerit ex, viverra sit finibus, est. Mattis elementum enim purus vitae, id maximus praesent ligula quisque.", new DateTime(2024, 4, 1, 21, 38, 50, 217, DateTimeKind.Local).AddTicks(5689), true, 29, "Pulvinar vulputate arcu aenean velit laoreet feugiat inceptos non enim erat laoreet massa", "Dignissim per sed", 212, "tellus-dolor-eu", 288 },
                    { 8, "98b052ec-1de5-45f8-95c6-9bf3beecda40", 3, null, "Eu fringilla risus laoreet, sed, tempor mauris enim sit himenaeos dapibus sem. Finibus, cursus posuere tempus pharetra suspendisse consectetur nec vel, vel libero venenatis lectus et, nullam pretium mattis vivamus. Nunc ligula sed, vivamus habitasse adipiscing vulputate est phasellus lectus euismod vel. Orci fringilla, viverra ligula, tellus, ipsum urna, tortor mi, sociosqu sit conubia diam amet, curabitur. Elementum porta quis, phasellus orci, quam, sit ad aliquam viverra massa vestibulum, arcu est.", new DateTime(2024, 3, 30, 23, 34, 50, 217, DateTimeKind.Local).AddTicks(9923), true, 13, "Sem dictumst finibus pellentesque magna rhoncus vehicula dapibus imperdiet efficitur massa varius augue", "Scelerisque odio mollis", 148, "habitasse-ultrices-gravida", 194 },
                    { 9, "39fff519-b448-49d4-8f12-bc0843137e3c", 4, null, "Aenean donec id mauris blandit, vestibulum nunc, inceptos ornare orci, tempor primis quis. Pulvinar, eros scelerisque molestie proin sed, mauris ipsum in purus nunc. Maximus fermentum facilisis sit urna massa, nibh at efficitur gravida inceptos nibh, lectus tincidunt sed, ac ultrices. Sit faucibus vivamus gravida taciti sollicitudin ultrices turpis vitae, torquent rhoncus libero lacus porttitor. Morbi fringilla, feugiat, ultrices, rutrum suscipit tristique in semper ante ex, vel. Urna, ipsum rhoncus sem, rutrum per ligula, curabitur magna, fusce leo, nisi, laoreet nunc, tempor, augue enim, mollis. Lacinia luctus bibendum feugiat, mi scelerisque nunc morbi arcu, sapien orci.", new DateTime(2024, 4, 5, 13, 29, 50, 218, DateTimeKind.Local).AddTicks(5705), true, 12, "Sem tortor ligula vehicula urna sociosqu consectetur in sed nec nibh duis praesent", "Platea nullam metus", 137, "ex-ligula-ultrices", 198 },
                    { 10, "98b052ec-1de5-45f8-95c6-9bf3beecda40", 7, null, "Finibus, sodales vel, neque per consequat ligula, vehicula vestibulum ligula interdum arcu, vitae dolor, lacinia. Orci, viverra imperdiet semper placerat, sapien urna mauris, arcu eleifend habitasse malesuada duis. In, lacinia mattis finibus laoreet, morbi lectus urna amet nisl justo ante nunc, feugiat. Sapien ante, nisi enim, interdum, arcu, vehicula inceptos neque semper. Maecenas pulvinar, risus blandit vel leo amet, convallis egestas vitae consequat fringilla molestie volutpat, arcu. Risus vehicula mi arcu nisl elit, ligula euismod, orci augue a, cursus, varius pharetra nibh. Felis id eros, auctor tellus, quis, lorem arcu, pharetra morbi consequat posuere, vel.", new DateTime(2024, 4, 1, 2, 28, 50, 219, DateTimeKind.Local).AddTicks(1775), true, 20, "Lectus magna ac laoreet erat in sem sollicitudin auctor augue aenean lacinia ex", "Convallis leo faucibus", 140, "nec-primis-porta", 231 },
                    { 11, "98b052ec-1de5-45f8-95c6-9bf3beecda40", 1, null, "Fusce etiam tristique class fermentum purus nostra, turpis at, risus sit habitasse laoreet eu. Dolor iaculis nibh fringilla elit fusce rhoncus, integer felis ullamcorper. Efficitur faucibus dui cras erat, volutpat dapibus ac, conubia quam tellus porta, sed finibus diam. Vel nunc, purus ut ipsum ac, nec, blandit, nulla nibh, dignissim facilisis viverra dui, tempor, lectus, semper mauris nec. Lacus eu, tellus, felis turpis euismod varius cursus, mauris, morbi faucibus nibh nostra, lorem, hac velit leo.", new DateTime(2024, 4, 3, 11, 50, 50, 219, DateTimeKind.Local).AddTicks(6106), true, 19, "Elit posuere id ultricies mattis leo lacinia mi quis venenatis nec tellus porta", "Dapibus nunc etiam", 279, "lectus-dictum-etiam", 144 },
                    { 12, "39fff519-b448-49d4-8f12-bc0843137e3c", 3, null, "Duis placerat, ante, vulputate elit, tortor eleifend iaculis inceptos nulla porta, porta convallis sit rhoncus aptent gravida blandit. Leo nisl massa erat, porttitor, pulvinar congue quam per vel eleifend rhoncus, mi lectus nostra, orci, iaculis tincidunt turpis. Lectus vitae, sapien elit inceptos ut vitae ultrices, quam quam, convallis nisi, primis aliquet tristique eu. Ligula mollis lacinia, leo felis neque, orci, feugiat tortor velit metus odio, auctor, congue, taciti praesent. Facilisis dignissim sem ultricies ullamcorper in, neque enim dui praesent iaculis risus ante inceptos egestas eleifend sociosqu cras.", new DateTime(2024, 3, 29, 8, 10, 50, 220, DateTimeKind.Local).AddTicks(329), true, 11, "Sociosqu interdum et fermentum interdum pellentesque justo diam proin turpis eleifend feugiat malesuada", "Sed massa enim", 230, "vel-leo-dolor", 217 },
                    { 13, "98b052ec-1de5-45f8-95c6-9bf3beecda40", 5, null, "Porta himenaeos nulla, non, nostra, a, suscipit posuere lacinia, euismod. At volutpat, porttitor, pulvinar urna eget arcu, pellentesque posuere, cursus, et, lacinia quisque dictumst ultricies auctor, etiam diam. Ipsum tellus, tempor, non et ac dui fermentum tempor cras cursus blandit, fames lacinia, taciti turpis. Interdum sagittis, ipsum id eleifend tellus, eros non rhoncus, litora at donec varius congue adipiscing viverra finibus. Pretium eget erat, nulla, aliquam tempor, tortor, hac egestas nam primis. Pharetra nulla, eu, quam viverra nec, fringilla, neque dolor dictum auctor metus vivamus. Urna, malesuada bibendum, a viverra nunc, aptent non, id euismod, vulputate congue dolor, elementum velit.", new DateTime(2024, 4, 2, 6, 22, 50, 220, DateTimeKind.Local).AddTicks(5656), true, 18, "Laoreet fermentum ex class hendrerit nisi primis diam euismod quis praesent ad enim", "Fringilla ac turpis", 207, "ultrices-varius-ornare", 141 },
                    { 14, "39fff519-b448-49d4-8f12-bc0843137e3c", 7, null, "Per primis in viverra phasellus lorem a dictumst convallis sapien molestie taciti pharetra nullam pulvinar, fringilla, aenean class interdum. Lectus, sem, fringilla, litora tellus, interdum, donec neque dictum cursus aliquet commodo nunc posuere sagittis. Et, auctor, primis sapien lectus, vehicula interdum erat vulputate elit, malesuada a, tellus nulla, orci mi lorem. Congue, eget sagittis rutrum elementum lobortis gravida a, mauris vehicula finibus imperdiet varius. Accumsan blandit tristique laoreet, rhoncus fringilla donec nunc tortor rhoncus, interdum eget pulvinar fusce. Aptent erat orci, ac sodales proin sociosqu tellus, et nulla. Purus augue inceptos in, nam molestie faucibus aliquam vehicula placerat, erat nisi, blandit, nibh laoreet, lorem, ligula sociosqu massa.", new DateTime(2024, 3, 28, 21, 33, 50, 221, DateTimeKind.Local).AddTicks(966), true, 29, "Sodales viverra nec nibh facilisis primis taciti mattis congue ex enim urna praesent", "Bibendum lobortis pretium", 223, "amet-volutpat-bibendum", 172 },
                    { 15, "39fff519-b448-49d4-8f12-bc0843137e3c", 6, null, "Quam eleifend nibh vestibulum, volutpat eros, leo, sociosqu integer phasellus at mauris. At, pulvinar praesent hac nisi ex, nam lectus, varius, porttitor aliquam fringilla tempor, id, pulvinar, tellus. Lectus volutpat, convallis sodales purus praesent vestibulum ut amet, libero maecenas. Iaculis conubia turpis vel bibendum in, mattis ornare mauris, vitae urna, elit duis neque.", new DateTime(2024, 3, 31, 5, 20, 50, 221, DateTimeKind.Local).AddTicks(4585), true, 10, "Torquent pulvinar nulla scelerisque habitasse odio leo lectus quis eget suspendisse ut justo", "Eros dictumst euismod", 213, "enim-porta-tempor", 246 },
                    { 16, "98b052ec-1de5-45f8-95c6-9bf3beecda40", 7, null, "Fermentum felis justo auctor, maximus lorem lacus dictumst blandit luctus vehicula mauris lorem, class. Litora metus sagittis accumsan mattis felis lorem placerat efficitur nisl massa imperdiet malesuada amet, ornare justo. Neque, nibh dapibus faucibus eu, maximus sociosqu eleifend mauris integer. Arcu feugiat, cras luctus vestibulum, efficitur nibh dolor, commodo, pulvinar nunc litora mauris, ultricies nec, himenaeos elit.", new DateTime(2024, 4, 5, 4, 41, 50, 221, DateTimeKind.Local).AddTicks(8339), true, 21, "Vel condimentum sem congue primis vitae pulvinar tellus vulputate dictumst curabitur quam tempor", "Rutrum tincidunt nunc", 149, "sem-laoreet-enim", 220 },
                    { 17, "39fff519-b448-49d4-8f12-bc0843137e3c", 6, null, "Lobortis turpis at amet, pulvinar, lacinia malesuada orci sollicitudin neque accumsan risus auctor, libero pellentesque porttitor mi. Venenatis cursus, porttitor, nulla himenaeos orci hac placerat mauris donec. Tristique interdum, tortor, aptent dignissim laoreet dictum placerat, sodales sed proin primis tincidunt. Et, porttitor habitasse ullamcorper consequat efficitur augue pretium tincidunt nullam fusce porta sociosqu condimentum. Lorem, mi himenaeos est et, porttitor ipsum varius, euismod suscipit adipiscing turpis volutpat, ex cursus a nibh. Fringilla porta, eros neque porttitor dictumst dolor dui est ex, conubia facilisis interdum, nibh purus. Quis, interdum, torquent nisi eros nibh lectus gravida class nisl velit vehicula.", new DateTime(2024, 4, 1, 13, 0, 50, 222, DateTimeKind.Local).AddTicks(3435), true, 20, "Commodo ipsum dui euismod et accumsan dictumst nibh malesuada id odio purus integer", "Hendrerit mi gravida", 146, "iaculis-platea-erat", 192 },
                    { 18, "39fff519-b448-49d4-8f12-bc0843137e3c", 2, null, "Ut sollicitudin nec lectus dignissim etiam libero himenaeos litora dolor erat. In, id ligula sit mollis auctor, lacinia placerat, vehicula erat, urna arcu, donec. Ante, mattis, habitasse nunc mattis sociosqu vivamus mi, ligula, sit accumsan imperdiet dolor etiam leo vestibulum, mauris, in. Tortor, blandit, volutpat, adipiscing felis elementum diam nibh, viverra leo sollicitudin ultricies fringilla eget varius efficitur luctus. Ad posuere duis tempus massa sodales condimentum dapibus suscipit interdum volutpat, sed, nunc, erat aenean magna.", new DateTime(2024, 4, 4, 16, 16, 50, 222, DateTimeKind.Local).AddTicks(7595), true, 13, "Orci diam bibendum pulvinar interdum vulputate aliquam egestas consectetur viverra inceptos feugiat sociosqu", "Porttitor at lorem", 146, "massa-ultricies-magna", 230 },
                    { 19, "39fff519-b448-49d4-8f12-bc0843137e3c", 7, null, "Porttitor, sollicitudin consequat ultrices id, per eros, commodo, semper pellentesque leo ex, nisi, finibus porttitor. Tempor nunc tempus hendrerit vel class venenatis nunc, nisl interdum. Neque, aliquam sagittis mattis, lectus, non lorem, adipiscing conubia leo neque cursus habitasse condimentum porta venenatis. Diam tristique justo porta eros, consectetur proin quam, praesent molestie fringilla, ultrices, cursus, adipiscing. Pulvinar elit, sed, hendrerit sed nulla, conubia morbi rutrum ligula, congue viverra congue, blandit. Amet pretium himenaeos id, nostra, placerat quis, eu odio, praesent dictum.", new DateTime(2024, 4, 1, 13, 37, 50, 223, DateTimeKind.Local).AddTicks(2476), true, 26, "Egestas tempor massa consequat ornare justo tempus taciti nunc non accumsan tortor felis", "Duis ex at", 291, "interdum-lacus-nunc", 195 },
                    { 20, "39fff519-b448-49d4-8f12-bc0843137e3c", 4, null, "Rutrum ante, ac faucibus facilisis augue integer curabitur magna fames tellus. Ex, tincidunt conubia purus a, sollicitudin fusce ornare quam, imperdiet quam lorem. Pharetra et, conubia non, auctor nec volutpat, posuere ipsum adipiscing condimentum porttitor, sapien quis torquent odio. Hac non, porttitor, dolor porttitor imperdiet leo, pulvinar, nunc semper tortor justo neque varius, venenatis vestibulum. Nunc pulvinar, tincidunt fusce posuere, platea phasellus massa, odio, maecenas ac lacinia, convallis. Lacus diam tempor nulla dignissim aliquam lectus, eros id, pretium commodo ante, leo ornare luctus, mi, a ultrices eleifend. Ligula, volutpat mauris, odio massa, mattis, eget porttitor, dolor ex sit iaculis fringilla suscipit erat.", new DateTime(2024, 3, 31, 7, 34, 50, 223, DateTimeKind.Local).AddTicks(9316), true, 25, "Adipiscing tincidunt dui at nisi finibus dignissim litora mi dolor aliquet leo commodo", "Adipiscing gravida bibendum", 215, "fringilla-egestas-massa", 116 },
                    { 21, "39fff519-b448-49d4-8f12-bc0843137e3c", 8, null, "Placerat viverra pharetra eleifend, amet, class elit luctus, finibus platea fringilla, aliquam. Lectus, commodo phasellus amet facilisis sollicitudin volutpat, erat, quam augue fermentum tortor, leo massa, in, sit euismod. Commodo nulla finibus vel amet, eget ex, vivamus lacus curabitur metus non facilisis orci, class rhoncus. Ad sem nam torquent quam rutrum pulvinar malesuada lectus, cras maecenas tempor. Aenean tristique vel euismod, nam lorem, vehicula euismod ac, at, rhoncus ex, suspendisse auctor nisl erat suscipit gravida interdum.", new DateTime(2024, 4, 2, 2, 26, 50, 224, DateTimeKind.Local).AddTicks(4937), true, 13, "Tellus torquent mollis a tempor tempus vel sapien praesent vel sociosqu phasellus nisi", "Dignissim porta elementum", 177, "mattis-nibh-tempus", 147 },
                    { 22, "98b052ec-1de5-45f8-95c6-9bf3beecda40", 8, null, "Convallis vestibulum rutrum massa arcu, euismod diam habitasse orci imperdiet tempor vivamus at, et, bibendum. Blandit, ultrices, euismod, ante porttitor faucibus per ligula, varius, lorem, mi, auctor. Fames feugiat sodales tristique nunc quisque velit libero eleifend mi porta pharetra adipiscing. Ac lorem orci, eros varius suscipit cursus, vitae, dolor aptent ligula et sit posuere pharetra nibh.", new DateTime(2024, 4, 4, 6, 11, 50, 224, DateTimeKind.Local).AddTicks(9730), true, 10, "Auctor fringilla ultricies commodo vestibulum ligula suspendisse ipsum eu himenaeos litora pretium lorem", "Volutpat quam posuere", 201, "dui-non-dictum", 263 },
                    { 23, "98b052ec-1de5-45f8-95c6-9bf3beecda40", 2, null, "Justo eros, dapibus fusce neque, erat aliquet interdum, vestibulum, mi, ad elit sem feugiat vitae eget. Eu adipiscing a, nunc, viverra facilisis volutpat mattis, conubia euismod ultrices scelerisque dolor hac dapibus risus ligula at ullamcorper. Odio faucibus eros taciti elementum lacinia rhoncus nunc, adipiscing commodo, cursus primis leo. Porttitor non mi orci id praesent integer interdum, auctor, ultrices, sem nam. Sodales fringilla, luctus a porttitor, metus enim, nullam aptent dolor, vulputate dui nulla ex erat, ac feugiat, adipiscing.", new DateTime(2024, 3, 29, 2, 39, 50, 225, DateTimeKind.Local).AddTicks(5234), true, 22, "Per ligula ligula semper tortor odio quis ornare sed arcu porttitor sociosqu phasellus", "Integer quisque tempus", 195, "luctus-quisque-pretium", 224 },
                    { 24, "39fff519-b448-49d4-8f12-bc0843137e3c", 3, null, "Blandit tortor, ullamcorper rhoncus, at pulvinar, nulla, justo accumsan luctus et posuere interdum, sed, a. Orci, rhoncus, justo feugiat, iaculis cursus, arcu lobortis sed, posuere enim orci magna, nec. Sem, quam, vitae nullam turpis finibus placerat, porta consequat phasellus aliquam erat, nibh, tempor, non massa, duis platea. Nunc sapien quam maximus feugiat magna lacus nam eros consequat.", new DateTime(2024, 4, 4, 18, 15, 50, 228, DateTimeKind.Local).AddTicks(4678), true, 10, "Ante laoreet nibh tortor non vulputate consequat fusce lorem sed commodo nulla euismod", "Commodo porta lectus", 285, "felis-laoreet-blandit", 174 },
                    { 25, "98b052ec-1de5-45f8-95c6-9bf3beecda40", 6, null, "At massa placerat mi, ullamcorper dictumst felis cras ultricies commodo, adipiscing nec. Molestie dolor, nibh, ultricies maximus euismod fusce porttitor, faucibus tellus euismod, congue bibendum felis leo, in inceptos venenatis. Tempor finibus, et neque, fames sit quam donec aenean ultrices, morbi odio tellus. Viverra lorem tempus nisl malesuada dui, congue, auctor, hac rutrum tortor, nunc, vestibulum, bibendum, quam. Vivamus consequat dolor, bibendum porta, primis aptent condimentum gravida odio in, laoreet luctus, vestibulum tortor. Ante est velit hendrerit proin eget porttitor lectus eros, laoreet felis quis posuere, molestie nec, commodo, commodo euismod at.", new DateTime(2024, 3, 29, 3, 58, 50, 228, DateTimeKind.Local).AddTicks(9559), true, 21, "Aenean hendrerit nam quam vitae fringilla fermentum dapibus volutpat orci lectus curabitur phasellus", "Ac magna feugiat", 230, "quis-duis-efficitur", 214 },
                    { 26, "98b052ec-1de5-45f8-95c6-9bf3beecda40", 9, null, "Volutpat, porta conubia ante, purus placerat, tortor enim, eros, congue, euismod duis dolor nisl integer commodo interdum sapien. Interdum sem, lobortis aliquam vel maecenas ac, fames blandit ullamcorper molestie tortor bibendum, congue, feugiat nisi hac. Nam lectus, cursus aenean nec proin enim urna, amet ante rhoncus, auctor. Posuere, dolor torquent ante, convallis imperdiet tellus, erat, sagittis faucibus egestas quam. Lectus litora commodo, vulputate arcu eu auctor aptent faucibus ut ac. Felis urna lectus nec dolor, eu et class volutpat iaculis massa, arcu, pharetra blandit, posuere. Vel, porttitor, congue, viverra sed, platea urna metus dignissim mattis.", new DateTime(2024, 3, 30, 1, 10, 50, 229, DateTimeKind.Local).AddTicks(4753), true, 14, "Rutrum inceptos placerat nisl massa integer eros tortor ante pulvinar augue ad vel", "In nec elit", 162, "malesuada-mattis-placerat", 198 },
                    { 27, "98b052ec-1de5-45f8-95c6-9bf3beecda40", 9, null, "Varius inceptos sed, a porta, massa urna, mi, gravida nunc, ex, fermentum placerat, eros, purus eu. Sagittis enim, tempor, mauris nam velit et, sed vehicula mauris, varius gravida hac auctor, erat. Placerat ultrices, dui blandit laoreet, himenaeos semper mattis, nulla, feugiat sed cursus vivamus ante finibus. Porttitor hendrerit tempus posuere et cursus, convallis duis elit nunc per dignissim. Suspendisse mi, nec, condimentum commodo ultrices, dui, sem, dolor fermentum maecenas posuere ultricies commodo.", new DateTime(2024, 4, 2, 15, 54, 50, 229, DateTimeKind.Local).AddTicks(9710), true, 25, "Interdum cras lorem mattis proin dolor dolor arcu vestibulum laoreet nisl ultricies dui", "Neque sociosqu id", 109, "imperdiet-vel-varius", 243 },
                    { 28, "98b052ec-1de5-45f8-95c6-9bf3beecda40", 3, null, "Morbi ultrices duis euismod, vel, quam eu ornare diam arcu, ad inceptos nostra, pretium magna mi cursus, suspendisse vivamus. Est accumsan dignissim ad quis purus nisl at non, dolor, aenean tortor interdum elit adipiscing at, augue. Id tellus, taciti posuere neque orci, nibh, eget molestie quam, fusce pulvinar. Enim, non, sem, ut phasellus augue vestibulum rutrum adipiscing at condimentum vel. Sollicitudin sed, habitasse feugiat, in tortor ultrices condimentum ex, mattis, nibh.", new DateTime(2024, 3, 31, 13, 32, 50, 230, DateTimeKind.Local).AddTicks(4884), true, 12, "Tincidunt nostra viverra nec sagittis nullam vehicula malesuada lectus euismod neque vulputate lacinia", "Eget faucibus vitae", 216, "euismod-erat-vestibulum", 233 },
                    { 29, "39fff519-b448-49d4-8f12-bc0843137e3c", 5, null, "Mattis elit at, fusce auctor felis lectus malesuada tellus aptent viverra vel, venenatis. At, ultrices, ad dui, orci arcu rhoncus, pharetra sodales morbi magna, adipiscing nisi, nulla, elit dapibus neque. Mauris consectetur urna, quisque vitae sem integer elit elementum elit, nisl ligula auctor, torquent gravida euismod. Venenatis blandit, mi ipsum pulvinar rhoncus, sodales fringilla tristique rutrum facilisis nec et eros mauris quis auctor ligula. Ultrices, auctor, elementum nibh, vitae, magna sem, in tellus, arcu. Ligula, tempor eu, laoreet urna neque eros, id, molestie finibus, placerat nunc at egestas laoreet, euismod. Vehicula sollicitudin tristique nunc, orci ac, ultrices varius, massa, ultricies vestibulum vestibulum, porta.", new DateTime(2024, 3, 28, 5, 19, 50, 231, DateTimeKind.Local).AddTicks(110), true, 17, "Libero orci vehicula viverra sapien massa eros litora hendrerit donec vivamus varius lacinia", "Duis nam nunc", 288, "taciti-massa-ante", 269 },
                    { 30, "39fff519-b448-49d4-8f12-bc0843137e3c", 1, null, "Varius lacus litora ante dictumst fringilla sollicitudin cras vestibulum, malesuada luctus, morbi feugiat porta blandit erat nibh rutrum ac. Auctor, in, nam faucibus velit interdum fermentum laoreet, eros, vehicula cursus, elit donec urna, eget. Leo class mauris, tempus pharetra a hac metus ac, maecenas ex. Eleifend pulvinar, dictum mattis sodales egestas non erat erat, metus maecenas mi, feugiat, convallis accumsan ac posuere. Lacinia nisi, nunc, non, ligula, aptent augue scelerisque vitae malesuada conubia torquent ante erat consequat felis urna libero ac. Convallis pulvinar laoreet, finibus placerat maximus curabitur id ac a, semper vivamus sollicitudin sed, diam aenean ipsum risus. Interdum ultricies ad pharetra augue euismod sem, vivamus mi, nam fusce habitasse.", new DateTime(2024, 3, 28, 12, 30, 50, 231, DateTimeKind.Local).AddTicks(5312), true, 16, "Neque congue consequat vitae porttitor erat morbi class arcu erat laoreet convallis eu", "Elit tincidunt nam", 122, "odio-suspendisse-orci", 202 },
                    { 31, "39fff519-b448-49d4-8f12-bc0843137e3c", 9, null, "Condimentum finibus, bibendum torquent nunc aliquam velit nibh taciti quam, leo. Cursus quis, sem massa ultrices bibendum litora elit, porttitor, eros, ante porta fames. Augue dui, ultrices, fringilla, quis porta, class porttitor tortor elementum est sem, ex, et scelerisque lacinia luctus, finibus. Quam, non, duis volutpat, ligula mattis, ad neque, nisi nam nibh, finibus, sed, fringilla, et, erat, porttitor. Accumsan finibus, magna, consequat curabitur aliquam magna erat, pharetra bibendum, at pulvinar, sollicitudin volutpat, varius, fusce in. Interdum, vulputate adipiscing sodales massa mi mauris, consectetur et quis, fames morbi arcu, diam ex erat congue velit eu.", new DateTime(2024, 4, 3, 2, 45, 50, 236, DateTimeKind.Local).AddTicks(42), true, 20, "Odio mollis feugiat dapibus vehicula nunc ut finibus finibus lobortis feugiat maecenas condimentum", "Pulvinar vestibulum maximus", 202, "magna-urna-in", 202 },
                    { 32, "39fff519-b448-49d4-8f12-bc0843137e3c", 6, null, "In at velit scelerisque euismod, sagittis, orci, tincidunt vitae mi, tristique maximus a pretium ex, curabitur. Dui neque ex, imperdiet vulputate nisi fringilla, primis libero vestibulum, auctor, himenaeos sed nisi. Porta, ligula feugiat tellus torquent blandit, tellus, id odio, orci ligula, vestibulum molestie ut sit diam amet. Condimentum finibus vulputate mi feugiat tincidunt aliquam hac vel, habitasse ex ad eu, lobortis sociosqu tortor, aenean nunc, class. Ligula, urna a, fermentum pulvinar tortor turpis sagittis, imperdiet lacinia, fringilla at, hendrerit vitae at mauris, condimentum bibendum, amet. Efficitur vivamus aliquam turpis magna, velit sociosqu tincidunt molestie et volutpat, vehicula justo.", new DateTime(2024, 3, 29, 13, 59, 50, 237, DateTimeKind.Local).AddTicks(1393), true, 17, "Sociosqu ac dapibus torquent integer fusce orci a lacinia nunc mi rhoncus ad", "Placerat nunc commodo", 152, "pulvinar-id-id", 256 },
                    { 33, "39fff519-b448-49d4-8f12-bc0843137e3c", 5, null, "At lectus blandit nisi, inceptos urna, ante vestibulum, varius, eros, congue congue, sem, mi, nulla, venenatis. Nisi, cursus dictumst ultricies lectus rutrum faucibus molestie diam sagittis, porta, lorem, nulla, nec, litora imperdiet maximus nibh, auctor. Tempor, blandit, mi, ligula blandit taciti ad odio orci ultrices, quis, lorem auctor massa, metus sapien lobortis. Nisi, pharetra neque, ipsum maximus finibus, pulvinar, cras quam maecenas hendrerit faucibus neque vivamus. Blandit amet, lectus, nostra, volutpat, aliquam elit, viverra erat, tempus praesent. Scelerisque mi magna, eget leo fringilla, vel elit, orci id taciti. Lacinia, consectetur vivamus orci, quam tempor, eleifend, mattis, torquent dignissim auctor, dui.", new DateTime(2024, 3, 31, 6, 54, 50, 237, DateTimeKind.Local).AddTicks(5903), true, 28, "Nec sagittis lorem vestibulum a etiam lectus mauris primis adipiscing tortor mauris turpis", "Enim eget vel", 207, "venenatis-ligula-conubia", 237 },
                    { 34, "98b052ec-1de5-45f8-95c6-9bf3beecda40", 7, null, "Pulvinar efficitur feugiat nec taciti nullam posuere, convallis libero aptent. Sed, molestie habitasse vestibulum, justo posuere, dui, fermentum porta, eleifend. Massa, facilisis nunc sociosqu placerat porttitor, varius est molestie erat, convallis volutpat. Convallis tristique porta velit nulla at, tempus erat bibendum, ad dignissim. Fames vestibulum, mattis, viverra eu a, nisl efficitur sagittis, metus ante, interdum, himenaeos felis ipsum eros. Cursus, vel, venenatis vestibulum, eros, erat nisi, metus vivamus laoreet, praesent torquent feugiat dui quis lectus quis.", new DateTime(2024, 4, 6, 4, 28, 50, 237, DateTimeKind.Local).AddTicks(9909), true, 17, "Sem ante vehicula molestie metus congue feugiat tellus per sed pulvinar auctor nec", "Consectetur nullam in", 247, "tortor-tempor-felis", 170 },
                    { 35, "98b052ec-1de5-45f8-95c6-9bf3beecda40", 10, null, "Tempor, in, leo scelerisque egestas at, id porta, nec, nunc erat aliquet. Placerat risus non ut mauris etiam suscipit nibh, malesuada massa, inceptos rutrum massa sociosqu nisl sit. Erat, commodo, tempus porttitor, vitae convallis congue et sociosqu hac blandit, lobortis. Vehicula ultrices nec vestibulum, curabitur orci vivamus placerat neque ut erat, enim pharetra ipsum efficitur tempor nullam. Ut fusce tempor, quam conubia ipsum scelerisque ac quam, ante eget placerat, mi convallis magna cursus lobortis ullamcorper risus. Libero vehicula aptent primis nunc lacus fringilla, sed sociosqu pretium nisi. Aptent rhoncus, eleifend, orci, eros, feugiat facilisis mollis adipiscing bibendum dolor.", new DateTime(2024, 3, 31, 12, 6, 50, 238, DateTimeKind.Local).AddTicks(5646), true, 14, "Blandit malesuada justo ligula odio dapibus ex tortor risus rhoncus curabitur sollicitudin tristique", "Nulla nunc ultrices", 103, "placerat-auctor-eros", 128 },
                    { 36, "98b052ec-1de5-45f8-95c6-9bf3beecda40", 8, null, "Purus posuere, laoreet, et, lacinia convallis odio, tempor lectus ligula ornare taciti nibh. Orci inceptos tellus vitae varius, ac tincidunt lacinia, volutpat, eu, fringilla hendrerit himenaeos luctus congue, class et. Tempor, lacinia, vitae velit suspendisse aliquet laoreet gravida rutrum convallis lobortis nam nec amet accumsan dignissim auctor sagittis, proin. Accumsan hendrerit id enim sit tempor, pulvinar, fermentum ultrices pellentesque. Phasellus dictumst sodales aliquet tortor, donec duis torquent non accumsan.", new DateTime(2024, 4, 4, 17, 17, 50, 239, DateTimeKind.Local).AddTicks(316), true, 14, "Eu dui nam sed metus in ornare faucibus magna pretium auctor quis urna", "Aliquam molestie ligula", 174, "quisque-interdum-bibendum", 296 },
                    { 37, "98b052ec-1de5-45f8-95c6-9bf3beecda40", 9, null, "Vivamus auctor, vitae purus facilisis nec, pharetra volutpat vestibulum, pulvinar eros tincidunt molestie euismod, blandit, ex lacinia, diam. Porttitor phasellus cursus, nibh lacinia, curabitur litora neque, mattis, vulputate est velit tellus pharetra tempor faucibus scelerisque. Pellentesque pretium class per in ut vestibulum, porta, maecenas nec, quisque neque, dictumst auctor mollis at. Nostra, aliquam consectetur mattis, in laoreet, eu ultrices, feugiat, sapien pellentesque imperdiet. Diam pulvinar sit ullamcorper pulvinar, dictum dolor mi, elit posuere porttitor, tristique blandit tellus, id tellus nunc. Commodo tellus, ornare interdum, amet, purus ligula volutpat, conubia malesuada ultrices, rutrum suscipit.", new DateTime(2024, 4, 3, 13, 16, 50, 239, DateTimeKind.Local).AddTicks(4628), true, 15, "Purus interdum sed accumsan viverra habitasse porttitor enim lacus magna turpis hendrerit vestibulum", "Proin per porta", 183, "sagittis-porttitor-maximus", 116 },
                    { 38, "39fff519-b448-49d4-8f12-bc0843137e3c", 4, null, "Convallis leo euismod vestibulum, nibh, laoreet placerat, rhoncus, pellentesque euismod, lectus interdum neque, accumsan varius ante, magna, ultricies. Ultricies varius, neque, quam libero inceptos lacinia primis sem auctor, augue sem, et porta, mattis. Nullam bibendum orci, ultricies vel, metus hendrerit blandit vehicula mattis, est sociosqu eros, volutpat augue. Fringilla, neque malesuada blandit, eleifend, bibendum, semper maximus massa, enim, tempus ligula, tortor, nisi ante, cursus. Cursus nam praesent iaculis integer laoreet duis nulla finibus, commodo, arcu, arcu bibendum, quis.", new DateTime(2024, 4, 3, 20, 10, 50, 239, DateTimeKind.Local).AddTicks(7865), true, 13, "Feugiat bibendum egestas ut tincidunt posuere viverra amet cras mattis porta ex imperdiet", "Congue interdum varius", 234, "sagittis-vulputate-lobortis", 201 },
                    { 39, "39fff519-b448-49d4-8f12-bc0843137e3c", 1, null, "Consequat nisi, commodo, accumsan odio dolor sed, velit viverra dolor, in, vel, sit. Nisl aliquet vitae orci, sapien vitae, pulvinar fames conubia posuere. Ac, lobortis lectus, interdum nulla, varius, dictumst aliquam feugiat nunc. Integer ornare ut est maximus ultrices primis auctor, amet urna.", new DateTime(2024, 3, 27, 17, 26, 50, 240, DateTimeKind.Local).AddTicks(1852), true, 10, "Sapien commodo auctor malesuada mi condimentum curabitur consectetur aptent ac ac maecenas est", "Euismod erat platea", 154, "auctor-interdum-egestas", 107 },
                    { 40, "39fff519-b448-49d4-8f12-bc0843137e3c", 2, null, "Eleifend, eros eleifend metus accumsan faucibus cursus, odio, mauris, volutpat sed. Rhoncus id odio donec suscipit dui, arcu, aliquam sagittis, ad nibh. Vel arcu at, vestibulum, diam ipsum eros posuere eu nunc, mauris tempus id, hac phasellus ultricies risus venenatis erat. Posuere, nunc, purus ligula, laoreet, ultrices commodo, mauris, euismod, vel, mattis, sagittis, sollicitudin sit risus blandit luctus, felis at. Quis molestie et, morbi tortor, ligula, ultrices, eleifend, bibendum, hac auctor nam metus erat id. Primis at, vestibulum sem suscipit id elit ligula dui, magna, conubia hendrerit condimentum bibendum vitae.", new DateTime(2024, 3, 29, 16, 18, 50, 240, DateTimeKind.Local).AddTicks(7065), true, 26, "Cursus lectus enim orci sociosqu iaculis maecenas varius lacinia eu tincidunt ex lacinia", "Vehicula tempor vulputate", 292, "eu-amet-torquent", 269 },
                    { 41, "98b052ec-1de5-45f8-95c6-9bf3beecda40", 3, null, "Ornare commodo tempus elit, morbi dignissim quis mollis condimentum auctor, elit est nullam id, curabitur accumsan sagittis, efficitur. Suspendisse imperdiet semper conubia rutrum nulla convallis fringilla, sed vehicula duis vel. Mi himenaeos fames mollis porttitor, blandit placerat auctor pellentesque in, nibh erat suscipit non. Vestibulum nisl eleifend non, elit cursus inceptos pellentesque sed quam, nunc tempor, rutrum ligula, sollicitudin.", new DateTime(2024, 4, 4, 18, 35, 50, 241, DateTimeKind.Local).AddTicks(1034), true, 20, "Congue porttitor praesent amet non magna sed varius amet dolor quis consectetur placerat", "Rhoncus turpis interdum", 177, "bibendum-ac-mi", 170 },
                    { 42, "39fff519-b448-49d4-8f12-bc0843137e3c", 8, null, "Fusce magna pulvinar ullamcorper et erat, maximus non viverra varius, arcu sociosqu eleifend. Dui, bibendum erat lorem, viverra class pretium dolor, ultrices elit. Taciti lorem, vestibulum, tellus accumsan duis quisque dui, lacinia, phasellus eros, ad fermentum conubia faucibus fusce fringilla nisl eget. Egestas tincidunt nibh, tellus, bibendum, aenean nisl arcu libero urna. Commodo, dui amet, morbi quam commodo massa metus orci nulla, lorem, vitae. Euismod pulvinar dictumst per morbi congue, tincidunt quam, cursus elit vehicula elementum sodales platea amet. Enim, ex hac pellentesque ullamcorper at phasellus facilisis ad vehicula fringilla, massa, in.", new DateTime(2024, 4, 1, 13, 6, 50, 241, DateTimeKind.Local).AddTicks(7016), true, 10, "Velit varius sagittis feugiat faucibus purus hendrerit vel commodo porta euismod dapibus suspendisse", "Cursus dolor taciti", 156, "a-non-cursus", 109 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "CategoryId", "Modified", "Post Content", "Posted On", "Published", "Rate Count", "Short Description", "Title", "Total Rate", "UrlSlug", "View Count" },
                values: new object[,]
                {
                    { 43, "98b052ec-1de5-45f8-95c6-9bf3beecda40", 7, null, "Mauris, aliquet venenatis in velit enim nulla, est tempor, placerat laoreet. Condimentum rhoncus urna commodo, auctor dignissim sem vehicula maximus phasellus. Ligula, fames nunc, nec est feugiat, euismod, mollis eleifend, nulla. Enim, nunc risus ipsum tellus, sed vivamus sapien aenean lorem amet. A, ultrices, id laoreet odio, class iaculis tristique tortor vitae, lorem, commodo fusce erat tincidunt ex, morbi euismod. Habitasse nisi, donec ornare pharetra at felis pulvinar nunc, eleifend bibendum curabitur dictumst et, laoreet, congue per taciti. Quis velit dapibus euismod dui egestas eleifend, pharetra felis vivamus non rhoncus, id, scelerisque nec vestibulum.", new DateTime(2024, 4, 4, 13, 17, 50, 242, DateTimeKind.Local).AddTicks(2714), true, 28, "Ligula ex porta litora mi finibus maecenas eros pretium dolor erat lacus sed", "Hac nam nunc", 136, "class-porta-neque", 267 },
                    { 44, "39fff519-b448-49d4-8f12-bc0843137e3c", 10, null, "Aliquet placerat dictum nunc, duis integer a bibendum, suscipit magna ultrices, at, quam nostra. Ullamcorper ex feugiat, leo nulla, per curabitur dictum ex, at ligula, elementum nunc, mollis ultrices ultrices, commodo. Sociosqu nisi, sollicitudin commodo, molestie lectus mauris volutpat erat donec suspendisse at tristique augue. Libero dolor diam auctor lobortis aenean suspendisse arcu at iaculis platea placerat, euismod, feugiat, ultrices, laoreet feugiat. Quisque magna est sed, consequat mauris, lobortis pharetra molestie nulla, lacinia, nibh fusce. Vel, auctor, mi, libero mattis, euismod, posuere pellentesque scelerisque porttitor.", new DateTime(2024, 3, 31, 16, 28, 50, 242, DateTimeKind.Local).AddTicks(7955), true, 17, "Volutpat porta felis nulla nec praesent maximus aenean et semper dapibus vivamus cras", "Leo eu pretium", 258, "blandit-tellus-elit", 218 },
                    { 45, "98b052ec-1de5-45f8-95c6-9bf3beecda40", 7, null, "Orci, sagittis magna, cras dictumst mollis nisl quam himenaeos massa, maximus pulvinar, dictum egestas maecenas scelerisque class torquent tempor. Nisi consequat at blandit blandit, porta sociosqu quis, habitasse nisi, odio finibus, molestie pharetra neque, dolor praesent tellus. Habitasse dictum laoreet, urna ultricies hac taciti congue feugiat ad eros. Nibh cursus vitae, leo eu ut diam inceptos venenatis nulla, lacus vivamus vehicula dapibus aptent interdum nibh. Id sed quisque adipiscing sapien blandit, lobortis lacinia bibendum, in vel purus nisi, ante. Ex, rhoncus, quis volutpat lacinia sollicitudin ut ullamcorper aenean fringilla inceptos nibh tempor, sociosqu pretium a vehicula. Hac libero neque ligula pretium justo purus lacinia, efficitur maximus ultricies erat, rhoncus, orci, proin quam, vitae hendrerit.", new DateTime(2024, 4, 1, 20, 43, 50, 243, DateTimeKind.Local).AddTicks(4048), true, 20, "Et maecenas blandit enim condimentum orci proin ornare placerat diam nam massa vitae", "Pulvinar et ligula", 266, "ipsum-sociosqu-lorem", 236 },
                    { 46, "98b052ec-1de5-45f8-95c6-9bf3beecda40", 2, null, "Finibus, dapibus a venenatis urna vivamus orci, lectus, turpis rutrum mi, hac vel, per. Ad venenatis id mattis pellentesque tortor placerat lorem iaculis viverra diam adipiscing urna mi. Erat ligula eu mi et, lorem, etiam iaculis hendrerit accumsan ad feugiat, felis posuere. Praesent varius sapien felis finibus, nostra, vitae est neque, condimentum conubia maecenas bibendum, sodales vivamus luctus, quis, tristique.", new DateTime(2024, 4, 3, 7, 57, 50, 243, DateTimeKind.Local).AddTicks(7980), true, 18, "Interdum sociosqu mauris per phasellus lacinia leo quisque tortor tristique maximus integer proin", "Lacinia aliquam nec", 170, "class-interdum-mi", 154 },
                    { 47, "39fff519-b448-49d4-8f12-bc0843137e3c", 9, null, "Dolor ante, lorem taciti erat, congue a, himenaeos litora enim, pulvinar, lacinia sed, vivamus aptent viverra cursus. Varius eros, vitae nec sem, aptent ultricies tincidunt habitasse vitae, dictum blandit congue neque, pretium. Felis dignissim tortor, tincidunt maximus fringilla lacinia, lobortis vel risus molestie tempor, cursus posuere, lectus magna integer ipsum nisi. Imperdiet sodales eros ornare nostra, phasellus nam tortor augue orci, volutpat quisque dictum vel, quam, eget elit eros. Viverra amet suspendisse nisl neque, ullamcorper ornare sociosqu mattis sollicitudin feugiat, fringilla, sed duis tempor. Volutpat lacinia, congue blandit sed quisque pulvinar rhoncus, interdum dui, feugiat cras sit consectetur ex volutpat, semper.", new DateTime(2024, 4, 5, 18, 4, 50, 244, DateTimeKind.Local).AddTicks(3137), true, 11, "Varius fusce enim leo posuere enim sem accumsan ornare vulputate blandit mauris posuere", "Et nisi eleifend", 240, "maximus-scelerisque-porta", 235 },
                    { 48, "39fff519-b448-49d4-8f12-bc0843137e3c", 8, null, "Arcu, convallis molestie platea et, dictum faucibus felis a, ultricies finibus, at. Mi sed, at, dui dolor, cursus lobortis interdum, ante, nibh erat, magna, praesent cras donec bibendum. Euismod, semper maecenas magna, feugiat, congue nibh magna imperdiet pellentesque varius tempor, mattis. Feugiat diam porta magna accumsan nec convallis elementum ultricies hendrerit ultrices, per. Porttitor, pulvinar, id dictum nibh, malesuada placerat, aptent ac, lacus tellus, neque id, platea lacinia magna, amet, mattis, sem. Fames quis sapien pulvinar, sem cursus litora curabitur lacus quam, amet volutpat nisi.", new DateTime(2024, 4, 4, 12, 41, 50, 244, DateTimeKind.Local).AddTicks(8230), true, 27, "Pretium tortor adipiscing lacinia ligula enim felis neque dictum mi nibh vitae semper", "Condimentum ac odio", 212, "tortor-sollicitudin-rhoncus", 179 },
                    { 49, "98b052ec-1de5-45f8-95c6-9bf3beecda40", 7, null, "Vel, volutpat, pulvinar dapibus facilisis nulla dolor praesent nibh fames iaculis magna, eu urna, suspendisse hac eleifend ultrices. Erat donec sem neque, elit luctus aliquam est nec mauris sollicitudin ligula condimentum arcu, pharetra lectus. Sodales pulvinar pulvinar, faucibus interdum, luctus nisi nisi, fringilla, cursus, at, varius, cursus lectus, finibus dictum class. Ac, ullamcorper eros, lorem ex, mi, quisque cursus, nulla urna, leo, velit sed volutpat faucibus. Proin eu neque tempor in, vel, vestibulum, euismod, id ac. Tempus nullam laoreet, feugiat, nulla taciti arcu eleifend interdum, venenatis. Ac, quisque vivamus sed inceptos odio, euismod, elit eleifend, duis enim est faucibus vestibulum, tempus.", new DateTime(2024, 4, 3, 20, 40, 50, 245, DateTimeKind.Local).AddTicks(4757), true, 19, "Curabitur elit lacus aptent porta aliquam torquent pulvinar vel phasellus at tincidunt vitae", "Leo himenaeos tortor", 239, "bibendum-vestibulum-auctor", 189 },
                    { 50, "98b052ec-1de5-45f8-95c6-9bf3beecda40", 10, null, "Per tempor pulvinar, congue in, mollis euismod, lectus, purus ante tristique porttitor hac nulla, elementum bibendum est. Facilisis bibendum sed arcu tellus, varius ex, tempor, enim porta, ad euismod, class lorem. Odio auctor, eu, iaculis non, tellus, lobortis taciti sed mattis. Phasellus eros, quam non mollis class lectus, mi felis velit.", new DateTime(2024, 4, 3, 5, 28, 50, 245, DateTimeKind.Local).AddTicks(9410), true, 20, "Tortor massa rhoncus elementum ac fringilla aliquam feugiat mi maximus libero cursus porttitor", "Eleifend nibh massa", 101, "platea-vitae-commodo", 227 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "e469389c-f466-4f50-b93d-3e3a60e8ed5f", "39fff519-b448-49d4-8f12-bc0843137e3c" },
                    { "0d6e9646-489c-4abd-8e80-d2a9d7cf96f6", "98b052ec-1de5-45f8-95c6-9bf3beecda40" },
                    { "4f5ba271-c697-4175-855d-ee8896e668ef", "b5ed2179-74c5-4406-b679-9268517256c9" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentHeader", "CommentText", "CommentTime", "Email", "Name", "PostId" },
                values: new object[,]
                {
                    { 1, "Mi nisi amet", "Dictum elementum auctor dolor nisi, dictumst amet, ex pulvinar, convallis. Massa eu odio odio, pellentesque tempor quis sed nec, a.", new DateTime(2024, 3, 30, 20, 8, 50, 247, DateTimeKind.Local).AddTicks(4227), "volutpat@auctor.com", "Eu blandit", 12 },
                    { 2, "Auctor fames tempor", "Pellentesque curabitur magna, at, hendrerit condimentum ac, himenaeos laoreet amet, hac praesent lobortis ante, mollis. Hendrerit ultricies integer ante sollicitudin ultrices, eleifend himenaeos platea ad viverra ex, praesent erat.", new DateTime(2024, 3, 29, 10, 37, 50, 247, DateTimeKind.Local).AddTicks(7397), "feugiat@nisi.com", "Nisi finibus", 6 },
                    { 3, "Eleifend sodales tortor", "Mattis, massa, fames hendrerit libero a, mattis urna amet molestie. Sagittis, vitae est etiam eros, at, dictum quam, placerat, id ante, litora mollis aptent interdum, diam.", new DateTime(2024, 4, 1, 6, 42, 50, 248, DateTimeKind.Local).AddTicks(5148), "et@posuere.com", "Nunc ligula", 38 },
                    { 4, "Ultrices nibh consequat", "Turpis tempor euismod, nisi, quis, luctus blandit ac nunc non, ad.", new DateTime(2024, 4, 4, 2, 26, 50, 248, DateTimeKind.Local).AddTicks(8181), "condimentum@vulputate.com", "Eleifend quis", 13 },
                    { 5, "Adipiscing phasellus finibus", "Bibendum, imperdiet nulla lectus blandit, vehicula ullamcorper sem, nisi convallis quis, dolor dictum lacus quam nec proin ornare vitae. Congue, erat mattis pulvinar laoreet, posuere, vulputate nunc tristique hac gravida.", new DateTime(2024, 4, 3, 7, 30, 50, 249, DateTimeKind.Local).AddTicks(1933), "eros@lorem.com", "Tortor dapibus", 3 },
                    { 6, "Tellus sollicitudin hac", "Pulvinar, vitae ac sapien aenean porta, ligula, at lectus himenaeos ultrices, posuere, molestie arcu, commodo, ultrices proin.", new DateTime(2024, 4, 3, 22, 12, 50, 249, DateTimeKind.Local).AddTicks(5794), "magna@nunc.com", "Rhoncus maximus", 32 },
                    { 7, "In rhoncus semper", "Congue massa cursus, dictum odio molestie orci, erat, morbi inceptos tincidunt pulvinar, dolor. Vestibulum, litora diam eu, habitasse ligula feugiat mauris ultrices, blandit.", new DateTime(2024, 4, 5, 7, 1, 50, 249, DateTimeKind.Local).AddTicks(9272), "gravida@proin.com", "Donec dui", 8 },
                    { 8, "Nulla aliquam non", "Dolor curabitur nostra, bibendum, proin etiam finibus porta ultrices, class fames luctus.", new DateTime(2024, 3, 29, 11, 27, 50, 250, DateTimeKind.Local).AddTicks(2199), "arcu@interdum.com", "Euismod quam", 40 },
                    { 9, "Semper sollicitudin aliquet", "Auctor, at, litora lobortis sodales vel laoreet, magna, bibendum scelerisque metus dolor, justo sollicitudin adipiscing neque, dapibus euismod mollis. Torquent ultrices blandit, hac finibus proin maecenas nibh, libero vitae leo tristique mattis et purus odio.", new DateTime(2024, 3, 30, 8, 35, 50, 250, DateTimeKind.Local).AddTicks(5590), "arcu@nibh.com", "Efficitur etiam", 33 },
                    { 10, "Ac tristique ante", "Quis, tempus himenaeos posuere, pellentesque tempor dapibus dignissim porta, sociosqu ad nunc inceptos leo ornare.", new DateTime(2024, 4, 5, 19, 16, 50, 250, DateTimeKind.Local).AddTicks(8395), "et@suspendisse.com", "Odio pharetra", 21 },
                    { 11, "Tincidunt vestibulum elementum", "Porta, ultrices, cursus arcu, integer venenatis fusce consequat magna ante, ac, vulputate sapien aliquet gravida nec.", new DateTime(2024, 3, 31, 18, 37, 50, 251, DateTimeKind.Local).AddTicks(1343), "dolor@amet.com", "Cursus quis", 39 },
                    { 12, "Posuere in quisque", "Facilisis egestas porta, consectetur tristique nostra, malesuada placerat, per tellus conubia. Hendrerit mauris, ex nullam nisl ex, mauris consequat fringilla laoreet tempor, egestas sed erat.", new DateTime(2024, 3, 28, 16, 3, 50, 251, DateTimeKind.Local).AddTicks(4864), "augue@magna.com", "Sem inceptos", 9 },
                    { 13, "Pretium sem dictum", "Sodales id, vestibulum aptent sollicitudin cras eu, placerat, posuere volutpat, risus ipsum eleifend elit, per. Eget tortor enim diam porta ipsum suscipit dapibus malesuada vestibulum scelerisque primis varius cursus.", new DateTime(2024, 4, 2, 9, 34, 50, 251, DateTimeKind.Local).AddTicks(8106), "quisque@sem.com", "Amet a", 29 },
                    { 14, "Fermentum nulla nunc", "Nulla, tortor, dui nisl id vestibulum, dolor mollis congue, litora porta, fames. Volutpat, venenatis platea et, eleifend, sagittis erat lacinia, orci vestibulum, aptent tristique fusce vivamus neque ultricies erat, pulvinar, ut.", new DateTime(2024, 3, 28, 21, 55, 50, 252, DateTimeKind.Local).AddTicks(1517), "phasellus@primis.com", "Convallis proin", 43 },
                    { 15, "In efficitur orci", "Donec congue pellentesque lectus dui, eu feugiat, magna posuere, habitasse molestie etiam quisque imperdiet torquent nisi, at auctor quam. Dictumst in, enim, congue, dapibus eget ultrices, neque, consectetur placerat integer.", new DateTime(2024, 3, 27, 14, 29, 50, 252, DateTimeKind.Local).AddTicks(4933), "dolor@eros.com", "Quam non", 47 },
                    { 16, "Ultrices fermentum neque", "Lacus erat ex varius, lorem, lorem magna suspendisse sagittis, laoreet sem arcu eleifend. Ipsum interdum dui nunc, hac habitasse iaculis consectetur turpis venenatis sem, eros massa, eleifend sit hendrerit sagittis tellus, tortor.", new DateTime(2024, 4, 5, 15, 50, 50, 252, DateTimeKind.Local).AddTicks(8567), "orci@aliquam.com", "Nisi lobortis", 17 },
                    { 17, "Tellus neque class", "Ipsum blandit sem commodo, nec, lectus tempor, quam, eget nullam lorem, tortor a tortor, sed. Vulputate pulvinar, imperdiet curabitur nibh fusce taciti aliquam porttitor, rutrum augue nostra, semper nisl feugiat, faucibus.", new DateTime(2024, 3, 31, 7, 48, 50, 253, DateTimeKind.Local).AddTicks(1918), "quam@turpis.com", "Id conubia", 43 },
                    { 18, "Laoreet lectus lorem", "Dui ornare nam ad suspendisse finibus, metus vulputate quis fusce iaculis velit ex, interdum, laoreet eleifend, duis.", new DateTime(2024, 4, 6, 11, 12, 50, 253, DateTimeKind.Local).AddTicks(4606), "fringilla@cursus.com", "Nostra ultricies", 23 },
                    { 19, "Tempus lacinia arcu", "Proin ultrices, arcu sodales convallis est vestibulum felis pellentesque fringilla, ligula posuere. Erat nam bibendum, nulla id dictumst elit, et, praesent tortor, euismod dignissim pulvinar, tristique egestas ante convallis taciti orci.", new DateTime(2024, 3, 29, 11, 31, 50, 253, DateTimeKind.Local).AddTicks(7899), "cursus@aenean.com", "Semper porta", 16 },
                    { 20, "Adipiscing diam sem", "Ultrices, vehicula aptent nullam metus turpis per hendrerit lobortis quam proin augue volutpat, non, convallis ante faucibus.", new DateTime(2024, 3, 29, 11, 11, 50, 254, DateTimeKind.Local).AddTicks(831), "volutpat@litora.com", "Tempor ac", 39 },
                    { 21, "Consequat iaculis nec", "Mollis accumsan orci, dapibus curabitur tempor, sapien nibh, habitasse vitae, ultricies. Lacinia, a, nec, auctor, cursus, nisl tempus suscipit in scelerisque enim maximus.", new DateTime(2024, 3, 27, 15, 1, 50, 254, DateTimeKind.Local).AddTicks(4206), "enim@platea.com", "Id orci", 18 },
                    { 22, "Platea leo aptent", "Elit ullamcorper quisque molestie commodo inceptos nullam ultrices pellentesque faucibus nibh.", new DateTime(2024, 3, 31, 5, 35, 50, 254, DateTimeKind.Local).AddTicks(7132), "volutpat@maecenas.com", "Suscipit nisl", 9 },
                    { 23, "Euismod blandit lacinia", "Dui sagittis, vel, et, placerat, adipiscing vivamus risus ullamcorper eu gravida erat, interdum, nostra, ipsum molestie. Convallis eu hendrerit velit habitasse a, tellus orci ipsum vivamus dapibus id, neque.", new DateTime(2024, 3, 28, 3, 45, 50, 255, DateTimeKind.Local).AddTicks(539), "sed@dui.com", "Ex vestibulum", 45 },
                    { 24, "Massa sem posuere", "Dictum adipiscing maximus facilisis etiam habitasse sem massa, pharetra mauris, ex molestie vestibulum, vel. Non, sem sit diam sem, tempor consectetur vulputate orci consequat leo eleifend, dapibus suspendisse amet, congue ac, lacinia eros.", new DateTime(2024, 3, 28, 8, 20, 50, 255, DateTimeKind.Local).AddTicks(4036), "leo@posuere.com", "Elit mauris", 11 },
                    { 25, "Posuere purus sapien", "Pellentesque sagittis, pharetra blandit, praesent ultrices curabitur rutrum laoreet posuere, ante luctus, lorem, primis vulputate dapibus.", new DateTime(2024, 4, 3, 5, 12, 50, 255, DateTimeKind.Local).AddTicks(6790), "odio@id.com", "Mi eu", 13 },
                    { 26, "Tempor finibus id", "Gravida nisi, ligula porttitor vestibulum diam neque blandit faucibus orci, nulla, eleifend ultrices, mollis posuere justo. Bibendum amet lorem ultricies fames dui fringilla, nec ac, neque sed, aptent.", new DateTime(2024, 4, 1, 4, 22, 50, 256, DateTimeKind.Local).AddTicks(267), "ornare@hac.com", "Pulvinar vehicula", 34 },
                    { 27, "Varius fringilla nullam", "Amet, magna porttitor, facilisis porttitor dui lorem sociosqu mauris, quis, vestibulum amet sem, cras pulvinar.", new DateTime(2024, 4, 5, 12, 8, 50, 256, DateTimeKind.Local).AddTicks(3144), "fames@integer.com", "Eu orci", 21 },
                    { 28, "Sed vel nec", "Class sem, malesuada nibh nulla, sagittis, consequat sodales integer inceptos egestas sagittis aenean feugiat fringilla feugiat, at.", new DateTime(2024, 3, 29, 13, 36, 50, 256, DateTimeKind.Local).AddTicks(6021), "primis@tellus.com", "Nostra ad", 17 },
                    { 29, "Cursus enim dapibus", "Et, orci praesent turpis ligula odio dictum tempus dignissim tortor varius class consectetur neque. Pellentesque class placerat nibh, nunc fringilla venenatis mauris, magna nulla, porttitor elit, donec lacinia volutpat.", new DateTime(2024, 3, 28, 18, 52, 50, 256, DateTimeKind.Local).AddTicks(9485), "eu@quam.com", "Volutpat sollicitudin", 9 },
                    { 30, "Massa sapien suscipit", "Consectetur mi, praesent tempor amet, tempor, taciti purus magna, habitasse pretium. Cras varius, convallis porttitor sed eros, gravida est aenean malesuada varius arcu scelerisque mollis.", new DateTime(2024, 4, 1, 11, 4, 50, 257, DateTimeKind.Local).AddTicks(2882), "lacinia@rutrum.com", "Litora dolor", 13 },
                    { 31, "Sollicitudin suspendisse ullamcorper", "Primis cursus mattis, hac diam ex aptent erat, efficitur interdum.", new DateTime(2024, 4, 5, 0, 40, 50, 257, DateTimeKind.Local).AddTicks(5697), "at@efficitur.com", "Tincidunt ligula", 47 },
                    { 32, "Habitasse euismod mauris", "Tortor, tortor sociosqu hac fringilla, tellus odio, elit luctus fusce efficitur nulla, eros, aliquet. Pharetra ex, himenaeos sagittis, proin mauris facilisis dapibus tempor rhoncus vitae, hendrerit auctor justo nibh.", new DateTime(2024, 3, 29, 23, 32, 50, 257, DateTimeKind.Local).AddTicks(9123), "velit@per.com", "Vehicula sagittis", 46 },
                    { 33, "Consectetur nec tortor", "Ante ultrices, leo, est elementum dapibus congue, fringilla mollis imperdiet odio suscipit a, dictum tempor purus massa. Congue egestas ex id, porttitor magna, suspendisse cursus quisque vulputate integer ipsum eleifend, arcu non ad sollicitudin primis malesuada.", new DateTime(2024, 3, 29, 13, 7, 50, 258, DateTimeKind.Local).AddTicks(2622), "vestibulum@amet.com", "Vel quam", 15 },
                    { 34, "Cursus fusce torquent", "Ex mi, vitae, laoreet, suspendisse sodales risus quisque massa et dignissim in, lectus, interdum ornare dolor, ante. Molestie lectus feugiat porttitor sed, iaculis ligula, ligula mauris, magna.", new DateTime(2024, 3, 28, 5, 6, 50, 258, DateTimeKind.Local).AddTicks(6046), "ligula@torquent.com", "Erat molestie", 6 },
                    { 35, "Nisi posuere neque", "Laoreet porta, sapien at efficitur quam, quam enim, nec, bibendum auctor vestibulum non. Mi hac blandit elementum convallis turpis luctus, id, habitasse libero dolor, elit mauris euismod, tempor, feugiat, sodales lectus.", new DateTime(2024, 4, 5, 8, 32, 50, 258, DateTimeKind.Local).AddTicks(9180), "ac@sem.com", "Luctus efficitur", 15 },
                    { 36, "Luctus fringilla tempus", "Ultricies tincidunt ante porttitor, eleifend at nec, gravida finibus, ut felis enim pulvinar congue dictumst primis ex, sapien nisl. Massa orci ornare faucibus urna fermentum vitae, posuere, ultricies velit nec, id, dui hendrerit dictum varius placerat.", new DateTime(2024, 4, 2, 3, 31, 50, 259, DateTimeKind.Local).AddTicks(2835), "volutpat@primis.com", "Magna a", 47 },
                    { 37, "Rhoncus ut nec", "Nisi libero ex pulvinar, placerat vulputate tempus mi, integer est pulvinar vitae, enim nulla, justo. Feugiat, class odio commodo vulputate blandit dignissim elit nec, integer posuere.", new DateTime(2024, 3, 29, 19, 58, 50, 259, DateTimeKind.Local).AddTicks(6818), "orci@convallis.com", "Tristique eros", 8 },
                    { 38, "Adipiscing litora mauris", "Maximus tempor, pulvinar, nam porttitor, neque, suspendisse felis porttitor venenatis eget arcu habitasse vitae.", new DateTime(2024, 3, 30, 14, 17, 50, 260, DateTimeKind.Local).AddTicks(255), "lectus@orci.com", "Cras varius", 34 },
                    { 39, "Enim dictum non", "Quis lacinia, per eleifend laoreet, primis sed, pharetra curabitur amet pretium varius, dolor leo, ligula fermentum.", new DateTime(2024, 3, 28, 1, 52, 50, 260, DateTimeKind.Local).AddTicks(3599), "interdum@maximus.com", "Bibendum mattis", 16 },
                    { 40, "Varius porttitor hac", "Et, mi non, sed justo consequat vitae, enim commodo, tempus dictumst bibendum, augue porta. Volutpat nam curabitur vehicula venenatis eu, fringilla morbi praesent ornare nunc, mi, habitasse congue, accumsan magna ipsum.", new DateTime(2024, 4, 2, 6, 35, 50, 260, DateTimeKind.Local).AddTicks(7223), "phasellus@feugiat.com", "Leo a", 6 },
                    { 41, "Felis urna feugiat", "Erat, dolor, et, massa nisi nulla, mi, urna, ac laoreet cursus nec sodales sollicitudin iaculis. Lorem augue imperdiet dapibus mi mi, sollicitudin erat, maecenas tellus, ligula aliquet ac, mattis.", new DateTime(2024, 3, 30, 5, 56, 50, 261, DateTimeKind.Local).AddTicks(563), "cras@leo.com", "Molestie nullam", 37 },
                    { 42, "Vehicula id sed", "Eros mi elit, lacus conubia augue sem, quam quisque mollis lectus taciti ac libero.", new DateTime(2024, 3, 30, 12, 52, 50, 261, DateTimeKind.Local).AddTicks(3416), "aenean@sagittis.com", "Id sociosqu", 21 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentHeader", "CommentText", "CommentTime", "Email", "Name", "PostId" },
                values: new object[,]
                {
                    { 43, "Feugiat tellus class", "Malesuada sociosqu varius, rhoncus volutpat molestie elementum lacinia, massa, turpis ex etiam taciti leo, blandit quis, lectus. Mattis aenean malesuada massa, et, lectus ligula, eros rutrum cursus, ligula pretium mollis blandit.", new DateTime(2024, 4, 3, 22, 24, 50, 261, DateTimeKind.Local).AddTicks(6745), "euismod@lobortis.com", "Ante massa", 42 },
                    { 44, "Imperdiet a hendrerit", "Vitae, finibus placerat, imperdiet laoreet, neque, a, sagittis, in, class purus hac ultrices, bibendum interdum mi hendrerit nunc.", new DateTime(2024, 4, 2, 0, 38, 50, 261, DateTimeKind.Local).AddTicks(9511), "a@tellus.com", "Nostra pretium", 38 },
                    { 45, "Fringilla lorem consequat", "Commodo, fringilla, fermentum volutpat, lectus, vitae cursus, primis ligula fusce elementum cras mi. Augue ac, eu elit, tempus lacus ipsum himenaeos nibh, neque bibendum posuere, eros non massa.", new DateTime(2024, 3, 30, 17, 44, 50, 262, DateTimeKind.Local).AddTicks(2823), "orci@mattis.com", "Nulla primis", 28 },
                    { 46, "Sit ac auctor", "Morbi etiam pellentesque a vel, vitae, fames rhoncus lacinia, dapibus posuere eleifend, porta, commodo.", new DateTime(2024, 4, 5, 13, 45, 50, 262, DateTimeKind.Local).AddTicks(5702), "posuere@neque.com", "A nec", 31 },
                    { 47, "At justo pharetra", "Rutrum tempus eleifend massa, sodales taciti dignissim congue vehicula laoreet, duis sed, cras dapibus faucibus.", new DateTime(2024, 4, 2, 8, 57, 50, 262, DateTimeKind.Local).AddTicks(8558), "ac@eleifend.com", "In fringilla", 27 },
                    { 48, "Auctor orci sem", "Adipiscing ante sed dapibus luctus, ligula nunc, tempor, erat, nisl efficitur at luctus venenatis sit aptent.", new DateTime(2024, 4, 4, 22, 21, 50, 263, DateTimeKind.Local).AddTicks(1462), "euismod@arcu.com", "Nunc ex", 13 },
                    { 49, "Nibh orci at", "Laoreet nibh integer auctor vitae, nunc orci, ad habitasse erat proin mattis tempor.", new DateTime(2024, 3, 30, 21, 28, 50, 263, DateTimeKind.Local).AddTicks(4412), "posuere@vestibulum.com", "Eleifend mattis", 30 },
                    { 50, "Nostra tellus erat", "At donec sit congue arcu, iaculis aenean sodales taciti blandit. Mattis adipiscing finibus lacinia pulvinar augue mauris dui luctus, malesuada porttitor velit pretium platea consequat suscipit elit.", new DateTime(2024, 3, 30, 8, 56, 50, 263, DateTimeKind.Local).AddTicks(7756), "id@non.com", "Vulputate at", 7 }
                });

            migrationBuilder.InsertData(
                table: "PostTagMaps",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 1, 10 },
                    { 1, 15 },
                    { 2, 1 },
                    { 2, 3 },
                    { 2, 15 },
                    { 3, 4 },
                    { 3, 9 },
                    { 3, 19 },
                    { 4, 3 },
                    { 4, 10 },
                    { 4, 13 },
                    { 5, 10 },
                    { 5, 16 },
                    { 5, 20 },
                    { 6, 15 },
                    { 6, 16 },
                    { 6, 20 },
                    { 7, 5 },
                    { 7, 17 },
                    { 7, 19 },
                    { 8, 1 },
                    { 8, 5 },
                    { 8, 11 },
                    { 9, 2 },
                    { 9, 7 },
                    { 9, 14 },
                    { 10, 1 },
                    { 10, 12 },
                    { 10, 18 },
                    { 11, 2 },
                    { 11, 3 },
                    { 11, 8 },
                    { 12, 8 }
                });

            migrationBuilder.InsertData(
                table: "PostTagMaps",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { 12, 10 },
                    { 12, 18 },
                    { 13, 6 },
                    { 13, 10 },
                    { 13, 13 },
                    { 14, 1 },
                    { 14, 3 },
                    { 14, 13 },
                    { 15, 2 },
                    { 15, 15 },
                    { 15, 19 },
                    { 16, 1 },
                    { 16, 9 },
                    { 16, 10 },
                    { 17, 1 },
                    { 17, 14 },
                    { 17, 15 },
                    { 18, 12 },
                    { 18, 16 },
                    { 18, 19 },
                    { 19, 2 },
                    { 19, 11 },
                    { 19, 17 },
                    { 20, 7 },
                    { 20, 14 },
                    { 20, 18 },
                    { 21, 2 },
                    { 21, 4 },
                    { 21, 12 },
                    { 22, 8 },
                    { 22, 9 },
                    { 22, 15 },
                    { 23, 2 },
                    { 23, 7 },
                    { 23, 8 },
                    { 24, 8 },
                    { 24, 9 },
                    { 24, 11 },
                    { 25, 2 },
                    { 25, 13 },
                    { 25, 18 },
                    { 26, 12 }
                });

            migrationBuilder.InsertData(
                table: "PostTagMaps",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { 26, 16 },
                    { 26, 20 },
                    { 27, 1 },
                    { 27, 8 },
                    { 27, 13 },
                    { 28, 8 },
                    { 28, 12 },
                    { 28, 14 },
                    { 29, 6 },
                    { 29, 8 },
                    { 29, 11 },
                    { 30, 3 },
                    { 30, 7 },
                    { 30, 10 },
                    { 31, 10 },
                    { 31, 15 },
                    { 31, 16 },
                    { 32, 2 },
                    { 32, 7 },
                    { 32, 9 },
                    { 33, 7 },
                    { 33, 10 },
                    { 33, 14 },
                    { 34, 2 },
                    { 34, 5 },
                    { 34, 7 },
                    { 35, 8 },
                    { 35, 10 },
                    { 35, 20 },
                    { 36, 2 },
                    { 36, 9 },
                    { 36, 19 },
                    { 37, 3 },
                    { 37, 5 },
                    { 37, 12 },
                    { 38, 4 },
                    { 38, 6 },
                    { 38, 13 },
                    { 39, 2 },
                    { 39, 10 },
                    { 39, 17 },
                    { 40, 4 }
                });

            migrationBuilder.InsertData(
                table: "PostTagMaps",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { 40, 17 },
                    { 40, 18 },
                    { 41, 2 },
                    { 41, 14 },
                    { 41, 19 },
                    { 42, 8 },
                    { 42, 12 },
                    { 42, 18 },
                    { 43, 1 },
                    { 43, 8 },
                    { 43, 10 },
                    { 44, 5 },
                    { 44, 6 },
                    { 44, 13 },
                    { 45, 3 },
                    { 45, 6 },
                    { 45, 8 },
                    { 46, 2 },
                    { 46, 6 },
                    { 46, 12 },
                    { 47, 8 },
                    { 47, 10 },
                    { 47, 20 },
                    { 48, 4 },
                    { 48, 6 },
                    { 48, 12 },
                    { 49, 3 },
                    { 49, 6 },
                    { 49, 9 },
                    { 50, 5 },
                    { 50, 10 },
                    { 50, 12 }
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

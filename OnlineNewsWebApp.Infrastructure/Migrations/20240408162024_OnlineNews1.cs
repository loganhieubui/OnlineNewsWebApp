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
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                    { 1, "Mollis id maecenas commodo posuere dapibus blandit elementum luctus vehicula lacus mattis", "Lacinia aliquam" },
                    { 2, "Quisque metus porttitor lobortis dictumst mi ex fringilla fermentum condimentum vehicula eu", "Per hendrerit" },
                    { 3, "Litora morbi suscipit nibh magna taciti efficitur consequat tortor ligula cursus quis", "Eros nunc" },
                    { 4, "Habitasse luctus maximus fringilla urna vitae ullamcorper euismod ex sem mollis tempus", "Mi quis" },
                    { 5, "A dictumst litora integer maximus lectus nulla non interdum a lectus dictum", "Fusce turpis" },
                    { 6, "Nostra porttitor mattis suscipit tempor non cursus ut sed in etiam fermentum", "Commodo consectetur" },
                    { 7, "Molestie morbi suspendisse est blandit dictum orci inceptos lectus malesuada vivamus proin", "Odio odio" },
                    { 8, "Volutpat ipsum sollicitudin semper interdum tristique habitasse tempus accumsan velit eu dui", "Lacinia tincidunt" },
                    { 9, "Quam tincidunt posuere mattis varius finibus euismod fringilla eleifend enim dapibus volutpat", "Placerat curabitur" },
                    { 10, "Elit bibendum a eu rhoncus proin vehicula volutpat malesuada porttitor mattis sem", "Integer enim" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "27cef948-cd91-4ae1-977b-f1320e13aff5", "f1ba5e95-3e9d-4d76-bdc2-a866f73edfe7", "Admin", "ADMIN" },
                    { "50aa55ba-fa89-4653-91e6-3fa9100476db", "3556f72c-a380-400d-9763-03a879bfd464", "Writer", "WRITER" },
                    { "dac92444-87c7-47a8-a88a-1c2a21bad1c4", "d2aaeceb-c21e-4e43-aada-bf1ce2bcc26a", "Reader", "READER" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Count", "Name" },
                values: new object[,]
                {
                    { 1, 6, "Tortor cras convallis" },
                    { 2, 10, "Tellus class placerat" },
                    { 3, 10, "Primis sollicitudin quam" },
                    { 4, 9, "Phasellus egestas elit" },
                    { 5, 6, "Nunc pulvinar viverra" },
                    { 6, 10, "Sociosqu morbi ante" },
                    { 7, 9, "Sapien mattis sed" },
                    { 8, 7, "Diam porta auctor" },
                    { 9, 6, "Et dictum id" },
                    { 10, 7, "Rutrum hac sed" },
                    { 11, 7, "Nam quis odio" },
                    { 12, 6, "Lacinia eros dolor" },
                    { 13, 9, "Commodo accumsan ac" },
                    { 14, 8, "Nunc ornare ligula" },
                    { 15, 5, "Ac nostra neque" },
                    { 16, 6, "Ipsum porta vitae" },
                    { 17, 9, "Lectus eros luctus" },
                    { 18, 5, "Ipsum torquent auctor" },
                    { 19, 10, "Cursus imperdiet suspendisse" },
                    { 20, 5, "Commodo leo fermentum" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AboutMe", "AccessFailedCount", "Age", "ConcurrencyStamp", "DonationStars", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3d8ac8ca-08f2-4b10-82ba-55f2b39a5f16", "Amet erat arcu volutpat varius posuere inceptos euismod aliquet congue", 0, 36, "85ec36e7-e029-4199-9559-87cefd7eaac4", 0, "buitrunghieu_t65@hus.edu.vn", true, "Jimmy", "Carter", false, null, "BUITRUNGHIEU_T65@HUS.EDU.VN", "JIMMYCARTER", "AQAAAAEAACcQAAAAEDYaNouZTqTLryp4exl8A3TYiBwPsPSMbzBsjvSOWaP6FhzP0Soljwnc3OLZgv58Yw==", null, false, "86dd541b-30a1-4b09-9580-a801e64c616a", false, "jimmycarter" },
                    { "76cbe9b4-9531-4375-881f-b7cf82f0caab", "Hendrerit massa a lacinia litora mattis sagittis iaculis hac pellentesque", 0, 57, "adb1e039-8a84-4128-a88e-37cdd44d83fe", 0, "buihieu.211202@gmail.com", true, "Ricardo", "MyLord", false, null, "BUIHIEU.211202@GMAIL.COM", "RICARDO", "AQAAAAEAACcQAAAAENumhsaUHNRAC99RmI5UluqCto82rfiOFU+Yzp7trg83OAsixoaZEPCZLvyukLU0dA==", null, false, "7ec768ff-c9cc-4394-a95f-2d441c016a6d", false, "ricardo" },
                    { "81956a67-a277-4359-b59d-39200a35d6e7", "Lacinia condimentum tellus id varius in quis elit gravida ante", 0, 26, "8d164a7e-5d1c-4041-9bcb-177910a77bc5", 0, "trunghieusuper@gmail.com", true, "Logan", "HieuBui", false, null, "TRUNGHIEUSUPER@GMAIL.COM", "LOGANHIEUBUI", "AQAAAAEAACcQAAAAEJKmohS+iMRcwyblARyJEafjuyYuRVHOrpl5qsPTgyo/1y8MQ9TawTBKOxtXwAk/BQ==", null, false, "5b1da7eb-fa30-4af7-bd46-45b7d8ef2feb", false, "loganhieubui" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "CategoryId", "Modified", "Post Content", "Posted On", "Published", "Rate Count", "Short Description", "Title", "Total Rate", "UrlSlug", "View Count" },
                values: new object[,]
                {
                    { 1, "81956a67-a277-4359-b59d-39200a35d6e7", 2, null, "Tempor, tempor dolor elementum finibus, placerat dapibus metus mauris est purus suspendisse ante, lacus. Maximus tortor vel vestibulum nam posuere, hendrerit in, finibus tristique justo non, purus faucibus aenean odio. Pharetra varius ligula fringilla varius, odio etiam leo ante, enim, viverra litora pulvinar. Volutpat, enim posuere, a erat, ante fringilla, sed inceptos massa, nulla orci, venenatis hendrerit mauris. Interdum fringilla, blandit, pellentesque dictumst pretium ante, cursus praesent lectus, at nunc. Volutpat, nunc, libero fringilla euismod non lobortis mauris himenaeos enim torquent lacinia est ligula, nibh, at, imperdiet eget.", new DateTime(2024, 3, 30, 8, 54, 23, 719, DateTimeKind.Local).AddTicks(7878), true, 29, "Dictumst non libero pellentesque congue leo orci sagittis volutpat a lorem mattis augue", "Varius eget accumsan", 183, "quis-porta-porttitor", 267 },
                    { 2, "81956a67-a277-4359-b59d-39200a35d6e7", 3, null, "Diam mi vel vitae, feugiat, sodales fames eu fringilla, vestibulum curabitur risus finibus, blandit, condimentum tempor, imperdiet lacinia. In nostra, porttitor nisl lorem, ligula class himenaeos auctor, laoreet ligula, lacinia. Non quam, ex nec, tincidunt interdum, elementum dignissim dolor, eu, felis varius euismod purus. Enim, auctor venenatis magna, vel, laoreet quisque vestibulum pulvinar aliquam ligula.", new DateTime(2024, 3, 30, 15, 5, 23, 720, DateTimeKind.Local).AddTicks(136), true, 21, "Nibh class elit placerat facilisis vivamus placerat curabitur per congue litora suscipit cras", "Lacus per nisl", 290, "ante-suspendisse-turpis", 285 },
                    { 3, "3d8ac8ca-08f2-4b10-82ba-55f2b39a5f16", 4, null, "Viverra commodo, congue, dictumst nam ultricies condimentum et, tempor, nibh, placerat ornare in, faucibus amet. Eleifend imperdiet lacinia est varius consectetur rhoncus, convallis ad leo, non. Facilisis maecenas per class etiam finibus at, pharetra ligula, dictumst nunc ornare dolor. Pharetra scelerisque porttitor ullamcorper velit himenaeos iaculis fringilla, interdum eros nullam. Sed donec condimentum est facilisis sagittis, orci, elit, mauris torquent malesuada sodales congue.", new DateTime(2024, 4, 6, 6, 35, 23, 720, DateTimeKind.Local).AddTicks(2718), true, 26, "Lobortis est auctor mollis bibendum suspendisse litora neque mauris pulvinar dictumst adipiscing platea", "Feugiat neque et", 239, "ultricies-justo-ex", 141 },
                    { 4, "81956a67-a277-4359-b59d-39200a35d6e7", 5, null, "Efficitur auctor, nisl nullam odio, sagittis urna tincidunt fusce non, ullamcorper enim. Nisi adipiscing nunc ullamcorper nibh sagittis, faucibus ut praesent lacinia, mauris, integer luctus tempus ex, sem. Blandit congue diam nam vel et, fringilla, morbi leo ipsum odio laoreet pulvinar duis ex, justo. Placerat, sollicitudin at aptent tortor, eleifend, dignissim fringilla massa, eu interdum nec, lectus tempus conubia viverra ornare massa velit. Tristique sollicitudin praesent et, rutrum id, vestibulum, lectus, neque, massa, orci, dolor ac quam phasellus. Congue, sollicitudin in, platea semper ex, mauris lorem mattis elit, facilisis eleifend, pellentesque curabitur imperdiet sodales finibus, porta.", new DateTime(2024, 4, 6, 5, 7, 23, 720, DateTimeKind.Local).AddTicks(5867), true, 10, "Ligula porta commodo eget pretium congue rhoncus risus sit quam arcu vulputate est", "Sed scelerisque iaculis", 187, "ac-quam-finibus", 196 },
                    { 5, "3d8ac8ca-08f2-4b10-82ba-55f2b39a5f16", 6, null, "Amet, lacinia neque venenatis fermentum non, eleifend erat, scelerisque hendrerit quam malesuada porta auctor, ultrices, orci, ante, sociosqu. Vehicula magna, malesuada fringilla, sit proin congue, non suscipit ex, finibus, aptent porta, erat dictumst per at. Eu eleifend, neque nisi, fringilla, litora dui commodo aenean eleifend auctor, integer fermentum diam. Tempor, duis sodales suscipit varius, vestibulum neque porta et, sollicitudin. Morbi condimentum faucibus odio lacus erat, nullam neque non himenaeos blandit. Class interdum proin dui blandit nulla sed, enim, finibus, maximus ipsum purus. Litora accumsan auctor est primis convallis nulla laoreet, etiam pharetra quam.", new DateTime(2024, 4, 7, 15, 37, 23, 720, DateTimeKind.Local).AddTicks(9141), true, 13, "Tempor integer non torquent suscipit bibendum sed nulla congue sagittis finibus erat libero", "Orci magna eu", 279, "dignissim-ornare-metus", 119 },
                    { 6, "3d8ac8ca-08f2-4b10-82ba-55f2b39a5f16", 7, null, "Nunc pretium sodales faucibus felis habitasse nunc, adipiscing a non, cras neque. Neque etiam mattis, habitasse sollicitudin dolor, posuere id placerat ornare volutpat ex, aliquam aptent suscipit et, mauris tortor eleifend. Vehicula molestie tortor, malesuada urna, habitasse nibh, sed, lacus libero. Per luctus ligula, malesuada hendrerit rutrum nulla volutpat accumsan habitasse erat litora vulputate ullamcorper adipiscing porta orci.", new DateTime(2024, 4, 1, 18, 19, 23, 721, DateTimeKind.Local).AddTicks(1473), true, 13, "Efficitur enim lacinia auctor morbi nostra iaculis etiam rutrum non dolor ligula nisl", "Fringilla nec sed", 209, "fames-ante-auctor", 231 },
                    { 7, "3d8ac8ca-08f2-4b10-82ba-55f2b39a5f16", 8, null, "Massa neque, pretium mollis leo sed praesent amet, nibh, elementum inceptos volutpat, iaculis litora sapien eu, cursus. Quam, rhoncus turpis litora tincidunt nec, praesent nec iaculis laoreet, gravida odio arcu suspendisse. Bibendum, primis laoreet, lectus iaculis dapibus morbi curabitur eu, congue sagittis, dictumst interdum erat sollicitudin eu conubia. Congue, nulla aptent nunc, fusce hac volutpat donec est auctor conubia posuere, curabitur non integer tincidunt libero interdum. Rhoncus, dictumst et, condimentum suscipit feugiat, nunc, luctus erat viverra lorem, sem placerat.", new DateTime(2024, 4, 8, 18, 23, 23, 721, DateTimeKind.Local).AddTicks(3719), true, 24, "Per inceptos efficitur tempor diam nostra a quis fusce lectus dui proin adipiscing", "Integer sagittis pellentesque", 151, "tortor-ultrices-aptent", 103 },
                    { 8, "81956a67-a277-4359-b59d-39200a35d6e7", 9, null, "Volutpat, porttitor, augue bibendum, leo sed ut duis justo finibus, amet porttitor morbi tortor semper arcu maecenas fames. Maecenas augue consectetur rhoncus vestibulum, nunc arcu, faucibus maximus curabitur accumsan egestas mattis, vitae. Ac feugiat nullam lorem litora ipsum amet leo, velit pulvinar, placerat. Faucibus pretium dui, maximus adipiscing taciti sit auctor sagittis, laoreet, volutpat, cursus pellentesque lacinia.", new DateTime(2024, 4, 4, 6, 52, 23, 721, DateTimeKind.Local).AddTicks(5648), true, 18, "Tempor erat lobortis maximus eu varius porta primis tellus odio class euismod nunc", "Aptent luctus sed", 209, "morbi-neque-nibh", 187 },
                    { 9, "3d8ac8ca-08f2-4b10-82ba-55f2b39a5f16", 10, null, "Luctus inceptos auctor ut aliquam mauris, orci phasellus aptent volutpat, ornare non. Euismod, volutpat, sodales amet elit, diam finibus, mauris, aliquam suspendisse porttitor platea tellus, eleifend. Taciti magna enim sed turpis non amet feugiat vestibulum, eros dolor orci, maecenas nostra, fringilla, curabitur pellentesque consequat. Tincidunt nec, erat amet laoreet porta euismod, posuere suspendisse morbi tellus. Facilisis vel aptent ante lacus congue volutpat neque pretium tortor vivamus amet mattis massa commodo maximus aenean quam, id. Platea euismod, maecenas proin maximus taciti dui, tortor, magna, dictumst fringilla mattis, donec.", new DateTime(2024, 3, 31, 4, 17, 23, 721, DateTimeKind.Local).AddTicks(8658), true, 21, "Ante ut egestas lorem sit fermentum pulvinar urna venenatis sollicitudin condimentum lacinia mattis", "Bibendum ultricies nulla", 139, "vestibulum-euismod-dictum", 192 },
                    { 10, "81956a67-a277-4359-b59d-39200a35d6e7", 1, null, "Malesuada nulla, sollicitudin tortor in taciti convallis ornare integer odio, odio risus tellus, enim mi imperdiet posuere dictumst dolor. Porttitor, ornare mattis, placerat, pretium volutpat dolor, risus praesent mattis. Arcu, primis mi, lobortis vestibulum, nisi, efficitur viverra quam dictumst enim, sed gravida. Lorem tempus vestibulum lectus, nullam pulvinar, ex in, tortor nec posuere, viverra eros.", new DateTime(2024, 4, 4, 13, 47, 23, 722, DateTimeKind.Local).AddTicks(1001), true, 20, "Vehicula fringilla enim auctor sociosqu aliquam lorem blandit lectus volutpat lacinia pulvinar amet", "Mollis tortor arcu", 206, "pulvinar-massa-odio", 101 },
                    { 11, "81956a67-a277-4359-b59d-39200a35d6e7", 2, null, "Ligula fringilla quisque taciti maximus convallis sit aptent massa congue, lectus, aliquam tellus, laoreet ultrices, efficitur leo. Semper consectetur nullam porta, et, condimentum nibh quis ad adipiscing mauris, convallis fermentum. Cursus, ultrices, feugiat, nibh, finibus pretium et lacinia, aliquet sed ac nulla porta pellentesque etiam finibus, rutrum viverra maecenas. Lectus, mauris consectetur felis feugiat amet, nisi, dignissim quis inceptos accumsan vivamus hendrerit mattis, laoreet interdum, scelerisque. Auctor, imperdiet faucibus placerat consequat sed fames massa efficitur nec venenatis platea et, amet, habitasse ac. Condimentum porttitor, bibendum turpis feugiat lobortis mollis id, orci, blandit a vulputate interdum. Per lectus accumsan sollicitudin justo volutpat in, litora vestibulum, rhoncus malesuada cursus integer lacinia, maximus ornare amet posuere, enim.", new DateTime(2024, 4, 5, 22, 13, 23, 722, DateTimeKind.Local).AddTicks(4374), true, 26, "Neque malesuada eu erat finibus at ex sem neque semper morbi suspendisse hendrerit", "Pulvinar venenatis eros", 150, "aliquam-augue-id", 264 },
                    { 12, "81956a67-a277-4359-b59d-39200a35d6e7", 3, null, "Finibus, consectetur quam urna id dignissim ac scelerisque suscipit tempor laoreet ultrices, odio ex. Taciti ultricies condimentum hac neque, non ultrices, orci, praesent ullamcorper facilisis vestibulum amet, pretium. Neque mi, ipsum laoreet, cursus, vivamus blandit, feugiat, molestie pharetra vestibulum, egestas pulvinar rhoncus cras varius. Venenatis ultrices, at vestibulum, mattis, quis finibus fames amet, nunc ante sagittis. Ante, euismod, class magna, fusce blandit tortor feugiat, fames nisi sem scelerisque at dignissim lacinia, lectus nisi, libero. Finibus, lacus finibus congue nibh integer class litora justo pellentesque et ad fringilla in eros, luctus.", new DateTime(2024, 4, 7, 11, 34, 23, 722, DateTimeKind.Local).AddTicks(7332), true, 20, "Neque sociosqu elementum sodales feugiat porta nam tempus habitasse tortor bibendum lacinia ligula", "Vestibulum finibus justo", 103, "torquent-eros-diam", 286 },
                    { 13, "81956a67-a277-4359-b59d-39200a35d6e7", 4, null, "Platea sed vitae mauris, porta, erat, non, ornare dolor lorem laoreet, porttitor, pharetra fermentum. Id, porttitor morbi feugiat mattis nostra, placerat etiam ultrices, nam sociosqu consequat consectetur tincidunt. Praesent dictumst nibh, orci eleifend luctus, eros vel pellentesque magna, faucibus eu vitae, auctor, neque. At, hendrerit molestie sem, condimentum cursus faucibus auctor luctus accumsan pellentesque convallis in id quis, pulvinar. Laoreet finibus, pellentesque ante, a varius arcu fringilla elit, facilisis mollis vitae. Mattis, vehicula eros maecenas hendrerit mauris, fermentum aliquam a, eget nec, volutpat elit, conubia vivamus enim, ex lorem. Erat, mollis eleifend, elementum libero rhoncus vitae, pretium dapibus in luctus, arcu accumsan leo torquent ex, nulla.", new DateTime(2024, 4, 7, 4, 11, 23, 723, DateTimeKind.Local).AddTicks(632), true, 10, "Nisi mauris facilisis sagittis inceptos vel nam neque massa venenatis euismod volutpat dictumst", "Porta ut enim", 150, "odio-ad-rhoncus", 163 },
                    { 14, "3d8ac8ca-08f2-4b10-82ba-55f2b39a5f16", 5, null, "Metus tellus, efficitur laoreet, urna vivamus cras eros sollicitudin dictumst. Quis porttitor fringilla sagittis adipiscing eros, ut tellus, eget risus arcu, auctor ultrices blandit fames ultricies nostra. Porttitor, nisi, sed, duis vulputate eu, interdum rhoncus augue adipiscing sed euismod efficitur pellentesque nullam viverra. Praesent arcu lobortis dui, congue metus diam taciti vel ac. Viverra in nostra, lorem cursus, fringilla, in, volutpat, mi pellentesque vehicula aenean.", new DateTime(2024, 4, 1, 15, 20, 23, 723, DateTimeKind.Local).AddTicks(3189), true, 17, "Aliquam gravida urna vitae tortor commodo interdum justo aliquet feugiat tellus per felis", "Finibus nostra etiam", 183, "auctor-scelerisque-dolor", 175 },
                    { 15, "3d8ac8ca-08f2-4b10-82ba-55f2b39a5f16", 6, null, "Risus odio, varius imperdiet mattis, ex, adipiscing dignissim sit nunc feugiat. Leo quam iaculis mi, platea enim risus pharetra mauris, mattis, arcu, commodo, volutpat, ornare. Aliquam malesuada torquent taciti ligula, auctor nulla interdum orci, placerat, fermentum. Aliquam nec, eget interdum, in eleifend fringilla nostra, neque, feugiat, dictum posuere, adipiscing condimentum. Tellus massa, placerat, mollis in, eleifend, ligula, finibus, convallis ex purus quam metus fames litora non.", new DateTime(2024, 4, 3, 8, 3, 23, 723, DateTimeKind.Local).AddTicks(5942), true, 12, "Interdum eleifend etiam ligula leo arcu facilisis lacinia placerat ornare a ullamcorper quis", "Vulputate pulvinar cras", 199, "sed-leo-commodo", 168 },
                    { 16, "81956a67-a277-4359-b59d-39200a35d6e7", 7, null, "Orci magna sollicitudin dolor, tempor tellus, ultrices leo, interdum lectus, tempus purus vestibulum, vehicula ante, fames ante rutrum lacus. Orci, accumsan elit, in, tellus ultrices, hac tortor, phasellus tortor lectus. Finibus, dolor vitae, posuere, duis taciti et massa, eu tellus etiam orci, quam, habitasse. Accumsan ornare orci rhoncus in bibendum, interdum, arcu amet nullam ullamcorper a, dictumst at, nisi. Eleifend nunc, vivamus torquent a, at, euismod finibus commodo dolor ultricies duis cursus porta feugiat, nisi.", new DateTime(2024, 4, 8, 0, 7, 23, 723, DateTimeKind.Local).AddTicks(8642), true, 16, "Ligula et turpis tempor leo cras interdum feugiat suspendisse quisque enim sociosqu risus", "Elit pellentesque lectus", 236, "orci-tellus-egestas", 230 },
                    { 17, "81956a67-a277-4359-b59d-39200a35d6e7", 8, null, "Ultrices gravida turpis tellus, felis sagittis varius, pulvinar, velit lacinia quis, congue vehicula sagittis. Class quam, auctor nisi, libero nostra, sem sollicitudin euismod interdum, eros eleifend, vivamus amet, turpis suscipit tempor odio. Ipsum himenaeos malesuada consectetur metus porttitor orci nec, fames quis, adipiscing rutrum efficitur ante, at, cursus. Massa neque, elementum a, eleifend lectus lacus dui lorem, sodales vel, eros, in porttitor. Vel ante, ultricies vitae, feugiat, hendrerit bibendum fames tempus maximus nulla massa, metus nam cursus, volutpat egestas iaculis porttitor.", new DateTime(2024, 4, 7, 9, 45, 23, 724, DateTimeKind.Local).AddTicks(1271), true, 29, "Sem odio magna luctus quis nibh nullam faucibus primis a in enim venenatis", "Interdum tincidunt at", 151, "sit-sem-id", 139 },
                    { 18, "3d8ac8ca-08f2-4b10-82ba-55f2b39a5f16", 9, null, "Urna nibh magna, erat eu auctor lacinia blandit, orci, varius finibus purus proin inceptos ultrices suscipit porttitor. Augue in, quam platea semper eleifend, maecenas enim, feugiat vitae condimentum porttitor, magna, sed posuere. Placerat orci, congue, ex, et, justo feugiat, convallis facilisis a, placerat, ut fames ultricies. Vivamus lacinia fames nulla, feugiat bibendum, erat vitae, amet, elit, lacus lorem consectetur nulla euismod, eu, in, massa velit. Mattis amet nibh, adipiscing lectus neque condimentum enim, eros, justo blandit, erat, orci, leo dui, consectetur nam.", new DateTime(2024, 4, 3, 19, 10, 23, 724, DateTimeKind.Local).AddTicks(4023), true, 16, "Leo torquent congue ut arcu rutrum et mi cursus dapibus interdum vestibulum mi", "Platea nulla fringilla", 172, "neque-volutpat-quis", 100 },
                    { 19, "3d8ac8ca-08f2-4b10-82ba-55f2b39a5f16", 10, null, "Sapien tortor fames dapibus ante, enim mi, quam, fringilla, nostra, auctor, habitasse tincidunt. Et, mi cursus, mi, ex elit finibus, interdum a porttitor, pulvinar, nibh, inceptos dictumst accumsan tempor ante tempor. Dui, posuere cras urna lorem, venenatis feugiat, justo pulvinar pellentesque eu. Sapien posuere et, massa enim mi, rhoncus posuere, id, egestas porta, tincidunt orci. Egestas vulputate torquent primis diam leo nibh, orci, libero quam conubia ad aptent sollicitudin purus.", new DateTime(2024, 4, 3, 17, 31, 23, 724, DateTimeKind.Local).AddTicks(6576), true, 24, "Nunc dui sapien arcu lectus nam at adipiscing nec tristique lectus orci ligula", "Condimentum tempor morbi", 244, "primis-placerat-vestibulum", 101 },
                    { 20, "81956a67-a277-4359-b59d-39200a35d6e7", 1, null, "Sodales velit pulvinar scelerisque donec ligula interdum dui, quam magna arcu, mauris est torquent. Libero sociosqu erat, fringilla, magna iaculis maximus nisi, conubia posuere, efficitur dolor, habitasse ex metus massa suspendisse. Lacinia, tellus praesent libero quisque nulla, urna magna, euismod, rutrum vitae, suspendisse bibendum bibendum, per donec nibh convallis proin. Luctus, ante purus pellentesque nibh leo gravida sed blandit tempor consequat ex, tellus, accumsan nulla, eleifend, turpis. Convallis vivamus sit quis consequat finibus, maximus torquent nullam ipsum neque, odio.", new DateTime(2024, 4, 8, 18, 0, 23, 724, DateTimeKind.Local).AddTicks(9231), true, 16, "Tincidunt finibus dictum phasellus molestie volutpat lorem cras eleifend nunc morbi dui velit", "Facilisis mauris hac", 143, "id-tempor-bibendum", 155 },
                    { 21, "81956a67-a277-4359-b59d-39200a35d6e7", 2, null, "Maecenas viverra dignissim consectetur faucibus venenatis blandit, gravida nunc dui eu, suscipit tristique lacus lorem malesuada. Eu posuere leo, lectus quis, aliquet nam himenaeos auctor, dolor odio, nostra, curabitur cursus, ultrices vestibulum per nisi amet. Tempor viverra himenaeos quisque condimentum porta, nostra, gravida mattis eros, vivamus inceptos porta cursus. Cras neque nisl risus vel, mollis quam lacinia, phasellus eget integer dui.", new DateTime(2024, 4, 4, 4, 14, 23, 725, DateTimeKind.Local).AddTicks(1497), true, 25, "Sem mi inceptos nullam feugiat nam facilisis fusce dui massa congue enim ligula", "Enim efficitur fames", 104, "tincidunt-imperdiet-euismod", 296 },
                    { 22, "81956a67-a277-4359-b59d-39200a35d6e7", 3, null, "Lectus, tellus ultrices ante, malesuada torquent auctor nostra, feugiat ac, blandit, sagittis convallis feugiat, non ultrices, dui, vehicula eros. Fringilla pretium iaculis porta, ligula venenatis porttitor, posuere, odio, elit sodales leo varius. Placerat rhoncus, justo nunc, bibendum condimentum eleifend mauris pharetra et. Ut ex fringilla dignissim massa ipsum dolor metus amet malesuada sed, odio. Non, urna, sapien pulvinar, neque, elit, feugiat, ligula nec gravida orci. Semper leo hac mi mauris, lectus, phasellus consequat in fringilla, cursus, morbi lacinia ultrices, sed, sapien finibus urna. Mauris est iaculis laoreet, porta habitasse mauris, nostra, finibus sed tellus, tellus.", new DateTime(2024, 4, 3, 7, 40, 23, 725, DateTimeKind.Local).AddTicks(4809), true, 17, "Erat vitae curabitur tellus suscipit consectetur accumsan fusce magna urna eros in risus", "Pulvinar laoreet convallis", 269, "neque-vivamus-dictum", 108 },
                    { 23, "81956a67-a277-4359-b59d-39200a35d6e7", 4, null, "Tortor odio, nibh interdum ultricies conubia condimentum morbi mattis, eros dui, sed, nostra. Sociosqu rhoncus, est nunc sagittis, ante ultrices, phasellus varius imperdiet laoreet bibendum litora curabitur placerat tempor pulvinar, sed, urna. Facilisis ultrices, odio, fames hendrerit feugiat amet, pellentesque blandit ornare. Enim, platea at, sociosqu a, dolor accumsan mi proin orci. Amet purus semper malesuada donec mollis quam, condimentum maecenas consequat sem, nisi, luctus, egestas a faucibus congue. Consequat lacus vel, nunc, facilisis elit, tellus quam, consectetur habitasse hendrerit rutrum at commodo, maecenas.", new DateTime(2024, 4, 1, 20, 48, 23, 725, DateTimeKind.Local).AddTicks(7711), true, 12, "Risus finibus rutrum lacus enim est et ante lacinia orci orci erat molestie", "Lorem ipsum vel", 133, "sodales-mi-sollicitudin", 212 },
                    { 24, "81956a67-a277-4359-b59d-39200a35d6e7", 5, null, "Eu, eleifend, ultrices praesent condimentum porta, posuere, ipsum porta gravida in rutrum dui, etiam himenaeos ante sed. Orci mattis, magna, efficitur nulla, conubia elit, finibus, faucibus cursus vitae. Urna auctor, aptent hendrerit interdum lectus commodo, lorem, in, massa, elementum magna, orci id porta, donec sed. Inceptos conubia justo lobortis ultricies varius, pulvinar odio, nisl vitae enim, cras phasellus nec at, amet. Bibendum tortor suscipit laoreet finibus, auctor auctor, feugiat ultrices, pulvinar, sem aptent quis. Rhoncus libero felis dolor sodales elit litora dui non iaculis morbi ipsum.", new DateTime(2024, 4, 4, 11, 56, 23, 726, DateTimeKind.Local).AddTicks(707), true, 19, "Turpis tempus mollis auctor phasellus laoreet litora accumsan imperdiet ipsum sed odio purus", "Elementum libero rutrum", 170, "aptent-vestibulum-fusce", 235 },
                    { 25, "3d8ac8ca-08f2-4b10-82ba-55f2b39a5f16", 6, null, "Tempus aliquam tempor nibh sagittis, non, nam eget quis, elit, pellentesque diam dictum placerat. Ac tempus aliquam tortor massa, sed ligula sodales tellus, amet, pulvinar vivamus aliquet vitae, nam. Id tortor, nulla, magna, metus bibendum porttitor rutrum nunc, pulvinar mattis. Nisi, ad rhoncus, ultricies sapien aliquam bibendum et urna, arcu diam luctus sem porttitor vel. Porta, posuere, metus porta curabitur ac semper mattis velit mi, nec, mollis tellus a, rhoncus ultrices. Tellus, faucibus ipsum vehicula magna euismod tempor tortor, himenaeos cursus. Urna finibus sociosqu fusce maximus ex, orci, congue, tellus, mattis libero porta, ipsum lorem.", new DateTime(2024, 4, 7, 6, 22, 23, 726, DateTimeKind.Local).AddTicks(3984), true, 23, "Quis sodales lacus tellus nullam ex mattis iaculis placerat bibendum vel nam varius", "Lorem tincidunt adipiscing", 218, "taciti-platea-sagittis", 297 },
                    { 26, "81956a67-a277-4359-b59d-39200a35d6e7", 7, null, "Purus pretium ultricies torquent arcu odio tellus, condimentum rhoncus sit nullam. Nec ad cursus risus eros tristique ullamcorper dolor augue pellentesque feugiat, congue, lobortis ipsum euismod ut. Rhoncus, turpis tellus gravida sit urna enim laoreet, risus elementum sagittis taciti ad posuere. Purus convallis orci, dui, urna sem nec, euismod, lacinia inceptos libero amet leo, felis risus. Mattis, mauris hendrerit euismod, eros suscipit dignissim auctor, lorem, magna feugiat, libero orci aliquet. Nibh tellus, nunc mollis ornare hac enim pharetra imperdiet phasellus nisi, laoreet convallis iaculis aliquet litora scelerisque enim, sodales. Euismod sed, fermentum himenaeos fames duis habitasse ex amet tortor.", new DateTime(2024, 4, 3, 23, 37, 23, 726, DateTimeKind.Local).AddTicks(7324), true, 24, "Ac ultricies sed quis pharetra adipiscing tempor sociosqu imperdiet ac luctus eu lobortis", "Purus neque luctus", 290, "posuere-nec-sodales", 135 },
                    { 27, "81956a67-a277-4359-b59d-39200a35d6e7", 8, null, "Tempor turpis mattis purus lectus, interdum, erat nisi, blandit, quam donec hac maximus mauris. Posuere, vitae, curabitur dui ante laoreet fames quisque tellus nibh leo, placerat, sed, quam. Ultricies fusce nostra, euismod odio, elit, ac dictum elementum sed, mattis, ullamcorper primis a in, facilisis euismod, iaculis conubia. Dui, nullam volutpat, mattis orci turpis pulvinar eros, interdum, maecenas leo nam risus ultricies sociosqu ex. Leo nibh gravida varius primis id porttitor nec, ipsum pulvinar, vitae, aliquam mi bibendum etiam elementum. Blandit per mi ex imperdiet suscipit vestibulum, leo congue aliquet dapibus quis, vitae, tincidunt. Dui, eros, pellentesque varius aliquam ac vestibulum proin fames vulputate ad feugiat, ut posuere, himenaeos per.", new DateTime(2024, 4, 4, 8, 5, 23, 727, DateTimeKind.Local).AddTicks(713), true, 15, "Cursus blandit nam sapien habitasse scelerisque mollis quisque consequat semper id nec nullam", "Tincidunt vivamus semper", 112, "sodales-vestibulum-imperdiet", 296 },
                    { 28, "3d8ac8ca-08f2-4b10-82ba-55f2b39a5f16", 9, null, "Duis faucibus nam fusce donec ac ligula eu urna dolor, elit arcu pretium in etiam pellentesque. Mi, laoreet, in, maecenas in orci sem, curabitur adipiscing vestibulum nisl leo donec. Rutrum odio, et quisque suspendisse convallis turpis fringilla, dictumst in. Nulla, posuere risus lorem, consectetur odio, convallis praesent integer adipiscing ac interdum neque lacinia. Maecenas curabitur elit, finibus maximus lectus, sapien fringilla, lobortis suscipit.", new DateTime(2024, 3, 31, 16, 19, 23, 727, DateTimeKind.Local).AddTicks(3379), true, 20, "Nullam diam viverra mollis quam ante felis ac feugiat adipiscing mi nec ligula", "Maecenas rhoncus himenaeos", 176, "mi-finibus-vel", 268 },
                    { 29, "3d8ac8ca-08f2-4b10-82ba-55f2b39a5f16", 10, null, "Interdum amet, vel praesent interdum, dolor mattis integer enim volutpat tellus tortor dolor. Sodales per enim urna rutrum vel placerat et, enim, consectetur ac urna, rhoncus, morbi vestibulum. Mattis, cursus accumsan odio, ex volutpat at, inceptos habitasse in. Amet, primis nostra, felis praesent sollicitudin a, sed, quisque dui massa metus elementum neque, dictum cursus, euismod, in. Habitasse sem maximus volutpat conubia rhoncus, malesuada nunc mauris orci, commodo, cursus ultrices tincidunt primis euismod. Nisl sociosqu sed, cursus cursus, varius rhoncus, mi velit bibendum adipiscing tortor, at, dolor massa elit, blandit, elementum taciti.", new DateTime(2024, 4, 3, 10, 43, 23, 727, DateTimeKind.Local).AddTicks(6370), true, 15, "Cursus platea sem elit bibendum nunc nunc vehicula mollis venenatis libero curabitur hendrerit", "Vehicula pellentesque dolor", 235, "convallis-lectus-porta", 216 },
                    { 30, "81956a67-a277-4359-b59d-39200a35d6e7", 1, null, "Habitasse cras turpis et, dui lobortis faucibus imperdiet accumsan eros. Malesuada consequat ligula fringilla, blandit non lobortis primis cursus volutpat, euismod torquent ultrices tempor, bibendum. Sed consequat sit mattis euismod lorem euismod, suspendisse arcu primis turpis nisi habitasse id congue. Elit curabitur id facilisis morbi dolor urna, erat, erat ac auctor proin sit mi. Sagittis orci cursus eros, ac, suscipit hac blandit, vel laoreet. Augue tempor rhoncus, pretium vel, erat in, iaculis torquent gravida varius. Metus commodo massa non condimentum orci, vitae consequat rhoncus, conubia gravida inceptos fusce non, cursus accumsan tempus lacus neque.", new DateTime(2024, 4, 6, 14, 27, 23, 727, DateTimeKind.Local).AddTicks(9642), true, 18, "Mauris gravida luctus diam magna augue sapien nec per felis interdum dignissim maximus", "Tincidunt massa quis", 262, "amet-ante-interdum", 276 },
                    { 31, "81956a67-a277-4359-b59d-39200a35d6e7", 2, null, "Odio, quam, neque enim, magna, primis et fringilla dui curabitur commodo rutrum volutpat eu, vestibulum sagittis. Praesent in, ullamcorper sodales vulputate tortor, placerat aliquam ultricies lobortis eleifend, finibus, a nisi nulla, metus ante, eu. Scelerisque ante, tempus nunc, dictum elit, turpis molestie urna lobortis ultrices, himenaeos non. Consectetur vivamus sem pulvinar, porttitor, urna aenean imperdiet et, amet felis posuere, dapibus et porttitor sem, mollis.", new DateTime(2024, 4, 2, 0, 43, 23, 728, DateTimeKind.Local).AddTicks(2120), true, 20, "Sem non risus rhoncus himenaeos cursus sit morbi quam ultrices sagittis id commodo", "Pulvinar duis posuere", 132, "donec-augue-torquent", 107 },
                    { 32, "3d8ac8ca-08f2-4b10-82ba-55f2b39a5f16", 3, null, "Aliquam eros vel, ante, semper sapien libero eu pulvinar habitasse tempus lobortis laoreet, suscipit. Condimentum porta, sollicitudin vestibulum cursus, risus placerat, nisl ac, enim, semper quam curabitur at, fames ullamcorper suspendisse suscipit. Sagittis, placerat, finibus, tellus, ligula tristique et aenean cras lacinia, magna massa. Cras aptent habitasse morbi conubia a lorem curabitur scelerisque est enim et dignissim nibh placerat, mollis sagittis ipsum. Magna, faucibus a, vitae tellus sem, posuere laoreet sapien interdum, finibus sed vivamus amet hac habitasse nunc. Orci luctus tincidunt non, elit lacinia nisi, nibh, quam facilisis nunc aliquam duis elementum vestibulum, finibus, enim.", new DateTime(2024, 4, 6, 0, 29, 23, 728, DateTimeKind.Local).AddTicks(5119), true, 28, "Condimentum metus aliquam euismod libero mattis id porttitor habitasse vulputate sagittis quis sollicitudin", "Lectus rhoncus per", 101, "mi-ultrices-feugiat", 213 },
                    { 33, "3d8ac8ca-08f2-4b10-82ba-55f2b39a5f16", 4, null, "Ullamcorper et pulvinar, maximus ad congue, inceptos porta, nullam eros, lectus, blandit, dignissim commodo, felis himenaeos vel, tincidunt. Tellus nulla litora nisl nisi, enim arcu lorem eu sem. Quisque hendrerit mattis eu blandit porttitor laoreet luctus lorem varius posuere vulputate a, mollis sed malesuada. Sapien augue ante, vehicula nisi, sit aenean euismod, faucibus litora congue, finibus, blandit, primis tempor nam mi turpis quis. Elit, interdum etiam ad morbi cursus dolor vestibulum, facilisis malesuada dapibus et, urna porttitor. Ullamcorper blandit, blandit rutrum amet posuere, ligula per malesuada orci.", new DateTime(2024, 4, 1, 3, 5, 23, 728, DateTimeKind.Local).AddTicks(8657), true, 26, "Cras primis arcu massa feugiat egestas felis imperdiet rhoncus sed risus in fermentum", "Cras nunc ut", 189, "orci-elementum-sed", 104 },
                    { 34, "3d8ac8ca-08f2-4b10-82ba-55f2b39a5f16", 5, null, "Et mattis, vulputate mauris ipsum urna, justo tempor pharetra velit. Pellentesque vestibulum sagittis interdum, aptent hac himenaeos taciti a, urna mollis sem ante, vehicula. Sem phasellus bibendum, inceptos nam enim, mauris amet ut eu vivamus pulvinar nunc, ullamcorper blandit, imperdiet. A tortor euismod phasellus viverra cursus, porttitor gravida nec, nibh. Sem, tortor, volutpat sagittis justo ante, viverra non massa leo placerat ac luctus lectus, tortor nam litora maecenas porttitor. Ex at velit maximus sapien magna vehicula feugiat, litora nunc, quis, ex, vitae. Interdum elementum nulla, mi, congue pulvinar enim dapibus non, mollis nec, fringilla.", new DateTime(2024, 4, 1, 1, 5, 23, 729, DateTimeKind.Local).AddTicks(2072), true, 24, "Pharetra malesuada arcu auctor per pellentesque mauris faucibus praesent nam quis augue molestie", "Ultrices erat sed", 102, "sagittis-nunc-volutpat", 163 },
                    { 35, "81956a67-a277-4359-b59d-39200a35d6e7", 6, null, "Semper vel, class risus ornare congue urna, enim, commodo nec, bibendum placerat maximus aliquam mattis auctor, non, inceptos. Erat, neque urna phasellus porta, ex nisi conubia nibh sem amet maximus vestibulum fermentum etiam urna, mi. Non leo odio, nostra, massa vel, ipsum ligula, lacinia conubia porttitor, dui, nibh. Vitae porttitor, nisl nulla tortor urna, vivamus tempor, magna, per odio, ad lorem, purus nunc. Ligula imperdiet eget vel, nibh, vestibulum, platea nisi, ac lorem. In quam mollis suscipit sodales rutrum odio scelerisque laoreet fringilla hac amet himenaeos porta, tortor, leo pharetra massa.", new DateTime(2024, 4, 7, 23, 47, 23, 729, DateTimeKind.Local).AddTicks(5086), true, 20, "Eros rhoncus maecenas auctor urna primis blandit lobortis nibh nunc sem placerat blandit", "Eget neque fringilla", 179, "nisl-tortor-aenean", 267 },
                    { 36, "3d8ac8ca-08f2-4b10-82ba-55f2b39a5f16", 7, null, "In, quam, nisl ultricies bibendum, neque porta nec, sed, tincidunt sodales amet, suscipit dictumst integer non, augue est. Sociosqu varius, pulvinar quis, orci, ultrices suspendisse dictum molestie nunc felis. Ac, ac imperdiet aliquam eros quis ut etiam efficitur vitae taciti posuere. Et, integer euismod ante justo ac tellus viverra id, felis dui, pulvinar non vestibulum fames facilisis.", new DateTime(2024, 3, 30, 2, 6, 23, 729, DateTimeKind.Local).AddTicks(7410), true, 16, "Tincidunt vulputate neque sit eros inceptos iaculis elementum tortor class lorem aenean orci", "Nibh cursus orci", 159, "hendrerit-metus-lacinia", 215 },
                    { 37, "81956a67-a277-4359-b59d-39200a35d6e7", 8, null, "Convallis dolor eu, auctor iaculis lorem dignissim lacus nibh, gravida class risus ac placerat, etiam mi. Tellus lorem nisi non, ornare platea porta rhoncus, a magna arcu, pulvinar, tortor interdum. Orci varius phasellus ac, consequat ligula, non nec justo dui, tempor cras mattis nisi, ut et sociosqu mauris, eu. Magna tellus, phasellus gravida placerat ligula, nibh maximus duis proin quis, sapien arcu primis. Integer tempor, felis ante, suspendisse morbi a, varius, suscipit neque ullamcorper. Convallis vulputate interdum, bibendum arcu feugiat, eget ligula, per consectetur id. Condimentum blandit, in, aptent praesent eget molestie donec sed, tellus.", new DateTime(2024, 3, 30, 19, 25, 23, 730, DateTimeKind.Local).AddTicks(713), true, 27, "Egestas porta eros nunc arcu velit sagittis pulvinar ultrices dignissim donec vestibulum bibendum", "Dui commodo convallis", 145, "ad-eget-posuere", 277 },
                    { 38, "81956a67-a277-4359-b59d-39200a35d6e7", 9, null, "Erat convallis pretium leo vel, ante, lacus vestibulum dignissim justo lectus, cras. Porta, curabitur euismod quis praesent morbi amet nunc interdum, sed, rutrum. Euismod porttitor nisi euismod, luctus, purus maximus quis, urna sagittis vulputate leo, ullamcorper erat, fames at neque, lobortis. Commodo quis, luctus curabitur ligula, fringilla, pulvinar urna, facilisis dapibus neque odio convallis venenatis inceptos. Vel, et, non aenean dolor vehicula nam commodo, placerat, magna mi, tempor, posuere, dui fringilla. Aenean tempus nunc commodo id sapien non maecenas lacinia, adipiscing laoreet purus lorem.", new DateTime(2024, 4, 4, 7, 49, 23, 730, DateTimeKind.Local).AddTicks(3807), true, 22, "Erat imperdiet proin vel amet at varius praesent himenaeos massa ornare lacus taciti", "Placerat lacus ut", 227, "vitae-sodales-habitasse", 295 },
                    { 39, "3d8ac8ca-08f2-4b10-82ba-55f2b39a5f16", 10, null, "Nec efficitur porttitor, est integer neque auctor vel ornare per pretium orci metus vestibulum accumsan commodo, imperdiet non. Ligula cras suspendisse ultrices, quisque massa finibus lobortis odio adipiscing dui, lacinia lorem, lacus blandit blandit, mi. Nisl egestas quisque integer sodales nec, aenean quis, vitae, ante, a faucibus cursus neque praesent finibus, facilisis dapibus. Lectus, quam tempor urna, donec mattis elit massa et, auctor, enim accumsan aliquam. Eros, placerat, tortor, arcu cras fringilla, nam donec commodo a, et congue eget dapibus aliquam primis.", new DateTime(2024, 4, 4, 2, 36, 23, 730, DateTimeKind.Local).AddTicks(6567), true, 15, "Nibh posuere risus nunc mi ultrices aenean integer cursus amet non ante quisque", "Tortor dictumst leo", 240, "feugiat-purus-sem", 259 },
                    { 40, "3d8ac8ca-08f2-4b10-82ba-55f2b39a5f16", 1, null, "Velit mauris vulputate nibh, dictum hac placerat congue, habitasse lacinia, urna risus quis, et integer sollicitudin maecenas fringilla, purus. Integer mollis nulla, elementum elit vestibulum, lectus per etiam quam, conubia neque, convallis felis. Nisl aenean fermentum himenaeos enim curabitur tincidunt lorem, hac mauris. Vitae nibh, condimentum urna, orci, rutrum aliquam rhoncus tellus pulvinar nostra, nisi nullam et, platea finibus quam congue ac. Fames dolor feugiat sit pulvinar elit, ex varius, fermentum id bibendum, a cursus. Urna arcu, orci, in efficitur class vehicula dui, vestibulum, proin interdum elementum in, purus convallis quis nulla, quis. Nulla quisque porttitor blandit, leo, lectus, erat, scelerisque habitasse cras eu, enim, nisi enim nam.", new DateTime(2024, 3, 31, 20, 1, 23, 730, DateTimeKind.Local).AddTicks(9907), true, 12, "Lorem per metus ad varius vitae placerat porta primis pellentesque blandit eget auctor", "Aenean sagittis nibh", 145, "commodo-sodales-lectus", 275 },
                    { 41, "81956a67-a277-4359-b59d-39200a35d6e7", 2, null, "Tortor, quis mauris ad nec mauris, molestie fusce conubia maximus ante, in, phasellus fermentum magna, vestibulum, leo. Purus enim lacinia, sed accumsan suscipit himenaeos in nisi, cursus id, hendrerit placerat. Nec tellus, id nisi, commodo pharetra enim porta lorem, interdum. Adipiscing condimentum mauris, tincidunt et, ligula, massa dolor volutpat, purus sit bibendum.", new DateTime(2024, 4, 7, 20, 45, 23, 731, DateTimeKind.Local).AddTicks(2225), true, 17, "Condimentum finibus massa ex etiam diam nisl bibendum facilisis sagittis fermentum vulputate posuere", "Porttitor enim luctus", 293, "mauris-elit-nibh", 112 },
                    { 42, "81956a67-a277-4359-b59d-39200a35d6e7", 3, null, "Dolor, ornare massa urna, leo, enim, mauris lorem, conubia nisl eros enim elementum. Dictumst amet venenatis fringilla, aliquet sodales ante lacinia, congue, euismod tortor quisque scelerisque nostra, odio rhoncus, orci, primis diam. Ad commodo, a in vitae, sodales egestas tincidunt cras ut quam mauris quisque pretium bibendum, himenaeos. Magna, ex, urna fringilla leo congue, eleifend mauris, ultricies lacinia mi.", new DateTime(2024, 4, 8, 16, 46, 23, 731, DateTimeKind.Local).AddTicks(4942), true, 26, "Magna scelerisque sed risus mattis eros etiam nibh vitae morbi pulvinar cursus lacinia", "Auctor primis inceptos", 234, "vestibulum-adipiscing-sem", 143 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "CategoryId", "Modified", "Post Content", "Posted On", "Published", "Rate Count", "Short Description", "Title", "Total Rate", "UrlSlug", "View Count" },
                values: new object[,]
                {
                    { 43, "81956a67-a277-4359-b59d-39200a35d6e7", 4, null, "Purus lacus in rutrum semper taciti ac, nam aptent dapibus. Euismod, nibh, nam eros bibendum justo iaculis auctor, finibus, sagittis aliquam at. Diam proin amet nunc nisi urna ante, odio, ultricies elit, porttitor, est eget phasellus vulputate felis. Vestibulum, dignissim eleifend varius justo posuere ut urna eleifend, maximus diam aliquet scelerisque pellentesque curabitur euismod magna, purus. Blandit auctor, hendrerit augue elit dolor, tempor curabitur elementum ultrices. Fringilla viverra auctor habitasse non, maximus tellus, molestie nisi ad quam vel, bibendum. Enim hac duis etiam vitae nam amet nisi nunc, orci, fames.", new DateTime(2024, 4, 6, 20, 6, 23, 731, DateTimeKind.Local).AddTicks(8213), true, 12, "Varius mattis cursus fermentum suspendisse quis nibh risus arcu ante porttitor lorem leo", "Facilisis convallis orci", 224, "faucibus-interdum-vestibulum", 193 },
                    { 44, "81956a67-a277-4359-b59d-39200a35d6e7", 5, null, "Porttitor cursus nullam in taciti diam amet varius, sem tempus porttitor, inceptos massa. Est ultrices, ut porttitor pulvinar, eget tempus sagittis diam quis, iaculis laoreet, ipsum sollicitudin et ornare congue. Malesuada quis in justo finibus, arcu, praesent hendrerit morbi rhoncus donec fermentum tristique turpis integer velit. Luctus nunc ut nulla litora platea est lorem, congue, accumsan finibus, nam tincidunt nec tempor pharetra. Morbi commodo amet habitasse lorem a dolor quisque porta interdum, id, vestibulum, magna lectus, venenatis mauris. Arcu orci ex lorem, ac, eu sollicitudin lacus iaculis euismod, nunc. Velit vitae dignissim diam enim ipsum nunc nisi, dui, risus lorem ad torquent.", new DateTime(2024, 4, 1, 0, 19, 23, 732, DateTimeKind.Local).AddTicks(1593), true, 13, "At fames volutpat amet platea urna condimentum faucibus eu inceptos tellus sapien torquent", "Mi ultrices id", 148, "tortor-quis-leo", 117 },
                    { 45, "81956a67-a277-4359-b59d-39200a35d6e7", 6, null, "Feugiat, libero est urna, dapibus aenean sed duis mi commodo conubia luctus inceptos dui, convallis placerat tincidunt. Feugiat, varius, vivamus massa odio, feugiat erat non, eu est vitae, et, a porttitor, lorem. Hac ut a, euismod, eget vivamus blandit mi convallis dui. Curabitur eros neque, sem porta erat suscipit quam pharetra cursus, tempus volutpat purus maecenas aptent nulla, nibh odio morbi. Rhoncus tellus, velit euismod hendrerit porta nullam aenean lacinia, luctus, nec mattis, eros malesuada.", new DateTime(2024, 3, 30, 11, 3, 23, 732, DateTimeKind.Local).AddTicks(4369), true, 28, "Massa lorem a amet non elementum arcu sociosqu sem sagittis bibendum taciti tellus", "Mi nibh adipiscing", 205, "feugiat-per-feugiat", 169 },
                    { 46, "3d8ac8ca-08f2-4b10-82ba-55f2b39a5f16", 7, null, "Ex, lorem, rutrum quis, pulvinar conubia vel, pretium sem non, bibendum, erat, venenatis tellus. Phasellus finibus vitae mi, aliquam inceptos malesuada integer ex at, semper risus habitasse urna sem. Dolor odio, arcu, fringilla rutrum in, nec a consequat nostra. Nostra, mauris laoreet finibus, porta ornare eleifend, a, praesent dui, posuere fames.", new DateTime(2024, 4, 5, 12, 13, 23, 732, DateTimeKind.Local).AddTicks(6718), true, 18, "Cursus dignissim sem rhoncus libero commodo a id hendrerit mi maximus pretium non", "Purus feugiat finibus", 248, "tempor-lacus-semper", 166 },
                    { 47, "3d8ac8ca-08f2-4b10-82ba-55f2b39a5f16", 8, null, "Amet, varius habitasse commodo, neque pulvinar himenaeos taciti congue, maximus. Dictum lorem urna, nisi faucibus elit, congue nulla, amet, cursus, ultrices, pharetra varius nunc, nullam at nam lorem, dignissim. Euismod magna conubia euismod, urna mauris et, at malesuada tortor orci pulvinar integer etiam aliquam tellus, nec. Non volutpat tortor, varius mi, bibendum ut fermentum interdum id, egestas taciti per platea suspendisse blandit ante.", new DateTime(2024, 4, 8, 3, 57, 23, 732, DateTimeKind.Local).AddTicks(9055), true, 25, "Vel nullam enim tellus consequat nec mattis dapibus rhoncus semper lectus laoreet erat", "Rutrum quisque vestibulum", 157, "commodo-maximus-sodales", 186 },
                    { 48, "3d8ac8ca-08f2-4b10-82ba-55f2b39a5f16", 9, null, "Adipiscing ut leo, elementum auctor, congue ex ipsum mollis commodo, orci et, nam ligula porttitor, nisi, massa, libero. Lacinia, nec, per nibh, feugiat sapien viverra pulvinar, non nulla, augue vel, maximus tempus sagittis, porta, tellus. Tellus adipiscing tristique erat, varius, purus mi nec congue, vel, risus. Aliquam himenaeos commodo praesent non, taciti iaculis nunc maecenas hendrerit lorem aenean.", new DateTime(2024, 4, 5, 1, 28, 23, 733, DateTimeKind.Local).AddTicks(1532), true, 11, "Suscipit aptent maecenas ante enim vestibulum sapien sociosqu blandit viverra mi odio quis", "Ex augue litora", 195, "urna-aenean-morbi", 225 },
                    { 49, "3d8ac8ca-08f2-4b10-82ba-55f2b39a5f16", 10, null, "Tellus, lobortis congue rhoncus adipiscing id, pretium lorem hac vulputate nibh, tortor, lectus neque, habitasse urna, nunc himenaeos. Cursus, id, nullam phasellus vitae orci, egestas aptent ipsum scelerisque primis imperdiet eleifend, commodo, cursus nibh magna, lacinia. Ligula enim fermentum orci, rhoncus himenaeos integer ante, odio molestie primis tortor, elementum finibus, ultrices, auctor, donec in, aptent. Urna morbi ligula, turpis sed auctor, dapibus pretium nisi, convallis congue porta eleifend, urna, lorem, fusce adipiscing. Porttitor viverra non, neque pellentesque fames id inceptos blandit, vitae pulvinar, urna urna, porta venenatis feugiat, sodales ex, aenean. Faucibus sed amet aliquam scelerisque mattis, dolor eros ad fringilla, rhoncus, viverra ultrices auctor, congue ante, consequat elementum.", new DateTime(2024, 4, 2, 5, 21, 23, 733, DateTimeKind.Local).AddTicks(4590), true, 23, "Bibendum rhoncus ac elementum ante laoreet eros aliquam sit aliquet at interdum arcu", "Vestibulum feugiat tellus", 192, "luctus-elementum-aliquam", 215 },
                    { 50, "81956a67-a277-4359-b59d-39200a35d6e7", 1, null, "Dignissim arcu, nisi, euismod, magna tortor, elit nam et, a pretium neque, condimentum ut quis sodales dictum metus vivamus. Suspendisse tempor, est rutrum finibus, dolor, enim lobortis aliquam convallis quam, volutpat. A, at, vitae morbi auctor, rhoncus ultrices laoreet, facilisis nullam suspendisse porttitor, torquent a adipiscing dictumst non, nibh amet. Nostra, malesuada elementum dignissim erat nec, posuere euismod, at fames himenaeos commodo eget tempor. Tortor laoreet, finibus fringilla, amet, cursus, sed, varius dignissim purus et, ullamcorper.", new DateTime(2024, 4, 8, 11, 44, 23, 733, DateTimeKind.Local).AddTicks(7253), true, 26, "Non laoreet quis ante orci volutpat sem felis risus tempor mattis euismod sed", "Nec justo pulvinar", 187, "dictumst-id-lectus", 267 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "50aa55ba-fa89-4653-91e6-3fa9100476db", "3d8ac8ca-08f2-4b10-82ba-55f2b39a5f16" },
                    { "dac92444-87c7-47a8-a88a-1c2a21bad1c4", "76cbe9b4-9531-4375-881f-b7cf82f0caab" },
                    { "27cef948-cd91-4ae1-977b-f1320e13aff5", "81956a67-a277-4359-b59d-39200a35d6e7" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentHeader", "CommentText", "CommentTime", "Email", "Name", "PostId" },
                values: new object[,]
                {
                    { 1, "Lectus duis ultrices", "Mattis, maximus proin commodo platea et in, in nisi risus cras.", new DateTime(2024, 4, 8, 2, 45, 23, 734, DateTimeKind.Local).AddTicks(5012), "torquent@varius.com", "Aliquam lobortis", 42 },
                    { 2, "Euismod cras efficitur", "Eros, nostra, porta donec egestas ante a tristique vel mi velit tincidunt adipiscing tempor, iaculis quam, tortor ultricies himenaeos. Fermentum et lorem egestas pharetra ac elit, accumsan lectus, dictum hendrerit dignissim sed, nulla massa.", new DateTime(2024, 4, 8, 1, 1, 23, 734, DateTimeKind.Local).AddTicks(6957), "hac@leo.com", "Ut lacinia", 4 },
                    { 3, "Odio mattis euismod", "Primis bibendum, elit, dignissim elit euismod, ex ligula, consectetur ante, at inceptos feugiat, pulvinar ultrices, sed.", new DateTime(2024, 4, 4, 22, 24, 23, 734, DateTimeKind.Local).AddTicks(8597), "arcu@mattis.com", "Non velit", 37 },
                    { 4, "Viverra volutpat efficitur", "Feugiat nisi, hac et, laoreet eu iaculis pharetra sapien aliquet euismod imperdiet interdum rhoncus, curabitur platea enim, at, tristique.", new DateTime(2024, 4, 8, 3, 48, 23, 735, DateTimeKind.Local).AddTicks(254), "dapibus@tortor.com", "Nisi tempor", 39 },
                    { 5, "Vitae ante et", "Bibendum aliquam sodales arcu amet, at, semper odio sagittis nisi commodo felis ligula diam laoreet, fringilla, eleifend enim.", new DateTime(2024, 3, 30, 9, 6, 23, 735, DateTimeKind.Local).AddTicks(1881), "lorem@pretium.com", "Vel cursus", 40 },
                    { 6, "Habitasse libero iaculis", "Accumsan curabitur at laoreet, posuere augue donec erat, erat ante dignissim ligula. Lacinia molestie nisl etiam ultricies dolor rutrum facilisis viverra finibus, fringilla urna, dignissim phasellus porttitor, porta.", new DateTime(2024, 4, 5, 0, 43, 23, 735, DateTimeKind.Local).AddTicks(3830), "integer@congue.com", "Tempor lorem", 39 },
                    { 7, "Bibendum sodales amet", "Aliquam volutpat, magna, varius, lobortis tellus, quis, leo, finibus, arcu, porttitor sit ultricies id orci, tincidunt fusce. Vehicula a, venenatis orci nec euismod luctus blandit, vitae fermentum purus euismod, ultrices vestibulum diam.", new DateTime(2024, 4, 6, 15, 8, 23, 735, DateTimeKind.Local).AddTicks(5951), "ante@bibendum.com", "Rhoncus consequat", 40 },
                    { 8, "Pharetra ad ipsum", "Eleifend, eleifend lectus, et class leo velit vestibulum, fermentum luctus, amet, iaculis metus quis porta porttitor.", new DateTime(2024, 4, 8, 15, 14, 23, 735, DateTimeKind.Local).AddTicks(7582), "malesuada@dui.com", "Ante fames", 1 },
                    { 9, "Enim eros lacinia", "Magna, consectetur vitae, auctor, nam nec lacinia, leo mattis, aptent aliquet ultrices, torquent sit ornare risus euismod tincidunt. Dignissim commodo sed hendrerit nibh, fames neque, nisl varius, enim, urna, vivamus porttitor vulputate consequat.", new DateTime(2024, 4, 6, 13, 6, 23, 735, DateTimeKind.Local).AddTicks(9532), "velit@euismod.com", "Elit tristique", 35 },
                    { 10, "Rhoncus sem non", "Proin mattis semper adipiscing commodo, litora vitae, leo volutpat, vestibulum, vehicula leo, primis congue.", new DateTime(2024, 4, 4, 6, 5, 23, 736, DateTimeKind.Local).AddTicks(1190), "morbi@mi.com", "Turpis elit", 10 },
                    { 11, "Vulputate dolor malesuada", "Dictum nunc, nec, turpis euismod, lobortis fringilla, eu luctus, torquent pretium hendrerit platea aliquam quis, per. Feugiat, urna, sem dolor arcu eu, orci, cursus id, lorem scelerisque ultricies aliquam mauris.", new DateTime(2024, 4, 6, 22, 42, 23, 736, DateTimeKind.Local).AddTicks(3183), "lacinia@vitae.com", "Elit conubia", 45 },
                    { 12, "Augue lobortis aptent", "Ac faucibus placerat, dapibus volutpat felis eu, laoreet porttitor, est.", new DateTime(2024, 4, 6, 18, 58, 23, 736, DateTimeKind.Local).AddTicks(4882), "porta@dolor.com", "Adipiscing rutrum", 26 },
                    { 13, "Ante placerat luctus", "Duis consequat ante porttitor, elit blandit, et, cursus praesent massa, donec. A, eu, egestas posuere tristique purus tempus arcu venenatis porta, nulla convallis amet, in efficitur.", new DateTime(2024, 3, 31, 6, 39, 23, 736, DateTimeKind.Local).AddTicks(6826), "molestie@lobortis.com", "Eget non", 27 },
                    { 14, "Massa vel etiam", "Praesent nec, arcu, egestas vivamus venenatis sit blandit augue quis lacinia rutrum erat. Scelerisque id, velit feugiat sit justo sollicitudin blandit, suspendisse a orci euismod accumsan est mattis, nisl.", new DateTime(2024, 3, 31, 19, 9, 23, 736, DateTimeKind.Local).AddTicks(8816), "ipsum@maximus.com", "Pretium et", 4 },
                    { 15, "Pretium porttitor ante", "Libero semper dolor, finibus, morbi ornare sociosqu posuere, vitae, pharetra nec. Vestibulum dolor, ante, bibendum, posuere magna, urna nisi inceptos volutpat, vitae.", new DateTime(2024, 3, 31, 16, 27, 23, 737, DateTimeKind.Local).AddTicks(727), "eros@sem.com", "Aenean id", 16 },
                    { 16, "Nisi mi sapien", "Per augue magna varius, urna, quam duis molestie et eros, efficitur quis, conubia arcu, lacinia, enim nullam. Odio, curabitur vehicula ac arcu, blandit, massa ante condimentum finibus at, cursus et.", new DateTime(2024, 4, 6, 20, 23, 23, 737, DateTimeKind.Local).AddTicks(2667), "tortor@cursus.com", "Ultrices lacinia", 4 },
                    { 17, "Elit mattis per", "Porttitor phasellus posuere, lacinia, in arcu est fames mi viverra vivamus ad a aliquam.", new DateTime(2024, 3, 31, 11, 0, 23, 737, DateTimeKind.Local).AddTicks(4315), "nibh@risus.com", "Per placerat", 49 },
                    { 18, "Elit mauris augue", "Tempor taciti cras odio, congue enim, dictumst eleifend massa, lectus, dui. Tortor, tempus convallis sodales lorem proin nibh porta velit feugiat turpis vel imperdiet placerat, lectus condimentum commodo, nisl odio.", new DateTime(2024, 4, 3, 5, 20, 23, 737, DateTimeKind.Local).AddTicks(6268), "convallis@finibus.com", "Turpis nullam", 1 },
                    { 19, "Vivamus dolor et", "Sed, ligula, sollicitudin non, feugiat, nunc, blandit ullamcorper at nullam varius, mollis quam, eu.", new DateTime(2024, 4, 1, 3, 7, 23, 737, DateTimeKind.Local).AddTicks(7862), "maximus@in.com", "Libero est", 17 },
                    { 20, "Sit nam litora", "Ante, ad tellus proin id, nibh, mattis tortor, viverra mi, commodo tempor lectus, eget diam accumsan. Auctor, porta euismod, a fermentum suscipit euismod urna inceptos turpis interdum, nibh, non.", new DateTime(2024, 4, 4, 8, 53, 23, 737, DateTimeKind.Local).AddTicks(9853), "et@feugiat.com", "Maximus donec", 4 },
                    { 21, "Nam urna pulvinar", "Dolor ante, congue, taciti ex facilisis urna, efficitur commodo, tristique dui, laoreet dui eget.", new DateTime(2024, 4, 4, 16, 56, 23, 738, DateTimeKind.Local).AddTicks(1450), "malesuada@mattis.com", "Sem enim", 44 },
                    { 22, "Ultrices orci habitasse", "Mauris aenean ultrices, leo, inceptos ac, laoreet, libero justo est erat lectus, commodo accumsan posuere, a.", new DateTime(2024, 4, 3, 7, 49, 23, 738, DateTimeKind.Local).AddTicks(3200), "porta@duis.com", "Aliquet eros", 43 },
                    { 23, "Libero sodales congue", "Commodo, tristique magna, congue viverra duis cursus aptent habitasse velit vitae quis at sodales vestibulum pellentesque mattis dolor a. Nibh, efficitur porta, tincidunt sed enim sagittis elementum in quis est.", new DateTime(2024, 4, 7, 23, 21, 23, 738, DateTimeKind.Local).AddTicks(5203), "dignissim@et.com", "Lacinia congue", 48 },
                    { 24, "Sociosqu aenean lorem", "Aliquet sit mattis curabitur ornare sed, turpis congue integer nec.", new DateTime(2024, 4, 3, 7, 27, 23, 738, DateTimeKind.Local).AddTicks(6754), "elementum@turpis.com", "Gravida mi", 29 },
                    { 25, "Semper ad risus", "Feugiat, quisque sed, gravida massa dictumst vulputate per euismod est conubia et molestie. Tortor mollis tristique placerat auctor, eros viverra blandit euismod euismod, aptent dui, mi urna, sagittis non convallis congue.", new DateTime(2024, 4, 5, 13, 54, 23, 738, DateTimeKind.Local).AddTicks(8660), "blandit@neque.com", "Cras sagittis", 26 },
                    { 26, "Feugiat eros sollicitudin", "Scelerisque efficitur commodo volutpat, hendrerit per erat lectus sagittis, in, volutpat conubia nostra, habitasse gravida ullamcorper posuere, magna.", new DateTime(2024, 3, 30, 0, 50, 23, 739, DateTimeKind.Local).AddTicks(238), "feugiat@iaculis.com", "Posuere odio", 46 },
                    { 27, "In turpis interdum", "Vitae, etiam nibh nunc porta, tellus, scelerisque nec mauris lobortis posuere vel, faucibus iaculis finibus in, duis leo, orci.", new DateTime(2024, 4, 6, 15, 33, 23, 739, DateTimeKind.Local).AddTicks(1818), "sit@aliquam.com", "Integer faucibus", 4 },
                    { 28, "Primis integer elit", "Primis sed massa pulvinar sem augue nam volutpat, rhoncus, ac vivamus.", new DateTime(2024, 3, 31, 3, 40, 23, 739, DateTimeKind.Local).AddTicks(3394), "lacinia@amet.com", "Posuere proin", 44 },
                    { 29, "Arcu blandit phasellus", "Nostra, fringilla ut efficitur leo, ultrices leo odio, inceptos mi enim, justo tortor. Bibendum, eleifend, dui gravida ullamcorper vivamus congue, sapien feugiat, pulvinar, fringilla, elit, enim ligula hac malesuada sed, himenaeos interdum.", new DateTime(2024, 4, 1, 15, 45, 23, 739, DateTimeKind.Local).AddTicks(5359), "tempus@dolor.com", "Fringilla purus", 7 },
                    { 30, "Ultrices in fringilla", "Tempor nunc, morbi quis, placerat purus interdum euismod dolor nulla molestie suscipit sem, laoreet, ex gravida vitae.", new DateTime(2024, 4, 7, 17, 31, 23, 739, DateTimeKind.Local).AddTicks(6948), "et@curabitur.com", "Erat augue", 23 },
                    { 31, "Ex lobortis mauris", "Lacus nec fermentum elit, ornare phasellus mattis aliquet bibendum, eros sem, ligula, urna, viverra varius, sed, dictum.", new DateTime(2024, 4, 6, 0, 4, 23, 739, DateTimeKind.Local).AddTicks(8493), "magna@ante.com", "Dapibus nam", 38 },
                    { 32, "Donec lacus semper", "Eu molestie massa pretium dignissim posuere magna, a cursus, tincidunt praesent lorem non, ac.", new DateTime(2024, 4, 8, 21, 29, 23, 740, DateTimeKind.Local).AddTicks(46), "posuere@tincidunt.com", "Mattis mauris", 28 },
                    { 33, "Tortor sagittis pulvinar", "Feugiat dictumst blandit, molestie a, non adipiscing himenaeos at mauris ante fermentum aliquam mi mauris, quisque venenatis luctus, enim.", new DateTime(2024, 4, 4, 4, 48, 23, 740, DateTimeKind.Local).AddTicks(1600), "platea@tortor.com", "Nunc dignissim", 24 },
                    { 34, "Elit hendrerit eu", "Pellentesque mauris, et dolor tellus, ligula sem, tortor, maecenas ad consequat tempor. Ante, mattis, blandit rhoncus, odio torquent rhoncus aliquet posuere, massa.", new DateTime(2024, 4, 4, 17, 4, 23, 740, DateTimeKind.Local).AddTicks(3629), "nibh@morbi.com", "Velit amet", 38 },
                    { 35, "Mi hendrerit luctus", "Blandit dictumst duis interdum eros, congue nibh dolor, sapien hac quisque arcu vitae, litora imperdiet orci, malesuada sagittis. Arcu efficitur quis, in posuere nec eros, conubia interdum, condimentum eu.", new DateTime(2024, 4, 5, 6, 33, 23, 740, DateTimeKind.Local).AddTicks(5536), "suscipit@semper.com", "Sed felis", 7 },
                    { 36, "Et congue dui", "Fringilla ut id, sapien sit est pulvinar, conubia dapibus tortor, dui augue vel, congue.", new DateTime(2024, 4, 4, 19, 4, 23, 740, DateTimeKind.Local).AddTicks(7169), "turpis@conubia.com", "Rutrum neque", 26 },
                    { 37, "Dictum mauris sodales", "Magna, lacinia, sagittis, iaculis odio, imperdiet primis etiam orci, eleifend at vulputate enim vehicula condimentum.", new DateTime(2024, 4, 1, 22, 20, 23, 740, DateTimeKind.Local).AddTicks(8774), "varius@molestie.com", "Pulvinar integer", 40 },
                    { 38, "Accumsan auctor lectus", "Aenean vehicula quis, nunc, diam urna interdum, gravida eleifend elementum.", new DateTime(2024, 4, 4, 3, 55, 23, 741, DateTimeKind.Local).AddTicks(354), "volutpat@aenean.com", "Tristique nunc", 25 },
                    { 39, "Magna vulputate arcu", "Aliquet finibus porttitor pharetra molestie duis fringilla mi feugiat aenean odio orci, ex laoreet quis, sed, placerat, platea a. Elit, facilisis aliquet quam, pulvinar, consequat luctus tempus auctor nullam eros, himenaeos orci.", new DateTime(2024, 4, 6, 16, 6, 23, 741, DateTimeKind.Local).AddTicks(2248), "finibus@aliquam.com", "Egestas sapien", 29 },
                    { 40, "Erat fringilla semper", "Volutpat, volutpat odio, a, elit consectetur curabitur at, diam class ac.", new DateTime(2024, 4, 2, 7, 58, 23, 741, DateTimeKind.Local).AddTicks(3815), "nullam@elit.com", "Feugiat pulvinar", 14 },
                    { 41, "Massa phasellus curabitur", "Sit nisi ultricies mollis scelerisque morbi himenaeos ullamcorper nibh integer cursus. Rhoncus, amet, lectus, ullamcorper interdum leo dictumst ac mauris, magna nunc, commodo per urna platea ipsum tristique.", new DateTime(2024, 4, 2, 3, 34, 23, 741, DateTimeKind.Local).AddTicks(5699), "diam@primis.com", "Feugiat auctor", 30 },
                    { 42, "Blandit duis congue", "Vulputate hac proin porta nunc velit nisl feugiat diam fringilla, et, euismod, quam, tempor quam nulla. Phasellus adipiscing accumsan orci vulputate sociosqu nec, et, pharetra arcu, bibendum, torquent tempus molestie platea convallis morbi.", new DateTime(2024, 3, 30, 14, 33, 23, 741, DateTimeKind.Local).AddTicks(7614), "purus@nulla.com", "Phasellus sagittis", 41 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentHeader", "CommentText", "CommentTime", "Email", "Name", "PostId" },
                values: new object[,]
                {
                    { 43, "Pellentesque orci neque", "Facilisis hac rutrum quis, mi, quisque lectus tellus sem, bibendum, ipsum adipiscing torquent tempor vestibulum, lobortis vitae.", new DateTime(2024, 3, 31, 14, 39, 23, 741, DateTimeKind.Local).AddTicks(9216), "vestibulum@tortor.com", "Eros tempor", 42 },
                    { 44, "Porttitor amet laoreet", "Tempus torquent vehicula metus malesuada suspendisse cursus, elit porttitor, nec lectus, nisi, dictum.", new DateTime(2024, 4, 3, 17, 13, 23, 742, DateTimeKind.Local).AddTicks(830), "mi@tincidunt.com", "Metus volutpat", 10 },
                    { 45, "Amet taciti ipsum", "Tincidunt laoreet egestas ex, finibus, eros nisi, id pharetra leo, enim, felis sagittis, purus rhoncus, rhoncus urna, lectus, dui. Blandit nibh, auctor, conubia rhoncus facilisis commodo efficitur nunc, auctor blandit, primis leo vehicula interdum.", new DateTime(2024, 4, 5, 17, 1, 23, 742, DateTimeKind.Local).AddTicks(2842), "neque@proin.com", "Morbi interdum", 1 },
                    { 46, "Cursus imperdiet scelerisque", "Cras rutrum efficitur fringilla blandit eros libero finibus, elementum luctus, congue rhoncus auctor, lorem nisi quam, est quis. Vivamus luctus orci dui, aliquam non, porttitor, blandit, odio primis vitae etiam euismod iaculis laoreet, egestas tristique.", new DateTime(2024, 4, 4, 18, 39, 23, 742, DateTimeKind.Local).AddTicks(4847), "venenatis@ullamcorper.com", "Nisi ante", 41 },
                    { 47, "Euismod tempor ultrices", "Etiam eget mollis tempus ligula, curabitur pretium quis, nisl ut laoreet finibus, eros in, vel, enim.", new DateTime(2024, 4, 6, 22, 0, 23, 742, DateTimeKind.Local).AddTicks(6497), "justo@elit.com", "Sed malesuada", 4 },
                    { 48, "Curabitur laoreet neque", "Orci, euismod class ex sem, auctor, fames porttitor ante, viverra.", new DateTime(2024, 4, 3, 5, 22, 23, 742, DateTimeKind.Local).AddTicks(8075), "ut@varius.com", "Massa ad", 10 },
                    { 49, "Ac blandit in", "Platea eleifend turpis commodo, risus torquent mauris, mollis rhoncus bibendum vivamus per tempor aptent imperdiet. Ornare magna et, mollis placerat sem, maecenas nulla, egestas pellentesque ex.", new DateTime(2024, 4, 6, 14, 11, 23, 743, DateTimeKind.Local).AddTicks(25), "ante@at.com", "Bibendum mattis", 2 },
                    { 50, "Interdum justo lorem", "Volutpat scelerisque eros etiam erat, ornare volutpat, tincidunt cursus elit venenatis egestas convallis non, nostra, finibus. Hendrerit finibus vestibulum, varius, convallis elit mauris ante fringilla, laoreet, scelerisque pulvinar, varius.", new DateTime(2024, 4, 2, 12, 43, 23, 743, DateTimeKind.Local).AddTicks(1894), "quam@rutrum.com", "Dictum sem", 20 },
                    { 51, "Augue pretium neque", "Odio, ex, platea luctus dictumst curabitur commodo orci, leo, sapien mattis et ante, nec tristique vel. Himenaeos in, a, aliquam habitasse interdum, molestie metus vulputate enim.", new DateTime(2024, 4, 6, 14, 12, 23, 743, DateTimeKind.Local).AddTicks(3805), "accumsan@nulla.com", "Placerat purus", 12 },
                    { 52, "Eleifend blandit eu", "Odio litora iaculis imperdiet commodo euismod, feugiat, amet, pellentesque rutrum quis, auctor mauris id erat inceptos etiam phasellus.", new DateTime(2024, 4, 8, 23, 1, 23, 743, DateTimeKind.Local).AddTicks(5401), "sodales@quam.com", "Nulla euismod", 14 },
                    { 53, "At nibh a", "Euismod, neque ornare semper vehicula nisi lectus, sed, interdum, porttitor, curabitur. Tortor conubia habitasse at placerat, porta pulvinar commodo morbi lorem velit id nullam nostra, commodo, maximus libero finibus imperdiet.", new DateTime(2024, 3, 30, 3, 47, 23, 743, DateTimeKind.Local).AddTicks(7344), "est@pulvinar.com", "Ultricies per", 29 },
                    { 54, "Tortor ante ultricies", "Quam, arcu elit, adipiscing orci, vulputate tortor, ut nunc mauris, elementum elit et. Libero nam eleifend magna, laoreet eu, fusce duis facilisis tortor, porttitor, sodales lectus, sit.", new DateTime(2024, 4, 4, 13, 14, 23, 743, DateTimeKind.Local).AddTicks(9399), "metus@sapien.com", "Phasellus aptent", 47 },
                    { 55, "Mattis congue proin", "Mattis, porta elit, blandit, velit himenaeos ante arcu torquent amet. In, lectus, himenaeos nibh platea porttitor, elit, ac, morbi dapibus eget lectus arcu at lacus sem, ex.", new DateTime(2024, 4, 2, 10, 28, 23, 744, DateTimeKind.Local).AddTicks(1362), "pellentesque@vitae.com", "Mauris nulla", 35 },
                    { 56, "Imperdiet volutpat phasellus", "Luctus vel erat cursus nam quam, mi, tristique efficitur feugiat, lorem, odio, pellentesque eros. Mollis maecenas nostra, duis cursus, urna feugiat, ante, consequat nec, rutrum pretium.", new DateTime(2024, 4, 3, 2, 42, 23, 744, DateTimeKind.Local).AddTicks(3341), "at@elit.com", "Lobortis aptent", 6 },
                    { 57, "Neque sollicitudin non", "Tincidunt odio etiam bibendum justo elit eleifend, semper proin nullam sem, sit sed.", new DateTime(2024, 4, 3, 1, 49, 23, 744, DateTimeKind.Local).AddTicks(5060), "lacus@orci.com", "Non sagittis", 7 },
                    { 58, "Bibendum mollis integer", "Et, nisl aliquam rhoncus eget arcu, euismod, fringilla, metus proin amet.", new DateTime(2024, 3, 30, 5, 33, 23, 744, DateTimeKind.Local).AddTicks(6667), "sem@hac.com", "Feugiat facilisis", 1 },
                    { 59, "Consectetur non luctus", "Vel, lectus, blandit, nec, ac, iaculis dui elit elit, dui, pulvinar proin aptent faucibus. Dui placerat facilisis vestibulum nulla eleifend maecenas nunc, per interdum.", new DateTime(2024, 3, 31, 22, 56, 23, 744, DateTimeKind.Local).AddTicks(8640), "magna@a.com", "Morbi egestas", 37 },
                    { 60, "Dictumst nunc vitae", "Nam etiam leo lectus, blandit consequat viverra aenean cras conubia. Neque, nullam iaculis suscipit eleifend, posuere, arcu, fames aliquet class leo fermentum fringilla hac a facilisis rhoncus fusce ad.", new DateTime(2024, 3, 31, 11, 40, 23, 745, DateTimeKind.Local).AddTicks(615), "mollis@dolor.com", "Vitae tristique", 40 },
                    { 61, "Velit eu cras", "Proin pharetra cursus, non, interdum, aliquet scelerisque varius, aenean suscipit risus ornare tincidunt libero eu.", new DateTime(2024, 4, 5, 6, 49, 23, 745, DateTimeKind.Local).AddTicks(2212), "at@enim.com", "Et eleifend", 47 },
                    { 62, "Ornare luctus eget", "Neque, eu bibendum, facilisis aliquam proin varius est magna, tellus sociosqu donec auctor, ad. Sagittis, finibus mi, tempor, bibendum semper sem, id, pretium iaculis tristique ante, eros purus integer luctus, laoreet fusce.", new DateTime(2024, 4, 4, 3, 23, 23, 745, DateTimeKind.Local).AddTicks(4541), "nulla@pulvinar.com", "Pellentesque non", 33 },
                    { 63, "Libero congue dui", "Vitae, ante, interdum porttitor, vehicula adipiscing ornare lectus, viverra aenean suspendisse massa vestibulum, maximus eros, egestas.", new DateTime(2024, 4, 7, 5, 9, 23, 745, DateTimeKind.Local).AddTicks(6204), "suscipit@eros.com", "Massa eget", 29 },
                    { 64, "Quisque sagittis nulla", "Velit ligula, fringilla nunc convallis proin nibh, facilisis curabitur sodales.", new DateTime(2024, 4, 1, 4, 54, 23, 745, DateTimeKind.Local).AddTicks(7841), "enim@aliquet.com", "Nibh tincidunt", 17 },
                    { 65, "Orci arcu taciti", "Proin justo mi ultrices mattis ut fusce varius euismod, at nisl id luctus, placerat, magna. Quam, sit sagittis, class a, finibus cras congue, nisi, augue tortor, nam adipiscing consequat eleifend, rhoncus, eu, commodo nulla.", new DateTime(2024, 4, 5, 19, 52, 23, 745, DateTimeKind.Local).AddTicks(9884), "nostra@dolor.com", "Eget luctus", 10 },
                    { 66, "Orci varius dignissim", "Maecenas congue neque, elit ante varius, tortor tempor, scelerisque felis habitasse sagittis, gravida nulla facilisis sed mauris ex.", new DateTime(2024, 4, 3, 13, 59, 23, 746, DateTimeKind.Local).AddTicks(1504), "faucibus@aptent.com", "Posuere sem", 47 },
                    { 67, "Amet odio platea", "Neque dui, semper ultricies porta, leo id vitae morbi dignissim vivamus ipsum habitasse sem, urna, ad. Cras primis amet orci, varius risus suscipit libero aenean eros, interdum, quis adipiscing mauris, nunc consectetur lorem.", new DateTime(2024, 4, 3, 10, 11, 23, 746, DateTimeKind.Local).AddTicks(3550), "vehicula@eu.com", "Tincidunt eu", 8 },
                    { 68, "Molestie sem eros", "Tempus eleifend, vitae, cursus, enim, mollis fringilla, tristique ante, neque orci eget quis, ex nam taciti erat, inceptos.", new DateTime(2024, 4, 5, 4, 10, 23, 746, DateTimeKind.Local).AddTicks(5371), "leo@viverra.com", "Vitae hac", 14 },
                    { 69, "Fringilla aliquam turpis", "Ligula et nam torquent interdum, platea tortor, suspendisse quam auctor, odio, ullamcorper enim, ut himenaeos mauris, suscipit.", new DateTime(2024, 4, 7, 23, 12, 23, 746, DateTimeKind.Local).AddTicks(6938), "eu@habitasse.com", "Fusce tortor", 49 },
                    { 70, "Elit elit mi", "Nisi, ultrices, porta, mi morbi orci, libero dapibus ac, hendrerit felis cursus rutrum consequat sed, donec at. Euismod lectus venenatis leo varius at amet ipsum donec adipiscing eros, neque, orci, in augue lacus ex, maecenas a.", new DateTime(2024, 4, 3, 22, 50, 23, 746, DateTimeKind.Local).AddTicks(8943), "libero@imperdiet.com", "Nulla vulputate", 48 },
                    { 71, "Quam nunc euismod", "At, lacinia, massa, vitae fringilla, dictum tellus, magna sociosqu sagittis fermentum nec, elementum elit, et, fringilla.", new DateTime(2024, 4, 1, 17, 37, 23, 747, DateTimeKind.Local).AddTicks(590), "nulla@lorem.com", "Ac leo", 29 },
                    { 72, "Hac auctor a", "Interdum, blandit nec felis vitae lectus ante placerat, imperdiet vivamus ultrices, odio.", new DateTime(2024, 3, 31, 6, 15, 23, 747, DateTimeKind.Local).AddTicks(2160), "nisi@egestas.com", "Conubia porta", 7 },
                    { 73, "Maecenas ligula sit", "In sem luctus, conubia id, enim porta, taciti per lectus urna, volutpat.", new DateTime(2024, 3, 30, 22, 27, 23, 747, DateTimeKind.Local).AddTicks(3747), "sociosqu@id.com", "Nisi neque", 50 },
                    { 74, "Tempor ante consequat", "Interdum, condimentum consectetur porta hac pulvinar, ligula, in, eleifend amet congue massa, justo porttitor et, lobortis.", new DateTime(2024, 4, 1, 22, 46, 23, 747, DateTimeKind.Local).AddTicks(5408), "neque@curabitur.com", "Eleifend ex", 24 },
                    { 75, "Erat lacinia gravida", "Dui duis ex, aliquet orci, vel, vulputate cursus, dignissim urna. Lobortis quam, molestie nisi ultrices tortor, et adipiscing ante porta id in habitasse nam pharetra posuere, efficitur urna.", new DateTime(2024, 3, 30, 4, 22, 23, 747, DateTimeKind.Local).AddTicks(7324), "vestibulum@amet.com", "Consequat congue", 43 },
                    { 76, "Sed pulvinar luctus", "Gravida etiam morbi elit eros leo, cursus vel, sagittis, venenatis sed, elementum facilisis metus nam. Dui ante erat, amet turpis velit amet, est etiam class tincidunt dolor.", new DateTime(2024, 3, 31, 19, 55, 23, 747, DateTimeKind.Local).AddTicks(9198), "porttitor@at.com", "Class sed", 6 },
                    { 77, "Quam porttitor scelerisque", "Nibh non, et, dui vivamus suspendisse non ultricies dui, laoreet cras. Vulputate faucibus a vel, consectetur mollis justo maximus et, sodales ultricies luctus tortor, pellentesque nullam convallis nibh.", new DateTime(2024, 4, 5, 11, 5, 23, 748, DateTimeKind.Local).AddTicks(1120), "elementum@per.com", "Pretium platea", 21 },
                    { 78, "Ad commodo in", "Risus tincidunt dapibus orci, fringilla ligula interdum, duis blandit justo feugiat, turpis nec.", new DateTime(2024, 4, 7, 22, 47, 23, 748, DateTimeKind.Local).AddTicks(2720), "sollicitudin@posuere.com", "Ut vestibulum", 35 },
                    { 79, "Semper sed erat", "Per non, pretium morbi ex molestie vitae, sagittis, efficitur platea class odio, elit.", new DateTime(2024, 4, 4, 0, 48, 23, 748, DateTimeKind.Local).AddTicks(4320), "tristique@eleifend.com", "Placerat quisque", 37 },
                    { 80, "Erat himenaeos arcu", "Aenean sociosqu at a dolor, rhoncus tempor, aliquam lacus ligula, neque urna, nulla ornare. Fames etiam adipiscing lectus, nisi hac dictumst arcu pharetra dui, finibus.", new DateTime(2024, 4, 8, 5, 49, 23, 748, DateTimeKind.Local).AddTicks(6235), "condimentum@iaculis.com", "Non libero", 28 },
                    { 81, "Nec sem aliquet", "Purus maximus vivamus nunc, duis arcu auctor, efficitur rhoncus, aliquet aenean a. Leo fermentum ornare non lectus ut sodales posuere, facilisis aenean nam dui, libero in, curabitur iaculis placerat quisque.", new DateTime(2024, 4, 2, 5, 5, 23, 748, DateTimeKind.Local).AddTicks(8163), "sagittis@nostra.com", "Erat varius", 43 },
                    { 82, "Praesent lectus sem", "A, rhoncus, morbi non sagittis, feugiat, odio, imperdiet eros, placerat, quisque erat, urna finibus. Magna, lorem, tellus fringilla primis diam enim, finibus, eu sagittis sed, blandit tortor maximus vivamus non.", new DateTime(2024, 4, 8, 18, 46, 23, 749, DateTimeKind.Local).AddTicks(92), "aliquet@proin.com", "Odio tristique", 7 },
                    { 83, "Auctor ligula neque", "Luctus, dui ante ipsum a, sodales odio ac, vitae, erat, enim, nunc tellus at fusce.", new DateTime(2024, 4, 6, 7, 16, 23, 749, DateTimeKind.Local).AddTicks(1661), "vitae@cursus.com", "Dapibus erat", 42 },
                    { 84, "Tortor lacinia cras", "Primis odio ante, taciti iaculis ornare congue congue, nunc, nisl ex, tempor, bibendum, nunc. Vestibulum mauris, ornare ligula, mattis, ultrices erat massa auctor libero sagittis lacus posuere.", new DateTime(2024, 4, 8, 20, 19, 23, 749, DateTimeKind.Local).AddTicks(3638), "quis@cursus.com", "Tortor eleifend", 13 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentHeader", "CommentText", "CommentTime", "Email", "Name", "PostId" },
                values: new object[,]
                {
                    { 85, "Risus ligula laoreet", "Ac torquent sapien volutpat maecenas pulvinar, metus ultrices, bibendum lectus, vestibulum vehicula vulputate varius euismod.", new DateTime(2024, 4, 2, 14, 24, 23, 749, DateTimeKind.Local).AddTicks(5217), "nostra@quis.com", "Ornare elementum", 50 },
                    { 86, "Hac eu eleifend", "Nunc, vel, vitae lectus, eleifend curabitur torquent tempor nostra, quam quisque. Nisi, nec, porttitor tempor quam, magna varius, et, dignissim morbi elit, at, hendrerit.", new DateTime(2024, 4, 6, 21, 52, 23, 749, DateTimeKind.Local).AddTicks(7166), "a@risus.com", "Pellentesque metus", 9 },
                    { 87, "Augue ex tempor", "Quisque magna, felis nostra, mauris, interdum vestibulum, vivamus ad tempor, sagittis, tristique rhoncus pulvinar, mattis, praesent arcu urna.", new DateTime(2024, 4, 3, 9, 3, 23, 749, DateTimeKind.Local).AddTicks(8708), "quis@scelerisque.com", "Dolor maecenas", 16 },
                    { 88, "Dui fringilla lacus", "Sed ante, laoreet, vestibulum, nostra, eleifend pellentesque tempor, congue, interdum, donec. Enim massa nunc, sed, accumsan eu luctus eros, eget orci auctor, nibh ut a sagittis.", new DateTime(2024, 4, 3, 22, 37, 23, 750, DateTimeKind.Local).AddTicks(597), "iaculis@feugiat.com", "Aptent volutpat", 41 },
                    { 89, "Donec cursus laoreet", "Aenean viverra sagittis vulputate integer vestibulum, est posuere ut velit vehicula sed luctus, eros cras proin a, metus nunc.", new DateTime(2024, 3, 30, 0, 59, 23, 750, DateTimeKind.Local).AddTicks(2262), "sagittis@arcu.com", "Proin euismod", 5 },
                    { 90, "Eros phasellus tellus", "Ultrices leo, urna finibus quis porta tortor, auctor, praesent lorem conubia faucibus nullam orci, bibendum.", new DateTime(2024, 4, 6, 8, 43, 23, 750, DateTimeKind.Local).AddTicks(3884), "ut@enim.com", "Phasellus orci", 8 },
                    { 91, "Congue varius lectus", "Hac mauris, sit vitae purus duis suscipit viverra odio enim dignissim vestibulum ipsum sed. Ut nec libero varius, vestibulum semper sed quam suscipit iaculis congue, lectus, elementum porta lorem, pretium.", new DateTime(2024, 4, 5, 18, 3, 23, 750, DateTimeKind.Local).AddTicks(5872), "lobortis@ut.com", "Sed urna", 41 },
                    { 92, "Ac in pellentesque", "A odio, lacus duis ante, non, taciti lacinia quam quis, eleifend. Pellentesque et lacinia tristique magna, lacinia, ante, sodales sapien sagittis at felis fermentum a, euismod.", new DateTime(2024, 4, 3, 20, 15, 23, 750, DateTimeKind.Local).AddTicks(7824), "blandit@placerat.com", "Semper euismod", 4 },
                    { 93, "Ligula posuere ante", "Elementum odio mauris iaculis class integer adipiscing magna, mauris, taciti nunc volutpat, ut gravida nam nunc, id, interdum nulla. Fringilla platea id, eleifend, blandit congue, nec, lacinia per maximus ultrices enim nostra, in volutpat, vestibulum, justo.", new DateTime(2024, 4, 1, 2, 37, 23, 750, DateTimeKind.Local).AddTicks(9781), "velit@ornare.com", "Rhoncus venenatis", 17 },
                    { 94, "Ex quam porttitor", "Ac, placerat, nullam non, pulvinar neque, consequat et scelerisque donec consectetur per est aliquet gravida porta. Mauris, placerat, nullam porttitor, eu hendrerit quis felis inceptos cursus purus maximus augue metus in, semper volutpat.", new DateTime(2024, 3, 31, 7, 34, 23, 751, DateTimeKind.Local).AddTicks(1687), "aptent@inceptos.com", "Ad turpis", 35 },
                    { 95, "Magna at accumsan", "Mi dapibus volutpat, ultrices, suspendisse at, turpis egestas amet dui, fames aliquam. Nisl sem, lorem, velit suspendisse curabitur aliquam sociosqu sem pulvinar, ornare urna.", new DateTime(2024, 4, 5, 23, 37, 23, 751, DateTimeKind.Local).AddTicks(3645), "commodo@ac.com", "Cursus platea", 36 },
                    { 96, "Nibh sodales elit", "Porttitor, sagittis ipsum ultrices, sed, feugiat, magna, habitasse mattis sem enim massa fringilla, pharetra a. Feugiat, gravida lorem quis primis risus eros, ligula, venenatis libero facilisis volutpat, mauris taciti.", new DateTime(2024, 4, 1, 21, 43, 23, 751, DateTimeKind.Local).AddTicks(5650), "odio@dictum.com", "Pulvinar at", 7 },
                    { 97, "Facilisis eleifend non", "Amet, dictumst nunc, eleifend, rutrum varius, luctus, ac, viverra justo tortor, urna velit.", new DateTime(2024, 4, 2, 0, 21, 23, 751, DateTimeKind.Local).AddTicks(7266), "odio@at.com", "Elit mollis", 25 },
                    { 98, "Sociosqu lacinia diam", "Interdum, diam cursus vel turpis luctus, rhoncus, himenaeos finibus, varius interdum ad quis.", new DateTime(2024, 4, 1, 5, 27, 23, 751, DateTimeKind.Local).AddTicks(8834), "taciti@commodo.com", "Porta lacinia", 1 },
                    { 99, "Egestas porttitor euismod", "Morbi erat malesuada dignissim scelerisque interdum primis sem, rhoncus posuere neque vitae nibh, luctus, ac.", new DateTime(2024, 4, 4, 14, 6, 23, 752, DateTimeKind.Local).AddTicks(476), "nunc@vitae.com", "Sagittis vitae", 31 },
                    { 100, "Volutpat luctus venenatis", "Pulvinar tincidunt mattis nec, risus non lacinia, tempor, tellus adipiscing ad porttitor, feugiat varius sodales dictum.", new DateTime(2024, 4, 2, 11, 47, 23, 752, DateTimeKind.Local).AddTicks(2038), "ex@mattis.com", "Volutpat taciti", 1 }
                });

            migrationBuilder.InsertData(
                table: "PostTagMaps",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 7 },
                    { 1, 16 },
                    { 2, 2 },
                    { 2, 6 },
                    { 2, 16 },
                    { 3, 1 },
                    { 3, 12 },
                    { 3, 17 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 11 },
                    { 5, 6 },
                    { 5, 7 },
                    { 5, 8 },
                    { 6, 2 },
                    { 6, 7 },
                    { 6, 8 },
                    { 7, 6 },
                    { 7, 11 },
                    { 7, 13 },
                    { 8, 7 },
                    { 8, 14 },
                    { 8, 17 },
                    { 9, 13 },
                    { 9, 14 }
                });

            migrationBuilder.InsertData(
                table: "PostTagMaps",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { 9, 16 },
                    { 10, 13 },
                    { 10, 15 },
                    { 10, 19 },
                    { 11, 4 },
                    { 11, 17 },
                    { 11, 19 },
                    { 12, 10 },
                    { 12, 13 },
                    { 12, 20 },
                    { 13, 6 },
                    { 13, 10 },
                    { 13, 19 },
                    { 14, 6 },
                    { 14, 9 },
                    { 14, 17 },
                    { 15, 5 },
                    { 15, 7 },
                    { 15, 17 },
                    { 16, 5 },
                    { 16, 12 },
                    { 16, 14 },
                    { 17, 1 },
                    { 17, 3 },
                    { 17, 12 },
                    { 18, 3 },
                    { 18, 6 },
                    { 18, 17 },
                    { 19, 3 },
                    { 19, 5 },
                    { 19, 15 },
                    { 20, 3 },
                    { 20, 6 },
                    { 20, 19 },
                    { 21, 3 },
                    { 21, 9 },
                    { 21, 14 },
                    { 22, 3 },
                    { 22, 14 },
                    { 22, 19 },
                    { 23, 2 },
                    { 23, 6 }
                });

            migrationBuilder.InsertData(
                table: "PostTagMaps",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { 23, 9 },
                    { 24, 6 },
                    { 24, 10 },
                    { 24, 13 },
                    { 25, 4 },
                    { 25, 13 },
                    { 25, 18 },
                    { 26, 1 },
                    { 26, 2 },
                    { 26, 9 },
                    { 27, 2 },
                    { 27, 7 },
                    { 27, 13 },
                    { 28, 3 },
                    { 28, 13 },
                    { 28, 14 },
                    { 29, 10 },
                    { 29, 15 },
                    { 29, 19 },
                    { 30, 7 },
                    { 30, 16 },
                    { 30, 20 },
                    { 31, 4 },
                    { 31, 11 },
                    { 31, 12 },
                    { 32, 7 },
                    { 32, 8 },
                    { 32, 11 },
                    { 33, 2 },
                    { 33, 5 },
                    { 33, 13 },
                    { 34, 7 },
                    { 34, 14 },
                    { 34, 20 },
                    { 35, 8 },
                    { 35, 11 },
                    { 35, 19 },
                    { 36, 1 },
                    { 36, 6 },
                    { 36, 11 },
                    { 37, 10 },
                    { 37, 12 }
                });

            migrationBuilder.InsertData(
                table: "PostTagMaps",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { 37, 18 },
                    { 38, 4 },
                    { 38, 16 },
                    { 38, 18 },
                    { 39, 10 },
                    { 39, 17 },
                    { 39, 20 },
                    { 40, 4 },
                    { 40, 5 },
                    { 40, 20 },
                    { 41, 4 },
                    { 41, 9 },
                    { 41, 11 },
                    { 42, 2 },
                    { 42, 15 },
                    { 42, 19 },
                    { 43, 2 },
                    { 43, 10 },
                    { 43, 18 },
                    { 44, 3 },
                    { 44, 8 },
                    { 44, 17 },
                    { 45, 1 },
                    { 45, 3 },
                    { 45, 9 },
                    { 46, 4 },
                    { 46, 14 },
                    { 46, 19 },
                    { 47, 4 },
                    { 47, 16 },
                    { 47, 19 },
                    { 48, 3 },
                    { 48, 4 },
                    { 48, 5 },
                    { 49, 8 },
                    { 49, 15 },
                    { 49, 18 },
                    { 50, 8 },
                    { 50, 12 },
                    { 50, 17 }
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

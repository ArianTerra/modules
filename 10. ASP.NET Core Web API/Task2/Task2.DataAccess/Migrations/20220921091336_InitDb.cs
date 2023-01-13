using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task2.DataAccess.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
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
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
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
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Name", "PublishDate", "Source" },
                values: new object[,]
                {
                    { new Guid("009c0114-a0c3-4c2b-80e3-6e3d05ae14db"), "Aut sapiente quisquam", new DateTime(2019, 10, 16, 1, 24, 36, 100, DateTimeKind.Local).AddTicks(5729), "https://destany.name" },
                    { new Guid("00e2d9ca-5286-4919-983a-d856161930e9"), "Vitae quia deserunt", new DateTime(2022, 5, 16, 1, 38, 37, 806, DateTimeKind.Local).AddTicks(1773), "http://tara.com" },
                    { new Guid("0244c8b7-fdd2-4d5a-b79d-f20448118425"), "Dolores molestiae dolorem", new DateTime(2021, 4, 5, 2, 0, 35, 630, DateTimeKind.Local).AddTicks(5775), "http://delmer.org" },
                    { new Guid("03813089-6293-4e38-998d-536106fe5fba"), "Neque eaque enim", new DateTime(2022, 5, 19, 11, 21, 35, 626, DateTimeKind.Local).AddTicks(5847), "http://nathan.name" },
                    { new Guid("03cdd312-c01e-480c-983b-582ef977f778"), "Voluptate adipisci a", new DateTime(2022, 3, 12, 20, 45, 27, 70, DateTimeKind.Local).AddTicks(2842), "http://eusebio.name" },
                    { new Guid("09718fc2-f257-451a-854e-b69db8f083e6"), "Dignissimos reprehenderit culpa", new DateTime(2021, 4, 17, 0, 11, 38, 590, DateTimeKind.Local).AddTicks(121), "https://godfrey.com" },
                    { new Guid("0e713713-bf70-425b-acda-3fc63063af1a"), "Aliquid a cumque", new DateTime(2020, 6, 12, 11, 26, 39, 801, DateTimeKind.Local).AddTicks(7036), "http://lauretta.org" },
                    { new Guid("0ee6ff87-00a9-40bd-96e1-ce640692fbf0"), "Delectus odio iste", new DateTime(2021, 9, 16, 17, 48, 54, 961, DateTimeKind.Local).AddTicks(8867), "http://nasir.com" },
                    { new Guid("1ade486f-fbe2-485e-9a9f-e9aef62b5db3"), "Error quae quibusdam", new DateTime(2020, 5, 15, 3, 48, 27, 755, DateTimeKind.Local).AddTicks(4195), "http://raymond.com" },
                    { new Guid("1c746e7f-5c94-4901-9f61-32e5f74ea058"), "A commodi quia", new DateTime(2020, 6, 4, 0, 24, 37, 475, DateTimeKind.Local).AddTicks(9323), "http://scot.info" },
                    { new Guid("212eb0c2-52e6-4054-8235-cb21819a7865"), "Tempora magni fuga", new DateTime(2022, 7, 7, 3, 23, 40, 541, DateTimeKind.Local).AddTicks(9077), "http://porter.com" },
                    { new Guid("21bfd0a6-313f-4360-9c5c-92da9ff943f5"), "Ut optio ad", new DateTime(2021, 6, 4, 15, 38, 3, 358, DateTimeKind.Local).AddTicks(4910), "http://quinn.net" },
                    { new Guid("26ee426b-bc90-452d-954e-cbbe496f1923"), "Quia eos consequatur", new DateTime(2021, 2, 17, 9, 1, 32, 544, DateTimeKind.Local).AddTicks(9780), "http://deonte.name" },
                    { new Guid("27540a9a-ec2d-4647-95dd-a26a900774d1"), "Quas id quos", new DateTime(2022, 1, 29, 22, 27, 10, 852, DateTimeKind.Local).AddTicks(3150), "https://maya.org" },
                    { new Guid("2adc29ea-db91-438f-baf5-e4f574ae50dc"), "Officia ullam voluptas", new DateTime(2021, 7, 27, 22, 0, 4, 364, DateTimeKind.Local).AddTicks(7689), "http://arch.biz" },
                    { new Guid("2b32cf24-a82c-4515-a49c-5a099fe884c1"), "Nisi suscipit veritatis", new DateTime(2019, 10, 3, 21, 55, 50, 160, DateTimeKind.Local).AddTicks(7245), "http://cale.info" },
                    { new Guid("2b3b123c-7228-4eb3-b138-8eda3638fbe0"), "Expedita est doloribus", new DateTime(2021, 11, 15, 22, 35, 37, 879, DateTimeKind.Local).AddTicks(8798), "http://kaleigh.name" },
                    { new Guid("2bba1d01-c17b-4de6-9c1c-bd092b4d0127"), "Debitis fugiat fugit", new DateTime(2020, 1, 13, 22, 10, 59, 918, DateTimeKind.Local).AddTicks(2654), "http://vicente.info" },
                    { new Guid("30567ee6-5cb7-405b-bfd3-672175885860"), "Nihil et ea", new DateTime(2021, 7, 16, 12, 30, 5, 293, DateTimeKind.Local).AddTicks(7042), "https://marge.biz" },
                    { new Guid("3724146a-f9c4-40f8-b566-ef5b7461688d"), "Assumenda explicabo ut", new DateTime(2021, 5, 16, 20, 21, 15, 241, DateTimeKind.Local).AddTicks(9427), "https://harvey.net" },
                    { new Guid("383a7005-a906-4904-bab6-23b44732eb70"), "Rem iste et", new DateTime(2020, 6, 29, 14, 59, 55, 28, DateTimeKind.Local).AddTicks(6242), "https://alyson.com" },
                    { new Guid("38897850-1bd7-469d-b86f-972057ca3bf1"), "Repudiandae nihil asperiores", new DateTime(2021, 8, 1, 6, 24, 52, 484, DateTimeKind.Local).AddTicks(6199), "https://elizabeth.com" },
                    { new Guid("3a7f0449-81ac-421c-bf24-c007efc0f2ca"), "Blanditiis quia consectetur", new DateTime(2020, 4, 25, 12, 20, 39, 165, DateTimeKind.Local).AddTicks(6732), "http://jackson.net" },
                    { new Guid("3ecfc6c3-f43f-4446-838f-5634c93882dc"), "Aut ea sunt", new DateTime(2022, 5, 26, 15, 36, 25, 29, DateTimeKind.Local).AddTicks(9530), "http://aletha.info" },
                    { new Guid("4278f613-5ed2-46be-bda8-8a046d91c069"), "Maiores cum aut", new DateTime(2022, 3, 16, 9, 58, 54, 106, DateTimeKind.Local).AddTicks(7496), "https://hershel.com" },
                    { new Guid("44f7a57d-63b2-4dfe-a463-f0338eec2205"), "Non voluptas qui", new DateTime(2019, 11, 8, 17, 32, 15, 871, DateTimeKind.Local).AddTicks(7345), "http://asha.info" },
                    { new Guid("46408047-5ecd-4a5d-843e-971b2cdf1815"), "Necessitatibus fugiat sed", new DateTime(2022, 2, 26, 1, 42, 24, 251, DateTimeKind.Local).AddTicks(4221), "https://winona.org" },
                    { new Guid("4bc79f2f-dbc8-4be5-aab5-c7a4f1c94cfc"), "Ipsa velit incidunt", new DateTime(2021, 10, 4, 14, 7, 14, 835, DateTimeKind.Local).AddTicks(713), "https://maybell.net" },
                    { new Guid("4cb893c5-e7a2-4ea8-a08d-ef4ffa4f97ef"), "Culpa debitis dolorem", new DateTime(2022, 7, 23, 5, 48, 22, 681, DateTimeKind.Local).AddTicks(4365), "https://hailey.name" },
                    { new Guid("5039a7ac-c910-4901-8dbb-ac57337f1a89"), "Qui necessitatibus facilis", new DateTime(2020, 12, 26, 23, 45, 17, 242, DateTimeKind.Local).AddTicks(5115), "https://oswaldo.net" },
                    { new Guid("516cfead-02e6-42d4-91ad-80ccf3af9058"), "Sit debitis voluptates", new DateTime(2020, 9, 2, 17, 21, 34, 284, DateTimeKind.Local).AddTicks(1946), "http://gonzalo.net" },
                    { new Guid("528089ce-d06f-43e6-bffa-409057e2a558"), "Et eum est", new DateTime(2020, 3, 26, 8, 51, 25, 253, DateTimeKind.Local).AddTicks(8703), "https://ethyl.com" },
                    { new Guid("52d73c52-6419-404d-b3c3-0c29f64b6edd"), "Aut quasi quia", new DateTime(2022, 7, 16, 19, 56, 29, 209, DateTimeKind.Local).AddTicks(9488), "https://jonas.biz" },
                    { new Guid("544719ec-ad7d-4af7-8a16-161b13b75297"), "Ducimus consectetur ut", new DateTime(2021, 7, 9, 5, 58, 33, 214, DateTimeKind.Local).AddTicks(4641), "http://marco.info" },
                    { new Guid("55fab735-0829-47c4-a507-b4e0aafccf75"), "A ut dolore", new DateTime(2022, 9, 16, 22, 44, 4, 425, DateTimeKind.Local).AddTicks(2790), "https://randy.name" },
                    { new Guid("5aa5544e-e1e3-4733-b3c7-3b841dfea2d7"), "Temporibus reprehenderit et", new DateTime(2020, 7, 4, 17, 18, 17, 6, DateTimeKind.Local).AddTicks(163), "https://judson.info" },
                    { new Guid("5d99013a-8442-4ce5-ac7b-cc83054b35ca"), "Est consequuntur atque", new DateTime(2022, 6, 24, 1, 11, 57, 139, DateTimeKind.Local).AddTicks(7893), "https://maynard.biz" },
                    { new Guid("5da2695c-3484-481f-addc-5468f0e36d4d"), "Autem hic ducimus", new DateTime(2021, 11, 24, 20, 24, 43, 25, DateTimeKind.Local).AddTicks(2389), "http://hettie.org" },
                    { new Guid("61324abb-643a-40fd-95d0-72af8252459e"), "Cupiditate amet expedita", new DateTime(2021, 7, 30, 6, 54, 20, 41, DateTimeKind.Local).AddTicks(1260), "http://elisha.name" },
                    { new Guid("65a05f20-cfd2-47ff-b02d-857806bc11ac"), "Perspiciatis deserunt expedita", new DateTime(2022, 1, 7, 23, 42, 30, 373, DateTimeKind.Local).AddTicks(6219), "http://elvie.biz" },
                    { new Guid("6a9e9433-3c92-464b-a035-db95754b42e0"), "Sunt iste eos", new DateTime(2020, 3, 9, 21, 5, 29, 327, DateTimeKind.Local).AddTicks(1390), "https://jeffrey.name" },
                    { new Guid("6d43f927-a537-44a2-8862-05fc47d1a227"), "Eveniet similique molestiae", new DateTime(2019, 12, 19, 18, 31, 30, 294, DateTimeKind.Local).AddTicks(7226), "http://hubert.info" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Name", "PublishDate", "Source" },
                values: new object[,]
                {
                    { new Guid("6efb0fc3-ffd4-4178-8a16-3ebd49d2e296"), "Numquam facilis et", new DateTime(2020, 9, 17, 14, 21, 39, 175, DateTimeKind.Local).AddTicks(3895), "http://delores.org" },
                    { new Guid("6efc4f92-3671-4993-985c-63d39b9c0e02"), "Et accusamus aperiam", new DateTime(2021, 3, 13, 0, 51, 43, 28, DateTimeKind.Local).AddTicks(5293), "http://graciela.info" },
                    { new Guid("6f65f72c-4ae7-477b-a803-46cae13b43a1"), "Vero voluptas sunt", new DateTime(2021, 12, 11, 12, 8, 37, 612, DateTimeKind.Local).AddTicks(8454), "https://chanel.org" },
                    { new Guid("714e7535-a4ea-4425-9f5a-4b3219cfb4d7"), "Officiis dolore distinctio", new DateTime(2022, 1, 18, 6, 1, 45, 547, DateTimeKind.Local).AddTicks(7806), "https://emery.biz" },
                    { new Guid("7327459c-6a1e-441d-8c02-3581dc88f530"), "Aut sit consequatur", new DateTime(2021, 10, 6, 22, 13, 54, 436, DateTimeKind.Local).AddTicks(6573), "https://ricardo.org" },
                    { new Guid("734b9d1b-5f1c-4e7d-bd86-6ce4d745b9ce"), "Dolores delectus aliquid", new DateTime(2022, 5, 29, 11, 58, 45, 588, DateTimeKind.Local).AddTicks(8074), "http://buck.net" },
                    { new Guid("78cbf6d1-ffe1-4937-996c-22967de028d8"), "Odit ratione quia", new DateTime(2020, 3, 12, 18, 27, 57, 87, DateTimeKind.Local).AddTicks(8161), "https://savion.net" },
                    { new Guid("78f6d540-8e3f-4252-b2d3-7df31f9cdc88"), "Voluptatum sunt nemo", new DateTime(2019, 9, 30, 21, 0, 1, 603, DateTimeKind.Local).AddTicks(980), "http://elmira.com" },
                    { new Guid("7cd79461-8db0-4522-840a-a83c88ad389a"), "Impedit odit placeat", new DateTime(2021, 10, 30, 5, 44, 43, 331, DateTimeKind.Local).AddTicks(8655), "http://moshe.name" },
                    { new Guid("7d259cae-ee76-475e-ba23-a20178f2567c"), "Similique sed ad", new DateTime(2021, 4, 5, 8, 24, 0, 868, DateTimeKind.Local).AddTicks(6646), "http://edward.biz" },
                    { new Guid("7ead2412-a565-4bad-9558-f8fff1fb318d"), "Esse fuga voluptatem", new DateTime(2021, 2, 21, 23, 33, 0, 144, DateTimeKind.Local).AddTicks(441), "https://devin.org" },
                    { new Guid("7feb8741-056d-44c4-866a-fc6b8c10cbcc"), "Voluptatem qui tempore", new DateTime(2019, 10, 12, 15, 40, 0, 129, DateTimeKind.Local).AddTicks(6911), "http://kaycee.biz" },
                    { new Guid("80ef931a-00b1-4fa1-b39d-bc0fc890b724"), "Et sunt esse", new DateTime(2021, 4, 16, 8, 24, 21, 202, DateTimeKind.Local).AddTicks(7131), "https://geovanni.info" },
                    { new Guid("83e7d345-b590-4ee7-80cd-7f29bf032f99"), "Minus vel ut", new DateTime(2019, 12, 13, 19, 19, 25, 22, DateTimeKind.Local).AddTicks(3134), "https://marc.net" },
                    { new Guid("8c27e230-be08-4235-af1b-23520f23d5b8"), "Corporis incidunt dolorem", new DateTime(2019, 11, 29, 7, 48, 16, 926, DateTimeKind.Local).AddTicks(1281), "http://vesta.net" },
                    { new Guid("8da90ec4-aa5c-44e3-aca7-5b95957b2d12"), "Et ut ducimus", new DateTime(2020, 4, 24, 9, 28, 37, 775, DateTimeKind.Local).AddTicks(6678), "http://zula.name" },
                    { new Guid("8f4288d6-cd96-4ee0-b339-4e5a8877afaf"), "Quo qui reprehenderit", new DateTime(2021, 12, 26, 19, 16, 52, 914, DateTimeKind.Local).AddTicks(8019), "https://grady.biz" },
                    { new Guid("91dee07e-0e1c-4d41-bf54-408bb9281bd8"), "Autem aut repellendus", new DateTime(2022, 4, 9, 15, 31, 55, 405, DateTimeKind.Local).AddTicks(1522), "http://amira.info" },
                    { new Guid("92bfd4d0-4ec6-43fe-8341-f36c4306901f"), "Dolorem aliquam odio", new DateTime(2020, 7, 6, 5, 6, 15, 63, DateTimeKind.Local).AddTicks(9243), "http://earline.biz" },
                    { new Guid("93e5f372-3554-4ba6-b8d5-89d184e2b207"), "Laudantium aspernatur culpa", new DateTime(2020, 12, 6, 7, 6, 50, 331, DateTimeKind.Local).AddTicks(6910), "http://mateo.net" },
                    { new Guid("94e7ade9-95cb-4070-969b-eba400c5f4e7"), "Autem incidunt autem", new DateTime(2020, 1, 30, 20, 10, 53, 369, DateTimeKind.Local).AddTicks(3505), "https://antonette.com" },
                    { new Guid("96cff470-5b4c-4582-a693-bff10aa2f425"), "Nemo vitae illum", new DateTime(2021, 3, 10, 8, 23, 55, 924, DateTimeKind.Local).AddTicks(9014), "https://charity.info" },
                    { new Guid("99edc7a6-2f65-4893-abd9-5ee1a2e070ae"), "Deserunt nostrum ipsum", new DateTime(2020, 5, 3, 23, 23, 17, 163, DateTimeKind.Local).AddTicks(1464), "http://arvel.org" },
                    { new Guid("9d385160-b210-4984-9c29-6216cffbd068"), "Sapiente veritatis ad", new DateTime(2020, 1, 2, 15, 55, 27, 153, DateTimeKind.Local).AddTicks(5967), "https://adeline.net" },
                    { new Guid("9e8c3e3e-3909-4178-a7b8-64c04041cef9"), "Aspernatur corporis quaerat", new DateTime(2021, 10, 8, 13, 21, 20, 313, DateTimeKind.Local).AddTicks(7268), "http://merl.info" },
                    { new Guid("a803b4da-8c66-4b4f-94c5-608fc81ee0e4"), "Harum mollitia suscipit", new DateTime(2021, 7, 3, 9, 1, 44, 442, DateTimeKind.Local).AddTicks(340), "http://nathanael.com" },
                    { new Guid("a8eaa7fc-7279-4784-a740-7b003ee3829a"), "Voluptatibus commodi officia", new DateTime(2020, 5, 15, 22, 28, 12, 569, DateTimeKind.Local).AddTicks(9864), "https://imelda.biz" },
                    { new Guid("a9701275-48a5-4cee-8465-e75c8b392cd1"), "Dolores delectus id", new DateTime(2020, 7, 15, 6, 45, 38, 85, DateTimeKind.Local).AddTicks(1409), "https://desmond.com" },
                    { new Guid("a974f859-959d-4506-a78a-3bd8df91ed3e"), "Quo facere et", new DateTime(2019, 11, 4, 12, 34, 15, 717, DateTimeKind.Local).AddTicks(3732), "http://cary.biz" },
                    { new Guid("aa40a4b1-c25e-402b-a6e4-d1bf5cc60d87"), "Veniam nihil voluptas", new DateTime(2022, 2, 18, 17, 31, 54, 87, DateTimeKind.Local).AddTicks(1273), "https://lessie.name" },
                    { new Guid("aabebeaa-d82d-4bb1-b8cb-19f580a25115"), "Magni voluptas fuga", new DateTime(2020, 6, 16, 15, 7, 52, 545, DateTimeKind.Local).AddTicks(1598), "http://everette.net" },
                    { new Guid("acbbcf1f-b283-463f-a7f2-217bf4654fef"), "Qui laudantium qui", new DateTime(2021, 6, 11, 23, 59, 38, 855, DateTimeKind.Local).AddTicks(7162), "https://ollie.net" },
                    { new Guid("b37af3da-5376-490e-b00f-2ce69df7834c"), "Beatae non amet", new DateTime(2021, 5, 23, 8, 22, 33, 515, DateTimeKind.Local).AddTicks(8374), "http://marques.name" },
                    { new Guid("b7946e00-1127-43a4-acd5-c13bded163ed"), "Natus nam corporis", new DateTime(2020, 1, 12, 12, 33, 14, 978, DateTimeKind.Local).AddTicks(5396), "https://nelda.info" },
                    { new Guid("b953fa2d-ce7c-4226-be13-db5c76ee7417"), "Natus consequuntur rerum", new DateTime(2021, 4, 4, 4, 38, 59, 99, DateTimeKind.Local).AddTicks(4813), "https://leland.net" },
                    { new Guid("bd788e23-c9cb-457e-afe5-e23a126adf19"), "Corrupti cumque itaque", new DateTime(2021, 7, 28, 18, 13, 34, 142, DateTimeKind.Local).AddTicks(2311), "https://kaia.info" },
                    { new Guid("bf118d7d-4f95-4420-9017-9492e38be94c"), "Consequatur autem vero", new DateTime(2021, 8, 10, 18, 38, 17, 214, DateTimeKind.Local).AddTicks(5703), "http://birdie.info" },
                    { new Guid("c096ed02-cd0c-42db-a4d2-f56320562746"), "Minima odio qui", new DateTime(2021, 4, 6, 12, 53, 9, 689, DateTimeKind.Local).AddTicks(9591), "https://hershel.info" },
                    { new Guid("c5de7bdc-4a31-4a88-8a93-1e6ac26c174a"), "Est quia qui", new DateTime(2020, 3, 31, 13, 26, 13, 510, DateTimeKind.Local).AddTicks(165), "https://everardo.biz" },
                    { new Guid("c9dc7b2e-cee5-44c1-8d96-298415ff5b12"), "Qui aperiam voluptas", new DateTime(2021, 8, 18, 6, 7, 50, 83, DateTimeKind.Local).AddTicks(846), "https://kylee.info" },
                    { new Guid("d09fc2e6-4393-4fc4-8639-011f7760d191"), "Ut ut iure", new DateTime(2020, 9, 14, 11, 35, 39, 991, DateTimeKind.Local).AddTicks(4909), "https://alexander.biz" },
                    { new Guid("d5a48db4-03d6-4c49-a6bb-cac362a550cf"), "Distinctio esse non", new DateTime(2022, 1, 3, 12, 17, 47, 410, DateTimeKind.Local).AddTicks(4045), "https://mariane.com" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Name", "PublishDate", "Source" },
                values: new object[,]
                {
                    { new Guid("d5d3bb16-8940-4697-8e4e-a624db09ac67"), "Sint pariatur omnis", new DateTime(2021, 12, 22, 15, 17, 55, 95, DateTimeKind.Local).AddTicks(222), "http://eveline.biz" },
                    { new Guid("d696ae3c-8855-4033-8505-cdebad1cd551"), "Quia vitae velit", new DateTime(2021, 9, 15, 5, 32, 2, 756, DateTimeKind.Local).AddTicks(2603), "https://bernardo.net" },
                    { new Guid("d8f2bbe0-1c0d-457c-9a81-cf3b07002c71"), "Omnis qui tempora", new DateTime(2020, 12, 15, 20, 29, 15, 374, DateTimeKind.Local).AddTicks(2495), "https://wilton.net" },
                    { new Guid("d957c55d-9727-470b-8c89-e1a67a8da216"), "Deleniti suscipit totam", new DateTime(2020, 7, 11, 21, 28, 48, 845, DateTimeKind.Local).AddTicks(4527), "https://murray.info" },
                    { new Guid("de6f8aba-eb87-4ae9-ad16-6434362d31a8"), "Laudantium corporis quisquam", new DateTime(2020, 7, 17, 0, 52, 19, 830, DateTimeKind.Local).AddTicks(636), "https://prudence.com" },
                    { new Guid("e220ef41-807c-4774-82fa-e42e0fb04707"), "Hic facilis tempora", new DateTime(2020, 7, 24, 17, 18, 46, 336, DateTimeKind.Local).AddTicks(3529), "https://hildegard.info" },
                    { new Guid("e3771edc-03b0-489a-a2d7-d61a63a64862"), "Officia voluptas eos", new DateTime(2020, 2, 7, 19, 27, 24, 159, DateTimeKind.Local).AddTicks(5996), "https://halie.name" },
                    { new Guid("e5b173f1-434a-4bae-af02-1c42cc2de0c2"), "Dolores quia odio", new DateTime(2020, 6, 24, 11, 54, 58, 73, DateTimeKind.Local).AddTicks(1077), "https://edmond.biz" },
                    { new Guid("ec2d80af-fa60-4110-9321-bd97947f1a2e"), "Consequuntur ut sed", new DateTime(2022, 6, 15, 4, 2, 35, 154, DateTimeKind.Local).AddTicks(1462), "https://willis.net" },
                    { new Guid("ed6b0e5d-487a-40df-bbb9-b252d30bd158"), "Voluptatem repellendus dolores", new DateTime(2021, 10, 8, 9, 53, 40, 682, DateTimeKind.Local).AddTicks(6647), "https://marlen.net" },
                    { new Guid("f612c1e6-64b3-451b-ac0b-051589857666"), "Molestiae eum voluptatem", new DateTime(2022, 9, 1, 14, 22, 58, 279, DateTimeKind.Local).AddTicks(97), "https://adele.com" },
                    { new Guid("f683da48-dad8-43db-a067-8a2a5bacd046"), "Debitis accusamus facilis", new DateTime(2020, 7, 23, 5, 8, 50, 42, DateTimeKind.Local).AddTicks(4328), "http://sanford.info" },
                    { new Guid("f8c94833-c258-4d17-b2b3-e8bd59d18714"), "Minima laudantium eos", new DateTime(2022, 6, 4, 17, 27, 46, 693, DateTimeKind.Local).AddTicks(9118), "https://vernie.org" },
                    { new Guid("fadfe8b1-be8f-4cbe-bc8f-0968f325e2fc"), "Velit itaque iure", new DateTime(2020, 1, 27, 9, 13, 39, 3, DateTimeKind.Local).AddTicks(4940), "http://katlyn.biz" },
                    { new Guid("faf855dd-817e-470d-8abd-dcef54273191"), "Aut qui cumque", new DateTime(2022, 7, 10, 19, 42, 58, 317, DateTimeKind.Local).AddTicks(97), "http://letitia.info" },
                    { new Guid("fc52fe88-2837-43cd-be40-6d4c0b21db01"), "Placeat repudiandae quia", new DateTime(2022, 3, 10, 15, 30, 0, 625, DateTimeKind.Local).AddTicks(4646), "https://jaleel.name" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}

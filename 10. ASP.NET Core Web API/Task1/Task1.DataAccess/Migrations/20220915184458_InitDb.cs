using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task1.DataAccess.Migrations
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

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Name", "PublishDate", "Source" },
                values: new object[,]
                {
                    { new Guid("0212c181-9f06-4d0c-839e-c56aebf12f95"), "Dolore est neque", new DateTime(2020, 4, 16, 1, 24, 20, 494, DateTimeKind.Local).AddTicks(1384), "https://claud.info" },
                    { new Guid("022a95a8-93e4-4459-8b4d-424d95e57586"), "Qui sed nam", new DateTime(2021, 2, 13, 10, 33, 57, 701, DateTimeKind.Local).AddTicks(9189), "http://jarod.com" },
                    { new Guid("0255f4c8-4a1b-4c3d-9bf2-c4a4ce86f02e"), "Quod sit ut", new DateTime(2022, 8, 4, 1, 59, 25, 542, DateTimeKind.Local).AddTicks(2344), "http://jane.info" },
                    { new Guid("032417c6-f3d0-4dd0-ab36-04d3b8e630d8"), "Ea aspernatur voluptatem", new DateTime(2020, 7, 1, 3, 31, 29, 506, DateTimeKind.Local).AddTicks(140), "http://kelsie.net" },
                    { new Guid("04d24607-c223-4497-9ab0-569436226330"), "Quo vel quia", new DateTime(2020, 11, 18, 0, 19, 2, 410, DateTimeKind.Local).AddTicks(7803), "https://jayda.biz" },
                    { new Guid("06615cc4-ead9-48c9-a2ef-a640fe0a4df8"), "Asperiores earum ratione", new DateTime(2020, 1, 12, 22, 14, 3, 874, DateTimeKind.Local).AddTicks(6465), "http://cortez.org" },
                    { new Guid("0dcbfb37-bcfa-4ed1-a63f-ea91ff0f7250"), "Et totam nihil", new DateTime(2022, 6, 25, 5, 9, 47, 416, DateTimeKind.Local).AddTicks(546), "https://merle.info" },
                    { new Guid("0f963b6c-750f-41b2-b4df-036ee8469c15"), "Ut qui et", new DateTime(2022, 7, 15, 7, 50, 22, 146, DateTimeKind.Local).AddTicks(3680), "https://paige.com" },
                    { new Guid("1061a631-473d-44d0-9a60-1172ffd7b65f"), "Provident et error", new DateTime(2021, 7, 23, 15, 55, 41, 650, DateTimeKind.Local).AddTicks(7822), "http://chauncey.name" },
                    { new Guid("136cd90e-a0bb-46e7-8a32-559845535784"), "Totam molestiae in", new DateTime(2019, 11, 6, 7, 37, 25, 791, DateTimeKind.Local).AddTicks(7179), "http://russel.name" },
                    { new Guid("13b68d77-bb20-4156-9f3b-ac1ec0768a89"), "Voluptatem magni amet", new DateTime(2022, 5, 25, 9, 35, 53, 142, DateTimeKind.Local).AddTicks(2550), "https://bernadine.net" },
                    { new Guid("141609b5-4b59-4e36-99c3-1a37ef0df40d"), "Quasi sunt doloremque", new DateTime(2022, 5, 27, 22, 34, 26, 429, DateTimeKind.Local).AddTicks(3579), "https://charity.org" },
                    { new Guid("18f17550-1ed7-4dee-a693-46becd9b6771"), "Sit sint consequatur", new DateTime(2021, 8, 14, 23, 37, 19, 112, DateTimeKind.Local).AddTicks(9966), "http://cooper.org" },
                    { new Guid("19d5dae5-1f88-49f8-8384-5beabe59fb88"), "Rem iure itaque", new DateTime(2021, 3, 2, 20, 2, 3, 93, DateTimeKind.Local).AddTicks(6873), "http://vallie.net" },
                    { new Guid("1a05a9bd-4b73-4b6b-b480-283f01079315"), "Eos perferendis qui", new DateTime(2019, 10, 17, 9, 46, 31, 333, DateTimeKind.Local).AddTicks(1490), "https://alessia.info" },
                    { new Guid("1ac02798-7ff3-4017-a0ec-aab41827f0fb"), "Ab libero quasi", new DateTime(2021, 8, 14, 10, 36, 37, 50, DateTimeKind.Local).AddTicks(4091), "https://breanna.biz" },
                    { new Guid("1b4e2a6a-af00-4fc4-98fa-4fb8252cae9a"), "Ipsam sed eaque", new DateTime(2022, 8, 21, 3, 51, 17, 324, DateTimeKind.Local).AddTicks(1716), "https://oleta.name" },
                    { new Guid("1c2e8f78-3573-4ffd-9897-2924dd2f8307"), "Magni culpa enim", new DateTime(2021, 3, 15, 6, 43, 10, 481, DateTimeKind.Local).AddTicks(3889), "https://wilma.info" },
                    { new Guid("1ebd3c05-2b45-4ece-8527-2e76343b8665"), "Veniam consequuntur consequuntur", new DateTime(2021, 10, 23, 10, 1, 48, 880, DateTimeKind.Local).AddTicks(1355), "http://elwin.net" },
                    { new Guid("250e6bf7-8d50-4102-9288-da28bd25069e"), "Sit officia suscipit", new DateTime(2021, 12, 21, 15, 49, 53, 468, DateTimeKind.Local).AddTicks(3170), "http://celestino.name" },
                    { new Guid("2dfc452c-7983-4fb2-b812-377a27838048"), "Dicta iure impedit", new DateTime(2021, 8, 25, 22, 50, 19, 280, DateTimeKind.Local).AddTicks(1391), "http://erica.com" },
                    { new Guid("2ee4dafe-9a2f-498f-8cd1-f4f91a5988e9"), "Velit ut sed", new DateTime(2021, 3, 24, 12, 34, 14, 358, DateTimeKind.Local).AddTicks(8949), "http://lenora.net" },
                    { new Guid("2f58523d-4a2e-4ffc-88f8-15ee6e2a8608"), "Hic qui soluta", new DateTime(2020, 6, 23, 10, 27, 9, 501, DateTimeKind.Local).AddTicks(2330), "https://renee.net" },
                    { new Guid("302a8c83-3b06-4827-9248-59290ee91246"), "Exercitationem ut omnis", new DateTime(2021, 10, 19, 21, 5, 7, 31, DateTimeKind.Local).AddTicks(6447), "https://noemy.org" },
                    { new Guid("3155db69-3c0c-4ae0-9f3e-181bb0a163dd"), "Similique labore modi", new DateTime(2021, 1, 8, 23, 36, 18, 142, DateTimeKind.Local).AddTicks(5612), "https://lazaro.info" },
                    { new Guid("31ec881d-f0af-4436-a830-a2a0dce23cae"), "Nisi ex voluptas", new DateTime(2022, 3, 27, 6, 43, 16, 201, DateTimeKind.Local).AddTicks(5123), "https://quinten.biz" },
                    { new Guid("370ef660-8bf8-4f88-9c02-2dd44d781b97"), "Consequatur quibusdam tempore", new DateTime(2020, 11, 12, 10, 10, 30, 933, DateTimeKind.Local).AddTicks(6130), "https://rasheed.biz" },
                    { new Guid("379b7dec-e1f1-47ee-ae0d-7597739b9975"), "Quia sint voluptas", new DateTime(2022, 5, 17, 10, 53, 29, 199, DateTimeKind.Local).AddTicks(4582), "https://mayra.info" },
                    { new Guid("3925f8ad-f05d-442d-ae41-680690c09a7b"), "Dolorem est autem", new DateTime(2019, 12, 8, 10, 46, 5, 325, DateTimeKind.Local).AddTicks(5747), "https://shane.com" },
                    { new Guid("3eb58b83-35bd-40a7-8822-5df9abc873b3"), "Aut perspiciatis aut", new DateTime(2022, 7, 24, 9, 57, 56, 191, DateTimeKind.Local).AddTicks(8990), "http://cade.net" },
                    { new Guid("4229fc33-422c-43fd-aea0-a021b4eda2f7"), "Aut beatae distinctio", new DateTime(2021, 9, 26, 4, 4, 39, 734, DateTimeKind.Local).AddTicks(5869), "http://tatyana.name" },
                    { new Guid("44d63228-c038-4237-ba56-f1e09264e3c3"), "Sit minima voluptatem", new DateTime(2020, 5, 9, 6, 0, 16, 629, DateTimeKind.Local).AddTicks(651), "https://rasheed.name" },
                    { new Guid("4ac3bdf1-e1f8-499d-9a92-d7967d5a2500"), "Sapiente nulla et", new DateTime(2022, 1, 2, 2, 10, 35, 565, DateTimeKind.Local).AddTicks(7607), "https://flavie.biz" },
                    { new Guid("4be1b53c-f42f-406a-b63c-3d8db7d97b48"), "Nostrum rem a", new DateTime(2021, 9, 11, 22, 3, 50, 204, DateTimeKind.Local).AddTicks(1677), "http://oran.biz" },
                    { new Guid("4ecd0785-795f-4587-a9e3-46235a959dd2"), "Sed eos provident", new DateTime(2022, 6, 13, 18, 32, 58, 981, DateTimeKind.Local).AddTicks(8869), "https://marilyne.com" },
                    { new Guid("518df44e-bd59-43f1-abaa-4301e2ecede1"), "Earum fugiat eum", new DateTime(2020, 1, 6, 0, 9, 0, 719, DateTimeKind.Local).AddTicks(1806), "https://rory.info" },
                    { new Guid("523feaff-2483-483d-ae14-25d78d6ae36b"), "Placeat placeat omnis", new DateTime(2022, 4, 26, 9, 22, 19, 333, DateTimeKind.Local).AddTicks(7374), "http://jeremie.com" },
                    { new Guid("5827e6b1-c952-475a-91d0-c0d1398028a7"), "Nesciunt molestiae tenetur", new DateTime(2020, 11, 10, 10, 27, 29, 61, DateTimeKind.Local).AddTicks(1439), "https://scotty.net" },
                    { new Guid("5c52f649-0f1d-4c42-b572-aa0a9b3284b4"), "Dolorem fugiat recusandae", new DateTime(2021, 4, 3, 21, 7, 22, 145, DateTimeKind.Local).AddTicks(6946), "https://sister.biz" },
                    { new Guid("601d77cd-b6c1-4bdc-bd01-6f747caa34a1"), "In est impedit", new DateTime(2021, 5, 27, 4, 8, 50, 146, DateTimeKind.Local).AddTicks(4936), "http://elaina.com" },
                    { new Guid("60e12285-3ec0-4718-8665-056095880d3e"), "Consectetur reprehenderit quisquam", new DateTime(2021, 1, 16, 16, 57, 39, 640, DateTimeKind.Local).AddTicks(5855), "https://reagan.com" },
                    { new Guid("6174fc5b-01a7-49df-a4fa-02951d2b4f47"), "Nisi beatae debitis", new DateTime(2020, 2, 17, 8, 39, 44, 313, DateTimeKind.Local).AddTicks(8839), "https://maryam.org" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Name", "PublishDate", "Source" },
                values: new object[,]
                {
                    { new Guid("648d8f9b-043a-4616-85ab-fd2deb2e3054"), "Eum est dolores", new DateTime(2021, 6, 25, 10, 9, 26, 609, DateTimeKind.Local).AddTicks(5853), "http://sally.info" },
                    { new Guid("6a65c99e-7373-44ab-aa99-6179bb0b844c"), "Tempore exercitationem corrupti", new DateTime(2022, 1, 2, 11, 30, 26, 34, DateTimeKind.Local).AddTicks(2795), "https://lolita.net" },
                    { new Guid("6b0715e7-5fdb-4f90-9a18-29720361e499"), "Voluptatum ratione odio", new DateTime(2022, 1, 20, 21, 44, 6, 753, DateTimeKind.Local).AddTicks(3364), "http://seth.biz" },
                    { new Guid("6c5472ff-4190-47ca-9598-e204df1609dc"), "Quis vel accusantium", new DateTime(2020, 4, 6, 13, 4, 40, 373, DateTimeKind.Local).AddTicks(8091), "https://josefina.com" },
                    { new Guid("6fe5b74f-200d-4884-b261-d07ad85b398d"), "Modi reprehenderit nihil", new DateTime(2019, 11, 10, 4, 41, 5, 425, DateTimeKind.Local).AddTicks(1352), "http://pearlie.net" },
                    { new Guid("707293e3-cb49-4ab9-a7a3-a876c0f8d8e6"), "Dicta quia eum", new DateTime(2020, 2, 23, 19, 30, 55, 891, DateTimeKind.Local).AddTicks(6527), "https://theron.name" },
                    { new Guid("70c7aed3-e670-461f-a6d9-66ebd056c483"), "Illum quia magni", new DateTime(2020, 1, 8, 18, 40, 52, 549, DateTimeKind.Local).AddTicks(1805), "http://edwina.info" },
                    { new Guid("7259eb11-079c-4b77-9c42-1ac42f03e4fa"), "Autem ea quod", new DateTime(2021, 8, 9, 22, 18, 13, 859, DateTimeKind.Local).AddTicks(7390), "https://marlene.biz" },
                    { new Guid("72bf684e-595d-48f5-ac18-c909aef98051"), "Deleniti similique ea", new DateTime(2020, 1, 27, 13, 41, 17, 914, DateTimeKind.Local).AddTicks(7286), "https://allene.net" },
                    { new Guid("74c15bf1-506e-46f8-b3d2-b168ed58ccac"), "Possimus qui doloribus", new DateTime(2019, 9, 27, 11, 59, 43, 668, DateTimeKind.Local).AddTicks(3655), "https://kiara.name" },
                    { new Guid("758a42bf-d2ff-4bd2-bd74-4164827041f8"), "Qui nemo magni", new DateTime(2021, 8, 29, 4, 52, 47, 16, DateTimeKind.Local).AddTicks(4643), "https://julia.net" },
                    { new Guid("75b6ec70-014d-4a5f-a5a0-ec9fcdb8f9b7"), "Quam iste nobis", new DateTime(2020, 7, 25, 0, 10, 34, 209, DateTimeKind.Local).AddTicks(9101), "http://jamir.com" },
                    { new Guid("78e1c3c2-0779-4dca-b2f2-713cba79d3e8"), "Omnis perferendis sit", new DateTime(2022, 6, 25, 7, 48, 56, 849, DateTimeKind.Local).AddTicks(7123), "https://wilmer.biz" },
                    { new Guid("79b5a531-21c1-4656-8a79-0ed17dac3040"), "Consequatur qui aliquid", new DateTime(2019, 11, 20, 9, 31, 19, 110, DateTimeKind.Local).AddTicks(9669), "https://sam.com" },
                    { new Guid("7d65b28d-7ebe-47e8-8fa6-33da2f9784a8"), "Illo minima nobis", new DateTime(2020, 5, 4, 0, 29, 53, 760, DateTimeKind.Local).AddTicks(7410), "https://royce.name" },
                    { new Guid("80b875f9-afd7-4c9f-8fc6-59b5fdae6296"), "Facere nulla molestiae", new DateTime(2021, 4, 16, 19, 46, 29, 437, DateTimeKind.Local).AddTicks(8091), "http://araceli.net" },
                    { new Guid("85e822b8-204b-44d0-8151-395064ca5391"), "Sequi harum in", new DateTime(2020, 8, 3, 2, 34, 23, 842, DateTimeKind.Local).AddTicks(6157), "http://bernice.biz" },
                    { new Guid("89756ef4-771e-48bd-bcce-f424c40b41ab"), "Laudantium hic rerum", new DateTime(2020, 4, 5, 0, 55, 9, 131, DateTimeKind.Local).AddTicks(4519), "http://kamren.biz" },
                    { new Guid("98f014c8-4a09-4a43-ba0b-a42602bf6d5b"), "Numquam voluptatem aut", new DateTime(2020, 9, 22, 5, 12, 21, 144, DateTimeKind.Local).AddTicks(6225), "https://guiseppe.org" },
                    { new Guid("9e5e142c-9b74-40f6-816d-92e21534592e"), "Omnis expedita velit", new DateTime(2021, 11, 16, 22, 16, 32, 446, DateTimeKind.Local).AddTicks(6886), "https://cassie.net" },
                    { new Guid("a2738000-0a8d-4b0e-be8c-e7725432a6fd"), "Nemo accusantium expedita", new DateTime(2019, 12, 24, 13, 38, 2, 473, DateTimeKind.Local).AddTicks(782), "https://hayley.org" },
                    { new Guid("a34d8e17-d044-48f0-a112-a6aefe470944"), "Earum natus nemo", new DateTime(2021, 7, 23, 15, 14, 55, 596, DateTimeKind.Local).AddTicks(9755), "https://ursula.com" },
                    { new Guid("a425d59c-d5f2-4543-8e76-f7532b52f79d"), "Facilis et nihil", new DateTime(2021, 10, 13, 0, 12, 32, 162, DateTimeKind.Local).AddTicks(8130), "https://mariam.org" },
                    { new Guid("a6209861-c3d9-4edb-a789-39a91dda64de"), "Quia omnis distinctio", new DateTime(2020, 1, 24, 9, 23, 36, 456, DateTimeKind.Local).AddTicks(7163), "http://ella.org" },
                    { new Guid("a829fa09-9017-4695-b89a-29add53405fd"), "Id illum omnis", new DateTime(2019, 10, 4, 18, 6, 9, 987, DateTimeKind.Local).AddTicks(1180), "http://crawford.org" },
                    { new Guid("a9abd7ce-5df0-4763-aea9-d61911b6f383"), "Esse ad corporis", new DateTime(2020, 4, 18, 20, 24, 0, 606, DateTimeKind.Local).AddTicks(6117), "http://nick.org" },
                    { new Guid("ab5436bf-bf45-4ee1-8e94-631990735947"), "Occaecati est numquam", new DateTime(2021, 1, 18, 3, 2, 22, 585, DateTimeKind.Local).AddTicks(3525), "http://tavares.com" },
                    { new Guid("ac6ef377-43b7-4f1c-9be5-abc4e99c6ab0"), "Numquam qui assumenda", new DateTime(2020, 2, 17, 7, 7, 46, 953, DateTimeKind.Local).AddTicks(5575), "https://cooper.biz" },
                    { new Guid("b7877b1f-8bad-443f-a8ea-16566dc9bd68"), "Laboriosam itaque optio", new DateTime(2021, 5, 17, 16, 25, 10, 948, DateTimeKind.Local).AddTicks(9710), "https://gerda.org" },
                    { new Guid("ba9feb22-e5d9-4ce8-b350-bef01ad2ff03"), "Autem quidem cumque", new DateTime(2022, 2, 18, 17, 3, 24, 317, DateTimeKind.Local).AddTicks(436), "https://irwin.biz" },
                    { new Guid("baa5d166-229b-49b1-aba7-e184d75c1dba"), "Velit saepe temporibus", new DateTime(2021, 7, 21, 1, 0, 22, 231, DateTimeKind.Local).AddTicks(2588), "https://mara.com" },
                    { new Guid("bcc3545a-93a3-496a-adb1-1e5151360c99"), "Voluptatibus cupiditate aliquid", new DateTime(2020, 12, 20, 7, 30, 22, 407, DateTimeKind.Local).AddTicks(4202), "http://toy.info" },
                    { new Guid("bd1e49ab-6841-41ee-bc54-3c24c873aeeb"), "Velit dolores culpa", new DateTime(2020, 11, 27, 19, 7, 44, 766, DateTimeKind.Local).AddTicks(9517), "https://magali.net" },
                    { new Guid("c45570d4-3a82-4758-93c2-6931e71e4d3c"), "Assumenda et aliquid", new DateTime(2020, 2, 28, 1, 13, 5, 675, DateTimeKind.Local).AddTicks(5920), "http://viva.net" },
                    { new Guid("ce34fd5b-71eb-4b7c-b0b8-2bfc963cf9da"), "Alias placeat ipsum", new DateTime(2022, 8, 5, 22, 45, 59, 817, DateTimeKind.Local).AddTicks(2813), "http://celestino.net" },
                    { new Guid("cf3435a1-cc58-47d8-96b3-530e5a19a0a3"), "Omnis possimus delectus", new DateTime(2020, 6, 16, 20, 12, 22, 276, DateTimeKind.Local).AddTicks(8736), "https://emory.org" },
                    { new Guid("d04408ff-6194-4d16-ac66-f297ee22ab80"), "Ratione odit voluptatum", new DateTime(2020, 4, 13, 4, 26, 10, 20, DateTimeKind.Local).AddTicks(1014), "https://petra.org" },
                    { new Guid("d0667805-cb84-468f-83b5-335f4bb83ed1"), "Asperiores in ut", new DateTime(2022, 7, 6, 13, 30, 34, 683, DateTimeKind.Local).AddTicks(8453), "https://arnulfo.com" },
                    { new Guid("d8d1d37a-eebb-4573-8066-aeb27486f6db"), "Non eligendi quidem", new DateTime(2022, 1, 13, 14, 50, 23, 557, DateTimeKind.Local).AddTicks(355), "http://donato.info" },
                    { new Guid("d985b02b-7ad6-4895-bc0d-b7c5d5f51a21"), "Molestiae dolor et", new DateTime(2020, 8, 19, 10, 11, 56, 400, DateTimeKind.Local).AddTicks(7338), "https://chanelle.net" },
                    { new Guid("db4704da-34dd-4499-84d9-6ee819175118"), "Id rerum non", new DateTime(2020, 9, 11, 7, 32, 24, 788, DateTimeKind.Local).AddTicks(7697), "http://trenton.com" },
                    { new Guid("dd8317fc-4106-41c2-8104-2abbd13e0205"), "Dolor excepturi recusandae", new DateTime(2021, 1, 29, 17, 30, 16, 935, DateTimeKind.Local).AddTicks(5052), "https://brandy.biz" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Name", "PublishDate", "Source" },
                values: new object[,]
                {
                    { new Guid("de028a39-747f-4e6f-8bc3-3ecd5ca0c119"), "Odit veniam sequi", new DateTime(2020, 1, 15, 15, 1, 13, 431, DateTimeKind.Local).AddTicks(3146), "http://tod.com" },
                    { new Guid("de49bfee-23da-4a50-b868-9f554950a090"), "Quis sit provident", new DateTime(2020, 2, 25, 1, 22, 36, 900, DateTimeKind.Local).AddTicks(4611), "https://kiara.name" },
                    { new Guid("e11c8a0b-24bf-4d1a-9395-9efa12758be3"), "Facere velit corporis", new DateTime(2019, 10, 24, 16, 33, 39, 66, DateTimeKind.Local).AddTicks(3991), "https://marge.org" },
                    { new Guid("e1a72b4c-3ad9-4f76-8977-47b7ea13817b"), "Quia nobis magni", new DateTime(2021, 6, 1, 21, 13, 21, 957, DateTimeKind.Local).AddTicks(5364), "http://green.info" },
                    { new Guid("e95c0bef-21e8-4f70-8b20-879e1fa0003e"), "Molestiae et saepe", new DateTime(2022, 5, 20, 12, 31, 55, 619, DateTimeKind.Local).AddTicks(8554), "https://hans.com" },
                    { new Guid("e9a14715-1e59-4762-a5b7-a8439a502cf2"), "Itaque perspiciatis rem", new DateTime(2021, 3, 31, 18, 4, 42, 908, DateTimeKind.Local).AddTicks(746), "https://sabryna.info" },
                    { new Guid("ecfbe558-5a87-47d4-b289-0f60f576070d"), "Aut nemo possimus", new DateTime(2021, 4, 11, 7, 19, 30, 842, DateTimeKind.Local).AddTicks(5038), "https://gaylord.info" },
                    { new Guid("edfa4e3e-acff-4380-b497-dd3e598e175a"), "Reprehenderit laudantium sed", new DateTime(2020, 8, 28, 19, 49, 44, 96, DateTimeKind.Local).AddTicks(7381), "http://helga.info" },
                    { new Guid("f4502ab0-b610-4f6d-890e-a4116d2054e1"), "Voluptas nam et", new DateTime(2020, 8, 26, 21, 11, 41, 273, DateTimeKind.Local).AddTicks(1929), "https://jodie.biz" },
                    { new Guid("f54ed109-9ec9-4ece-971b-32676f95db52"), "At voluptas unde", new DateTime(2019, 12, 19, 5, 18, 26, 587, DateTimeKind.Local).AddTicks(8312), "https://jarvis.info" },
                    { new Guid("f64338b6-21e7-4892-8dae-5126c5e51f2e"), "Doloremque nihil et", new DateTime(2019, 11, 25, 18, 35, 53, 892, DateTimeKind.Local).AddTicks(8365), "http://chelsea.name" },
                    { new Guid("f8806a71-6e3c-4187-827a-40f694b5335b"), "Suscipit omnis mollitia", new DateTime(2021, 11, 23, 15, 12, 0, 223, DateTimeKind.Local).AddTicks(9052), "https://joana.name" },
                    { new Guid("fa35dd62-33eb-4b23-83b4-d34a340372c0"), "Animi molestias sit", new DateTime(2021, 4, 19, 3, 54, 24, 562, DateTimeKind.Local).AddTicks(9870), "https://emmalee.name" },
                    { new Guid("fbc08c93-4c0a-4507-bcfa-bb13e5895e26"), "In quasi veniam", new DateTime(2021, 2, 16, 8, 5, 36, 250, DateTimeKind.Local).AddTicks(4196), "https://zachery.name" },
                    { new Guid("fcd30ceb-e51f-4ac9-bf0f-fe716f405a24"), "Quisquam earum et", new DateTime(2021, 3, 23, 12, 6, 23, 145, DateTimeKind.Local).AddTicks(7332), "https://bradly.org" },
                    { new Guid("fd46a837-637e-44af-b293-14ac9655195d"), "Voluptas quam sit", new DateTime(2022, 1, 18, 8, 36, 30, 688, DateTimeKind.Local).AddTicks(6116), "https://florence.biz" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}

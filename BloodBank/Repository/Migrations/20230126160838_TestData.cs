using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class TestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0325c6cc-a303-4165-ad42-2c08d8516c91", "42496e0e-f381-4248-b340-bdd305fca573", "RegUser", "REGUSER" },
                    { "f808309d-9564-4748-a469-46270826774e", "7644c8e2-830d-4f3d-8f64-675a48e9efb2", "Admin", "ADMIN" },
                    { "f871b11d-ecad-4d67-9223-1f6d3cf684b1", "ea64d964-3212-4103-ad79-9261c934a03f", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0f585944-59f6-4824-bea9-d64c24cbe934", 0, "200730b4-eefd-4447-ba0a-1c4e95332f10", "sibin.stojanovic@gmail.com", true, false, null, "SIBIN.STOJANOVIC@GMAIL.COM", null, "AQAAAAEAACcQAAAAEP2tm8+Sudn8bVwLaaRVM0UgudG7nezmxgVG8e/qjjgoEExVOXoK5PKB8yNaS4hZBA==", null, false, "5d013926-67cb-4678-bb46-f1101b9b4dd0", false, "sibin.stojanovic@gmail.com" },
                    { "32cb85d0-3b66-486d-b6a0-0749ee6ccdf3", 0, "47e4383c-4e7a-44af-9291-aa2664b07a8e", "lazar.markovic@gmail.com", true, false, null, "LAZAR.MARKOVIC@GMAIL.COM", null, "AQAAAAEAACcQAAAAECg2axY0agc2+ibVmLElNlgZWRjr8YFcRFSMO+F/0vRME2AXs6cRaRIvfEgkIfA1IA==", null, false, "8bc871be-9322-47d6-98d5-4b2df5792c3d", false, "lazar.markovic@gmail.com" },
                    { "aca6bea4-4ce0-4617-901b-a7f1474ebb1d", 0, "7d41896c-aa18-41a0-b77b-7e7e3a49e523", "ivan.lendjer@gmail.com", true, false, null, "IVAN.LENDJER@GMAIL.COM", null, "AQAAAAEAACcQAAAAENJjBZyIuBJbsCwZ4SfBpcOQn1f3CZQ02EJnfsB4+4xY7zHlwRsJm6SU9xOYPllzdA==", null, false, "e571fe5a-c61b-44e3-af39-80c65eb7f133", false, "ivan.lendjer@gmail.com" },
                    { "b49d90ea-e546-48df-a128-994a58354ccc", 0, "0620a292-cf5f-453b-a1d2-e1d50896475f", "nikola.rokvic@gmail.com", true, false, null, "NIKOLA.ROKVIC@GMAIL.COM", null, "AQAAAAEAACcQAAAAEDURToGbRmJKDBzqMFjUoHWqG7oTi68a9ycHKp9JHmP67ZkgwU5ypZSpXSDV9b2Pmg==", null, false, "8f380a5d-e40f-406b-a766-ad4242d374c0", false, "nikola.rokvic@gmail.com" },
                    { "d6c6300c-d516-4c79-8a82-b47ef6b4e37d", 0, "edfde933-3348-4b73-aa34-b39d757d03b8", "blagoje.jevrosimov@gmail.com", true, false, null, "BLAGOJE.JEVROSIMOV@GMAIL.COM", null, "AQAAAAEAACcQAAAAEPwFha8gH0qAUWc/7sRqnYM8p8IqikBQ/osAcNc4VboHrhG12kaau1NlvQNlsxX8tg==", null, false, "b266e2a8-d0b3-41b8-b7d5-d699ba4eb2a9", false, "blagoje.jevrosimov@gmail.com" },
                    { "f028f3a7-a01e-49df-9e9c-3a25a51843ca", 0, "43328704-99e6-4d0c-8281-23a71f7a26f2", "novak.djokovic@gmail.com", true, false, null, "NOVAK.DJOKOVIC@GMAIL.COM", null, "AQAAAAEAACcQAAAAEN1K8uP6Fwjhon0uSh9Jr1z5tpwv4hwnDzZMC2uwfwojvoN0ceubraJkZLcZcVMQow==", null, false, "2c7b395d-1668-4b5a-87da-a27fbfe1cf21", false, "novak.djokovic@gmail.com" },
                    { "f59199d7-3e1f-4d63-870d-688936b2523e", 0, "3b230b54-3daf-40ca-9f46-a3789052c85b", "ivana.mihajlovic@gmail.com", true, false, null, "IVANA.MIHAJLOVIC@GMAIL.COM", null, "AQAAAAEAACcQAAAAEJKGFvWG7SwM1Ge+3e/CyHZLEMVsAEuLyvcm+4TAcQ7f4vdb+ViUdnq0AT3HxItZ/w==", null, false, "e62f3050-678d-4055-b5e0-816d5acc6c06", false, "ivana.mihajlovic@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "Id", "DateOfSubmition", "FirstName", "Gender", "JMBG", "LastName", "Location", "NumberOfPreviousDonations", "PhoneNumber", "Q1", "Q10", "Q11", "Q12", "Q13", "Q14", "Q15", "Q16", "Q17", "Q18", "Q19", "Q2", "Q20", "Q21", "Q22", "Q23", "Q3", "Q4", "Q5", "Q6", "Q7", "Q8", "Q9", "ResidenceAddress" },
                values: new object[] { 1, new DateTime(2023, 1, 25, 15, 0, 0, 0, DateTimeKind.Unspecified), "Lazar", "male", "1105973850123", "Markovic", "Beograd", 0, "0623088513", false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, "Miletićeva 12" });

            migrationBuilder.InsertData(
                table: "TransfusionCenters",
                columns: new[] { "Id", "Address", "Description", "Location", "Name", "Rating" },
                values: new object[,]
                {
                    { 1, "Njegoseva 31", "Prelepa bolnica u centru Gradnulice", "Zrenjanin", "Sudri", 5f },
                    { 2, "Ive Lole Ribara 12", "Preko puta divne picerije 'Saracena'", "Zrenjanin", "Sveti Jovan", 4f },
                    { 3, "Jevrejska 25b", "Moderni dom zdravlja sa dugom tradicijom", "Novi Sad", "Dom Zdravlja 'Zvonimir Radulović'", 3f },
                    { 4, "Svetog Save 39", "Vodeća, visoko specijalizovana naučno istraživačka i nastavna zdravstvena ustanova, referalna za oblast transfuziologije u Srbiji", "Beograd", "Institut za transfuziju krvi Beograd", 5f },
                    { 5, "Temerinska 20", "Ljubazno i profesionalno osoblje koje Vas očekuje od prijemnog šaltera do lekara specijaliste koji vrši preglede, uz puno poštovanje Vaše ličnosti i razumevanje Vaših potreba i tegoba, je ono što nas već godinama čini prepoznatljivim, a sa tom tradicijom nastavlja se i u novootvorenoj bolnici “Poliklinika Obradović”.", "Pančevo", "Poliklinika Obradović", 2f }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1, "0f585944-59f6-4824-bea9-d64c24cbe934" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "f808309d-9564-4748-a469-46270826774e", "0f585944-59f6-4824-bea9-d64c24cbe934" },
                    { "0325c6cc-a303-4165-ad42-2c08d8516c91", "32cb85d0-3b66-486d-b6a0-0749ee6ccdf3" },
                    { "f871b11d-ecad-4d67-9223-1f6d3cf684b1", "aca6bea4-4ce0-4617-901b-a7f1474ebb1d" },
                    { "f871b11d-ecad-4d67-9223-1f6d3cf684b1", "b49d90ea-e546-48df-a128-994a58354ccc" },
                    { "f871b11d-ecad-4d67-9223-1f6d3cf684b1", "d6c6300c-d516-4c79-8a82-b47ef6b4e37d" },
                    { "f871b11d-ecad-4d67-9223-1f6d3cf684b1", "f028f3a7-a01e-49df-9e9c-3a25a51843ca" },
                    { "f871b11d-ecad-4d67-9223-1f6d3cf684b1", "f59199d7-3e1f-4d63-870d-688936b2523e" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "TransfusionCenterId", "UserId" },
                values: new object[,]
                {
                    { 1, 2, "aca6bea4-4ce0-4617-901b-a7f1474ebb1d" },
                    { 2, 4, "f028f3a7-a01e-49df-9e9c-3a25a51843ca" },
                    { 3, 1, "d6c6300c-d516-4c79-8a82-b47ef6b4e37d" },
                    { 4, 3, "b49d90ea-e546-48df-a128-994a58354ccc" },
                    { 5, 5, "f59199d7-3e1f-4d63-870d-688936b2523e" }
                });

            migrationBuilder.InsertData(
                table: "RegUsers",
                columns: new[] { "Id", "Address", "BirthDate", "Career", "City", "CompanyName", "Country", "FirstName", "Gender", "JMBG", "LastBloodDonation", "LastName", "Penalties", "PhoneNumber", "UserID" },
                values: new object[] { 1, "Miletićeva 12", new DateTime(1973, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arhitekta", "Beograd", "Jadran d.o.o Beograd", "Srbija", "Lazar", "male", "1105973850123", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Markovic", 0, "0623088513", "32cb85d0-3b66-486d-b6a0-0749ee6ccdf3" });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "DateTime", "Duration", "EmployeeId", "IsAvailable", "RegUserId", "TransfusionCenterId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), 30, 1, true, null, 2 },
                    { 2, new DateTime(2023, 2, 2, 9, 30, 0, 0, DateTimeKind.Unspecified), 30, 1, true, null, 2 },
                    { 3, new DateTime(2023, 2, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), 30, 1, true, null, 2 },
                    { 4, new DateTime(2023, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), 30, 1, false, 1, 2 },
                    { 5, new DateTime(2023, 1, 20, 19, 0, 0, 0, DateTimeKind.Unspecified), 25, 1, false, 1, 2 },
                    { 6, new DateTime(2023, 2, 6, 15, 30, 0, 0, DateTimeKind.Unspecified), 15, 1, true, null, 2 },
                    { 7, new DateTime(2023, 2, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), 30, 2, true, null, 4 },
                    { 8, new DateTime(2023, 12, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), 30, 2, false, 1, 4 },
                    { 9, new DateTime(2023, 5, 8, 11, 0, 0, 0, DateTimeKind.Unspecified), 30, 2, true, null, 4 },
                    { 10, new DateTime(2023, 2, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), 30, 3, true, null, 1 },
                    { 11, new DateTime(2023, 2, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), 30, 4, true, null, 3 },
                    { 12, new DateTime(2023, 2, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), 30, 5, true, null, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f808309d-9564-4748-a469-46270826774e", "0f585944-59f6-4824-bea9-d64c24cbe934" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0325c6cc-a303-4165-ad42-2c08d8516c91", "32cb85d0-3b66-486d-b6a0-0749ee6ccdf3" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f871b11d-ecad-4d67-9223-1f6d3cf684b1", "aca6bea4-4ce0-4617-901b-a7f1474ebb1d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f871b11d-ecad-4d67-9223-1f6d3cf684b1", "b49d90ea-e546-48df-a128-994a58354ccc" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f871b11d-ecad-4d67-9223-1f6d3cf684b1", "d6c6300c-d516-4c79-8a82-b47ef6b4e37d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f871b11d-ecad-4d67-9223-1f6d3cf684b1", "f028f3a7-a01e-49df-9e9c-3a25a51843ca" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f871b11d-ecad-4d67-9223-1f6d3cf684b1", "f59199d7-3e1f-4d63-870d-688936b2523e" });

            migrationBuilder.DeleteData(
                table: "Surveys",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0325c6cc-a303-4165-ad42-2c08d8516c91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f808309d-9564-4748-a469-46270826774e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f871b11d-ecad-4d67-9223-1f6d3cf684b1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f585944-59f6-4824-bea9-d64c24cbe934");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RegUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32cb85d0-3b66-486d-b6a0-0749ee6ccdf3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aca6bea4-4ce0-4617-901b-a7f1474ebb1d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b49d90ea-e546-48df-a128-994a58354ccc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6c6300c-d516-4c79-8a82-b47ef6b4e37d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f028f3a7-a01e-49df-9e9c-3a25a51843ca");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f59199d7-3e1f-4d63-870d-688936b2523e");

            migrationBuilder.DeleteData(
                table: "TransfusionCenters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TransfusionCenters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TransfusionCenters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TransfusionCenters",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TransfusionCenters",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}

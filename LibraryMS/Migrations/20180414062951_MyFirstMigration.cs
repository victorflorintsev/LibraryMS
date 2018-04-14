using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryMS.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "LIBDB");

            migrationBuilder.CreateTable(
                name: "CUSTOMER_TYPE",
                schema: "LIBDB",
                columns: table => new
                {
                    CUSTOMER_TYPE_ID = table.Column<int>(nullable: false),
                    CUSTOMER_TYPE_NAME = table.Column<string>(type: "nchar(10)", nullable: false),
                    BOOK_LIMIT = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER_TYPE", x => x.CUSTOMER_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "MEDIA_TYPE",
                schema: "LIBDB",
                columns: table => new
                {
                    MEDIA_TYPE_ID = table.Column<int>(nullable: false),
                    MEDIA_TYPE_NAME = table.Column<string>(unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEDIA_TYPE", x => x.MEDIA_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "SECTION",
                schema: "LIBDB",
                columns: table => new
                {
                    Section_ID = table.Column<int>(nullable: false),
                    locationString = table.Column<string>(maxLength: 50, nullable: false),
                    sectionName = table.Column<string>(type: "nchar(10)", nullable: false),
                    Start_call_num = table.Column<string>(type: "nchar(10)", nullable: false),
                    End_call_num = table.Column<string>(type: "nchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SECTION", x => x.Section_ID);
                });

            migrationBuilder.CreateTable(
                name: "USER_TYPE",
                schema: "LIBDB",
                columns: table => new
                {
                    User_Type_Id = table.Column<int>(nullable: false),
                    User_Type_String = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_TYPE", x => x.User_Type_Id);
                });

            migrationBuilder.CreateTable(
                name: "MEDIA",
                schema: "LIBDB",
                columns: table => new
                {
                    Media_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Isbn = table.Column<int>(nullable: false),
                    author = table.Column<string>(type: "nchar(10)", nullable: false),
                    genre = table.Column<string>(type: "nchar(15)", nullable: false),
                    title = table.Column<string>(type: "nchar(50)", nullable: false),
                    media_type = table.Column<int>(nullable: false),
                    call_num = table.Column<string>(type: "nchar(10)", nullable: false),
                    date_added = table.Column<DateTime>(type: "date", nullable: false),
                    copies_left = table.Column<int>(nullable: false),
                    max_copies = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEDIA", x => x.Media_ID);
                    table.ForeignKey(
                        name: "Type_of_Media",
                        column: x => x.Media_ID,
                        principalSchema: "LIBDB",
                        principalTable: "MEDIA_TYPE",
                        principalColumn: "MEDIA_TYPE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                schema: "LIBDB",
                columns: table => new
                {
                    Username_ID = table.Column<int>(nullable: false),
                    Hashed_Password = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Failed_Attempts = table.Column<int>(nullable: false),
                    Username_String = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Last_Login_Attempt = table.Column<DateTime>(type: "datetime", nullable: true),
                    User_Type = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.Username_ID);
                    table.ForeignKey(
                        name: "FK__USERS__User_Type__6442E2C9",
                        column: x => x.User_Type,
                        principalSchema: "LIBDB",
                        principalTable: "USER_TYPE",
                        principalColumn: "User_Type_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMER",
                schema: "LIBDB",
                columns: table => new
                {
                    First_Name = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    Middle_Initial = table.Column<string>(type: "char(1)", nullable: false),
                    Last_Name = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    Birth_Date = table.Column<DateTime>(type: "date", nullable: false),
                    Customer_ID = table.Column<int>(nullable: false),
                    Phone_Number = table.Column<decimal>(type: "numeric(10, 0)", nullable: false),
                    Membership_Issued = table.Column<DateTime>(type: "date", nullable: false),
                    Address_Street = table.Column<string>(type: "nchar(25)", nullable: false),
                    Address_City = table.Column<string>(type: "nchar(15)", nullable: false),
                    Address_State = table.Column<string>(type: "nchar(2)", nullable: false),
                    Address_Zipcode = table.Column<string>(type: "nchar(5)", nullable: false),
                    Customer_Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER", x => x.Customer_ID);
                    table.ForeignKey(
                        name: "Users_to_Customer",
                        column: x => x.Customer_ID,
                        principalSchema: "LIBDB",
                        principalTable: "USERS",
                        principalColumn: "Username_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Type_of_Customer",
                        column: x => x.Customer_Type,
                        principalSchema: "LIBDB",
                        principalTable: "CUSTOMER_TYPE",
                        principalColumn: "CUSTOMER_TYPE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEE",
                schema: "LIBDB",
                columns: table => new
                {
                    Employee_ID = table.Column<int>(nullable: false),
                    First_Name = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    Last_Name = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    Address_Street = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Phone_Number = table.Column<decimal>(type: "numeric(10, 0)", nullable: false),
                    Address_City = table.Column<string>(type: "nchar(20)", nullable: false),
                    Address_State = table.Column<string>(type: "nchar(25)", nullable: false),
                    Address_Zipcode = table.Column<string>(type: "nchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEE", x => x.Employee_ID);
                    table.ForeignKey(
                        name: "Users_to_Employee",
                        column: x => x.Employee_ID,
                        principalSchema: "LIBDB",
                        principalTable: "USERS",
                        principalColumn: "Username_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_Customer_Type",
                schema: "LIBDB",
                table: "CUSTOMER",
                column: "Customer_Type");

            migrationBuilder.CreateIndex(
                name: "IX_Media",
                schema: "LIBDB",
                table: "MEDIA",
                column: "Media_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USERS_User_Type",
                schema: "LIBDB",
                table: "USERS",
                column: "User_Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CUSTOMER",
                schema: "LIBDB");

            migrationBuilder.DropTable(
                name: "EMPLOYEE",
                schema: "LIBDB");

            migrationBuilder.DropTable(
                name: "MEDIA",
                schema: "LIBDB");

            migrationBuilder.DropTable(
                name: "SECTION",
                schema: "LIBDB");

            migrationBuilder.DropTable(
                name: "CUSTOMER_TYPE",
                schema: "LIBDB");

            migrationBuilder.DropTable(
                name: "USERS",
                schema: "LIBDB");

            migrationBuilder.DropTable(
                name: "MEDIA_TYPE",
                schema: "LIBDB");

            migrationBuilder.DropTable(
                name: "USER_TYPE",
                schema: "LIBDB");
        }
    }
}

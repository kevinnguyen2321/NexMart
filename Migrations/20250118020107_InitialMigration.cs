using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NexMart.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    IdentityUserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    StockQuantity = table.Column<int>(type: "integer", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserProfileId = table.Column<int>(type: "integer", nullable: false),
                    isCanceled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", null, "Admin", "admin" },
                    { "c4bbeb97-d3ba-4b53-b521-5ffa61e59b36", null, "Customer", "customer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "d6bc2e97-e1fc-4a2f-b112-6ff861e69c37", 0, "8af89f33-a268-4f95-b545-9e7b47e61688", "customer1@company.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEOOxkMHT4K29/FFi5fx8ZvoaQTrn7y4eLnRJS5G5CRxWJRzKyiAf+J/OSZvN+FYMtQ==", null, false, "6ffa0820-56be-44b5-bd26-850bfae03dd6", false, "customer1" },
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "87aa8f6a-b881-43f2-8ef1-aeac782e2fb0", "admina@strator.comx", false, false, null, null, null, "AQAAAAIAAYagAAAAEOQ4yX11i0t0fr5QPG1IPdInJn9JwWMiqvSXW9w2HQxQwioA/NphA77UwMeNQ5v5cg==", null, false, "28593d9a-73f4-4034-89c7-c5b3c350527d", false, "Administrator" },
                    { "e7cd3e98-f2cd-4b3f-c223-7ffe71f79c48", 0, "3c556f57-4e55-4dbd-9628-da9034e569f8", "customer2@company.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEPaYsYECoLQZWsDLhLEkjG3SsJxbjysixWH851+OWtC9ZpLnvqf19Xe4vleFEuIG7w==", null, false, "3317013d-a366-4a4b-baed-54ff8e93c100", false, "customer2" },
                    { "f8de4f99-g3de-5c4g-d334-8fff82g89d59", 0, "2fa7d9e6-9cc5-4f72-8965-c72fc02e7260", "customer3@company.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEMXe3w5lIvXILTC+kFH1obGi3Mgua/15FRV2Uw6YiHWDBeX24bK/wcUTER/+TiDPiA==", null, false, "fb8d16b3-4385-4924-8f54-aca2b3dfaf56", false, "customer3" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Clothing" },
                    { 3, "Home & Kitchen" },
                    { 4, "Books" },
                    { 5, "Toys & Games" },
                    { 6, "Health & Beauty" },
                    { 7, "Sports & Outdoors" },
                    { 8, "Automotive" },
                    { 9, "Pet Supplies" },
                    { 10, "Office Products" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c4bbeb97-d3ba-4b53-b521-5ffa61e59b36", "d6bc2e97-e1fc-4a2f-b112-6ff861e69c37" },
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f" },
                    { "c4bbeb97-d3ba-4b53-b521-5ffa61e59b36", "e7cd3e98-f2cd-4b3f-c223-7ffe71f79c48" },
                    { "c4bbeb97-d3ba-4b53-b521-5ffa61e59b36", "f8de4f99-g3de-5c4g-d334-8fff82g89d59" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 1, "Latest model with advanced features.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737147528/smartphone_snyc32.png", "Smartphone", 699.99m, 50 },
                    { 2, 1, "High-performance laptop for work and gaming.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161746/laptop_rqwu1z.png", "Laptop", 999.99m, 30 },
                    { 3, 1, "Noise-cancelling and long battery life.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161738/wirelss_earbuds_zquyxb.png", "Wireless Earbuds", 129.99m, 100 },
                    { 4, 1, "Track your fitness and stay connected.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161749/smartwatch_trbw5c.png", "Smartwatch", 199.99m, 70 },
                    { 5, 1, "Ultra HD display for a cinematic experience.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161738/4K_TV_kcravp.png", "4K TV", 499.99m, 20 },
                    { 6, 1, "Next-gen console with immersive graphics.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161745/gaming_console_spdufh.png", "Gaming Console", 399.99m, 25 },
                    { 7, 1, "Portable speaker with deep bass.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161740/bluetooth_speaker_mvvzdy.png", "Bluetooth Speaker", 89.99m, 80 },
                    { 8, 1, "1TB storage for backups and data.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161744/external_hard_drive_slcnru.png", "External Hard Drive", 59.99m, 40 },
                    { 9, 1, "Capture memories in stunning detail.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161742/Digital_camera_kxhz9p.png", "Digital Camera", 349.99m, 15 },
                    { 10, 1, "Lightweight tablet for on-the-go use.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737163713/tablet_fjpny0.png", "Tablet", 299.99m, 60 },
                    { 11, 2, "100% cotton and breathable.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161746/men_s_t-shirts_sikyul.png", "Men's T-Shirt", 19.99m, 150 },
                    { 12, 2, "Comfortable and stylish fit.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161738/women_s_jeans_sslsjr.png", "Women's Jeans", 49.99m, 100 },
                    { 13, 2, "Keeps you warm in extreme cold.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161738/winter_jacket_fswhps.png", "Winter Jacket", 89.99m, 50 },
                    { 14, 2, "Perfect for workouts or casual wear.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161750/sports_hoodie_sjqiyv.png", "Sports Hoodie", 39.99m, 80 },
                    { 15, 2, "Comfortable and trendy footwear.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161749/sneakers_cibtlt.png", "Sneakers", 69.99m, 120 },
                    { 16, 2, "Perfect for office or events.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161745/formal_shirt_nvaxvy.png", "Formal Shirt", 29.99m, 100 },
                    { 17, 2, "Lightweight and flowy fabric.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161749/skirt_n5fkoc.png", "Skirt", 24.99m, 70 },
                    { 18, 2, "Adjustable size for comfort.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161739/Baseball_cap_ekwzf6.png", "Baseball Cap", 14.99m, 200 },
                    { 19, 2, "Flexible and breathable material.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161738/yoga_pants_ygvn9e.png", "Yoga Pants", 34.99m, 90 },
                    { 20, 2, "Durable and stylish accessory.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161746/leather_belt_ixkvgd.png", "Leather Belt", 19.99m, 60 },
                    { 21, 3, "Brew fresh coffee every morning with ease.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161741/coffee_maker_tm6s61.png", "Coffee Maker", 59.99m, 30 },
                    { 22, 3, "Perfect for smoothies, soups, and sauces.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161739/blender_hmmby2.png", "Blender", 39.99m, 40 },
                    { 23, 3, "Healthier frying with little to no oil.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161738/air_fryer_gtjeby.png", "Air Fryer", 89.99m, 25 },
                    { 24, 3, "Durable pots and pans with nonstick coating.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161747/nonstick_cookware_set_nqdtjp.png", "Nonstick Cookware Set", 99.99m, 15 },
                    { 25, 3, "Powerful suction for deep cleaning.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161750/vacuum_cleaner_vqrjio.png", "Vacuum Cleaner", 129.99m, 20 },
                    { 26, 3, "Compact and efficient heating appliance.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161746/microwave_tiyun4.png", "Microwave Oven", 149.99m, 10 },
                    { 27, 3, "Quickly boils water for tea or coffee.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161744/electric_kettle_oolbr4.png", "Electric Kettle", 29.99m, 50 },
                    { 28, 3, "Sturdy and rust-proof drying rack.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161742/dish_rack_eswuqb.png", "Dish Rack", 19.99m, 60 },
                    { 29, 3, "Cooks food faster and retains nutrients.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161748/pressure_cooker_uym9wi.png", "Pressure Cooker", 79.99m, 35 },
                    { 30, 3, "Elegant stainless steel knives and forks.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161742/cutlery_set_xlaqse.png", "Cutlery Set", 49.99m, 70 },
                    { 31, 4, "A bestselling page-turner full of suspense.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161744/ficiton_novel_nh0yvj.png", "Fiction Novel", 14.99m, 80 },
                    { 32, 4, "Motivational tips for personal growth.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161748/self-help_guide_dttosc.png", "Self-Help Guide", 19.99m, 50 },
                    { 33, 4, "Delicious recipes for everyday cooking.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161741/cookbook_sfzbd5.png", "Cookbook", 24.99m, 60 },
                    { 34, 4, "An imaginative journey across galaxies.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161749/science_fiction_epic_bvvfqi.png", "Science Fiction Epic", 29.99m, 40 },
                    { 35, 4, "The life story of an influential figure.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161739/biography_ybbuyj.png", "Biography", 17.99m, 30 },
                    { 36, 4, "Magic and heroism in an epic tale.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161744/fantasy_adventure_book_kxcpjl.png", "Fantasy Adventure", 14.99m, 70 },
                    { 37, 4, "A gripping whodunit with twists and turns.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161747/mystery_thriller_mpd5ru.png", "Mystery Thriller", 12.99m, 90 },
                    { 38, 4, "Bright and engaging stories for kids.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161741/children_s_picture_book_ph0spz.png", "Children's Picture Book", 9.99m, 100 },
                    { 39, 4, "Rich narratives set in the past.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161747/historical_fiction_book_rcjuad.png", "Historical Fiction", 19.99m, 45 },
                    { 40, 4, "Beautifully written verses to inspire.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161748/poetry_collection_tqtpbu.png", "Poetry Collection", 11.99m, 50 },
                    { 41, 5, "Colorful blocks to encourage creativity.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161740/building_blocks_set_j4fmvl.png", "Building Blocks Set", 24.99m, 50 },
                    { 42, 5, "A fun strategy game for the whole family.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161740/board_game_gbdxxp.png", "Board Game", 29.99m, 40 },
                    { 43, 5, "Detailed collectible for kids and adults.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161738/action_figure_xcdiyd.png", "Action Figure", 19.99m, 30 },
                    { 44, 5, "Soft and cuddly companion for children.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161750/stuffed_animal_ro8kuy.png", "Stuffed Animal", 14.99m, 80 },
                    { 45, 5, "Challenging puzzles for brain exercise.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161748/puzzle_set_w2ytxm.png", "Puzzle Set", 12.99m, 60 },
                    { 46, 5, "Fast and fun RC vehicle for kids.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161749/remote_control_car_gqev1c.png", "Remote Control Car", 39.99m, 20 },
                    { 47, 5, "Detailed dollhouse for imaginative play.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161743/dollhouse_odfmdv.png", "Dollhouse", 49.99m, 15 },
                    { 48, 5, "Safe and durable swing for outdoor fun.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161747/outdoorswing_iowmjv.png", "Outdoor Swing", 59.99m, 25 },
                    { 49, 5, "Portable card game for travel or parties.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161741/card_game_r4rtt1.png", "Card Game", 9.99m, 100 },
                    { 50, 5, "Includes paint, brushes, and crayons.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161745/kid_s_art_kit_ekcbe8.png", "Kids' Art Kit", 19.99m, 50 },
                    { 51, 6, "Hydrates and nourishes dry skin.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161746/moisturizing_lotion_f1ljlf.png", "Moisturizing Lotion", 14.99m, 40 },
                    { 52, 6, "Brightens skin and reduces dark spots.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161737/vitamin_c_serum_ncuxbx.png", "Vitamin C Serum", 24.99m, 35 },
                    { 53, 6, "For soft and healthy hair.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161748/shampoo_conditioner_set_eo50m5.png", "Shampoo & Conditioner Set", 19.99m, 50 },
                    { 54, 6, "Provides a deep and thorough clean.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161743/electric_toothbrush_yd8jfw.png", "Electric Toothbrush", 29.99m, 20 },
                    { 55, 6, "Includes essentials for daily makeup.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161746/makeup_kit_vjinoe.png", "Makeup Kit", 49.99m, 25 },
                    { 56, 6, "Relax with soothing aromatherapy.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161744/essential_oil_diffuser_mziiyp.png", "Essential Oil Diffuser", 34.99m, 15 },
                    { 57, 6, "Tracks activity, heart rate, and sleep.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161745/fitness_tracker_hfjjg4.png", "Fitness Tracker", 59.99m, 30 },
                    { 58, 6, "Includes hydrating and purifying masks.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161744/face_mask_pack_wubexr.png", "Face Mask Pack", 12.99m, 70 },
                    { 59, 7, "Non-slip mat for yoga and exercise.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161738/yoga_pants_ygvn9e.png", "Yoga Mat", 19.99m, 40 },
                    { 60, 7, "Lightweight tent for 2 people.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161740/camping_tent_kqlfgl.png", "Camping Tent", 89.99m, 25 },
                    { 61, 7, "Durable backpack with multiple compartments.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161746/hiking_backpack_jznpao.png", "Hiking Backpack", 49.99m, 30 },
                    { 62, 7, "Telescopic fishing rod for outdoor adventures.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161744/fishing_rod_nbipzz.png", "Fishing Rod", 39.99m, 20 },
                    { 63, 7, "Official size and weight basketball.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161739/basketball_a6xgmd.png", "Basketball", 29.99m, 50 },
                    { 64, 7, "Warm and lightweight sleeping bag.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161749/sleeping_bag_mckumk.png", "Sleeping Bag", 34.99m, 35 },
                    { 65, 7, "Insulated bottle to keep drinks hot or cold.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161737/water_bottle_c5ryy9.png", "Water Bottle", 14.99m, 80 },
                    { 66, 7, "Adjustable weights for strength training.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161743/dumbbell_set_ksagsb.png", "Dumbbell Set", 59.99m, 15 },
                    { 67, 7, "Protective helmet for cycling.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161739/bicycle_helmet_amk6no.png", "Bicycle Helmet", 39.99m, 45 },
                    { 68, 7, "Lightweight poles for hiking.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161750/trekking_poles_pvlbje.png", "Trekking Poles", 24.99m, 50 },
                    { 69, 8, "Includes sponge, soap, and microfiber towel.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161741/car_wash_kit_l6rmsa.png", "Car Wash Kit", 29.99m, 30 },
                    { 70, 8, "Portable vacuum for interior cleaning.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161741/car_vauum_cleaner_aazhcv.png", "Car Vacuum Cleaner", 49.99m, 20 },
                    { 71, 8, "Energy-efficient and bright LED headlights.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161746/LED_headlights_jhsqst.png", "LED Headlights", 79.99m, 15 },
                    { 72, 8, "Compact and easy-to-use air compressor.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161750/tire_inflator_ntu5jp.png", "Tire Inflator", 39.99m, 25 },
                    { 73, 8, "Records high-definition video for safety.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161742/dashboard_camera_bp3aff.png", "Dashboard Camera", 99.99m, 10 },
                    { 74, 8, "Stylish and durable covers for car seats.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161741/car_seat_cover_set_c6h5wo.png", "Car Seat Cover Set", 59.99m, 18 },
                    { 75, 9, "Durable chew toy for dogs of all sizes.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161742/dog_chew_toy_wa5vcl.png", "Dog Chew Toy", 9.99m, 50 },
                    { 76, 9, "Sturdy post to keep your cat entertained.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161741/cat_scratching_post_if1syl.png", "Cat Scratching Post", 24.99m, 30 },
                    { 77, 9, "Non-slip bowl for feeding your pets.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161747/pet_food_bowl_tyhbdu.png", "Pet Food Bowl", 7.99m, 80 },
                    { 78, 9, "Complete kit for setting up a home aquarium.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161739/aquarium_starter_kit_vqzhea.png", "Aquarium Starter Kit", 49.99m, 15 },
                    { 79, 9, "Strong and adjustable leash for dogs.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161743/dog_leash_ywpqez.png", "Dog Leash", 14.99m, 60 },
                    { 80, 10, "Comfortable and adjustable chair for office use.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161743/ergonomic_office_chair_klsqqj.png", "Ergonomic Office Chair", 149.99m, 20 },
                    { 81, 10, "Compact and responsive keyboard-mouse combo.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161738/wireless_keyboard_and_mouse_sdrcu3.png", "Wireless Keyboard and Mouse", 39.99m, 35 },
                    { 82, 10, "Keeps your desk neat and clutter-free.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161742/desk_organizer_jrdpch.png", "Desk Organizer", 19.99m, 50 },
                    { 83, 10, "Set of 3 notebooks for work or study.", "https://res.cloudinary.com/dpq83a6ds/image/upload/v1737161747/notebook_set_fw4axu.png", "Notebook Set", 12.99m, 60 }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Address", "FirstName", "IdentityUserId", "LastName" },
                values: new object[,]
                {
                    { 1, "101 Main Street", "Admina", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", "Strator" },
                    { 2, " 220 High Street", "Tom", "d6bc2e97-e1fc-4a2f-b112-6ff861e69c37", "Jones" },
                    { 3, "300 Elm Avenue", "Jane", "e7cd3e98-f2cd-4b3f-c223-7ffe71f79c48", "Smith" },
                    { 4, "400 Oak Street", "John", "f8de4f99-g3de-5c4g-d334-8fff82g89d59", "Doe" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "OrderDate", "UserProfileId", "isCanceled" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 7, 20, 1, 7, 616, DateTimeKind.Local).AddTicks(2778), 2, false },
                    { 2, new DateTime(2025, 1, 10, 20, 1, 7, 616, DateTimeKind.Local).AddTicks(2834), 3, false },
                    { 3, new DateTime(2025, 1, 12, 20, 1, 7, 616, DateTimeKind.Local).AddTicks(2836), 2, false },
                    { 4, new DateTime(2025, 1, 14, 20, 1, 7, 616, DateTimeKind.Local).AddTicks(2839), 4, true },
                    { 5, new DateTime(2025, 1, 16, 20, 1, 7, 616, DateTimeKind.Local).AddTicks(2841), 3, false }
                });

            migrationBuilder.InsertData(
                table: "OrderProducts",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 10, 1 },
                    { 2, 1, 20, 2 },
                    { 3, 2, 30, 1 },
                    { 4, 2, 40, 1 },
                    { 5, 3, 50, 2 },
                    { 6, 3, 60, 1 },
                    { 7, 4, 70, 3 },
                    { 8, 4, 80, 1 },
                    { 9, 5, 75, 1 },
                    { 10, 5, 81, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserProfileId",
                table: "Orders",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_IdentityUserId",
                table: "UserProfiles",
                column: "IdentityUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}

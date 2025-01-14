using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NexMart.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    { "d6bc2e97-e1fc-4a2f-b112-6ff861e69c37", 0, "278b0767-e968-44ea-8427-ebc956e64709", "customer1@company.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEJeqfk5TJIxiYIoZwE88rFS9AcA0oqlt9vF4pnNuneljZJaanLe7dcSOlpKXxamBwg==", null, false, "2ce76b15-e976-4811-a3c1-edf8c696b34a", false, "customer1" },
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "e6ef7d0b-6bd1-40d2-a4b0-e10400bc5553", "admina@strator.comx", false, false, null, null, null, "AQAAAAIAAYagAAAAEE42TU0Uyzor1e1j8acqeaTrAMYMLQhMIq2QX6robkYjNYu0mIHJJF+9KdmqCG1Utg==", null, false, "ebdd6e92-e2db-4b13-af0e-4d5ce41a0d79", false, "Administrator" },
                    { "e7cd3e98-f2cd-4b3f-c223-7ffe71f79c48", 0, "76f5a886-b41a-444d-96d7-30eda9b27b13", "customer2@company.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEI0xAKxSANJDeOpMdu80KbDuS1CkNH70LQrCBoLIFdZx3ZFPLIM3vqaEHTBSv2P/4Q==", null, false, "a6fab7be-4546-4182-a3c0-0a2ce4dcdf57", false, "customer2" },
                    { "f8de4f99-g3de-5c4g-d334-8fff82g89d59", 0, "81f1e2a3-c7c8-4c22-a099-64ed512caf5d", "customer3@company.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEPlroARA0Dgqw4bth3X4s1wJ23PxPFd3gnO+YCAfDoHd2lACtnZY4tOv6csn2Zs8MQ==", null, false, "61238a26-2cfc-4162-af53-8ede7c93d942", false, "customer3" }
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
                    { 1, 1, "Latest model with advanced features.", null, "Smartphone", 699.99m, 50 },
                    { 2, 1, "High-performance laptop for work and gaming.", null, "Laptop", 999.99m, 30 },
                    { 3, 1, "Noise-cancelling and long battery life.", null, "Wireless Earbuds", 129.99m, 100 },
                    { 4, 1, "Track your fitness and stay connected.", null, "Smartwatch", 199.99m, 70 },
                    { 5, 1, "Ultra HD display for a cinematic experience.", null, "4K TV", 499.99m, 20 },
                    { 6, 1, "Next-gen console with immersive graphics.", null, "Gaming Console", 399.99m, 25 },
                    { 7, 1, "Portable speaker with deep bass.", null, "Bluetooth Speaker", 89.99m, 80 },
                    { 8, 1, "1TB storage for backups and data.", null, "External Hard Drive", 59.99m, 40 },
                    { 9, 1, "Capture memories in stunning detail.", null, "Digital Camera", 349.99m, 15 },
                    { 10, 1, "Lightweight tablet for on-the-go use.", null, "Tablet", 299.99m, 60 },
                    { 11, 2, "100% cotton and breathable.", null, "Men's T-Shirt", 19.99m, 150 },
                    { 12, 2, "Comfortable and stylish fit.", null, "Women's Jeans", 49.99m, 100 },
                    { 13, 2, "Keeps you warm in extreme cold.", null, "Winter Jacket", 89.99m, 50 },
                    { 14, 2, "Perfect for workouts or casual wear.", null, "Sports Hoodie", 39.99m, 80 },
                    { 15, 2, "Comfortable and trendy footwear.", null, "Sneakers", 69.99m, 120 },
                    { 16, 2, "Perfect for office or events.", null, "Formal Shirt", 29.99m, 100 },
                    { 17, 2, "Lightweight and flowy fabric.", null, "Skirt", 24.99m, 70 },
                    { 18, 2, "Adjustable size for comfort.", null, "Baseball Cap", 14.99m, 200 },
                    { 19, 2, "Flexible and breathable material.", null, "Yoga Pants", 34.99m, 90 },
                    { 20, 2, "Durable and stylish accessory.", null, "Leather Belt", 19.99m, 60 },
                    { 21, 3, "Brew fresh coffee every morning with ease.", null, "Coffee Maker", 59.99m, 30 },
                    { 22, 3, "Perfect for smoothies, soups, and sauces.", null, "Blender", 39.99m, 40 },
                    { 23, 3, "Healthier frying with little to no oil.", null, "Air Fryer", 89.99m, 25 },
                    { 24, 3, "Durable pots and pans with nonstick coating.", null, "Nonstick Cookware Set", 99.99m, 15 },
                    { 25, 3, "Powerful suction for deep cleaning.", null, "Vacuum Cleaner", 129.99m, 20 },
                    { 26, 3, "Compact and efficient heating appliance.", null, "Microwave Oven", 149.99m, 10 },
                    { 27, 3, "Quickly boils water for tea or coffee.", null, "Electric Kettle", 29.99m, 50 },
                    { 28, 3, "Sturdy and rust-proof drying rack.", null, "Dish Rack", 19.99m, 60 },
                    { 29, 3, "Cooks food faster and retains nutrients.", null, "Pressure Cooker", 79.99m, 35 },
                    { 30, 3, "Elegant stainless steel knives and forks.", null, "Cutlery Set", 49.99m, 70 },
                    { 31, 4, "A bestselling page-turner full of suspense.", null, "Fiction Novel", 14.99m, 80 },
                    { 32, 4, "Motivational tips for personal growth.", null, "Self-Help Guide", 19.99m, 50 },
                    { 33, 4, "Delicious recipes for everyday cooking.", null, "Cookbook", 24.99m, 60 },
                    { 34, 4, "An imaginative journey across galaxies.", null, "Science Fiction Epic", 29.99m, 40 },
                    { 35, 4, "The life story of an influential figure.", null, "Biography", 17.99m, 30 },
                    { 36, 4, "Magic and heroism in an epic tale.", null, "Fantasy Adventure", 14.99m, 70 },
                    { 37, 4, "A gripping whodunit with twists and turns.", null, "Mystery Thriller", 12.99m, 90 },
                    { 38, 4, "Bright and engaging stories for kids.", null, "Children's Picture Book", 9.99m, 100 },
                    { 39, 4, "Rich narratives set in the past.", null, "Historical Fiction", 19.99m, 45 },
                    { 40, 4, "Beautifully written verses to inspire.", null, "Poetry Collection", 11.99m, 50 },
                    { 41, 5, "Colorful blocks to encourage creativity.", null, "Building Blocks Set", 24.99m, 50 },
                    { 42, 5, "A fun strategy game for the whole family.", null, "Board Game", 29.99m, 40 },
                    { 43, 5, "Detailed collectible for kids and adults.", null, "Action Figure", 19.99m, 30 },
                    { 44, 5, "Soft and cuddly companion for children.", null, "Stuffed Animal", 14.99m, 80 },
                    { 45, 5, "Challenging puzzles for brain exercise.", null, "Puzzle Set", 12.99m, 60 },
                    { 46, 5, "Fast and fun RC vehicle for kids.", null, "Remote Control Car", 39.99m, 20 },
                    { 47, 5, "Detailed dollhouse for imaginative play.", null, "Dollhouse", 49.99m, 15 },
                    { 48, 5, "Safe and durable swing for outdoor fun.", null, "Outdoor Swing", 59.99m, 25 },
                    { 49, 5, "Portable card game for travel or parties.", null, "Card Game", 9.99m, 100 },
                    { 50, 5, "Includes paint, brushes, and crayons.", null, "Kids' Art Kit", 19.99m, 50 },
                    { 51, 6, "Hydrates and nourishes dry skin.", null, "Moisturizing Lotion", 14.99m, 40 },
                    { 52, 6, "Brightens skin and reduces dark spots.", null, "Vitamin C Serum", 24.99m, 35 },
                    { 53, 6, "For soft and healthy hair.", null, "Shampoo & Conditioner Set", 19.99m, 50 },
                    { 54, 6, "Provides a deep and thorough clean.", null, "Electric Toothbrush", 29.99m, 20 },
                    { 55, 6, "Includes essentials for daily makeup.", null, "Makeup Kit", 49.99m, 25 },
                    { 56, 6, "Relax with soothing aromatherapy.", null, "Essential Oil Diffuser", 34.99m, 15 },
                    { 57, 6, "Tracks activity, heart rate, and sleep.", null, "Fitness Tracker", 59.99m, 30 },
                    { 58, 6, "Includes hydrating and purifying masks.", null, "Face Mask Pack", 12.99m, 70 },
                    { 59, 7, "Non-slip mat for yoga and exercise.", null, "Yoga Mat", 19.99m, 40 },
                    { 60, 7, "Lightweight tent for 2 people.", null, "Camping Tent", 89.99m, 25 },
                    { 61, 7, "Durable backpack with multiple compartments.", null, "Hiking Backpack", 49.99m, 30 },
                    { 62, 7, "Telescopic fishing rod for outdoor adventures.", null, "Fishing Rod", 39.99m, 20 },
                    { 63, 7, "Official size and weight basketball.", null, "Basketball", 29.99m, 50 },
                    { 64, 7, "Warm and lightweight sleeping bag.", null, "Sleeping Bag", 34.99m, 35 },
                    { 65, 7, "Insulated bottle to keep drinks hot or cold.", null, "Water Bottle", 14.99m, 80 },
                    { 66, 7, "Adjustable weights for strength training.", null, "Dumbbell Set", 59.99m, 15 },
                    { 67, 7, "Protective helmet for cycling.", null, "Bicycle Helmet", 39.99m, 45 },
                    { 68, 7, "Lightweight poles for hiking.", null, "Trekking Poles", 24.99m, 50 },
                    { 69, 8, "Includes sponge, soap, and microfiber towel.", null, "Car Wash Kit", 29.99m, 30 },
                    { 70, 8, "Portable vacuum for interior cleaning.", null, "Car Vacuum Cleaner", 49.99m, 20 },
                    { 71, 8, "Energy-efficient and bright LED headlights.", null, "LED Headlights", 79.99m, 15 },
                    { 72, 8, "Compact and easy-to-use air compressor.", null, "Tire Inflator", 39.99m, 25 },
                    { 73, 8, "Records high-definition video for safety.", null, "Dashboard Camera", 99.99m, 10 },
                    { 74, 8, "Stylish and durable covers for car seats.", null, "Car Seat Cover Set", 59.99m, 18 },
                    { 75, 9, "Durable chew toy for dogs of all sizes.", null, "Dog Chew Toy", 9.99m, 50 },
                    { 76, 9, "Sturdy post to keep your cat entertained.", null, "Cat Scratching Post", 24.99m, 30 },
                    { 77, 9, "Non-slip bowl for feeding your pets.", null, "Pet Food Bowl", 7.99m, 80 },
                    { 78, 9, "Complete kit for setting up a home aquarium.", null, "Aquarium Starter Kit", 49.99m, 15 },
                    { 79, 9, "Strong and adjustable leash for dogs.", null, "Dog Leash", 14.99m, 60 },
                    { 80, 10, "Comfortable and adjustable chair for office use.", null, "Ergonomic Office Chair", 149.99m, 20 },
                    { 81, 10, "Compact and responsive keyboard-mouse combo.", null, "Wireless Keyboard and Mouse", 39.99m, 35 },
                    { 82, 10, "Keeps your desk neat and clutter-free.", null, "Desk Organizer", 19.99m, 50 },
                    { 83, 10, "Set of 3 notebooks for work or study.", null, "Notebook Set", 12.99m, 60 },
                    { 84, 10, "Adjustable lamp with LED lighting.", null, "Office Desk Lamp", 29.99m, 40 }
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
                    { 1, new DateTime(2025, 1, 3, 15, 4, 52, 356, DateTimeKind.Local).AddTicks(3559), 2, false },
                    { 2, new DateTime(2025, 1, 6, 15, 4, 52, 356, DateTimeKind.Local).AddTicks(3602), 3, false },
                    { 3, new DateTime(2025, 1, 8, 15, 4, 52, 356, DateTimeKind.Local).AddTicks(3604), 2, false },
                    { 4, new DateTime(2025, 1, 10, 15, 4, 52, 356, DateTimeKind.Local).AddTicks(3606), 4, true },
                    { 5, new DateTime(2025, 1, 12, 15, 4, 52, 356, DateTimeKind.Local).AddTicks(3609), 3, false }
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

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NexMart.Models;
using Microsoft.AspNetCore.Identity;

namespace NexMart.Data;
public class NexMartDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }
    

    public NexMartDbContext(DbContextOptions<NexMartDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole []
        {
            new IdentityRole
            {
                Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                Name = "Admin",
                NormalizedName = "admin"
            },
            new IdentityRole
            {
                Id = "c4bbeb97-d3ba-4b53-b521-5ffa61e59b36",
                Name = "Customer",
                NormalizedName = "customer"
            }
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser []
        {
            new IdentityUser
            {
                Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                UserName = "Administrator",
                Email = "admina@strator.comx",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "d6bc2e97-e1fc-4a2f-b112-6ff861e69c37",
                UserName = "customer1",
                Email = "customer1@company.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "Customer123")
            },
             new IdentityUser
            {
                Id = "e7cd3e98-f2cd-4b3f-c223-7ffe71f79c48", // New Customer 2
                UserName = "customer2",
                Email = "customer2@company.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "Customer234")
            },
            new IdentityUser
            {
                Id = "f8de4f99-g3de-5c4g-d334-8fff82g89d59", // New Customer 3
                UserName = "customer3",
                Email = "customer3@company.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "Customer345")
            }
            
        });


        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>[]
        {
            new IdentityUserRole<string>
            {
                RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", // Admin role ID
                UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"  // User ID for Admin
            },
            new IdentityUserRole<string>
            {
                RoleId = "c4bbeb97-d3ba-4b53-b521-5ffa61e59b36", // Customer role ID
                UserId = "d6bc2e97-e1fc-4a2f-b112-6ff861e69c37"  // User ID for Customer
            },
            new IdentityUserRole<string>
            {
                RoleId = "c4bbeb97-d3ba-4b53-b521-5ffa61e59b36", // Customer role ID
                UserId = "e7cd3e98-f2cd-4b3f-c223-7ffe71f79c48"  // User ID for Customer 2
            },
            new IdentityUserRole<string>
            {
                RoleId = "c4bbeb97-d3ba-4b53-b521-5ffa61e59b36", // Customer role ID
                UserId = "f8de4f99-g3de-5c4g-d334-8fff82g89d59"  // User ID for Customer 3
            }

        });

        
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile []
        {
            new UserProfile
            {
                Id = 1,
                IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                FirstName = "Admina",
                LastName = "Strator",
                Address = "101 Main Street",
            },
              new UserProfile
              {
                Id = 2,
                IdentityUserId = "d6bc2e97-e1fc-4a2f-b112-6ff861e69c37",
                FirstName = "Tom",
                LastName = "Jones",
                Address = " 220 High Street",
            },
             new UserProfile
            {
                Id = 3,
                IdentityUserId = "e7cd3e98-f2cd-4b3f-c223-7ffe71f79c48", // Customer 2 UserProfile
                FirstName = "Jane",
                LastName = "Smith",
                Address = "300 Elm Avenue"
            },
            new UserProfile
            {
                Id = 4,
                IdentityUserId = "f8de4f99-g3de-5c4g-d334-8fff82g89d59", // Customer 3 UserProfile
                FirstName = "John",
                LastName = "Doe",
                Address = "400 Oak Street"
            }
            
        });


         modelBuilder.Entity<Category>().HasData(new Category[]
        {
            new Category { Id = 1, Name = "Electronics" },
            new Category { Id = 2, Name = "Clothing" },
            new Category { Id = 3, Name = "Home & Kitchen" },
            new Category { Id = 4, Name = "Books" },
            new Category { Id = 5, Name = "Toys & Games" },
            new Category { Id = 6, Name = "Health & Beauty" },
            new Category { Id = 7, Name = "Sports & Outdoors" },
            new Category { Id = 8, Name = "Automotive" },
            new Category { Id = 9, Name = "Pet Supplies" },
            new Category { Id = 10, Name = "Office Products" }
        });


        
    modelBuilder.Entity<Product>().HasData(new Product[]
    {
        // Electronics
        new Product { Id = 1, Name = "Smartphone", Price = 699.99m, CategoryId = 1, Description = "Latest model with advanced features.", StockQuantity = 50 },
        new Product { Id = 2, Name = "Laptop", Price = 999.99m, CategoryId = 1, Description = "High-performance laptop for work and gaming.", StockQuantity = 30 },
        new Product { Id = 3, Name = "Wireless Earbuds", Price = 129.99m, CategoryId = 1, Description = "Noise-cancelling and long battery life.", StockQuantity = 100 },
        new Product { Id = 4, Name = "Smartwatch", Price = 199.99m, CategoryId = 1, Description = "Track your fitness and stay connected.", StockQuantity = 70 },
        new Product { Id = 5, Name = "4K TV", Price = 499.99m, CategoryId = 1, Description = "Ultra HD display for a cinematic experience.", StockQuantity = 20 },
        new Product { Id = 6, Name = "Gaming Console", Price = 399.99m, CategoryId = 1, Description = "Next-gen console with immersive graphics.", StockQuantity = 25 },
        new Product { Id = 7, Name = "Bluetooth Speaker", Price = 89.99m, CategoryId = 1, Description = "Portable speaker with deep bass.", StockQuantity = 80 },
        new Product { Id = 8, Name = "External Hard Drive", Price = 59.99m, CategoryId = 1, Description = "1TB storage for backups and data.", StockQuantity = 40 },
        new Product { Id = 9, Name = "Digital Camera", Price = 349.99m, CategoryId = 1, Description = "Capture memories in stunning detail.", StockQuantity = 15 },
        new Product { Id = 10, Name = "Tablet", Price = 299.99m, CategoryId = 1, Description = "Lightweight tablet for on-the-go use.", StockQuantity = 60 },

        // Clothing
        new Product { Id = 11, Name = "Men's T-Shirt", Price = 19.99m, CategoryId = 2, Description = "100% cotton and breathable.", StockQuantity = 150 },
        new Product { Id = 12, Name = "Women's Jeans", Price = 49.99m, CategoryId = 2, Description = "Comfortable and stylish fit.", StockQuantity = 100 },
        new Product { Id = 13, Name = "Winter Jacket", Price = 89.99m, CategoryId = 2, Description = "Keeps you warm in extreme cold.", StockQuantity = 50 },
        new Product { Id = 14, Name = "Sports Hoodie", Price = 39.99m, CategoryId = 2, Description = "Perfect for workouts or casual wear.", StockQuantity = 80 },
        new Product { Id = 15, Name = "Sneakers", Price = 69.99m, CategoryId = 2, Description = "Comfortable and trendy footwear.", StockQuantity = 120 },
        new Product { Id = 16, Name = "Formal Shirt", Price = 29.99m, CategoryId = 2, Description = "Perfect for office or events.", StockQuantity = 100 },
        new Product { Id = 17, Name = "Skirt", Price = 24.99m, CategoryId = 2, Description = "Lightweight and flowy fabric.", StockQuantity = 70 },
        new Product { Id = 18, Name = "Baseball Cap", Price = 14.99m, CategoryId = 2, Description = "Adjustable size for comfort.", StockQuantity = 200 },
        new Product { Id = 19, Name = "Yoga Pants", Price = 34.99m, CategoryId = 2, Description = "Flexible and breathable material.", StockQuantity = 90 },
        new Product { Id = 20, Name = "Leather Belt", Price = 19.99m, CategoryId = 2, Description = "Durable and stylish accessory.", StockQuantity = 60 },

       
        // Home & Kitchen
        new Product { Id = 21, Name = "Coffee Maker", Price = 59.99m, CategoryId = 3, Description = "Brew fresh coffee every morning with ease.", StockQuantity = 30 },
        new Product { Id = 22, Name = "Blender", Price = 39.99m, CategoryId = 3, Description = "Perfect for smoothies, soups, and sauces.", StockQuantity = 40 },
        new Product { Id = 23, Name = "Air Fryer", Price = 89.99m, CategoryId = 3, Description = "Healthier frying with little to no oil.", StockQuantity = 25 },
        new Product { Id = 24, Name = "Nonstick Cookware Set", Price = 99.99m, CategoryId = 3, Description = "Durable pots and pans with nonstick coating.", StockQuantity = 15 },
        new Product { Id = 25, Name = "Vacuum Cleaner", Price = 129.99m, CategoryId = 3, Description = "Powerful suction for deep cleaning.", StockQuantity = 20 },
        new Product { Id = 26, Name = "Microwave Oven", Price = 149.99m, CategoryId = 3, Description = "Compact and efficient heating appliance.", StockQuantity = 10 },
        new Product { Id = 27, Name = "Electric Kettle", Price = 29.99m, CategoryId = 3, Description = "Quickly boils water for tea or coffee.", StockQuantity = 50 },
        new Product { Id = 28, Name = "Dish Rack", Price = 19.99m, CategoryId = 3, Description = "Sturdy and rust-proof drying rack.", StockQuantity = 60 },
        new Product { Id = 29, Name = "Pressure Cooker", Price = 79.99m, CategoryId = 3, Description = "Cooks food faster and retains nutrients.", StockQuantity = 35 },
        new Product { Id = 30, Name = "Cutlery Set", Price = 49.99m, CategoryId = 3, Description = "Elegant stainless steel knives and forks.", StockQuantity = 70 },

    

        // Books
        new Product { Id = 31, Name = "Fiction Novel", Price = 14.99m, CategoryId = 4, Description = "A bestselling page-turner full of suspense.", StockQuantity = 80 },
        new Product { Id = 32, Name = "Self-Help Guide", Price = 19.99m, CategoryId = 4, Description = "Motivational tips for personal growth.", StockQuantity = 50 },
        new Product { Id = 33, Name = "Cookbook", Price = 24.99m, CategoryId = 4, Description = "Delicious recipes for everyday cooking.", StockQuantity = 60 },
        new Product { Id = 34, Name = "Science Fiction Epic", Price = 29.99m, CategoryId = 4, Description = "An imaginative journey across galaxies.", StockQuantity = 40 },
        new Product { Id = 35, Name = "Biography", Price = 17.99m, CategoryId = 4, Description = "The life story of an influential figure.", StockQuantity = 30 },
        new Product { Id = 36, Name = "Fantasy Adventure", Price = 14.99m, CategoryId = 4, Description = "Magic and heroism in an epic tale.", StockQuantity = 70 },
        new Product { Id = 37, Name = "Mystery Thriller", Price = 12.99m, CategoryId = 4, Description = "A gripping whodunit with twists and turns.", StockQuantity = 90 },
        new Product { Id = 38, Name = "Children's Picture Book", Price = 9.99m, CategoryId = 4, Description = "Bright and engaging stories for kids.", StockQuantity = 100 },
        new Product { Id = 39, Name = "Historical Fiction", Price = 19.99m, CategoryId = 4, Description = "Rich narratives set in the past.", StockQuantity = 45 },
        new Product { Id = 40, Name = "Poetry Collection", Price = 11.99m, CategoryId = 4, Description = "Beautifully written verses to inspire.", StockQuantity = 50 },

        

        // Toys & Games
        new Product { Id = 41, Name = "Building Blocks Set", Price = 24.99m, CategoryId = 5, Description = "Colorful blocks to encourage creativity.", StockQuantity = 50 },
        new Product { Id = 42, Name = "Board Game", Price = 29.99m, CategoryId = 5, Description = "A fun strategy game for the whole family.", StockQuantity = 40 },
        new Product { Id = 43, Name = "Action Figure", Price = 19.99m, CategoryId = 5, Description = "Detailed collectible for kids and adults.", StockQuantity = 30 },
        new Product { Id = 44, Name = "Stuffed Animal", Price = 14.99m, CategoryId = 5, Description = "Soft and cuddly companion for children.", StockQuantity = 80 },
        new Product { Id = 45, Name = "Puzzle Set", Price = 12.99m, CategoryId = 5, Description = "Challenging puzzles for brain exercise.", StockQuantity = 60 },
        new Product { Id = 46, Name = "Remote Control Car", Price = 39.99m, CategoryId = 5, Description = "Fast and fun RC vehicle for kids.", StockQuantity = 20 },
        new Product { Id = 47, Name = "Dollhouse", Price = 49.99m, CategoryId = 5, Description = "Detailed dollhouse for imaginative play.", StockQuantity = 15 },
        new Product { Id = 48, Name = "Outdoor Swing", Price = 59.99m, CategoryId = 5, Description = "Safe and durable swing for outdoor fun.", StockQuantity = 25 },
        new Product { Id = 49, Name = "Card Game", Price = 9.99m, CategoryId = 5, Description = "Portable card game for travel or parties.", StockQuantity = 100 },
        new Product { Id = 50, Name = "Kids' Art Kit", Price = 19.99m, CategoryId = 5, Description = "Includes paint, brushes, and crayons.", StockQuantity = 50 },

       

        // Health & Beauty
        new Product { Id = 51, Name = "Moisturizing Lotion", Price = 14.99m, CategoryId = 6, Description = "Hydrates and nourishes dry skin.", StockQuantity = 40 },
        new Product { Id = 52, Name = "Vitamin C Serum", Price = 24.99m, CategoryId = 6, Description = "Brightens skin and reduces dark spots.", StockQuantity = 35 },
        new Product { Id = 53, Name = "Shampoo & Conditioner Set", Price = 19.99m, CategoryId = 6, Description = "For soft and healthy hair.", StockQuantity = 50 },
        new Product { Id = 54, Name = "Electric Toothbrush", Price = 29.99m, CategoryId = 6, Description = "Provides a deep and thorough clean.", StockQuantity = 20 },
        new Product { Id = 55, Name = "Makeup Kit", Price = 49.99m, CategoryId = 6, Description = "Includes essentials for daily makeup.", StockQuantity = 25 },
        new Product { Id = 56, Name = "Essential Oil Diffuser", Price = 34.99m, CategoryId = 6, Description = "Relax with soothing aromatherapy.", StockQuantity = 15 },
        new Product { Id = 57, Name = "Fitness Tracker", Price = 59.99m, CategoryId = 6, Description = "Tracks activity, heart rate, and sleep.", StockQuantity = 30 },
        new Product { Id = 58, Name = "Face Mask Pack", Price = 12.99m, CategoryId = 6, Description = "Includes hydrating and purifying masks.", StockQuantity = 70 },


        // Sports & Outdoors
        new Product { Id = 59, Name = "Yoga Mat", Price = 19.99m, CategoryId = 7, Description = "Non-slip mat for yoga and exercise.", StockQuantity = 40 },
        new Product { Id = 60, Name = "Camping Tent", Price = 89.99m, CategoryId = 7, Description = "Lightweight tent for 2 people.", StockQuantity = 25 },
        new Product { Id = 61, Name = "Hiking Backpack", Price = 49.99m, CategoryId = 7, Description = "Durable backpack with multiple compartments.", StockQuantity = 30 },
        new Product { Id = 62, Name = "Fishing Rod", Price = 39.99m, CategoryId = 7, Description = "Telescopic fishing rod for outdoor adventures.", StockQuantity = 20 },
        new Product { Id = 63, Name = "Basketball", Price = 29.99m, CategoryId = 7, Description = "Official size and weight basketball.", StockQuantity = 50 },
        new Product { Id = 64, Name = "Sleeping Bag", Price = 34.99m, CategoryId = 7, Description = "Warm and lightweight sleeping bag.", StockQuantity = 35 },
        new Product { Id = 65, Name = "Water Bottle", Price = 14.99m, CategoryId = 7, Description = "Insulated bottle to keep drinks hot or cold.", StockQuantity = 80 },
        new Product { Id = 66, Name = "Dumbbell Set", Price = 59.99m, CategoryId = 7, Description = "Adjustable weights for strength training.", StockQuantity = 15 },
        new Product { Id = 67, Name = "Bicycle Helmet", Price = 39.99m, CategoryId = 7, Description = "Protective helmet for cycling.", StockQuantity = 45 },
        new Product { Id = 68, Name = "Trekking Poles", Price = 24.99m, CategoryId = 7, Description = "Lightweight poles for hiking.", StockQuantity = 50 },


        // Automotive
        new Product { Id = 69, Name = "Car Wash Kit", Price = 29.99m, CategoryId = 8, Description = "Includes sponge, soap, and microfiber towel.", StockQuantity = 30 },
        new Product { Id = 70, Name = "Car Vacuum Cleaner", Price = 49.99m, CategoryId = 8, Description = "Portable vacuum for interior cleaning.", StockQuantity = 20 },
        new Product { Id = 71, Name = "LED Headlights", Price = 79.99m, CategoryId = 8, Description = "Energy-efficient and bright LED headlights.", StockQuantity = 15 },
        new Product { Id = 72, Name = "Tire Inflator", Price = 39.99m, CategoryId = 8, Description = "Compact and easy-to-use air compressor.", StockQuantity = 25 },
        new Product { Id = 73, Name = "Dashboard Camera", Price = 99.99m, CategoryId = 8, Description = "Records high-definition video for safety.", StockQuantity = 10 },
        new Product { Id = 74, Name = "Car Seat Cover Set", Price = 59.99m, CategoryId = 8, Description = "Stylish and durable covers for car seats.", StockQuantity = 18 },


        // Pet Supplies
        new Product { Id = 75, Name = "Dog Chew Toy", Price = 9.99m, CategoryId = 9, Description = "Durable chew toy for dogs of all sizes.", StockQuantity = 50 },
        new Product { Id = 76, Name = "Cat Scratching Post", Price = 24.99m, CategoryId = 9, Description = "Sturdy post to keep your cat entertained.", StockQuantity = 30 },
        new Product { Id = 77, Name = "Pet Food Bowl", Price = 7.99m, CategoryId = 9, Description = "Non-slip bowl for feeding your pets.", StockQuantity = 80 },
        new Product { Id = 78, Name = "Aquarium Starter Kit", Price = 49.99m, CategoryId = 9, Description = "Complete kit for setting up a home aquarium.", StockQuantity = 15 },
        new Product { Id = 79, Name = "Dog Leash", Price = 14.99m, CategoryId = 9, Description = "Strong and adjustable leash for dogs.", StockQuantity = 60 },


        // Office Products
        new Product { Id = 80, Name = "Ergonomic Office Chair", Price = 149.99m, CategoryId = 10, Description = "Comfortable and adjustable chair for office use.", StockQuantity = 20 },
        new Product { Id = 81, Name = "Wireless Keyboard and Mouse", Price = 39.99m, CategoryId = 10, Description = "Compact and responsive keyboard-mouse combo.", StockQuantity = 35 },
        new Product { Id = 82, Name = "Desk Organizer", Price = 19.99m, CategoryId = 10, Description = "Keeps your desk neat and clutter-free.", StockQuantity = 50 },
        new Product { Id = 83, Name = "Notebook Set", Price = 12.99m, CategoryId = 10, Description = "Set of 3 notebooks for work or study.", StockQuantity = 60 },
        new Product { Id = 84, Name = "Office Desk Lamp", Price = 29.99m, CategoryId = 10, Description = "Adjustable lamp with LED lighting.", StockQuantity = 40 },

       
    });



     // Seeding Orders
    modelBuilder.Entity<Order>().HasData(new Order[]
    {
        new Order { Id = 1, OrderDate = DateTime.Now.AddDays(-10), UserProfileId = 2, isCanceled = false },
        new Order { Id = 2, OrderDate = DateTime.Now.AddDays(-7), UserProfileId = 3 , isCanceled = false },
        new Order { Id = 3, OrderDate = DateTime.Now.AddDays(-5), UserProfileId = 2 , isCanceled = false},
        new Order { Id = 4, OrderDate = DateTime.Now.AddDays(-3), UserProfileId = 4 , isCanceled = true },
        new Order { Id = 5, OrderDate = DateTime.Now.AddDays(-1), UserProfileId = 3 , isCanceled = false },
    });


     // Seeding OrderProducts
    modelBuilder.Entity<OrderProduct>().HasData(new OrderProduct[]
    {
        new OrderProduct { Id = 1, OrderId = 1, ProductId = 10, Quantity = 1 },
        new OrderProduct { Id = 2, OrderId = 1, ProductId = 20, Quantity = 2 },
        
        new OrderProduct { Id = 3, OrderId = 2, ProductId = 30, Quantity = 1 },
        new OrderProduct { Id = 4, OrderId = 2, ProductId = 40, Quantity = 1 },

        new OrderProduct { Id = 5, OrderId = 3, ProductId = 50, Quantity = 2 },
        new OrderProduct { Id = 6, OrderId = 3, ProductId = 60, Quantity = 1 },

        new OrderProduct { Id = 7, OrderId = 4, ProductId = 70, Quantity = 3 },
        new OrderProduct { Id = 8, OrderId = 4, ProductId = 80, Quantity = 1 },

        new OrderProduct { Id = 9, OrderId = 5, ProductId = 75, Quantity = 1 },
        new OrderProduct { Id = 10, OrderId = 5, ProductId = 81, Quantity = 2 }
    });





   
      
 
    
    }
}
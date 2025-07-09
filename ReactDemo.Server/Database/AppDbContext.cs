using Microsoft.EntityFrameworkCore;
using ReactDemo.Server.Models;

namespace ReactDemo.Server.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<RoomType>().HasData(
                new RoomType{ 
                    Id = 1, 
                    Name = "Classic Courtyard", 
                    BasePrice = 750.00m, Size = "25 sq m", 
                    SleepersCapacity = 2, 
                    ImageId = 1,
                    Description = "1 Queen bed or 2 Twin beds – 25sqm / 269sqft. Balcony or window. Coastal view", 
                    BedsDescription = "1 Queen bed", },
                new RoomType{ 
                    Id = 2, 
                    Name = "Superior", 
                    BasePrice = 850.00m, 
                    Size = "32 to 36 sq m", 
                    SleepersCapacity = 2, 
                    ImageId = 2,
                    Description = "1 Queen bed or 2 Twin beds – From 32 to 36sqm / From 345 to 388sqft. Window – Juliet balcony. Lateral Sea view/coastal view", 
                    BedsDescription = "1 Queen bed", },
                new RoomType{ 
                    Id = 3, 
                    Name = "Deluxe with sea view balcony", 
                    BasePrice = 1075.00m, 
                    Size = "35 to 40 sq m", 
                    SleepersCapacity = 2, 
                    ImageId = 3,
                    Description = "1 Large Queen bed or 2 Twin beds – From 35 to 40sqm / From 377 to 431sqft. Sitting area – Desk. Balcony. Sea view", 
                    BedsDescription = "1 Queen bed", },
                new RoomType{ 
                    Id = 4, 
                    Name = "Junior Suite", 
                    BasePrice = 1400.00m, 
                    Size = "45 to 55 sq m", 
                    SleepersCapacity = 2, 
                    ImageId = 4,
                    Description = "1 King bed or 2 Twin beds – From 45 to 55sqm / From 485 to 582sqft. Sitting area – Desk. Big window – Sea view", 
                    BedsDescription = "1 King bed", },
                new RoomType{ 
                    Id = 5, 
                    Name = "Corner Suite", 
                    BasePrice = 2100.00m, 
                    Size = "65 to 75 sq m", 
                    SleepersCapacity = 3, 
                    ImageId = 5,
                    Description = "1 King bed or 2 Twin beds – From 65 to 75sqm / From 700 to 807sqft. Separate sitting area – Desk. Big window – Sea view", 
                    BedsDescription = "1 King bed", },
                new RoomType{ 
                    Id = 6, 
                    Name = "Suite Deluxe with Terrace", 
                    BasePrice = 2275.00m, 
                    Size = "107 to 120 sq m", 
                    SleepersCapacity = 3, 
                    ImageId = 6,
                    Description = "1 King bed or 2 Twin beds – From 107 to 120sqm / From 1151 to 1291sqft. Separate living area – Desk. Private terrace – Sea view", 
                    BedsDescription = "1 King bed", },
                new RoomType{ 
                    Id = 7, 
                    Name = "Junior Suite sea view with Pool", 
                    BasePrice = 2325.00m, 
                    Size = "90 sq m", 
                    SleepersCapacity = 2, 
                    ImageId = 7,
                    Description = "1 King bed – 90sqm / 968sqft. Separate sitting area – Private terrace – Sea view. Private heated infinity plunge pool", 
                    BedsDescription = "1 King bed", },
                new RoomType{ 
                    Id = 8, 
                    Name = "Suite Deluxe with Pool", 
                    BasePrice = 2470.00m, 
                    Size = "85 to 105 sq m", 
                    SleepersCapacity = 3, 
                    ImageId = 8,
                    Description = "1 King or 2 Twin beds – From 85 to 105qm. Separate living area – Desk. Private terrace – Sea view. Private heated infinity plunge pool", 
                    BedsDescription = "1 King bed", },
                new RoomType{ 
                    Id = 9, 
                    Name = "Premium Suite Pool", 
                    BasePrice = 2850.00m, 
                    Size = "105 sq m", 
                    SleepersCapacity = 3, 
                    ImageId = 9,
                    Description = "1 King bed or 2 Twin beds – 105sqm / 1131sqft. Sitting area – Desk. Private terrace or garden – Sea view. Private heated infinity plunge pool", 
                    BedsDescription = "1 Queen bed", }
                );
            builder.Entity<Room>().HasData(
                new Room { Id = 1, RoomTypeId = 1, RoomNumber = 101},
                new Room { Id = 2, RoomTypeId = 1, RoomNumber = 102},
                new Room { Id = 3, RoomTypeId = 1, RoomNumber = 103},
                new Room { Id = 4, RoomTypeId = 2, RoomNumber = 201},
                new Room { Id = 5, RoomTypeId = 2, RoomNumber = 202},
                new Room { Id = 6, RoomTypeId = 2, RoomNumber = 203},
                new Room { Id = 7, RoomTypeId = 3, RoomNumber = 301},
                new Room { Id = 8, RoomTypeId = 3, RoomNumber = 302},
                new Room { Id = 9, RoomTypeId = 3, RoomNumber = 303},
                new Room { Id = 10, RoomTypeId = 4, RoomNumber = 401},
                new Room { Id = 11, RoomTypeId = 4, RoomNumber = 402},
                new Room { Id = 12, RoomTypeId = 4, RoomNumber = 403},
                new Room { Id = 13, RoomTypeId = 5, RoomNumber = 501},
                new Room { Id = 14, RoomTypeId = 5, RoomNumber = 502},
                new Room { Id = 15, RoomTypeId = 5, RoomNumber = 503},
                new Room { Id = 16, RoomTypeId = 6, RoomNumber = 601},
                new Room { Id = 17, RoomTypeId = 6, RoomNumber = 602},
                new Room { Id = 18, RoomTypeId = 6, RoomNumber = 603},
                new Room { Id = 19, RoomTypeId = 7, RoomNumber = 701},
                new Room { Id = 20, RoomTypeId = 7, RoomNumber = 702},
                new Room { Id = 21, RoomTypeId = 7, RoomNumber = 703},
                new Room { Id = 22, RoomTypeId = 8, RoomNumber = 801},
                new Room { Id = 23, RoomTypeId = 8, RoomNumber = 802},
                new Room { Id = 24, RoomTypeId = 8, RoomNumber = 803},
                new Room { Id = 25, RoomTypeId = 9, RoomNumber = 901},
                new Room { Id = 26, RoomTypeId = 9, RoomNumber = 902},
                new Room { Id = 27, RoomTypeId = 9, RoomNumber = 903}
                );
        }


        public DbSet<RoomType> RoomType { get; set; }
        public DbSet<Room> Room { get; set; }

    }
}

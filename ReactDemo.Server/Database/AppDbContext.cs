using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ReactDemo.Server.Models;

namespace ReactDemo.Server.Database
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
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
            builder.Entity<Guest>().HasData(
                new Guest { Id = 1, FirstName = "Jess", LastName = "Day", Email = "jess@test.com"},
                new Guest { Id = 2, FirstName = "Nick", LastName = "Miller", Email = "nick@test.com"},
                new Guest { Id = 3, FirstName = "Schmidt", Email = "schmidt@test.com"},
                new Guest { Id = 4, FirstName = "Cece", LastName = "Parekh", Email = "cece@test.com"},
                new Guest { Id = 5, FirstName = "Winston", LastName = "Bishop", Email = "winston@test.com"}
                );
            builder.Entity<Booking>().HasData(
                new Booking { Id = 1, GuestId = 1},
                new Booking { Id = 2, GuestId = 2},
                new Booking { Id = 3, GuestId = 3},
                new Booking { Id = 4, GuestId = 1},
                new Booking { Id = 5, GuestId = 4},
                new Booking { Id = 6, GuestId = 4}
                );
            builder.Entity<BookingRoom>().HasData(
                new BookingRoom { Id = 1, BookingId =  1, RoomId = 1, CheckInDate = new DateOnly(2025, 7, 20), CheckOutDate = new DateOnly(2025, 7, 25), NumberAdults = 2 },
                new BookingRoom { Id = 2, BookingId =  2, RoomId = 9, CheckInDate = new DateOnly(2025, 7, 28), CheckOutDate = new DateOnly(2025, 7, 31), NumberAdults = 2, NumberChildren = 1 },
                new BookingRoom { Id = 3, BookingId =  2, RoomId = 11, CheckInDate = new DateOnly(2025, 7, 28), CheckOutDate = new DateOnly(2025, 7, 31), NumberAdults = 1, NumberChildren = 1 },
                new BookingRoom { Id = 4, BookingId =  4, RoomId = 2, CheckInDate = new DateOnly(2025, 9, 1), CheckOutDate = new DateOnly(2025, 9, 10), NumberAdults = 2 },
                new BookingRoom { Id = 5, BookingId =  3, RoomId = 3, CheckInDate = new DateOnly(2025, 8, 1), CheckOutDate = new DateOnly(2025, 8, 31), NumberAdults = 1, NumberChildren = 1 },
                new BookingRoom { Id = 6, BookingId =  5, RoomId = 8, CheckInDate = new DateOnly(2025, 9, 15), CheckOutDate = new DateOnly(2025, 9, 16), NumberAdults = 1, NumberChildren = 1 },
                new BookingRoom { Id = 7, BookingId =  6, RoomId = 13, CheckInDate = new DateOnly(2025, 9, 15), CheckOutDate = new DateOnly(2025, 9, 16), NumberAdults = 1, NumberChildren = 1 },
                new BookingRoom { Id = 8, BookingId =  6, RoomId = 16, CheckInDate = new DateOnly(2025, 9, 16), CheckOutDate = new DateOnly(2025, 9, 20), NumberAdults = 1, NumberChildren = 1 }
                );
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "fdf41afb-4841-43b9-8642-b32179934a49", Name = "User", NormalizedName = "USER" },
                new IdentityRole { Id = "0428efdd-bbf9-44fa-bba3-0a1873af0e56", Name = "Front Desk", NormalizedName = "FRONTDESK" },
                new IdentityRole { Id = "b117d060-6194-4e16-8c49-f60bbf42ec3e", Name = "Administrator", NormalizedName = "ADMINISTRATOR" }
                );
            var hasher = new PasswordHasher<AppUser>();
            builder.Entity<AppUser>().HasData(new AppUser
            {
                Id = "80c4e17f-70dd-4aaa-bbc0-ac3fd88682bf",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                UserName = "admin@admin.com",
                PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                EmailConfirmed = true,
                FirstName = "Borgo",
                LastName = "Admin",
            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "b117d060-6194-4e16-8c49-f60bbf42ec3e",
                UserId = "80c4e17f-70dd-4aaa-bbc0-ac3fd88682bf"
            });
        }


        public DbSet<RoomType> RoomType { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Guest> Guest { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<BookingRoom> BookingRoom { get; set; }

    }
}

using GoFive_CRM.Core.Entites;
using Microsoft.EntityFrameworkCore;
using static Azure.Core.HttpHeader;

namespace GoFive_CRM.Infrastructure.Data
{

    public class GoFive_CRMDbContext :DbContext
    {
        private readonly DbContextOptions<GoFive_CRMDbContext> _options;
        public DbContextOptions<GoFive_CRMDbContext> Options
        {
            get
            {
                return _options;
            }
        }
        public GoFive_CRMDbContext(DbContextOptions<GoFive_CRMDbContext> options)
            : base(options)
        {
            _options = options;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Id, Name, price , image , descritpion
            modelBuilder.Entity<Customers>().HasData(new Customers
            {
                ID = 1,
                Name = "Alex",
                Email = "alex@gmail.com",
                Phone = "9598888888",
                Address = "Yangon, Myanmar",
                Notes = "Alex is a Developer!"
            });
            modelBuilder.Entity<Customers>().HasData(new Customers
            {
                ID = 2,
                Name = "Jhon",
                Email = "Jhon@gmail.com",
                Phone = "9597777777",
                Address = "Yangon, Myanmar",
                Notes = "Alex is a Developer!"
            });
            modelBuilder.Entity<Customers>().HasData(new Customers
            {
                ID = 3,
                Name = "Eddie",
                Email = "Eddie@gmail.com",
                Phone = "9596666666",
                Address = "Yangon, Myanmar",
                Notes = "Alex is a Product Develiry Manager!"
            });
            modelBuilder.Entity<Customers>().HasData(new Customers
            {
                ID = 4,
                Name = "Sampar",
                Email = "Sampar@gmail.com",
                Phone = "9595555555",
                Address = "Yangon, Myanmar",
                Notes = "Sampar is a QA!"
            });
            modelBuilder.Entity<Customers>().HasData(new Customers
            {
                ID = 5,
                Name = "Aaron",
                Email = "Aaron@gmail.com",
                Phone = "9594444444",
                Address = "Yangon, Myanmar",
                Notes = "Sampar is a Operation Manager!"
            });
            modelBuilder.Entity<Customers>().HasData(new Customers
            {
                ID = 6,
                Name = "Doraalex",
                Email = "Doraalex@gmail.com",
                Phone = "9593333333",
                Address = "Yangon, Myanmar",
                Notes = "Doraalex is a Project Manager!"
            });
            modelBuilder.Entity<Customers>().HasData(new Customers
            {
                ID = 7,
                Name = "Kelvin",
                Email = "Kelvin@gmail.com",
                Phone = "9592222222",
                Address = "Yangon, Myanmar",
                Notes = "Kelvin is a Support Lead!"
            });
            modelBuilder.Entity<Customers>().HasData(new Customers
            {
                ID = 8,
                Name = "Andrew",
                Email = "Andrew@gmail.com",
                Phone = "9591111111",
                Address = "Yangon, Myanmar",
                Notes = "Andrew is a API Developer!"
            });
            modelBuilder.Entity<Customers>().HasData(new Customers
            {
                ID = 9,
                Name = "Mark",
                Email = "Mark@gmail.com",
                Phone = "9599999999",
                Address = "Yangon, Myanmar",
                Notes = "Mark is a API Developer!"
            });
            modelBuilder.Entity<Customers>().HasData(new Customers
            {
                ID = 10,
                Name = "Kusshi",
                Email = "Kusshi@gmail.com",
                Phone = "9598888888",
                Address = "Yangon, Myanmar",
                Notes = "Kusshi is a support!"
            });
            modelBuilder.Entity<Customers>().HasData(new Customers
            {
                ID = 11,
                Name = "Penny",
                Email = "Penny@gmail.com",
                Phone = "9597777777",
                Address = "Yangon, Myanmar",
                Notes = "Penny is a support!"
            });
            modelBuilder.Entity<Customers>().HasData(new Customers
            {
                ID = 12,
                Name = "Maria",
                Email = "Maria@gmail.com",
                Phone = "9597777777",
                Address = "Yangon, Myanmar",
                Notes = "Maria is a support!"
            });
            modelBuilder.Entity<Customers>().HasData(new Customers
            {
                ID = 13,
                Name = "Izi",
                Email = "Izi@gmail.com",
                Phone = "9597777777",
                Address = "Yangon, Myanmar",
                Notes = "Maria is a QA!"
            });
            modelBuilder.Entity<Customers>().HasData(new Customers
            {
                ID = 14,
                Name = "Chriatian",
                Email = "Chriatian@gmail.com",
                Phone = "9597777777",
                Address = "Yangon, Myanmar",
                Notes = "Maria is a QA!"
            });
            modelBuilder.Entity<Customers>().HasData(new Customers
            {
                ID = 15,
                Name = "Hwaimin",
                Email = "Hwaimin@gmail.com",
                Phone = "9597777777",
                Address = "Yangon, Myanmar",
                Notes = "Hwaimin is a QA!"
            }); 
        }
        public DbSet<Customers> customers { get; set; }
    }
}

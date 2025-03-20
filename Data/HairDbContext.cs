using HairSalon.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace HairSalon.Data
{
    public class HairDbContext : IdentityDbContext
    {
        public HairDbContext(DbContextOptions<HairDbContext> options) : base(options)
        {

        }
        public DbSet<HairSalonData> HairSalons { get; set; }

    }
}

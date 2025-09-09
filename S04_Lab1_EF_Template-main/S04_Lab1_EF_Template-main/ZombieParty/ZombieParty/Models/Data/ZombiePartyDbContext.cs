using Microsoft.EntityFrameworkCore;

namespace ZombieParty.Models.Data
    
{
    public class ZombiePartyDbContext:DbContext
    {
        public DbSet<Zombie> Zombie { get; set; }
        public DbSet<ZombieType> zombieType { get; set; }
        public DbSet<HuntingLog> Hunginglog { get; set; }

        public ZombiePartyDbContext(DbContextOptions<ZombiePartyDbContext> options) : base(options)
        {

        }
      

    }
}

using Microsoft.EntityFrameworkCore;
using SystemWspomagania.API.Models;

namespace SystemWspomagania.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
        public DbSet<Soldier> Soldiers { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<IssueWeapon> IssueWeapons { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
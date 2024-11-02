using AspnetCoreMvcFull.Models;
using events.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace events.data
{
    public class WeppAppDbContext: DbContext
    {
        public WeppAppDbContext(DbContextOptions<WeppAppDbContext> options) : base(options) // add type
        {
        }
        public DbSet<Eventtype> Event_type { get; set; }
        public DbSet<Customers> Customers { get; set; }

    public DbSet<Hall> Halls { get; set; }
    public DbSet<Events> TblEvents { get; set; }

    public DbSet<H> Hll { get; set; }




  }
}

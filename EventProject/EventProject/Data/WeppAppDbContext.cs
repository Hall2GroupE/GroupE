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
        public DbSet<Halls> Hallss { get; set; }



    }
}

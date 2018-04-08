using System;
using Microsoft.EntityFrameworkCore;
using lost_found_api.Models;

namespace lost_found_api.Data{

    public class lostfoundcontext : DbContext{

        public lostfoundcontext(DbContextOptions<lostfoundcontext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder) => base.OnModelCreating(builder);

        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
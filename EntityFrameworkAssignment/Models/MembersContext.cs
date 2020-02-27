using System;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkAssignment.Models
{
    public class MembersContext : DbContext
    {
        public MembersContext(DbContextOptions<MembersContext> options) : base(options) { }

        public DbSet<Member> Members { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=gigaming;Database=membersdb");
    }
}

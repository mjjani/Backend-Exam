using Microsoft.EntityFrameworkCore;
using SupportTicketManagement.Model;
using System;

namespace SupportTicketManagement.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<TicketComments> TicketComments { get; set; }
        public DbSet<TicketStatusLogs> TicketStatusLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Tickets>()
            //    .HasOne(t => t.AssignToUser)
            //    .WithMany()
            //    .HasForeignKey(t => t.AssignToUser)
            //    .OnDelete(DeleteBehavior.Restrict); // 🔴 IMPORTANT

            //modelBuilder.Entity<Teams>()
            //    .HasOne(t => t.OwnerUser)
            //    .WithMany()
            //    .HasForeignKey(t => t.OwnerUserID)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

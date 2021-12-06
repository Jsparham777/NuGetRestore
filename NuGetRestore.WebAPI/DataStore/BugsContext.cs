using Microsoft.EntityFrameworkCore;
using NuGetRestore.WebAPI.Models;
using System;

namespace NuGetRestore.WebAPI.DataStore
{
    public class BugsContext : DbContext
    {
        public BugsContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        /// <summary>
        /// Creates the schema in the database.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Create the table relationships
            modelBuilder.Entity<Project>()
                .HasMany(p => p.Tickets)
                .WithOne(p => p.Project)
                .HasForeignKey(t => t.ProjectId);

            // Seed the database
            modelBuilder.Entity<Project>().HasData(
                    new Project { ProjectId = 1, Name = "Project 1" },
                    new Project { ProjectId = 2, Name = "Project 2" }
                );

            modelBuilder.Entity<Ticket>().HasData(
                    new Ticket { TicketId = 1, Title = "Bug #1", ProjectId = 1, Owner = "James Sparham", ReportDate = new DateTime(2021, 1, 1), DueDate = new DateTime(2021, 2, 1) },
                    new Ticket { TicketId = 2, Title = "Bug #2", ProjectId = 1, Owner = "James Sparham", ReportDate = new DateTime(2021, 1, 1), DueDate = new DateTime(2021, 2, 1) },
                    new Ticket { TicketId = 3, Title = "Bug #3", ProjectId = 2, Owner = "John Doe" },
                    new Ticket { TicketId = 4, Title = "Bug #4", Description = "Another bug", ProjectId = 2, Owner = "Roger Taylor", ReportDate = new DateTime(2021, 1, 1), DueDate = new DateTime(2021, 2, 1) }
                );
        }
    }
}

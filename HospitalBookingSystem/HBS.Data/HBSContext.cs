using HBS.Dash.Models;
using HBS.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HBS.Data
{
	public class HBSContext : IdentityDbContext<ApplicationUser>
	{
		public HBSContext(DbContextOptions options) : base(options)
		{
		}
        public DbSet<Booking> Booking { get; set; }
		public DbSet<Clinic> Clinic { get; set; }
		public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DoctorCategory> DoctorCategory { get; set; }
        public DbSet<DoctorCategory> DoctorSchedule { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DoctorCategory>()
                .HasKey(t => new { t.DoctorId, t.CategoryId });

            modelBuilder.Entity<DoctorCategory>()
                .HasOne(pt => pt.Doctor)
                .WithMany(p => p.Categories)
                .HasForeignKey(pt => pt.DoctorId);

            modelBuilder.Entity<DoctorCategory>()
                .HasOne(pt => pt.Category)
                .WithMany(t => t.Doctors)
                .HasForeignKey(pt => pt.CategoryId);
        }
    }
}

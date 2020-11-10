using Microsoft.EntityFrameworkCore;
using SoftrayNewsAPI.DL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace SoftrayNewsAPI.DL.DBContext
{
    public partial class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).IsUnicode(false);
                entity.Property(e => e.LastName).IsUnicode(false);
                entity.Property(e => e.Username).IsUnicode(false);
                entity.Property(e => e.Role).IsUnicode(false);
                entity.Property(e => e.Token).IsUnicode(false);
                entity.Property(e => e.Password).IsUnicode(false);
                entity.Property(e => e.Status);
                entity.Property(e => e.DateInserted).HasColumnType("datetime");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsUnicode(false);
                entity.Property(e => e.Text).IsUnicode(false);
                entity.Property(e => e.Status);
                entity.Property(e => e.DateInserted).HasColumnType("datetime");
            });
        }
    }
}

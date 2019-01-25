using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Scooch.Models
{
    public partial class ScoochDBContext : DbContext
    {
        public ScoochDBContext()
        {
        }

        public ScoochDBContext(DbContextOptions<ScoochDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EventEntity> EventEntity { get; set; }
        public virtual DbSet<UserEntity> UserEntity { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventEntity>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.ToTable("eventEntity");

                entity.Property(e => e.EventId).HasColumnName("eventID");

                entity.Property(e => e.EventLocation)
                    .HasColumnName("eventLocation")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EventName)
                    .HasColumnName("eventName")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EventTime)
                    .HasColumnName("eventTime")
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("userEntity");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.EventTime)
                    .HasColumnName("eventTime")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.UserEmail)
                    .HasColumnName("userEmail")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FastX_CaseStudy.Models
{
    public partial class BusBookingContext : DbContext
    {
        public BusBookingContext()
        {
        }

        public BusBookingContext(DbContextOptions<BusBookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<BusOperator> BusOperators { get; set; } = null!;
        public virtual DbSet<BusRoute> BusRoutes { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<bus> Buses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-JR3HKNSE\\SQLEXPRESS;Database=BusBooking;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.BookingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.BookingStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Booked')");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.RouteId)
                    .HasConstraintName("FK__Bookings__RouteI__5441852A");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Bookings__UserId__534D60F1");
            });

            modelBuilder.Entity<BusOperator>(entity =>
            {
                entity.HasKey(e => e.OperatorId)
                    .HasName("PK__BusOpera__7BB12FAE5C818A6C");

                entity.ToTable("BusOperator");

                entity.Property(e => e.BusId).HasColumnName("BusID");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OperatorName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OperatorPhone)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.HasOne(d => d.Bus)
                    .WithMany(p => p.BusOperators)
                    .HasForeignKey(d => d.BusId)
                    .HasConstraintName("FK__BusOperat__BusID__5812160E");
            });

            modelBuilder.Entity<BusRoute>(entity =>
            {
                entity.HasKey(e => e.RouteId)
                    .HasName("PK__BusRoute__80979B4D1B654CE5");

                entity.Property(e => e.ArrivalTime).HasColumnType("datetime");

                entity.Property(e => e.DepartureTime).HasColumnType("datetime");

                entity.Property(e => e.Destination)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SourcePoint)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Bus)
                    .WithMany(p => p.BusRoutes)
                    .HasForeignKey(d => d.BusId)
                    .HasConstraintName("FK__BusRoutes__BusId__4E88ABD4");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PaymentMode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__Payments__Bookin__5BE2A6F2");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<bus>(entity =>
            {
                entity.Property(e => e.Amenities)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BusName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Bustype)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

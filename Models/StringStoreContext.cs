using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ViolinShop.Models
{
    public partial class StringStoreContext : DbContext
    {
        public virtual DbSet<Calendars> Calendars { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<CartItems> CartItems { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<InstructorInstruments> InstrtorInstruments { get; set; }
        public virtual DbSet<Instructors> Instructors { get; set; }
        public virtual DbSet<Instruments> Instruments { get; set; }
        public virtual DbSet<InstrumentTypes> InstrumentTypes { get; set; }
        public virtual DbSet<Lessons> Lessons { get; set; }
        public virtual DbSet<LineItems> LineItems { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<RentalHistory> RentalHistory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Data Source=RIXS-06;Initial Catalog=StringStore;Integrated Security=True;Connect Timeout=15;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calendars>(entity =>
            {
                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.InstructorID).HasColumnName("InstructorID");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.CartId).HasColumnName("CartID");
            });

            modelBuilder.Entity<CartItems>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CartId).HasColumnType("varchar(50)");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.CartItems)
                    .HasForeignKey<CartItems>(d => d.Id)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_CartItems_CartItems");
            });

            modelBuilder.Entity<Contacts>(entity =>
            {
                entity.Property(e => e.ID).HasColumnName("ID");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.ToTable("customers");

                entity.Property(e => e.ID).HasColumnName("ID");

                //entity.Property(e => e.Birthdate)
                //    .HasColumnName("birthdate")
                //    .HasColumnType("date");
            });

            modelBuilder.Entity<InstructorInstruments>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.InstructorId).HasColumnName("InstructorID");

                entity.Property(e => e.InstrumentId).HasColumnName("InstrumentID");
            });

            modelBuilder.Entity<Instructors>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Instruments>(entity =>
            {
                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.ProductID)
                    .HasColumnName("ProductID")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.TypeID).HasColumnName("TypeID");
            });

            modelBuilder.Entity<InstrumentTypes>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Lessons>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CalendarId).HasColumnName("CalendarID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.InstructorId).HasColumnName("InstructorID");

                entity.Property(e => e.InsturmentId).HasColumnName("InsturmentID");

                entity.Property(e => e.MusicId).HasColumnName("MusicID");
            });

            modelBuilder.Entity<LineItems>(entity =>
            {
                entity.HasIndex(e => e.ProductId)
                    .HasName("IX_LineItem_ProductID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.LineItem)
                    .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<RentalHistory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.InsturmentId).HasColumnName("InsturmentID");
            });
        }
    }
}
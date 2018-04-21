using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LibraryData.LIBDBModels;

namespace LibraryData
{
    public class LibraryMSContext : DbContext
    {
        public LibraryMSContext(DbContextOptions options) : base(options) { }
        //
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerType> CustomerType { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<MediaType> MediaType { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserType> UserType { get; set; }

        // Unable to generate entity type for table 'LIBDB.MANAGES'. Please see the warning messages.
        // Unable to generate entity type for table 'LIBDB.BORROW'. Please see the warning messages.
        // Unable to generate entity type for table 'LIBDB.IS_WAITLISTED_BY'. Please see the warning messages.
        // Unable to generate entity type for table 'LIBDB.LOCATED'. Please see the warning messages.
        // Unable to generate entity type for table 'LIBDB.FINE'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=den1.mssql4.gear.host;Initial Catalog=cosc3380;Persist Security Info=True;User ID=cosc3380;Password=vfegaf$");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            

           

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("CUSTOMER", "LIBDB");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.AddressCity)
                    .HasColumnName("Address_City")
                    .HasMaxLength(20);

                entity.Property(e => e.AddressState)
                    .HasColumnName("Address_State")
                    .HasMaxLength(2);

                entity.Property(e => e.AddressStreet)
                    .HasColumnName("Address_Street")
                    .HasMaxLength(25);

                entity.Property(e => e.AddressZipcode)
                    .HasColumnName("Address_Zipcode")
                    .HasMaxLength(5);

                entity.Property(e => e.BirthDate)
                    .HasColumnName("Birth_Date")
                    .HasColumnType("date");

                entity.Property(e => e.CustomerType).HasColumnName("Customer_Type");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("First_Name")
                    .HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("Last_Name")
                    .HasMaxLength(20);

                entity.Property(e => e.MembershipIssued)
                    .HasColumnName("Membership_Issued")
                    .HasColumnType("date");

                entity.Property(e => e.MiddleInitial)
                    .IsRequired()
                    .HasColumnName("Middle_Initial")
                    .HasMaxLength(1);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("Phone_Number")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Customer_to_Username");
            });

            modelBuilder.Entity<CustomerType>(entity =>
            {
                entity.ToTable("CUSTOMER_TYPE", "LIBDB");

                entity.Property(e => e.CustomerTypeId)
                    .HasColumnName("CUSTOMER_TYPE_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BookLimit).HasColumnName("BOOK_LIMIT");

                entity.Property(e => e.CustomerTypeName)
                    .IsRequired()
                    .HasColumnName("CUSTOMER_TYPE_NAME")
                    .HasColumnType("nchar(10)");
            });

          

           
           
           

            modelBuilder.Entity<Media>(entity =>
            {
                entity.ToTable("MEDIA", "LIBDB");

                entity.HasIndex(e => e.MediaId)
                    .HasName("IX_Media")
                    .IsUnique();

                entity.Property(e => e.MediaId).HasColumnName("Media_ID");

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasColumnName("author")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CallNum)
                    .IsRequired()
                    .HasColumnName("call_num")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.CopiesLeft).HasColumnName("copies_left");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("date");

                entity.Property(e => e.Genre)
                    .IsRequired()
                    .HasColumnName("genre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaxCopies).HasColumnName("max_copies");

                entity.Property(e => e.MediaType).HasColumnName("media_type");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.MediaTypeNavigation)
                    .WithMany(p => p.Media)
                    .HasForeignKey(d => d.MediaType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Type_of_Media");
            });

            modelBuilder.Entity<MediaType>(entity =>
            {
                entity.ToTable("MEDIA_TYPE", "LIBDB");

                entity.Property(e => e.MediaTypeId)
                    .HasColumnName("MEDIA_TYPE_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.MediaTypeName)
                    .IsRequired()
                    .HasColumnName("MEDIA_TYPE_NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            
            modelBuilder.Entity<Section>(entity =>
            {
                entity.ToTable("SECTION", "LIBDB");

                entity.Property(e => e.SectionId)
                    .HasColumnName("Section_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.EndCallNum)
                    .IsRequired()
                    .HasColumnName("End_call_num")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.LocationString)
                    .IsRequired()
                    .HasColumnName("locationString")
                    .HasMaxLength(50);

                entity.Property(e => e.SectionName)
                    .IsRequired()
                    .HasColumnName("sectionName")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.StartCallNum)
                    .IsRequired()
                    .HasColumnName("Start_call_num")
                    .HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserName);

                entity.ToTable("USERS", "LIBDB");

                entity.Property(e => e.UserName)
                    .HasMaxLength(256)
                    .ValueGeneratedNever();

                entity.Property(e => e.AccessFailedCount).HasDefaultValueSql("((0))");

                entity.Property(e => e.AddressCity)
                    .HasColumnName("Address_City")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AddressState)
                    .HasColumnName("Address_State")
                    .HasColumnType("nchar(2)");

                entity.Property(e => e.AddressStreet)
                    .HasColumnName("Address_Street")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddressZipcode)
                    .HasColumnName("Address_Zipcode")
                    .HasColumnType("nchar(20)");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .HasColumnName("First_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastLoginAttempt)
                    .HasColumnName("Last_Login_Attempt")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .HasColumnName("Last_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MembershipDate)
                    .HasColumnName("Membership_Date")
                    .HasColumnType("date");

                entity.Property(e => e.PasswordHash).IsRequired();

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("Phone_Number")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.UserType)
                    .HasColumnName("User_Type")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.ToTable("USER_TYPE", "LIBDB");

                entity.Property(e => e.UserTypeId).HasColumnName("User_Type_Id");

                entity.Property(e => e.UserTypeString)
                    .IsRequired()
                    .HasColumnName("User_Type_String")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LibraryData.LIBDBModels;

namespace LibraryData
{
    public class LibraryMSContext : DbContext
    {
        public LibraryMSContext(DbContextOptions options) : base(options) { }

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

                entity.Property(e => e.CustomerId)
                    .HasColumnName("Customer_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddressCity)
                    .IsRequired()
                    .HasColumnName("Address_City")
                    .HasColumnType("nchar(15)");

                entity.Property(e => e.AddressState)
                    .IsRequired()
                    .HasColumnName("Address_State")
                    .HasColumnType("nchar(2)");

                entity.Property(e => e.AddressStreet)
                    .IsRequired()
                    .HasColumnName("Address_Street")
                    .HasColumnType("nchar(25)");

                entity.Property(e => e.AddressZipcode)
                    .IsRequired()
                    .HasColumnName("Address_Zipcode")
                    .HasColumnType("nchar(5)");

                entity.Property(e => e.BirthDate)
                    .HasColumnName("Birth_Date")
                    .HasColumnType("date");

                entity.Property(e => e.CustomerType).HasColumnName("Customer_Type");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("First_Name")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("Last_Name")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.MembershipIssued)
                    .HasColumnName("Membership_Issued")
                    .HasColumnType("date");

                entity.Property(e => e.MiddleInitial)
                    .IsRequired()
                    .HasColumnName("Middle_Initial")
                    .HasColumnType("char(1)");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("Phone_Number")
                    .HasColumnType("numeric(10, 0)");

               entity.HasOne(d => d.CustomerNavigation)
                    .WithOne(p => p.Customer)
                    .HasForeignKey<Customer>(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Users_to_Customer");

                entity.HasOne(d => d.CustomerTypeNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.CustomerType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Type_of_Customer");
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

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("EMPLOYEE", "LIBDB");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("Employee_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddressCity)
                    .IsRequired()
                    .HasColumnName("Address_City")
                    .HasColumnType("nchar(20)");

                entity.Property(e => e.AddressState)
                    .IsRequired()
                    .HasColumnName("Address_State")
                    .HasColumnType("nchar(25)");

                entity.Property(e => e.AddressStreet)
                    .IsRequired()
                    .HasColumnName("Address_Street")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddressZipcode)
                    .IsRequired()
                    .HasColumnName("Address_Zipcode")
                    .HasColumnType("nchar(20)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("First_Name")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("Last_Name")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("Phone_Number")
                    .HasColumnType("numeric(10, 0)");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithOne(p => p.Employee)
                    .HasForeignKey<Employee>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Users_to_Employee");
            });

            modelBuilder.Entity<Media>(entity =>
            {
                entity.ToTable("MEDIA", "LIBDB");

                entity.HasIndex(e => e.MediaId)
                    .HasName("IX_Media")
                    .IsUnique();

                entity.Property(e => e.MediaId)
                    .HasColumnName("Media_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasColumnName("author")
                    .HasColumnType("nchar(10)");

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
                    .HasColumnType("nchar(15)");

                entity.Property(e => e.MaxCopies).HasColumnName("max_copies");

                entity.Property(e => e.MediaType).HasColumnName("media_type");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("nchar(50)");

                entity.HasOne(d => d.MediaNavigation)
                    .WithOne(p => p.Media)
                    .HasForeignKey<Media>(d => d.MediaId)
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
                entity.HasKey(e => e.UsernameId);

                entity.ToTable("USERS", "LIBDB");

                entity.Property(e => e.UsernameId)
                    .HasColumnName("Username_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FailedAttempts).HasColumnName("Failed_Attempts");

                entity.Property(e => e.HashedPassword)
                    .IsRequired()
                    .HasColumnName("Hashed_Password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastLoginAttempt)
                    .HasColumnName("Last_Login_Attempt")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserType).HasColumnName("User_Type");

                entity.Property(e => e.UsernameString)
                    .IsRequired()
                    .HasColumnName("Username_String")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserTypeNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserType)
                    .HasConstraintName("FK__USERS__User_Type__6442E2C9");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.ToTable("USER_TYPE", "LIBDB");

                entity.Property(e => e.UserTypeId)
                    .HasColumnName("User_Type_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.UserTypeString)
                    .IsRequired()
                    .HasColumnName("User_Type_String")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}

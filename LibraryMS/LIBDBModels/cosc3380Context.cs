using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LibraryMS.LIBDBModels
{
    public partial class cosc3380Context : DbContext
    {
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Borrow> Borrow { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerType> CustomerType { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<IsWaitlistedBy> IsWaitlistedBy { get; set; }
        public virtual DbSet<Located> Located { get; set; }
        public virtual DbSet<Manages> Manages { get; set; }
        public virtual DbSet<Media> Media { get; set; }
        public virtual DbSet<MediaType> MediaType { get; set; }
        public virtual DbSet<Section> Section { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }

        // Unable to generate entity type for table 'LIBDB.FINE'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=den1.mssql4.gear.host;Database=cosc3380;Uid=cosc3380;Pwd=vfegaf$;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            modelBuilder.Entity<Borrow>(entity =>
            {
                entity.HasKey(e => e.PkId);

                entity.ToTable("BORROW", "LIBDB");

                entity.Property(e => e.PkId)
                    .HasColumnName("pk_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.DueDate)
                    .HasColumnName("Due_Date")
                    .HasColumnType("date");

                entity.Property(e => e.IssueDate)
                    .HasColumnName("Issue_Date")
                    .HasColumnType("date");

                entity.Property(e => e.MediaId).HasColumnName("Media_ID");

                entity.Property(e => e.ReturnDate)
                    .HasColumnName("Return_Date")
                    .HasColumnType("date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Borrow)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Customer_ID");

                entity.HasOne(d => d.Media)
                    .WithMany(p => p.Borrow)
                    .HasForeignKey(d => d.MediaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Media_ID");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("CUSTOMER", "LIBDB");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("Customer_ID")
                    .ValueGeneratedNever();

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
                    .HasColumnName("First_Name")
                    .HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .HasColumnName("Last_Name")
                    .HasMaxLength(20);

                entity.Property(e => e.MembershipIssued)
                    .HasColumnName("Membership_Issued")
                    .HasColumnType("date");

                entity.Property(e => e.MiddleInitial)
                    .HasColumnName("Middle_Initial")
                    .HasMaxLength(1);

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

            modelBuilder.Entity<IsWaitlistedBy>(entity =>
            {
                entity.HasKey(e => e.PkId);

                entity.ToTable("IS_WAITLISTED_BY", "LIBDB");

                entity.Property(e => e.PkId)
                    .HasColumnName("pk_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.ExpirationDate)
                    .HasColumnName("Expiration_Date")
                    .HasColumnType("date");

                entity.Property(e => e.MediaId).HasColumnName("Media_ID");

                entity.Property(e => e.PositionNum).HasColumnName("position_num");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.IsWaitlistedBy)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Customer_ID_");

                entity.HasOne(d => d.Media)
                    .WithMany(p => p.IsWaitlistedBy)
                    .HasForeignKey(d => d.MediaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Media_ID_");
            });

            modelBuilder.Entity<Located>(entity =>
            {
                entity.HasKey(e => e.PkId);

                entity.ToTable("LOCATED", "LIBDB");

                entity.Property(e => e.PkId)
                    .HasColumnName("pk_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.MediaId).HasColumnName("Media_ID");

                entity.Property(e => e.SectionId).HasColumnName("Section_ID");

                entity.HasOne(d => d.Media)
                    .WithMany(p => p.Located)
                    .HasForeignKey(d => d.MediaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ID_of_Media");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Located)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ID_of_Section");
            });

            modelBuilder.Entity<Manages>(entity =>
            {
                entity.HasKey(e => e.PkId);

                entity.ToTable("MANAGES", "LIBDB");

                entity.Property(e => e.PkId)
                    .HasColumnName("pk_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.SectionId).HasColumnName("Section_ID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Manages)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employee_ID");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Manages)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Section_ID");
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
                    .HasColumnName("Username_String")
                    .HasMaxLength(256);

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

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LibraryMS
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
        public virtual DbSet<BranchHours> BranchHours { get; set; }
        public virtual DbSet<CheckoutHistories> CheckoutHistories { get; set; }
        public virtual DbSet<Checkouts> Checkouts { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerType> CustomerType { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Fine> Fine { get; set; }
        public virtual DbSet<Holds> Holds { get; set; }
        public virtual DbSet<IsWaitlistedBy> IsWaitlistedBy { get; set; }
        public virtual DbSet<LibraryAssets> LibraryAssets { get; set; }
        public virtual DbSet<LibraryBranches> LibraryBranches { get; set; }
        public virtual DbSet<LibraryCards> LibraryCards { get; set; }
        public virtual DbSet<Located> Located { get; set; }
        public virtual DbSet<Manages> Manages { get; set; }
        public virtual DbSet<Media> Media { get; set; }
        public virtual DbSet<MediaType> MediaType { get; set; }
        public virtual DbSet<Patrons> Patrons { get; set; }
        public virtual DbSet<Section> Section { get; set; }
        public virtual DbSet<Statuses> Statuses { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
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

            modelBuilder.Entity<BranchHours>(entity =>
            {
                entity.HasIndex(e => e.BranchId);

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.BranchHours)
                    .HasForeignKey(d => d.BranchId);
            });

            modelBuilder.Entity<CheckoutHistories>(entity =>
            {
                entity.HasIndex(e => e.LibraryAssetId);

                entity.HasIndex(e => e.LibraryCardId);

                entity.HasOne(d => d.LibraryAsset)
                    .WithMany(p => p.CheckoutHistories)
                    .HasForeignKey(d => d.LibraryAssetId);

                entity.HasOne(d => d.LibraryCard)
                    .WithMany(p => p.CheckoutHistories)
                    .HasForeignKey(d => d.LibraryCardId);
            });

            modelBuilder.Entity<Checkouts>(entity =>
            {
                entity.HasIndex(e => e.LibraryAssetId);

                entity.HasIndex(e => e.LibraryCardId);

                entity.HasOne(d => d.LibraryAsset)
                    .WithMany(p => p.Checkouts)
                    .HasForeignKey(d => d.LibraryAssetId);

                entity.HasOne(d => d.LibraryCard)
                    .WithMany(p => p.Checkouts)
                    .HasForeignKey(d => d.LibraryCardId);
            });

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
            });

            modelBuilder.Entity<Fine>(entity =>
            {
                entity.HasKey(e => e.PkId);

                entity.ToTable("FINE", "LIBDB");

                entity.Property(e => e.PkId)
                    .HasColumnName("pk_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.DueDate)
                    .HasColumnName("Due_Date")
                    .HasColumnType("date");

                entity.Property(e => e.HasPaid).HasColumnName("Has_Paid");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Fine)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Customer_to_Fine");
            });

            modelBuilder.Entity<Holds>(entity =>
            {
                entity.HasIndex(e => e.LibraryAssetId);

                entity.HasIndex(e => e.LibraryCardId);

                entity.HasOne(d => d.LibraryAsset)
                    .WithMany(p => p.Holds)
                    .HasForeignKey(d => d.LibraryAssetId);

                entity.HasOne(d => d.LibraryCard)
                    .WithMany(p => p.Holds)
                    .HasForeignKey(d => d.LibraryCardId);
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

            modelBuilder.Entity<LibraryAssets>(entity =>
            {
                entity.HasIndex(e => e.LocationId);

                entity.HasIndex(e => e.StatusId);

                entity.Property(e => e.Discriminator).IsRequired();

                entity.Property(e => e.Isbn).HasColumnName("ISBN");

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.LibraryAssets)
                    .HasForeignKey(d => d.LocationId);

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.LibraryAssets)
                    .HasForeignKey(d => d.StatusId);
            });

            modelBuilder.Entity<LibraryBranches>(entity =>
            {
                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Telephone).IsRequired();
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

            modelBuilder.Entity<Patrons>(entity =>
            {
                entity.HasIndex(e => e.HomeLibraryBranchId);

                entity.HasIndex(e => e.LibraryCardId);

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.HomeLibraryBranch)
                    .WithMany(p => p.Patrons)
                    .HasForeignKey(d => d.HomeLibraryBranchId);

                entity.HasOne(d => d.LibraryCard)
                    .WithMany(p => p.Patrons)
                    .HasForeignKey(d => d.LibraryCardId);
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

            modelBuilder.Entity<Statuses>(entity =>
            {
                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name).IsRequired();
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

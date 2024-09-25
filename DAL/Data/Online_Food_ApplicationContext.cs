using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnlineFastFoodDelivery
{
    public partial class Online_Food_ApplicationContext : DbContext
    {
        public Online_Food_ApplicationContext()
        {
        }

        public Online_Food_ApplicationContext(DbContextOptions<Online_Food_ApplicationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAdmin> TblAdmins { get; set; } = null!;
        public virtual DbSet<TblAdminSession> TblAdminSessions { get; set; } = null!;
        public virtual DbSet<TblCart> TblCarts { get; set; } = null!;
        public virtual DbSet<TblCategory> TblCategories { get; set; } = null!;
        public virtual DbSet<TblFood> TblFoods { get; set; } = null!;
        public virtual DbSet<TblFoodType> TblFoodTypes { get; set; } = null!;
        public virtual DbSet<TblOrder> TblOrders { get; set; } = null!;
        public virtual DbSet<TblOrderDetail> TblOrderDetails { get; set; } = null!;
        public virtual DbSet<TblPaymentDetail> TblPaymentDetails { get; set; } = null!;
        public virtual DbSet<TblProductImage> TblProductImages { get; set; } = null!;
        public virtual DbSet<TblRating> TblRatings { get; set; } = null!;
        public virtual DbSet<TblRole> TblRoles { get; set; } = null!;
        public virtual DbSet<TblSubCategory> TblSubCategories { get; set; } = null!;
        public virtual DbSet<TblUser> TblUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(
                    "Server=DESKTOP-RBREH2D\\SQLEXPRESS;Database=Online_Food_Application;Trusted_Connection=True;ConnectRetryCount=0", sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                });
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblAdmin>(entity =>
            {
                entity.HasKey(e => e.AdminId)
                    .HasName("PK__tbl_Admi__719FE4E89550B207");

                entity.ToTable("tbl_Admin");

                entity.Property(e => e.AdminId)
                    .ValueGeneratedNever()
                    .HasColumnName("AdminID");

                entity.Property(e => e.AdminName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FullAddress)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TblAdmins)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_Admin_tbl_Role");
            });

            modelBuilder.Entity<TblAdminSession>(entity =>
            {
                entity.HasKey(e => e.AdminSessionId)
                    .HasName("PK__tbl_Admi__151774C5F4AF1AB0");

                entity.ToTable("tbl_AdminSession");

                entity.Property(e => e.AdminSessionId)
                    .ValueGeneratedNever()
                    .HasColumnName("admin_sessionID");

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.SessionEnd)
                    .HasColumnType("datetime")
                    .HasColumnName("session_End");

                entity.Property(e => e.SessionStart)
                    .HasColumnType("datetime")
                    .HasColumnName("session_Start");

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.TblAdminSessions)
                    .HasForeignKey(d => d.AdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Admin__Admin__4BAC3F29");
            });

            modelBuilder.Entity<TblCart>(entity =>
            {
                entity.HasKey(e => e.CartId);

                entity.ToTable("tbl_Cart");

                entity.Property(e => e.CartId)
                    .ValueGeneratedNever()
                    .HasColumnName("cart_id");

                entity.Property(e => e.AddedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Added_Date");

                entity.Property(e => e.CartStatus)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("cart_status");

                entity.Property(e => e.FoodId).HasColumnName("food_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.TblCarts)
                    .HasForeignKey(d => d.FoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_Cart_tbl_Food");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblCarts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_Cart_tbl_User");
            });

            modelBuilder.Entity<TblCategory>(entity =>
            {
                entity.HasKey(e => e.CatId)
                    .HasName("PK__tbl_Cate__DD5DDDBDC40B6FD8");

                entity.ToTable("tbl_Category");

                entity.Property(e => e.CatId)
                    .ValueGeneratedNever()
                    .HasColumnName("cat_id");

                entity.Property(e => e.CatDesc).HasColumnName("cat_desc");

                entity.Property(e => e.CatName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("cat_Name");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.TblCategoryCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_tbl_Category_tbl_AdminSession");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.TblCategoryDeletedByNavigations)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK_tbl_Category_tbl_AdminSession1");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.TblCategoryUpdatedByNavigations)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("FK_tbl_Category_tbl_AdminSession2");
            });

            modelBuilder.Entity<TblFood>(entity =>
            {
                entity.HasKey(e => e.FoodId);

                entity.ToTable("tbl_Food");

                entity.Property(e => e.FoodId)
                    .ValueGeneratedNever()
                    .HasColumnName("Food_id");

                entity.Property(e => e.CatId).HasColumnName("cat_id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.FoodAmount)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Food_Amount");

                entity.Property(e => e.FoodDesc).HasColumnName("Food_Desc");

                entity.Property(e => e.FoodName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Food_Name");

                entity.Property(e => e.FoodTypeId).HasColumnName("Food_typeID");

                entity.Property(e => e.SubCatId).HasColumnName("sub_cat_id");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.TblFoods)
                    .HasForeignKey(d => d.CatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Food__cat_id__5FB337D6");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.TblFoodCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__tbl_Food__Create__628FA481");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.TblFoodDeletedByNavigations)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK__tbl_Food__Delete__6477ECF3");

                entity.HasOne(d => d.FoodType)
                    .WithMany(p => p.TblFoods)
                    .HasForeignKey(d => d.FoodTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Food__Food_t__619B8048");

                entity.HasOne(d => d.SubCat)
                    .WithMany(p => p.TblFoods)
                    .HasForeignKey(d => d.SubCatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Food__sub_ca__60A75C0F");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.TblFoodUpdatedByNavigations)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("FK__tbl_Food__Update__6383C8BA");
            });

            modelBuilder.Entity<TblFoodType>(entity =>
            {
                entity.HasKey(e => e.FoodTypeId)
                    .HasName("PK__tbl_Food__E4FF8B8E48628857");

                entity.ToTable("tbl_FoodType");

                entity.Property(e => e.FoodTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("FoodType_Id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.FoodType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FoodTypeDesc).HasColumnName("foodType_desc");

                entity.Property(e => e.FoodTypeImg).HasColumnName("foodType_img");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.TblFoodTypeCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__tbl_FoodT__Creat__5BE2A6F2");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.TblFoodTypeDeletedByNavigations)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK__tbl_FoodT__Delet__5DCAEF64");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.TblFoodTypeUpdatedByNavigations)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("FK__tbl_FoodT__Updat__5CD6CB2B");
            });

            modelBuilder.Entity<TblOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("tbl_Order");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("order_id");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("order_date");

                entity.Property(e => e.OrderStatus)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("order_status");

                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.Property(e => e.ProcessedBy).HasColumnName("processed_by");

                entity.Property(e => e.ProcessedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("processed_date");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("total_amount");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.TblOrders)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK_tbl_Order_tbl_PaymentDetails");

                entity.HasOne(d => d.ProcessedByNavigation)
                    .WithMany(p => p.TblOrderProcessedByNavigations)
                    .HasForeignKey(d => d.ProcessedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_Order_tbl_User1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblOrderUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_Order_tbl_User");
            });

            modelBuilder.Entity<TblOrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrderDetailsId);

                entity.ToTable("tbl_orderDetails");

                entity.Property(e => e.OrderDetailsId)
                    .ValueGeneratedNever()
                    .HasColumnName("orderDetails_id");

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.FoodId).HasColumnName("food_id");

                entity.Property(e => e.NoOfServings).HasColumnName("no_of_servings");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 4)");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.TblOrderDetails)
                    .HasForeignKey(d => d.FoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_orderDetails_tbl_Food");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.TblOrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_tbl_orderDetails_tbl_Order");
            });

            modelBuilder.Entity<TblPaymentDetail>(entity =>
            {
                entity.HasKey(e => e.PaymentId);

                entity.ToTable("tbl_PaymentDetails");

                entity.Property(e => e.PaymentId)
                    .ValueGeneratedNever()
                    .HasColumnName("payment_id");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("amount");

                entity.Property(e => e.PaidBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("paidBy");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("payment_Date");

                entity.Property(e => e.ProcessedBy).HasColumnName("processed_by");

                entity.Property(e => e.TransactionId)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("transaction_id");

                entity.HasOne(d => d.ProcessedByNavigation)
                    .WithMany(p => p.TblPaymentDetails)
                    .HasForeignKey(d => d.ProcessedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_PaymentDetails_tbl_User");
            });

            modelBuilder.Entity<TblProductImage>(entity =>
            {
                entity.HasKey(e => e.ProductImgId);

                entity.ToTable("tbl_ProductImages");

                entity.Property(e => e.ProductImgId)
                    .ValueGeneratedNever()
                    .HasColumnName("product_img_id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.FoodId).HasColumnName("Food_id");

                entity.Property(e => e.ProductImg).HasColumnName("product_img");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.TblProductImageCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_tbl_ProductImages_tbl_AdminSession");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.TblProductImageDeletedByNavigations)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK_tbl_ProductImages_tbl_AdminSession1");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.TblProductImages)
                    .HasForeignKey(d => d.FoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_ProductImages_tbl_Food");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.TblProductImageUpdatedByNavigations)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("FK_tbl_ProductImages_tbl_AdminSession2");
            });

            modelBuilder.Entity<TblRating>(entity =>
            {
                entity.HasKey(e => e.RatingId);

                entity.ToTable("tbl_Rating");

                entity.Property(e => e.RatingId)
                    .ValueGeneratedNever()
                    .HasColumnName("rating_id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.FoodId).HasColumnName("food_id");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("remarks");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.CreatedbyNavigation)
                    .WithMany(p => p.TblRatingCreatedbyNavigations)
                    .HasForeignKey(d => d.Createdby)
                    .HasConstraintName("FK_tbl_Rating_tbl_AdminSession");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.TblRatingDeletedByNavigations)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK_tbl_Rating_tbl_AdminSession1");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.TblRatings)
                    .HasForeignKey(d => d.FoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_Rating_tbl_Food");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.TblRatingUpdatedByNavigations)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("FK_tbl_Rating_tbl_AdminSession2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblRatings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_Rating_tbl_User");
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__tbl_Role__8AFACE3A1D8C4650");

                entity.ToTable("tbl_Role");

                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("RoleID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.Role)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.TblRoleCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_tbl_Role_tbl_AdminSession");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.TblRoleDeletedByNavigations)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK_tbl_Role_tbl_AdminSession1");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.TblRoleUpdatedByNavigations)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("FK_tbl_Role_tbl_AdminSession2");
            });

            modelBuilder.Entity<TblSubCategory>(entity =>
            {
                entity.HasKey(e => e.SubCatid)
                    .HasName("PK__tbl_SubC__9328944AB8DE0D4E");

                entity.ToTable("tbl_SubCategory");

                entity.Property(e => e.SubCatid)
                    .ValueGeneratedNever()
                    .HasColumnName("sub_catid");

                entity.Property(e => e.BannerImg).HasColumnName("banner_img");

                entity.Property(e => e.CatId).HasColumnName("cat_id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.IconImg).HasColumnName("icon_img");

                entity.Property(e => e.SubCatDescription).HasColumnName("sub_cat_description");

                entity.Property(e => e.SubCatName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sub_catName");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.TblSubCategories)
                    .HasForeignKey(d => d.CatId)
                    .HasConstraintName("FK__tbl_SubCa__cat_i__5441852A");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.TblSubCategoryCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__tbl_SubCa__Creat__5535A963");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.TblSubCategoryDeletedByNavigations)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK__tbl_SubCa__Delet__571DF1D5");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.TblSubCategoryUpdatedByNavigations)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("FK__tbl_SubCa__Updat__5629CD9C");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__tbl_User__1788CCAC473C23F0");

                entity.ToTable("tbl_User");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserID");

                entity.Property(e => e.AccountStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FullAddress)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

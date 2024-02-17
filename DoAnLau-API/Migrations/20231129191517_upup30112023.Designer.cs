﻿// <auto-generated />
using System;
using DoAnLau_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DoAnLau_API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231129191517_upup30112023")]
    partial class upup30112023
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DoAnLau_API.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("birthdate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("gender")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("rewardPoints")
                        .HasColumnType("int");

                    b.Property<byte[]>("userImage")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("DoAnLau_API.Models.Address", b =>
                {
                    b.Property<string>("address_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("addressDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("district")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType(" varchar(100)");

                    b.Property<bool>("isDefault")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType(" varchar(15)");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ward")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("address_Id");

                    b.HasIndex("userId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("DoAnLau_API.Models.Branch", b =>
                {
                    b.Property<string>("branch_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("addressDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("branchName")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("city")
                        .HasColumnType("int");

                    b.Property<int>("district")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("openingTime")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.Property<int>("ward")
                        .HasColumnType("int");

                    b.HasKey("branch_Id");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("DoAnLau_API.Models.BranchReservationTime", b =>
                {
                    b.Property<string>("branch_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("reservationTime_Id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("branch_Id", "reservationTime_Id");

                    b.HasIndex("reservationTime_Id");

                    b.ToTable("BranchReservationTime");
                });

            modelBuilder.Entity("DoAnLau_API.Models.CustomerSize", b =>
                {
                    b.Property<string>("customerSize_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("size")
                        .HasColumnType("int");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.HasKey("customerSize_Id");

                    b.ToTable("CustomerSize");
                });

            modelBuilder.Entity("DoAnLau_API.Models.Menu", b =>
                {
                    b.Property<string>("menu_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("bestSaller")
                        .HasColumnType("bit");

                    b.Property<bool>("hotDeal")
                        .HasColumnType("bit");

                    b.Property<string>("menuCategory_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("menuImage")
                        .IsRequired()
                        .HasColumnType("varchar(400)");

                    b.Property<string>("menuName")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.HasKey("menu_Id");

                    b.HasIndex("menuCategory_Id");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("DoAnLau_API.Models.MenuCategory", b =>
                {
                    b.Property<string>("menuCategory_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("categoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.HasKey("menuCategory_Id");

                    b.ToTable("MenuCategories");
                });

            modelBuilder.Entity("DoAnLau_API.Models.News", b =>
                {
                    b.Property<string>("news_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("PostDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("news_Id");

                    b.ToTable("News");
                });

            modelBuilder.Entity("DoAnLau_API.Models.Order", b =>
                {
                    b.Property<string>("order_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(400)");

                    b.Property<DateTime>("orderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("paymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("promotion_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("totalPrice")
                        .HasColumnType("int");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("order_Id");

                    b.HasIndex("promotion_Id");

                    b.HasIndex("userId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DoAnLau_API.Models.Order_Detail", b =>
                {
                    b.Property<string>("order_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("orderDetail_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("menuTotalPrice")
                        .HasColumnType("int");

                    b.Property<string>("menu_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("order_Id", "orderDetail_Id");

                    b.HasIndex("menu_Id");

                    b.HasIndex("order_Id")
                        .IsUnique();

                    b.ToTable("Order_Details");
                });

            modelBuilder.Entity("DoAnLau_API.Models.Promotion", b =>
                {
                    b.Property<string>("promotion_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PromotionImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("expirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("imagePath")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("promotionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.HasKey("promotion_Id");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("DoAnLau_API.Models.PromotionBranch", b =>
                {
                    b.Property<string>("promotion_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("branch_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.HasKey("promotion_Id", "branch_Id");

                    b.HasIndex("branch_Id");

                    b.ToTable("PromotionBranchs");
                });

            modelBuilder.Entity("DoAnLau_API.Models.PromotionDetail", b =>
                {
                    b.Property<string>("promotionDetail_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("promotion_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("promotionDetail_Id");

                    b.HasIndex("promotion_Id");

                    b.ToTable("PromotionDetails");
                });

            modelBuilder.Entity("DoAnLau_API.Models.PromotionUser", b =>
                {
                    b.Property<string>("promotion_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("user_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.HasKey("promotion_Id", "user_Id");

                    b.HasIndex("user_Id");

                    b.ToTable("PromotionUsers");
                });

            modelBuilder.Entity("DoAnLau_API.Models.QuanHuyen", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("tenQuanHuyen")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("tinhThanhPhoId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("tinhThanhPhoId");

                    b.ToTable("QuanHuyen");
                });

            modelBuilder.Entity("DoAnLau_API.Models.QuocGia", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("tenQuocGia")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("QuocGia");
                });

            modelBuilder.Entity("DoAnLau_API.Models.Reservation", b =>
                {
                    b.Property<string>("reservation_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("branch_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("customerSize_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("reservationTime_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.HasKey("reservation_Id");

                    b.HasIndex("branch_Id");

                    b.HasIndex("customerSize_Id");

                    b.HasIndex("reservationTime_Id");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("DoAnLau_API.Models.ReservationTime", b =>
                {
                    b.Property<string>("reservationTime_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("time");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.HasKey("reservationTime_Id");

                    b.ToTable("ReservationTime");
                });

            modelBuilder.Entity("DoAnLau_API.Models.ReservationUser", b =>
                {
                    b.Property<string>("reservation_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("user_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.HasKey("reservation_Id", "user_Id");

                    b.HasIndex("user_Id");

                    b.ToTable("ReservationUsers");
                });

            modelBuilder.Entity("DoAnLau_API.Models.SYS_INDEX", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("currentIndex")
                        .HasColumnType("int");

                    b.Property<string>("nameIndex")
                        .IsRequired()
                        .HasColumnType(" nvarchar(100)");

                    b.Property<string>("prefix")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("id");

                    b.ToTable("SYS_INDices");
                });

            modelBuilder.Entity("DoAnLau_API.Models.TinhThanhPho", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<int>("quocGiaId")
                        .HasColumnType("int");

                    b.Property<string>("tenTinhThanhPho")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.HasIndex("quocGiaId");

                    b.ToTable("TinhThanhPho");
                });

            modelBuilder.Entity("DoAnLau_API.Models.XaPhuong", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<int>("quanHuyenId")
                        .HasColumnType("int");

                    b.Property<string>("tenXaPhuong")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.HasIndex("quanHuyenId");

                    b.ToTable("XaPhuong");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DoAnLau_API.Models.Address", b =>
                {
                    b.HasOne("DoAnLau_API.Data.ApplicationUser", "user")
                        .WithMany("addresses")
                        .HasForeignKey("userId");

                    b.Navigation("user");
                });

            modelBuilder.Entity("DoAnLau_API.Models.BranchReservationTime", b =>
                {
                    b.HasOne("DoAnLau_API.Models.ReservationTime", "reservationTime")
                        .WithMany("branchReservationTimes")
                        .HasForeignKey("branch_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAnLau_API.Models.Branch", "branch")
                        .WithMany("branchReservationTimes")
                        .HasForeignKey("reservationTime_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("branch");

                    b.Navigation("reservationTime");
                });

            modelBuilder.Entity("DoAnLau_API.Models.Menu", b =>
                {
                    b.HasOne("DoAnLau_API.Models.MenuCategory", "menuCategory")
                        .WithMany("menus")
                        .HasForeignKey("menuCategory_Id");

                    b.Navigation("menuCategory");
                });

            modelBuilder.Entity("DoAnLau_API.Models.Order", b =>
                {
                    b.HasOne("DoAnLau_API.Models.Promotion", "promotion")
                        .WithMany("orders")
                        .HasForeignKey("promotion_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAnLau_API.Data.ApplicationUser", "user")
                        .WithMany("orders")
                        .HasForeignKey("userId");

                    b.Navigation("promotion");

                    b.Navigation("user");
                });

            modelBuilder.Entity("DoAnLau_API.Models.Order_Detail", b =>
                {
                    b.HasOne("DoAnLau_API.Models.Menu", "menu")
                        .WithMany("order_Details")
                        .HasForeignKey("menu_Id");

                    b.HasOne("DoAnLau_API.Models.Order", "order")
                        .WithOne("order_Detail")
                        .HasForeignKey("DoAnLau_API.Models.Order_Detail", "order_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("menu");

                    b.Navigation("order");
                });

            modelBuilder.Entity("DoAnLau_API.Models.PromotionBranch", b =>
                {
                    b.HasOne("DoAnLau_API.Models.Promotion", "promotion")
                        .WithMany("promotionBranches")
                        .HasForeignKey("branch_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAnLau_API.Models.Branch", "branch")
                        .WithMany("promotionBranches")
                        .HasForeignKey("promotion_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("branch");

                    b.Navigation("promotion");
                });

            modelBuilder.Entity("DoAnLau_API.Models.PromotionDetail", b =>
                {
                    b.HasOne("DoAnLau_API.Models.Promotion", "promotion")
                        .WithMany("promotionDetails")
                        .HasForeignKey("promotion_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("promotion");
                });

            modelBuilder.Entity("DoAnLau_API.Models.PromotionUser", b =>
                {
                    b.HasOne("DoAnLau_API.Data.ApplicationUser", "user")
                        .WithMany("promotionUsers")
                        .HasForeignKey("promotion_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAnLau_API.Models.Promotion", "promotion")
                        .WithMany("promotionUsers")
                        .HasForeignKey("user_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("promotion");

                    b.Navigation("user");
                });

            modelBuilder.Entity("DoAnLau_API.Models.QuanHuyen", b =>
                {
                    b.HasOne("DoAnLau_API.Models.TinhThanhPho", "tinhThanhPho")
                        .WithMany("quanHuyens")
                        .HasForeignKey("tinhThanhPhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tinhThanhPho");
                });

            modelBuilder.Entity("DoAnLau_API.Models.Reservation", b =>
                {
                    b.HasOne("DoAnLau_API.Models.Branch", "branch")
                        .WithMany("reservations")
                        .HasForeignKey("branch_Id");

                    b.HasOne("DoAnLau_API.Models.CustomerSize", "customerSize")
                        .WithMany("reservations")
                        .HasForeignKey("customerSize_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAnLau_API.Models.ReservationTime", "reservationTime")
                        .WithMany("reservations")
                        .HasForeignKey("reservationTime_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("branch");

                    b.Navigation("customerSize");

                    b.Navigation("reservationTime");
                });

            modelBuilder.Entity("DoAnLau_API.Models.ReservationUser", b =>
                {
                    b.HasOne("DoAnLau_API.Data.ApplicationUser", "user")
                        .WithMany("reservationUsers")
                        .HasForeignKey("reservation_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAnLau_API.Models.Reservation", "reservation")
                        .WithMany("reservationUsers")
                        .HasForeignKey("user_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("reservation");

                    b.Navigation("user");
                });

            modelBuilder.Entity("DoAnLau_API.Models.TinhThanhPho", b =>
                {
                    b.HasOne("DoAnLau_API.Models.QuocGia", "quocGia")
                        .WithMany()
                        .HasForeignKey("quocGiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("quocGia");
                });

            modelBuilder.Entity("DoAnLau_API.Models.XaPhuong", b =>
                {
                    b.HasOne("DoAnLau_API.Models.QuanHuyen", "quanHuyen")
                        .WithMany("xaPhuongs")
                        .HasForeignKey("quanHuyenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("quanHuyen");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DoAnLau_API.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DoAnLau_API.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAnLau_API.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DoAnLau_API.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DoAnLau_API.Data.ApplicationUser", b =>
                {
                    b.Navigation("addresses");

                    b.Navigation("orders");

                    b.Navigation("promotionUsers");

                    b.Navigation("reservationUsers");
                });

            modelBuilder.Entity("DoAnLau_API.Models.Branch", b =>
                {
                    b.Navigation("branchReservationTimes");

                    b.Navigation("promotionBranches");

                    b.Navigation("reservations");
                });

            modelBuilder.Entity("DoAnLau_API.Models.CustomerSize", b =>
                {
                    b.Navigation("reservations");
                });

            modelBuilder.Entity("DoAnLau_API.Models.Menu", b =>
                {
                    b.Navigation("order_Details");
                });

            modelBuilder.Entity("DoAnLau_API.Models.MenuCategory", b =>
                {
                    b.Navigation("menus");
                });

            modelBuilder.Entity("DoAnLau_API.Models.Order", b =>
                {
                    b.Navigation("order_Detail")
                        .IsRequired();
                });

            modelBuilder.Entity("DoAnLau_API.Models.Promotion", b =>
                {
                    b.Navigation("orders");

                    b.Navigation("promotionBranches");

                    b.Navigation("promotionDetails");

                    b.Navigation("promotionUsers");
                });

            modelBuilder.Entity("DoAnLau_API.Models.QuanHuyen", b =>
                {
                    b.Navigation("xaPhuongs");
                });

            modelBuilder.Entity("DoAnLau_API.Models.Reservation", b =>
                {
                    b.Navigation("reservationUsers");
                });

            modelBuilder.Entity("DoAnLau_API.Models.ReservationTime", b =>
                {
                    b.Navigation("branchReservationTimes");

                    b.Navigation("reservations");
                });

            modelBuilder.Entity("DoAnLau_API.Models.TinhThanhPho", b =>
                {
                    b.Navigation("quanHuyens");
                });
#pragma warning restore 612, 618
        }
    }
}

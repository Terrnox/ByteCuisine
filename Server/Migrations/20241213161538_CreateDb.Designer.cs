﻿// <auto-generated />
using System;
using ByteCuisine.Server.Controllers.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ByteCuisine.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241213161538_CreateDb")]
    partial class CreateDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ByteCuisine.Shared.Account", b =>
                {
                    b.Property<int>("User_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("User_Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("PictureData")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("User_Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Account", "ByteCuisine");
                });

            modelBuilder.Entity("ByteCuisine.Shared.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Category", "ByteCuisine");
                });

            modelBuilder.Entity("ByteCuisine.Shared.Dish", b =>
                {
                    b.Property<int>("Dish_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Dish_Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("DishImage")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Dish_Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Dish", "ByteCuisine");
                });

            modelBuilder.Entity("ByteCuisine.Shared.DishIngredient", b =>
                {
                    b.Property<int>("DishIngredient_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DishIngredient_Id"));

                    b.Property<int>("Dish_Id")
                        .HasColumnType("integer");

                    b.Property<int>("Ingredient_Id")
                        .HasColumnType("integer");

                    b.HasKey("DishIngredient_Id");

                    b.HasIndex("Dish_Id");

                    b.HasIndex("Ingredient_Id");

                    b.ToTable("DishIngredient", "ByteCuisine");
                });

            modelBuilder.Entity("ByteCuisine.Shared.Ingredient", b =>
                {
                    b.Property<int>("Ingredient_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Ingredient_Id"));

                    b.Property<double>("Callories")
                        .HasColumnType("double precision");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Ingredient_Id");

                    b.ToTable("Ingredient", "ByteCuisine");
                });

            modelBuilder.Entity("ByteCuisine.Shared.IngredientsInFridge", b =>
                {
                    b.Property<int>("IngredientsInFridge_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IngredientsInFridge_Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<int>("Ingredient_Id")
                        .HasColumnType("integer");

                    b.HasKey("IngredientsInFridge_Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("Ingredient_Id");

                    b.ToTable("IngredientsInFridge", "ByteCuisine");
                });

            modelBuilder.Entity("ByteCuisine.Shared.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<string>("ActivityName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("ActivityTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Log", "ByteCuisine");
                });

            modelBuilder.Entity("ByteCuisine.Shared.Dish", b =>
                {
                    b.HasOne("ByteCuisine.Shared.Category", "Category")
                        .WithMany("Dishes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ByteCuisine.Shared.DishIngredient", b =>
                {
                    b.HasOne("ByteCuisine.Shared.Dish", "Dish")
                        .WithMany("DishIngredients")
                        .HasForeignKey("Dish_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ByteCuisine.Shared.Ingredient", "Ingredient")
                        .WithMany("DishIngredients")
                        .HasForeignKey("Ingredient_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("ByteCuisine.Shared.IngredientsInFridge", b =>
                {
                    b.HasOne("ByteCuisine.Shared.Account", "Account")
                        .WithMany("IngredientsInFridge")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ByteCuisine.Shared.Ingredient", "Ingredient")
                        .WithMany("IngredientsInFridge")
                        .HasForeignKey("Ingredient_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("ByteCuisine.Shared.Log", b =>
                {
                    b.HasOne("ByteCuisine.Shared.Account", "Account")
                        .WithMany("Logs")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("ByteCuisine.Shared.Account", b =>
                {
                    b.Navigation("IngredientsInFridge");

                    b.Navigation("Logs");
                });

            modelBuilder.Entity("ByteCuisine.Shared.Category", b =>
                {
                    b.Navigation("Dishes");
                });

            modelBuilder.Entity("ByteCuisine.Shared.Dish", b =>
                {
                    b.Navigation("DishIngredients");
                });

            modelBuilder.Entity("ByteCuisine.Shared.Ingredient", b =>
                {
                    b.Navigation("DishIngredients");

                    b.Navigation("IngredientsInFridge");
                });
#pragma warning restore 612, 618
        }
    }
}

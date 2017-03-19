using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ASPNETCOREFORM.Models;

namespace DotNetReactSqlLitemaster.Migrations
{
    [DbContext(typeof(InventoryContext))]
    [Migration("20170309015809_AddedPriceField")]
    partial class AddedPriceField
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("ASPNETCOREFORM.Models.FormControl", b =>
                {
                    b.Property<int>("FormControlId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.Property<int>("Quantity");

                    b.HasKey("FormControlId");

                    b.ToTable("Inventories");
                });
        }
    }
}

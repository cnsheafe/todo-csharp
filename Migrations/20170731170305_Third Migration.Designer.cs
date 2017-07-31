using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TodoList;

namespace TodoList.Migrations
{
    [DbContext(typeof(TodoListDb))]
    [Migration("20170731170305_Third Migration")]
    partial class ThirdMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("TodoList.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int?>("TodoId");

                    b.HasKey("ItemId");

                    b.HasIndex("TodoId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("TodoList.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("TodoLists");
                });

            modelBuilder.Entity("TodoList.Item", b =>
                {
                    b.HasOne("TodoList.Todo")
                        .WithMany("Items")
                        .HasForeignKey("TodoId");
                });
        }
    }
}

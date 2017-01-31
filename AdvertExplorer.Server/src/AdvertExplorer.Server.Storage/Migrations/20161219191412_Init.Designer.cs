using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AdvertExplorer.Server.Storage;
using AdvertExplorer.Server.Domain.ValueObjects;

namespace AdvertExplorer.Server.Storage.Migrations
{
    [DbContext(typeof(AdvertExplorerContext))]
    [Migration("20161219191412_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-preview1-22509");

            modelBuilder.Entity("AdvertExplorer.Server.Storage.DTO.QueryDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<uint?>("AgeMax");

                    b.Property<uint?>("AgeMin");

                    b.Property<int?>("Experience");

                    b.Property<DateTime>("LastUpdateDate");

                    b.Property<int>("Region");

                    b.Property<int?>("Rubric");

                    b.Property<uint?>("Salary");

                    b.Property<string>("SearchString");

                    b.HasKey("Id");

                    b.ToTable("Queries");
                });

            modelBuilder.Entity("AdvertExplorer.Server.Storage.DTO.ResumeDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<uint?>("Age");

                    b.Property<int>("City");

                    b.Property<string>("Description");

                    b.Property<string>("EducationType");

                    b.Property<int?>("Experience");

                    b.Property<string>("Institution");

                    b.Property<string>("JobTitle");

                    b.Property<string>("Name");

                    b.Property<string>("PhotoUri");

                    b.Property<string>("Rubrics");

                    b.Property<uint?>("Salary");

                    b.Property<string>("Specialty");

                    b.Property<string>("WorkingType");

                    b.HasKey("Id");

                    b.ToTable("Resumes");
                });
        }
    }
}

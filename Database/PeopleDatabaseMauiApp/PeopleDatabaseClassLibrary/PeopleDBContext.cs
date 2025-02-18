﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PeopleDatabaseClassLibrary.Models;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace PeopleDatabaseClassLibrary;

public partial class PeopleDBContext : DbContext
{
    public PeopleDBContext()
    {
    }

    public PeopleDBContext(DbContextOptions<PeopleDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;database=people;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_polish_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("person");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Age)
                .HasColumnType("int(11)")
                .HasColumnName("age");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.Surname)
                .HasMaxLength(20)
                .HasColumnName("surname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

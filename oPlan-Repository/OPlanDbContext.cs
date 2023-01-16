using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace oPlan_Repository;

public partial class OPlanDbContext : DbContext
{
    public OPlanDbContext()
    {
    }

    public OPlanDbContext(DbContextOptions<OPlanDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agenda> Agendas { get; set; }

    public virtual DbSet<Todo> Todos { get; set; }

    public virtual DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agenda>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("agendas_pkey");

            entity.ToTable("agendas");

            entity.Property(e => e.Id)
                .HasMaxLength(13)
                .HasColumnName("id");
            entity.Property(e => e.DateCreated).HasColumnName("date_created");
            entity.Property(e => e.DateDone).HasColumnName("date_done");
            entity.Property(e => e.DateUpdated).HasColumnName("date_updated");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.TodoCount).HasColumnName("todo_count");
            entity.Property(e => e.UserId)
                .IsRequired()
                .HasMaxLength(13)
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Agenda)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user");
        });

        modelBuilder.Entity<Todo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("todos_pkey");

            entity.ToTable("todos");

            entity.Property(e => e.Id)
                .HasMaxLength(13)
                .HasColumnName("id");
            entity.Property(e => e.AgendaId)
                .IsRequired()
                .HasMaxLength(13)
                .HasColumnName("agenda_id");
            entity.Property(e => e.DateCreated).HasColumnName("date_created");
            entity.Property(e => e.DateDone).HasColumnName("date_done");
            entity.Property(e => e.DateUpdated).HasColumnName("date_updated");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasColumnName("description");
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(75)
                .HasColumnName("title");
            entity.Property(e => e.UserId)
                .IsRequired()
                .HasMaxLength(13)
                .HasColumnName("user_id");

            entity.HasOne(d => d.Agenda).WithMany(p => p.Todos)
                .HasForeignKey(d => d.AgendaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_agenda");

            entity.HasOne(d => d.User).WithMany(p => p.Todos)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Username, "users_username_key").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(13)
                .HasColumnName("id");
            entity.Property(e => e.DateCreated).HasColumnName("date_created");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

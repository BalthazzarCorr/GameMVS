﻿namespace MyGameStoreApp.Data
{
   using EntityModels;
   using Microsoft.EntityFrameworkCore;

   public class GameStoreDbContext : DbContext
    {

       public DbSet<User> Users { get; set; }

       public DbSet<Game> Games { get; set; }

      public  DbSet<Order> Orders { get; set; }

       protected override void OnConfiguring(DbContextOptionsBuilder builder)
       {
          builder
            .UseSqlServer("Server=.;Database=MyGameStoreDb;Integrated security=True;");
       }

       protected override void OnModelCreating(ModelBuilder builder)
       {
          builder.Entity<User>().HasIndex(u => u.Email).IsUnique();
       }

    }
}

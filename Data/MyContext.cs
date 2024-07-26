using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MyContext  : IdentityDbContext<AppUser, AppRole, int>
    {
        public DbSet<Video> Videos { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {



        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           

            // Subscription ve AppUser arasındaki ilişkiler
            modelBuilder.Entity<Subscription>()
                .HasOne(s => s.Subscriber)
                .WithMany(u => u.Subscriptions)
                .HasForeignKey(s => s.SubscriberId)
                .OnDelete(DeleteBehavior.Restrict); // Abonelik yapan kullanıcı silindiğinde bu aboneliklerin de silinmesini engeller

            modelBuilder.Entity<Subscription>()
                .HasOne(s => s.Channel)
                .WithMany() // Kanalın kendisinde bir koleksiyon olmadığı için WithMany() kullanılır
                .HasForeignKey(s => s.ChannelId)
                .OnDelete(DeleteBehavior.Restrict); // Abonelik yapılan kanal silindiğinde bu aboneliklerin de silinmesini engeller





            // Örnek başlangıç kullanıcı verileri ekleme
            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = 1,
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@example.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Admin@123")
                },
                new AppUser
                {
                    Id = 2,
                    UserName = "user",
                    NormalizedUserName = "USER",
                    Email = "user@example.com",
                    NormalizedEmail = "USER@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "User@123")
                }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "spor" }
            );

            // Video verilerini ekle
            modelBuilder.Entity<Video>().HasData(
                new Video
                {
                    VideoId = 1,
                    Title = "ASP.NET Core Tutorial",
                    Description = "Learn ASP.NET Core from scratch.",
                    Url = "https://example.com/video1",
                    PublishedOn = new DateTime(2024, 7, 20),
                    UserId = 1,
                    CategoryId = 1
                }
            );

            // Like verilerini ekle
            modelBuilder.Entity<Like>().HasData(
                new Like { LikeId = 1, VideoId = 1, UserId = 1 },
                new Like { LikeId = 2, VideoId = 1, UserId = 2 }
            );

            // Comment verilerini ekle
            modelBuilder.Entity<Comment>().HasData(
                new Comment { CommentId = 1, Text = "iyi bir kurs", PublishedOn = DateTime.Now.AddDays(-20), VideoId = 1, UserId = 1 },
                new Comment { CommentId = 2, Text = "çok faydalandığım bir kurs", PublishedOn = DateTime.Now.AddDays(-10), VideoId = 1, UserId = 2 }
            );
            // İlişkileri yapılandır

        }
    }

}
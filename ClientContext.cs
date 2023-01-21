using ClientsDb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ClientsDb
{
    public class ClientContext : DbContext
    {
        public DbSet<Client> Clients { get; set; } = null!; // помощью выражения null!, которое говорит, что данное свойство в принципе не будет иметь значение null
        public DbSet<Order> Orders { get; set; } = null!; //  помощью выражения null!, которое говорит, что данное свойство в принципе не будет иметь значение null

        public ClientContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Так же вместо написание конфигурации в методы мы можем создать отдельный класс (это имеет смысл при большом кол-во настроек)

            //modelBuilder.ApplyConfiguration(new ClientConfiguration());
            //modelBuilder.Entity<Client>(ClientConfigure); - использывать отдельный метод и подставить в качестве делигата
            //альтернативный вариант применения конфигураций представляет атрибут EntityTypeConfiguration

            //converter
            /*
            var blogKeyConverter = new ValueConverter<BlogKey, int>(
            v => v.Id,
            v => new BlogKey(v));

            modelBuilder.Entity<Blog>().Property(e => e.Id).HasConversion(blogKeyConverter);
            modelBuilder.Entity<Post>(
                b =>
                {
                    b.Property(e => e.Id).HasConversion(v => v.Id, v => new PostKey(v));
                    b.Property(e => e.BlogId).HasConversion(blogKeyConverter);
                });
            */
            modelBuilder.Entity<Order>()
                .HasOne(c => c.Customer)
                .WithMany(u => u.Orders)
                .HasForeignKey(k => k.ClientId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
            

            //Property
            modelBuilder.Entity<Client>().Property(u => u.Name).HasColumnName("Name");
            modelBuilder.Entity<Client>().Property(u => u.Surname).HasColumnName("Surname");
            modelBuilder.Entity<Client>().Property(u => u.Age).HasColumnName("Age");
            modelBuilder.Entity<Client>().Property(u => u.Email).HasColumnName("Email");
            //modelBuilder.Entity<Client>().Property(u => u.Orders).HasColumnName("Заказы");

            //Required указывает, что данное свойство обязательно для установки, то есть будет иметь определение NOT NULL в БД
            modelBuilder.Entity<Client>().Property(b => b.Name).IsRequired();
            modelBuilder.Entity<Client>().Property(b => b.Surname).IsRequired();

            //key
            modelBuilder.Entity<Client>().HasKey(b => b.Id);

            modelBuilder.Entity<Client>().Property(b => b.Age).HasDefaultValue(18);

            //ограничение
            modelBuilder.Entity<Client>().HasCheckConstraint("Age", "Age < 100");
        }
    }

}

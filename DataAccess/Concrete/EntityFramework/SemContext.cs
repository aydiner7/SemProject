using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    // VeriTabanı bağlantısı ve tablo ilişkilendirilmesi.
    // Farklı bilgisayar ortamında server adını değiştirmek yeterli.
    // Farklı veri tabanı ortamında çalışmak için bağlantı adresini değiştirmek yeterli.

    public class SemContext : DbContext
    {
        //DESKTOP-CT296RK   MSI
        //DESKTOP-OPGD9LL   MONSTER
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-CT296RK; Database=Sem; Trusted_Connection=true");
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-OPGD9LL; Database=Sem; Trusted_Connection=true");
        }

        public DbSet<Lesson> Lessons { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<Url> Urls { get; set; }

        public DbSet<IpCheck> IpChecks { get; set; }

        public DbSet<OperationClaim> OperationClaims { get; set; }

        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }




        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<IpCheck>().Property(_ => _.RowVersion).IsRowVersion();
        //}
    }
}

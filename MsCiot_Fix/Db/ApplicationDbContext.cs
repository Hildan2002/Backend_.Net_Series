using Microsoft.EntityFrameworkCore;
using MsCiot_Fix.Models;
using System.Reflection.Metadata;

namespace MsCiot_Fix.Db
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<MesinModel> MesinModel {  get; set; }
        public DbSet<UserModel> UserModel {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MesinModel>()
                .HasOne(p => p.UserModel)
                .WithMany()
                .HasForeignKey(p => p.IdUser);
        }
    }
}

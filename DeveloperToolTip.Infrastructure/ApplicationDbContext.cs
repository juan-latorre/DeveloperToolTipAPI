using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeveloperToolTip.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Developer> Developers { get; set; }
        public DbSet<DeveloperRole> DeveloperRoles { get; set; }
        public DbSet<TopicCategory> TopicCategories { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<TopicContent> TopicContent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la relación Topic -> Developer (CreatedBy)
            modelBuilder.Entity<Topic>()
                .HasOne(t => t.Creator) // Relación con la entidad Developer
                .WithMany() // Un Developer puede estar relacionado con muchos Topics
                .HasForeignKey(t => t.CreatedBy) // Llave foránea: CreatedBy
                .OnDelete(DeleteBehavior.Restrict); // Restricción para evitar eliminaciones en cascada

            // Configuración adicional de otras relaciones si es necesario
            modelBuilder.Entity<Topic>()
                .HasOne(t => t.Category) // Relación con TopicCategory
                .WithMany() // Una categoría puede estar relacionada con muchos Topics
                .HasForeignKey(t => t.CategoryId) // Llave foránea: CategoryId
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TopicContent>()
                .HasOne(tc => tc.Topic)
                .WithMany(t => t.TopicContents)
                .HasForeignKey(tc => tc.TopicId)
                .OnDelete(DeleteBehavior.Restrict); // Evita eliminar Topics con TopicContents relacionados

            modelBuilder.Entity<TopicCategory>()
                .Property(t => t.CreatedDate)
                .HasDefaultValueSql("GETDATE()"); // Valor predeterminado SQL válido para datetime

            modelBuilder.Entity<Topic>()
                .Property(t => t.CreatedDate)
                .HasDefaultValueSql("GETDATE()"); // Valor predeterminado SQL válido para datetime

            modelBuilder.Entity<TopicContent>()
                .Property(t => t.CreatedDate)
                .HasDefaultValueSql("GETDATE()"); // Valor predeterminado SQL válido para datetime

            // Llamar al comportamiento base si es necesario
            base.OnModelCreating(modelBuilder);
        }

    }
}

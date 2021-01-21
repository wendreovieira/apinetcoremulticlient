using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using TemplateMultiClient.Domain.Entities;

namespace TemplateMultiClient.Infra.Context
{
    public class RootContext : DbContext
    {
        public RootContext(DbContextOptions<RootContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();            
        }
    }
}
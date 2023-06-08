using Elmeya_Soft.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Type = Elmeya_Soft.Models.Type;

namespace EntityFrameWorkDemo
{
    public class ApplicationContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public ApplicationContext(IConfiguration configuration) 
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("FirstConnection"));
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public  DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public DbSet<Type> Types  { get; set; }
    }
}

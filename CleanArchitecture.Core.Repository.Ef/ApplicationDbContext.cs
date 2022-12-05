using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Core.Domain;
using CleanArchitecture.Core.Service;
namespace CleanArchitecture.Core.Repository.Ef
{
    public class ApplicationDbContext : DbContext,IApplicationDbContext
    {
        private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

   
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
        AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) : base(options)
        {
            _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
       
        protected override void OnModelCreating(ModelBuilder builder)
        {    
            base.OnModelCreating(builder);
            //builder.ApplyConfiguration(new ChannelTypeConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
        }


        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}


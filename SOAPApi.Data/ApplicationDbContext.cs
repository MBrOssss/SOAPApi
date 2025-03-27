using SOAPApi.Data.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SOAPApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=MyDbConnectionString") // Nazwa musi być zgodna z wpisem w configu
        {
        }

        public DbSet<Doctor> Doctors { get; set; }

        public override async Task<int> SaveChangesAsync()
        {
            OnBeforeSaveChanges();
            return await base.SaveChangesAsync();
        }

        private void OnBeforeSaveChanges()
        {
            ChangeTracker.DetectChanges();
            foreach (var entity in ChangeTracker
                .Entries()
                .Where(x => x.Entity is BaseModel && x.State == EntityState.Modified)
                .Select(x => x.Entity)
                .Cast<BaseModel>())
            {
                entity.UpdatedDate = DateTime.Now;
            }

            foreach (var entity in ChangeTracker
                .Entries()
                .Where(x => x.Entity is BaseModel && x.State == EntityState.Added)
                .Select(x => x.Entity)
                .Cast<BaseModel>())
            {
                entity.CreatedDate = DateTime.Now;
            }
        }
    }
}

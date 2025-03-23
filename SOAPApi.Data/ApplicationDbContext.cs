using SOAPApi.Data.Models;
using System.Data.Entity;

namespace SOAPApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=MyDbConnectionString") // Nazwa musi być zgodna z wpisem w configu
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
    }
}

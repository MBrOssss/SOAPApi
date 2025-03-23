using SOAPApi.CompositeTypes;
using SOAPApi.Data;
using System.Threading.Tasks;

namespace SOAPApi
{
    public class DoctorService : IDoctorService
    {
        public async Task<Doctor> GetDoctor(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var doctor = await context.Doctors.FindAsync(id);

                return new Doctor()
                {
                    Id = doctor.Id,
                    FirstName = doctor.FirstName,
                    LastName = doctor.LastName,
                    Specialization = doctor.Specialization
                };
            }
        }
    }
}
using SOAPApi.CompositeTypes;
using SOAPApi.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SOAPApi
{
    public class DoctorService : IDoctorService
    {
        public async Task<IEnumerable<DoctorDTO>> GetDoctors()
        {
            using (var context = new ApplicationDbContext())
            {
                return await context.Doctors.Select(x => MapToDTO(x)).ToListAsync();
            }
        }

        public async Task<DoctorDTO> GetDoctor(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var doctor = await context.Doctors.FindAsync(id);
                if (doctor == null)
                {
                    throw new KeyNotFoundException($"Doctor with ID {id} not found.");
                }

                return MapToDTO(doctor);
            }
        }

        public async Task<DoctorDTO> AddDoctor(DoctorDTO doctor)
        {
            ValidateDoctor(doctor);

            using (var context = new ApplicationDbContext())
            {
                var newDoctor = new Data.Models.Doctor()
                {
                    FirstName = doctor.FirstName,
                    LastName = doctor.LastName,
                    Specialization = doctor.Specialization,
                };

                context.Doctors.Add(newDoctor);
                await context.SaveChangesAsync();

                return MapToDTO(newDoctor);
            }
        }

        public async Task<DoctorDTO> UpdateDoctor(DoctorDTO doctor)
        {
            ValidateDoctor(doctor);

            using (var context = new ApplicationDbContext())
            {
                var existingDoctor = await context.Doctors.FindAsync(doctor.Id);
                if (existingDoctor == null)
                {
                    throw new KeyNotFoundException($"Doctor with ID {doctor.Id} not found.");
                }

                existingDoctor.FirstName = doctor.FirstName;
                existingDoctor.LastName = doctor.LastName;
                existingDoctor.Specialization = doctor.Specialization;
                await context.SaveChangesAsync();

                return MapToDTO(existingDoctor);
            }
        }

        public async Task DeleteDoctor(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var doctor = await context.Doctors.FindAsync(id);
                if (doctor == null)
                {
                    throw new KeyNotFoundException($"Doctor with ID {id} not found.");
                }

                context.Doctors.Remove(doctor);
                await context.SaveChangesAsync();
            }
        }

        private DoctorDTO MapToDTO(Data.Models.Doctor doctor)
        {
            return new DoctorDTO()
            {
                Id = doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Specialization = doctor.Specialization,
                CreatedDate = doctor.CreatedDate,
                UpdatedDate = doctor.UpdatedDate
            };
        }

        private void ValidateDoctor(DoctorDTO doctor)
        {
            if (doctor == null)
            {
                throw new KeyNotFoundException("Doctor cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(doctor.FirstName))
            {
                throw new KeyNotFoundException("Doctor's first name cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(doctor.LastName))
            {
                throw new KeyNotFoundException("Doctor's last name cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(doctor.Specialization))
            {
                throw new KeyNotFoundException("Doctor's specialization cannot be empty.");
            }
        }
    }
}
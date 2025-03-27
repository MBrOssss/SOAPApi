using SOAPApi.CompositeTypes;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace SOAPApi
{
    [ServiceContract]
    interface IDoctorService
    {
        [OperationContract]
        Task<IEnumerable<DoctorDTO>> GetDoctors();
        
        [OperationContract]
        Task<DoctorDTO> GetDoctor(int id);

        [OperationContract]
        Task<DoctorDTO> AddDoctor(DoctorDTO doctor);

        [OperationContract]
        Task<DoctorDTO> UpdateDoctor(DoctorDTO doctor);

        [OperationContract]
        Task DeleteDoctor(int id);
    }
}

using SOAPApi.CompositeTypes;
using System.ServiceModel;
using System.Threading.Tasks;

namespace SOAPApi
{
    [ServiceContract]
    interface IDoctorService
    {
        [OperationContract]
        Task<Doctor> GetDoctor(int id);
    }
}

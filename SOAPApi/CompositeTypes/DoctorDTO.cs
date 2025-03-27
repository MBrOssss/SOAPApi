using System;
using System.Runtime.Serialization;

namespace SOAPApi.CompositeTypes
{
	[DataContract]
	public class DoctorDTO
	{
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Specialization { get; set; }

        [DataMember]
        public DateTime? CreatedDate { get; set; }

        [DataMember]
        public DateTime? UpdatedDate { get; set; }
    }
}
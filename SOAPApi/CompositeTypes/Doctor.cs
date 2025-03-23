using System.Runtime.Serialization;

namespace SOAPApi.CompositeTypes
{
	[DataContract]
	public class Doctor
	{
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Specialization { get; set; }
    }
}
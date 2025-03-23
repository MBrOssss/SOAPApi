using System.Runtime.Serialization;

namespace SOAPApi.CompositeTypes
{
	[DataContract]
	public enum ResponseState
	{
        [EnumMember]
        OK,
        [EnumMember]
        NotFound,
        [EnumMember]
        Error
    }
}
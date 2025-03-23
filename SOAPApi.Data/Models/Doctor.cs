namespace SOAPApi.Data.Models
{
    public class Doctor : BaseModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Specialization { get; set; }
    }
}

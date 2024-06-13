namespace PersonService.Entities
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public List<ContactInfo> ContactInfos { get; set; }
    }

    public class ContactInfo
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public ContactType Type { get; set; }
        public string Content { get; set; }
    }

    public enum ContactType
    {
        PhoneNumber,
        EmailAddress,
        Location
    }
}

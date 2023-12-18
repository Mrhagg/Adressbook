namespace Adressbook.Interfaces
{
    public interface IContact
    {
        string City { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
        string PostalCode { get; set; }
        string StreetName { get; set; }
    }
}
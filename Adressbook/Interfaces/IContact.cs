namespace Adressbook.Interfaces
{

    /// <summary>
    /// Shows all possible string names from Icontact that can be implementet in the consolapp.
    /// </summary>
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
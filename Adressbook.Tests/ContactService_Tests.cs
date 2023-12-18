using Adressbook.Interfaces;
using Adressbook.Models;
using Adressbook.Services;
using NuGet.Frameworks;

namespace Adressbook.Tests;

public class ContactService_Tests
{
    [Fact]
    public void AddToList_AddCustomersToList_ThenReturnTrue()
    {
        // Arrange 
        IContactService contactService = new ContactService();
        IContact contact = new Contact { FirstName = "William", LastName = "Hägg", Email = "William@domain.com", City = "Halmstad", PhoneNumber = "022-222", PostalCode = "02022", StreetName = "Malcusgatan" };
        
        // Act
        bool result = contactService.AddToList(contact);


        // Assert
       Assert.True(result);
    }

    [Fact]
    public void GetList_GetAllCustomerList_ThenReturnListOfCustomer()
    {
        // Arrange
        IContactService contactService = new ContactService();
        IContact contact = new Contact { FirstName = "William", LastName = "Hägg", Email = "William@domain.com", City = "Halmstad", PhoneNumber = "022-222", PostalCode = "02022", StreetName = "Malcusgatan" };
        contactService.AddToList(contact);
        // Act
        IEnumerable<IContact> result = contactService.GetContacts();


        //Assert
        Assert.NotNull(result);
       IContact returned_contact = result.FirstOrDefault()!;
       Assert.NotNull(returned_contact);
       Assert.Equal(contact.FirstName, returned_contact.FirstName);
    }
}

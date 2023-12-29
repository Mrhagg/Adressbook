using Adressbook.Interfaces;
using Adressbook.Models;
using Adressbook.Services;
using NuGet.Frameworks;

namespace Adressbook.Tests;


public class ContactService_Tests
{

    /// <summary>
    /// Here we are testing the functionality of adding a contact to a list, and verifying that the addition of a contact was succesfull.
    /// </summary>
    
    [Fact]
    public void AddToList_AddContactsToList_ThenReturnTrue()
    {
        // Arrange 
        IContactService contactService = new ContactService();
        IContact contact = new Contact { FirstName = "William", LastName = "Hägg", Email = "William@domain.com", City = "Halmstad", PhoneNumber = "022-222", PostalCode = "02022", StreetName = "Malcusgatan" };
        
        // Act
        var serviceResult = contactService.AddContactToList(contact);
        bool targeted_result = contactService.AddToList(contact);

        // Assert
        Assert.NotNull(serviceResult);
        Assert.True(targeted_result);
        
    }


    /// <summary>
    ///  Here we are testing the functionality of recieving a list of contacts from a Contactservice.
    ///  /// </summary>
    [Fact]
    public void GetList_GetAllContactList_ThenReturnListOfContacts()
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

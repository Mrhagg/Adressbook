using Adressbook.Models.Responses;
namespace Adressbook.Interfaces;

public interface IContactService
{

    /// <summary>
    /// Adds a contact to the contactlist of your choice.
    /// </summary>
    /// <param name="contact">a contact of the type IContact</param>
    /// <returns>If true adds a contact to the contactlist in my consolapp.</returns>
    ServiceResult AddContactToList(IContact contact);

   /// <summary>
   /// Shows the contactlist of names that been put there. 
   /// </summary>
   /// <returns>If true, shows the information about the contacts in the contactlist</returns>
    ServiceResult GetContactsFromList();

    /// <summary>
    /// Removes a contact by writing specific contact-email.
    /// </summary>
    /// <param name="email">enters your email as a string.</param>
    /// <returns>returns true if contact is deleted by specific email, else failed.</returns>
    ServiceResult DeleteContactByEmail (string email);

    /// <summary>
    /// Saves the contacts in the contactlist.
    /// </summary>
    /// <returns>If true saves contacts to the contactlist, else returns null.</returns>
    IEnumerable<IContact> GetContacts();

    /// <summary>
    /// Shows if the AddToList method in my Adressbook.test is true or false.
    /// </summary>
    /// <param name="contact">a contact of the type IContact</param>
    /// <returns>If true test will be succesfull, else test will have errors</returns>
    bool AddToList(IContact contact);
}

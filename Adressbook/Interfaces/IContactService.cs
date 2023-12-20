using Adressbook.Models.Responses;
namespace Adressbook.Interfaces;

public interface IContactService
{

    /// <summary>
    /// Adds a contact to the contactlist.
    /// </summary>
    /// <param name="contact">a contact of the type IContact</param>
    /// <returns>If true adds a contact to the contactlist in my consolapp.</returns>
    ServiceResult AddContactToList(IContact contact);

   /// <summary>
   /// 
   /// </summary>
   /// <returns></returns>
    ServiceResult GetContactsFromList();

    /// <summary>
    /// Removes a contact from the contactlist.
    /// </summary>
    /// <param name="contact">a contact of the type IContact</param>
    /// <returns>If true removes a contact from the contact list, else is null.</returns>
    ServiceResult DeleteContactFromList(IContact contact);


    /// <summary>
    /// Removes a contact by writing specific contact-email.
    /// </summary>
    /// <param name="email">enters yuor email as a string.</param>
    /// <returns>returns true if contact is deleted by specific email, else failed.</returns>
    ServiceResult DeleteContactByEmail (string email);

    /// <summary>
    /// Saves the contacts in the contactlist.
    /// </summary>
    /// <returns>If true saves contacts to the contactlist, else returns null.</returns>
    IEnumerable<IContact> GetContacts();


    bool AddToList(IContact contact);
}

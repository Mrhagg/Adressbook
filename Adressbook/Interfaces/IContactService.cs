using Adressbook.Models;
using Adressbook.Models.Responses;

namespace Adressbook.Interfaces;

public interface IContactService
{
    ServiceResult AddContactToList(IContact contact);

    ServiceResult GetContactsFromList();

    ServiceResult DeleteContactFromList(IContact contact);

    ServiceResult DeleteContactByEmail (string email);

    IEnumerable<IContact> GetContacts();

    bool AddToList(IContact contact);
}

using Adressbook.Models.Responses;


namespace Adressbook.Interfaces;

public interface IContactService
{
    ServiceResult AddContactToList(IContactModels contact);

    ServiceResult GetContactsFromList();

    ServiceResult DeleteContactFromList(IContactModels contact);

    ServiceResult DeleteContactByEmail (string email);

    


}

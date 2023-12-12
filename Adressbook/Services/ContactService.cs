using Adressbook.Interfaces;
using Adressbook.Models.Responses;
using Newtonsoft.Json;
using System.Diagnostics;



namespace Adressbook.Services;


public class ContactService : IContactService
{
    private readonly FileService _fileService = new FileService(@"C:\my-projects\Adressbook\content.json");

    private List<IContactModels> _contacts = new List<IContactModels>();

    public ServiceResult AddContactToList(IContactModels contact)
    {
        ServiceResult response = new ServiceResult();

        try
        {
            if (!_contacts.Any(x => x.Email == contact.Email))
            {
                _contacts.Add(contact);
                _fileService.SaveContentToFile(JsonConvert.SerializeObject(_contacts, Formatting.Indented));
                response.Status = Enums.ServiceResultStatus.SUCCESSED;
            }
            else
            {
                response.Status = Enums.ServiceResultStatus.ALREADY_EXISTS;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            response.Status = Enums.ServiceResultStatus.FAILED;
            response.Result = ex.Message;
        }
        return response;
    }

    public IEnumerable<IContactModels> GetContacts() 
    {
        try
        {
            var content = _fileService.GetContentFromFile();
            if (!string.IsNullOrEmpty(content))
            {
                _contacts = JsonConvert.DeserializeObject<List<IContactModels>>(content)!;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return _contacts;
    }


    {
        ServiceResult response = new ServiceResult();

        try
        {
            response.Status = Enums.ServiceResultStatus.SUCCESSED;
            return new ServiceResult { Status = Enums.ServiceResultStatus.SUCCESSED, };
        }
        else
        {
            return new ServiceResult { Status = Enums.ServiceResultStatus.FAILED };
        }
        }



    public ServiceResult DeleteContactFromList(IContactModels contact)
    {
        ServiceResult response = new ServiceResult();

        try
        {
            if (!_contacts.Any(x => x.Email == contact.Email))
            {
                _contacts.Remove(contact);
                response.Status = Enums.ServiceResultStatus.SUCCESSED;
            }
            else
            {
                response.Status = Enums.ServiceResultStatus.ALREADY_EXISTS;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            response.Status = Enums.ServiceResultStatus.FAILED;
            response.Result = ex.Message;
        }

        return response;

    }

    public ServiceResult DeleteContactByEmail(string email)
    {
        var contactToRemove = _contacts.FirstOrDefault(c => c.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

        if (contactToRemove != null)
        {
            _contacts.Remove(contactToRemove);
            return new ServiceResult { Status = Enums.ServiceResultStatus.SUCCESSED, };
        }
        else
        {
            return new ServiceResult { Status = Enums.ServiceResultStatus.FAILED };
        }
    }
  }

    



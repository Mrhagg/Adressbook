using Adressbook.Interfaces;
using Adressbook.Models;
using Adressbook.Models.Responses;
using Newtonsoft.Json;
using System.Diagnostics;



namespace Adressbook.Services;


public class ContactService : IContactService
{
    private readonly FileService _fileService = new FileService(@"C:\my-projects\Adressbook\Adressbook\content.json");

    private List<IContact> _contacts = new List<IContact>();

    public ContactService() { GetContacts(); }
    public ServiceResult AddContactToList(IContact contact)
    {
       ServiceResult response = new ServiceResult();

        var settings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.All,
            Formatting = Formatting.Indented
        };

        try
        {
            if (!_contacts.Any(x => x.Email == contact.Email))
            {
                _contacts.Add(contact);
                _fileService.SaveContentToFile(JsonConvert.SerializeObject(_contacts,settings));
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


    public IEnumerable<IContact> GetContacts()
    {
        var settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        };

        try
        {
            var content = _fileService.GetContentFromFile();
            if (!string.IsNullOrEmpty(content))
            {
                _contacts = JsonConvert.DeserializeObject<List<IContact>>(content, settings)!;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return _contacts;
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



    public ServiceResult DeleteContactFromList(IContact contact)
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


    public ServiceResult GetContactsFromList()
    {
        ServiceResult response = new ServiceResult();

        try
        {
            response.Status = Enums.ServiceResultStatus.SUCCESSED;
            response.Result = _contacts;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            response.Status = Enums.ServiceResultStatus.FAILED;
            response.Result = ex.Message;
        }

        return response;
    }

  
    public bool AddToList(IContact contact)
    {
       try
        {
            _contacts.Add(contact);
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
       
    }
}

 

    
  

    



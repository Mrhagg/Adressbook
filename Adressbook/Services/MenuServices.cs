using Adressbook.Interfaces;
using Adressbook.Models;
namespace Adressbook.Services;


public interface IMenuServices
{
    void ShowMainMenu();

}

public class MenuServices : IMenuServices
{

    private readonly IContactService _contactService = new ContactService();

  /// <summary>
  /// Shows the starting Menu when u open the consolapplication, and gives u multipel choices to chose from.
  /// </summary>
    public void ShowMainMenu()
    {
        while (true)
        {
            DisplayMenuTitle("KONTAKTMENY");
            Console.WriteLine($"{"1.",-3} Lägg till kontakt");
            Console.WriteLine($"{"2.",-3} Visa kontaktlista");
            Console.WriteLine($"{"3.",-3} Klicka här för att ta bort en kontakt med email");
            Console.WriteLine($"{"0.",-3} Klicka här för att stänga ner sidan");
            Console.WriteLine();
            Console.Write("Meny alternativ:  ");
           

            var option = Console.ReadLine();

            switch (option) {

                case "1":
                    ShowAddContactOption();
                    break;
                case "2":
                    ShowViewContactListOption();
                    break;
                case "0":
                    ShowExitApplicationOption();
                    break;
                case "3":
                    ShowDeleteContactOption();
                    break;

                default:
                    Console.WriteLine("Alternativet du valt fungerar inte, försök igen");
                    Console.ReadKey();
                    break;
            }
        }
    }

   /// <summary>
   /// This method shows us how we can delete a contact from the contactlist, also how we can remove a contact if u write the contacts emailadress.
   /// </summary>
    private void ShowDeleteContactOption()
    {
        DisplayMenuTitle("Ta bort en kontakt från listan");
        Console.Write("Ange en e-postadress för kontakten du vill ta bort: ");
        var email = Console.ReadLine();

        var result = _contactService.DeleteContactByEmail(email!);

        switch (result.Status)
        {
            case Enums.ServiceResultStatus.SUCCESSED:
                Console.WriteLine("Kontakten har tagits bort framgångsrikt");
                break;

            case Enums.ServiceResultStatus.NOT_FOUND:
                Console.WriteLine("Kontakten med den angivna e-postadressen hittades inte");
                break;

            default:
                Console.WriteLine("Något gick fel. Se felmeddelande: " + result.Result?.ToString());
                break;
        }

        DisplayPressAnyKey();
    }
    
    /// <summary>
    /// This one shows us a choice if we want to exit the application
    /// </summary>
    private void ShowExitApplicationOption()
    {
        Console.Clear();
        Console.Write("Är du säker på att du vill avsluta applikationen? (Ja/Nej): ");
        var option = Console.ReadLine() ?? "";

        if (option.Equals("Ja", StringComparison.CurrentCultureIgnoreCase))
            Environment.Exit(0);
        

    }

    /// <summary>
    /// This shows up when u want to create a new contact in your contactlist, and also delcares if the contact was added or not.
    /// </summary>
    private void ShowAddContactOption()
    {
        var contactModels = new Contact();

        DisplayMenuTitle("Lägg till ny kontakt");

        Console.Write("Förnamn:  ");
        contactModels.FirstName = Console.ReadLine() ?? "";

        Console.Write("Efternamn:  ");
        contactModels.LastName = Console.ReadLine() ?? "";

        Console.Write("Telefonnummer:  ");
        contactModels.PhoneNumber = Console.ReadLine() ?? "";

        Console.Write("EmailAdress:  ");
        contactModels.Email = Console.ReadLine() ?? "";

        Console.Write("Gatuadress:  ");
        contactModels.StreetName = Console.ReadLine() ?? "";

        Console.Write("Stad:  ");
        contactModels.City = Console.ReadLine() ?? "";

        Console.Write("Postkod:  ");
        contactModels.PostalCode = Console.ReadLine() ?? "";

        var res = _contactService.AddContactToList(contactModels);

        switch (res.Status)
        {
            case Enums.ServiceResultStatus.SUCCESSED:
                Console.WriteLine("Kontakten lyckades läggas till i listan.");
                break;

            case Enums.ServiceResultStatus.ALREADY_EXISTS:
                Console.WriteLine("Kontakten finns redan i listan.");
                break;

            case Enums.ServiceResultStatus.FAILED:
                Console.WriteLine("Kontakten kunde inte läggas till i listan.");
                Console.WriteLine("Se felmeddelande :: " + res.Result.ToString());
                break;
        }

        DisplayPressAnyKey();

    }

   /// <summary>
   /// Shows your contactlist options u got. 
   /// </summary>
    private void ShowViewContactListOption()
    {
        DisplayMenuTitle("KONTAKT LISTA");
        var res = _contactService.GetContactsFromList();

        if (res.Status == Enums.ServiceResultStatus.SUCCESSED)
        {
            if (res.Result is List<IContact> contactlist)
            {

                if (!contactlist.Any())
                {
                    Console.WriteLine("Inga kontaker hittades.");
                }
                else
                {
                    foreach (var contact in contactlist)
                    {
                        Console.WriteLine($" Namn: {contact.FirstName}\n Efternamn: {contact.LastName}\n Telefonnummer: {contact.PhoneNumber}\n Gatuadress: {contact.StreetName}\n Stad: {contact.City}\n Postkod: {contact.PostalCode}\n EmailAdress: <{contact.Email}>\n ");
                    }
                }
            }
        }

        DisplayPressAnyKey();
    }


    
   
    /// <summary>
    /// Shows the menu titel in your consolapplication.
    /// </summary>
    /// <param name="title">titel shows the name of the menu, and in this case the name is ''KONTAKTMENY''</param>
    private void DisplayMenuTitle(string title)
    {
        Console.Clear();
        Console.WriteLine($"-----------------------------------------  {title}  -------------------------------------------------------");
        Console.WriteLine();
    }

   /// <summary>
   /// A short key command that makes it easy in the consolapp to use any key on your keyboard to navigate further.
   /// </summary>
    private void DisplayPressAnyKey()
    {
        Console.WriteLine();
        Console.WriteLine("Tryck på valfri tangent för att fortsätta");
        Console.WriteLine("\n-----------------------------------------------------------------------------------------------------------------------");
        Console.ReadKey();
    }
}

using System.Text.RegularExpressions;
using System.Xml.Linq;

class Contact
{
    public string Name { get; set; }
    public string ID { get; set; }
    public string PhoneNumber { get; set; }
}

class Program
{
    public static List<Contact> ProcessContacts(string inputFilePath)
    {
        string[] lines = File.ReadAllLines(inputFilePath);
        List<Contact> contacts = new List<Contact>();

        Regex phoneRegex = new Regex(@"\+395\d{3}\d{2}\d{2}");

        Contact currentContact = new Contact();

        foreach (string line in lines)
        {
            if (line.Contains("+395"))
            {
                currentContact.PhoneNumber = line;
            }
            else if (Regex.IsMatch(line, @"\p{IsCyrillic}"))
            {
                currentContact.Name = line;
            }
            else
            {
                currentContact.ID = line;
            }

            if (currentContact.Name != null && currentContact.ID != null && currentContact.PhoneNumber != null)
            {
                contacts.Add(currentContact);
                currentContact = new Contact();
            }
        }

        XElement contactsXml = new XElement("Contacts",
            from contact in contacts
            select new XElement("Contact",
                new XElement("Name", contact.Name),
                new XElement("ID", contact.ID),
                new XElement("PhoneNumber", contact.PhoneNumber)
            )
        );

        contactsXml.Save("C:\\Users\\student\\43\\UPR2\\UPR2\\UPR2\\contacts.xml");

        return contacts;
    }

    public static string SearchByName(List<Contact> contacts, string name)
    {
        return contacts.FirstOrDefault(c => c.Name == name)?.PhoneNumber;
    }

    public static string SearchByID(List<Contact> contacts, string id)
    {
        return contacts.FirstOrDefault(c => c.ID == id)?.PhoneNumber;
    }


}

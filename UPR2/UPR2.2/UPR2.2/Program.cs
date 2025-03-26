using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Linq;

class Contact
{
    public string Name { get; set; }
    public string ContactId { get; set; }
    public string Phone { get; set; }

    public Contact(string name, string contactId, string phone)
    {
        Name = name;
        ContactId = contactId;
        Phone = phone;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string inputFilePath = "input2.txt";
        string outputFilePath = "contacts.xml";
        Console.WriteLine(inputFilePath);
        List<Contact> contacts = ParseContactsFromFile(inputFilePath);

        GenerateXml(contacts, outputFilePath);


        Console.WriteLine($"XML файлът е генериран успешно в: {outputFilePath}");
    }

    static Contact ParseLine(string line)
    {
        string phonePattern = @"\+395\d{3}\d{2}\d{2}";

        Match phoneMatch = Regex.Match(line, phonePattern);
        if (phoneMatch.Success)
        {
            string phone = phoneMatch.Value;
            string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string name = null;
            string contactId = null;

            foreach (var part in parts)
            {
                if (long.TryParse(part, out long id) && part.Length == 9)
                {
                    contactId = part;
                }
                else if (!long.TryParse(part, out _))
                {
                    name = part;
                }
            }

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(contactId))
            {
                return new Contact(name, contactId, phone);
            }
        }

        return null;
    }

    static List<Contact> ParseContactsFromFile(string filePath)
    {
        List<Contact> contacts = new List<Contact>();

        foreach (var line in File.ReadLines(filePath))
        {
            var contact = ParseLine(line.Trim());
            if (contact != null)
            {
                contacts.Add(contact);
            }
        }

        return contacts;
    }

    static void GenerateXml(List<Contact> contacts, string outputFile)
    {
        XElement root = new XElement("contacts");

        foreach (var contact in contacts)
        {
            XElement contactElement = new XElement("contact",
                new XElement("name", contact.Name),
                new XElement("id", contact.ContactId),
                new XElement("phone", contact.Phone)
            );

            root.Add(contactElement);
        }

        XDocument doc = new XDocument(
            new XDeclaration("1.0", "utf-8", null),
            root
        );

        doc.Save(outputFile);
    }
}

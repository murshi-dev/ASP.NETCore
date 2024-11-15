class Program
{
    static void Main()
    {
        ContactManager contactManager = new ContactManager();
        bool option = true;
        while (option)
        {
            Console.WriteLine("1.Add Contact");
            Console.WriteLine("2.Display Contact");
            Console.WriteLine("3.Edit Contact");
            Console.WriteLine("4. Remove Contact");
            Console.Write("Enter an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter a name to add: ");
                    string nameToAdd = Console.ReadLine();
                    //use Add method to list
                    contactManager.Add(nameToAdd);
                    Console.WriteLine($"{nameToAdd} has been added");
                    break;
                case "2":
                    Console.WriteLine("Contacts in the list are: ");
                    var contact = contactManager.GetContacts();//all the results are in 'contact' variable

                    //check if contact has eni items using Any()
                    if (contact.Any())
                    {
                        //use foreach loop through the contact variable
                        contact.ForEach(c => Console.WriteLine(c.Name));//LINQ method to loop through the list
                    }
                    else
                    {
                        Console.WriteLine("No Contact in the list");
                    }
                    break;
                case "3":
                    Console.Write("Enter the name to edit: ");
                    string oldName = Console.ReadLine();

                    if (contactManager.ListItemExists(oldName))
                    {
                        Console.WriteLine("Enter the new name: ");
                        string newName = Console.ReadLine();
                        contactManager.EditContact(oldName, newName);
                        Console.WriteLine($"{oldName} has been updated");
                    }
                    else
                    {
                        Console.WriteLine($"{oldName} does not exist in the list");
                    }
                    break;
                case "4":
                    Console.Write("Enter the name to remove: ");
                    string nameToRemove = Console.ReadLine();
                    if (contactManager.ListItemExists(nameToRemove))
                    {
                        contactManager.RemoveContact(nameToRemove);
                        Console.WriteLine($"{nameToRemove} has been removed");
                    }
                    else
                    {
                        Console.WriteLine($"{nameToRemove} doe snot exist in the list");
                    }
                    break;
                default:
                    {
                        Console.WriteLine("Invalid input. Enter valid input");
                        break;
                    }
            
            }
        }
    }
}
class ContactManager
{
    //declare  a list
    private List<Contact> contactList;
    //constructor
    public ContactManager()
    {
        //initialise the list
        contactList = new List<Contact>();
    }
    //define the Add method
    public void Add(string name)
    {
        //add the name to the list
        contactList.Add(new Contact { Name = name });
    }
    //define method to display contact list
    public List<Contact> GetContacts()
    {
        return contactList.ToList();
    }
    //define a method to edit the item 
    public void EditContact(string oldname, string newname)
    {
        //finding the old name
        var contactToEdit = contactList.FirstOrDefault(c => c.Name.Equals(oldname));
        //replace old name with new name
        contactToEdit.Name = newname;
    }

    //define a method to check if the contact exist in the list
    public bool ListItemExists(string name)
    {
        return contactList.Any(c => c.Name.Equals(name));
    }

    //define a method to delete the item
    public bool RemoveContact(string name)
    {
        //finding the name
        var contactToRemove = contactList.FirstOrDefault(c => c.Name.Equals(name));
        //remove process
        contactList.Remove(contactToRemove);
        return true;
    }
}
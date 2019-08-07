using SQLiteDemo.Database.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteDemo.Services.Abstractions
{
    public interface IContactRepository
    {
        List<ContactInfo> GetAllContactsData();

        //Get Specific Contact data  
        ContactInfo GetContactData(int contactID);

        // Delete all Contacts Data  
        void DeleteAllContacts();

        // Delete Specific Contact  
        void DeleteContact(int contactID);

        // Insert new Contact to DB   
        void InsertContact(ContactInfo contact);

        // Update Contact Data  
        void UpdateContact(ContactInfo contact);
    }
}

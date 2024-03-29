﻿using SQLite;
using SQLiteDemo.Database.Connection.Abstractions;
using SQLiteDemo.Database.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace SQLiteDemo.Helpers
{
    public class DatabaseHelper
    {
        static SQLiteConnection sqliteconnection;
        public const string DbFileName = "Contacts.db";

        public DatabaseHelper()
        {
            sqliteconnection = DependencyService.Get<IDatabaseConnection>().DbConnection();
            sqliteconnection.CreateTable<ContactInfo>();
        }

        // Get All Contact data      
        public List<ContactInfo> GetAllContactsData()
        {
            return (from data in sqliteconnection.Table<ContactInfo>()
                    select data).ToList();
        }

        //Get Specific Contact data  
        public ContactInfo GetContactData(int id)
        {
            return sqliteconnection.Table<ContactInfo>().FirstOrDefault(t => t.Id == id);
        }

        // Delete all Contacts Data  
        public void DeleteAllContacts()
        {
            sqliteconnection.DeleteAll<ContactInfo>();
        }

        // Delete Specific Contact  
        public void DeleteContact(int id)
        {
            sqliteconnection.Delete<ContactInfo>(id);
        }

        // Insert new Contact to DB   
        public void InsertContact(ContactInfo contact)
        {
            sqliteconnection.Insert(contact);
        }

        // Update Contact Data  
        public void UpdateContact(ContactInfo contact)
        {
            sqliteconnection.Update(contact);
        }
    }
}

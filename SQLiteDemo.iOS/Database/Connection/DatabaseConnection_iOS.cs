﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using SQLite;
using SQLiteDemo.Database.Connection.Abstractions;
using SQLiteDemo.iOS.Database.Connection;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_iOS))]
namespace SQLiteDemo.iOS.Database.Connection
{
    public class DatabaseConnection_iOS : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "DemoDb.db3";
            string personalFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder = Path.Combine(personalFolder + "..", "Library");
            var path = Path.Combine(libraryFolder, dbName);
            return new SQLiteConnection(path);
        }
    }
}
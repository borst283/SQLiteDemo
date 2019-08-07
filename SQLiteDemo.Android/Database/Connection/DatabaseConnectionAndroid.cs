using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using SQLiteDemo.Database.Connection.Abstractions;
using SQLiteDemo.Droid.Database.Connection;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnectionAndroid))]
namespace SQLiteDemo.Droid.Database.Connection
{
    public class DatabaseConnectionAndroid : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "DemoDb.db3";
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);
            return new SQLiteConnection(path);
        }
    }
}
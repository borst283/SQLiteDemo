using SQLite;
using SQLiteDemo.Database.Connection.Abstractions;
using SQLiteDemo.Database.Tables;
using System;
using System.Collections.ObjectModel;
using System.IO;
using Xamarin.Forms;

namespace SQLiteDemo
{
    public partial class App : Application
    {
        private SQLiteConnection database;
        public ObservableCollection<User> Users { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

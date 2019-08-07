using SQLite;
using SQLiteDemo.Database.Connection.Abstractions;
using SQLiteDemo.Database.Tables;
using SQLiteDemo.Services;
using SQLiteDemo.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SQLiteDemo.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private ICommand _newContact;
        private ICommand _editContact;
        private ICommand _deleteContact;
        private ICommand _deleteAllContact;
        private ContactRepository _contactRepository;


        public List<ContactInfo> contactList;

        public List<ContactInfo> ContactList
        {
            get => contactList;
            set
            {
                contactList = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand NewUserCommand
        {
            get => _newContact;
            private set
            {
                _newContact = value;
            }
        }

        public ICommand EditContactCommand
        {
            get => _editContact;
            private set
            {
                _editContact = value;
            }
        }

        public ICommand DeleteContactCommand
        {
            get => _deleteContact;
            private set
            {
                _deleteContact = value;
            }
        }

        public ICommand DeleteAllContactsCommand
        {
            get => _deleteAllContact;
            private set
            {
                _deleteAllContact = value;
            }
        }

        public MainPageViewModel()
        {
            RefreshData();
            NewUserCommand = new Command(NewUserCommandHandler);
            EditContactCommand = new Command(EditContactCommandHandler);
            DeleteContactCommand = new Command(DeleteContactCommandHandler);
            DeleteAllContactsCommand = new Command(DeleteAllContactsCommandHandler);
        }

        internal void RefreshData()
        {
            _contactRepository = new ContactRepository();
            try
            {
                ContactList = _contactRepository.GetAllContactsData();
            }
            catch (Exception e)
            {

            }
        }

        private void NewUserCommandHandler()
        {
            App.Current.MainPage.Navigation.PushAsync(new AddContactPage());
        }

        private void EditContactCommandHandler(object obj)
        {
            ContactInfo contact = ((Button)obj).BindingContext as ContactInfo;
            App.Current.MainPage.Navigation.PushAsync(new AddContactPage(contact));
        }

        private async void DeleteContactCommandHandler(object obj)
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Deleete this contact", "Do you want to deelte this contact?", "Yes", "No");
            if (isUserAccept)
            {
                ContactInfo contact = ((Button)obj).BindingContext as ContactInfo;
                _contactRepository.DeleteContact(contact.Id);
                RefreshData();
            }
        }

        private async void DeleteAllContactsCommandHandler()
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Deleete All Contact", "Do you want to deelte all contacts?", "OK", "Cancel");
            if (isUserAccept)
            {
                _contactRepository.DeleteAllContacts();
                RefreshData();
            }
        }

        #region INotifyPropertyChanged      
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

using SQLiteDemo.Database.Tables;
using SQLiteDemo.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SQLiteDemo.ViewModels
{
    public class AddContactViewModel : INotifyPropertyChanged
    {
        private ContactInfo _contact;
        private ContactRepository _contactRepository;
        private ICommand _addContactCommand;

        public string Name
        {
            get => _contact.Name;
            set
            {
                _contact.Name = value;
                NotifyPropertyChanged();
            }
        }

        public string MobileNumber
        {
            get => _contact.MobileNumber;
            set
            {
                _contact.MobileNumber = value;
                NotifyPropertyChanged();
            }
        }

        public string Age
        {
            get => _contact.Age;
            set
            {
                _contact.Age = value;
                NotifyPropertyChanged();
            }
        }

        public string Gender
        {
            get => _contact.Gender;
            set
            {
                _contact.Gender = value;
                NotifyPropertyChanged();
            }
        }

        public string Address
        {
            get => _contact.Address;
            set
            {
                _contact.Address = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand AddContactCommand
        {
            get => _addContactCommand;
            private set
            {
                _addContactCommand = value;
            }
        }

        public AddContactViewModel(ContactInfo contact = null)
        {
            if (contact == null)
                _contact = new ContactInfo();
            else
                _contact = contact;
            _contactRepository = new ContactRepository();

            AddContactCommand = new Command(AddContactCommandHandler);
        }

        public async void AddContactCommandHandler()
        {
            var _object = _contactRepository.GetContactData(_contact.Id);

            if(_object == null)
            {
                bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Add Contact", "Do you want to save Contact details?", "OK", "Cancel");
                if (isUserAccept)
                {
                    _contactRepository.InsertContact(_contact);
                }
            }
            else
            {
                bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Add Contact", "Do you want to update Contact details?", "OK", "Cancel");
                if (isUserAccept)
                {
                    _contactRepository.UpdateContact(_contact);
                }
            }
            await App.Current.MainPage.Navigation.PopAsync();


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

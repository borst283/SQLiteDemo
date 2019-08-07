using SQLite;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SQLiteDemo.Database.Tables
{
    [Table("User")]
    public class User : INotifyPropertyChanged
    {
        private int _id;
        [PrimaryKey,AutoIncrement]
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        private string _name;
        [NotNull]
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private Uri _image;
        public Uri Uri
        {
            get => _image;
            set
            {
                _image = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

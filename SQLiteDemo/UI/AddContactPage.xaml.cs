using SQLiteDemo.Database.Tables;
using SQLiteDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteDemo.UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddContactPage : ContentPage
    {
        public AddContactPage(ContactInfo _contact = null)
        {
            InitializeComponent();

            BindingContext = new AddContactViewModel(_contact);
        }
    }
}
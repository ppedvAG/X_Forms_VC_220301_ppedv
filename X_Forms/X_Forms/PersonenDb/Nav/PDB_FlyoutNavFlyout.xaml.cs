using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X_Forms.PersonenDb.Nav
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PDB_FlyoutNavFlyout : ContentPage
    {
        public ListView ListView;

        public PDB_FlyoutNavFlyout()
        {
            InitializeComponent();

            BindingContext = new PDB_FlyoutNavFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class PDB_FlyoutNavFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<PDB_FlyoutNavFlyoutMenuItem> MenuItems { get; set; }

            public PDB_FlyoutNavFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<PDB_FlyoutNavFlyoutMenuItem>(new[]
                {
                    new PDB_FlyoutNavFlyoutMenuItem { Id = 0, Title = "List" , TargetType=typeof(PersonenDb.Pages.Pg_List)},
                    new PDB_FlyoutNavFlyoutMenuItem { Id = 1, Title = "Add new person" , TargetType=typeof(PersonenDb.Pages.Pg_Add)},
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}
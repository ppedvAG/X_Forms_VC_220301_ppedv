using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace X_Forms
{
    public partial class MainPage : ContentPage
    {

        //Property zum Zwischenspeichern der Personenliste (ObservableCollection ist eine generische Liste, welche die GUI
        //automatisch über Veränderungen innerhalb der Liste informiert)
        public ObservableCollection<Person> Personenliste { get; set; } = new ObservableCollection<Person>()
        {
            new Person(){Vorname="Anna", Nachname="Nass"},
            new Person(){Vorname="Rainer", Nachname="Zufall"}
        };

        //Konstruktor
        public MainPage()
        {
            //Initialisierung der UI (Xaml-Datei). Sollte immer erste Aktion des Konstruktors sein
            InitializeComponent();

            //Neuzuweisung einer UI-Property über die x:Name-Property des Steuerelements
            Lbl_Main.Text = "Hallo Xamarin";

            //Durch Setzen des BindingContextes nehmen Kurzbindungen aus dem XAML-Code automatisch Bezug auf die Properties
            //des im BindingContext gesetzten Objekts
            this.BindingContext = this;
        }

        private void Btn_KlickMich_Clicked(object sender, EventArgs e)
        {
            //Neuzuweisung einer Property des Eventauslösenden Steuerelements
            (sender as Button).Text = "Button wurde betätigt";
        }

        private void Ibtn_Beispiel_Clicked(object sender, EventArgs e)
        {
            //Neuzuweisung der Textproperty des Labels mit dem Ausgewählten Element des Pickers
            Lbl_Main.Text = Pkr_Monkeys.SelectedItem?.ToString();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Person", $"{(StL_DataBinding.BindingContext as Person).Nachname}", "OK");

            //Änderung einer Property des BindingContexts des StackLayouts (INotifyPropertyChanged informiert GUI über Veränderung (vgl. Person.cs))
            (StL_DataBinding.BindingContext as Person).Vorname = "Anna";
        }

        private void Btn_New_Clicked(object sender, EventArgs e)
        {
            //Hinzufügen einer neuen Person zur Liste
            Personenliste.Add(new Person() { Vorname = "Hannes", Nachname = "Müller" });
        }

        private async void Mit_Delete_Clicked(object sender, EventArgs e)
        {
            //Anzeige einer 'MessageBox' und Abfrage der User-Antwort
            bool result = await DisplayAlert("Löschen", "Soll diese Person wirklich gelöscht werden?", "Ja", "Nein");

            if (result)
            {
                //Löschen eines Listeneintrags
                Person person = (sender as MenuItem).CommandParameter as Person;
                Personenliste.Remove(person);
            }
        }
    }
}

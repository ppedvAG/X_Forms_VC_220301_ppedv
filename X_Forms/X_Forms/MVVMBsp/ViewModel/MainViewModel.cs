﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace X_Forms.MVVMBsp.ViewModel
{
    //Im ViewModel-Teil eines MVVM-Programms werden Klassen definiert, welche als Verbindungsstück zwischen den Views und den Modelklassen fungieren.
    //Diese Klassen sind die einzigen Programmteile, welche Referenzen auf Model-Klassen beinhalten. Sie selbst sind jeweils einem View zugrordnet,
    //mit welchem sie (nur) über den BindingContext des jeweiligen Views verbunden sind.
    //INotifyPropertyChanged informiert die GUI über Veränderungen in den Daten
    public class MainViewModel : INotifyPropertyChanged
    {
        //View-Property für z.B. DisplayAlerts
        public Page ContextPage { get; set; }

        public string NeuerName { get; set; }
        public int NeuesAlter { get; set; }

        //Property zur Repräsentation der Anzahl der geladenen Personen (verlinkt an die Model-Klasse)
        public ObservableCollection<Model.Person> Personenliste 
        { 
            get { return Model.Person.Personenliste; } 
            set { Model.Person.Personenliste = value; } 
        }

        //Command-Properties
        public Command HinzufuegenCmd { get; set; }
        public Command LöschenCmd { get; set; }

        //Konstruktor
        public MainViewModel()
        {
            //Initialisierung der Commands mit ihren Methoden
            HinzufuegenCmd = new Command(AddPerson, CanAddPerson);
            LöschenCmd = new Command(DeletePerson);
        }

        //Command-Methoden
        public async void DeletePerson(object parameter)
        {
            if(await ContextPage.DisplayAlert("Löschen", "Soll diese Person wirklich gelöscht werden?", "Ja", "Nein"))
                Personenliste.Remove(parameter as Model.Person);                       
        }

        public void AddPerson(object parameter)
        {
            Model.Person person = new Model.Person()
            {
                Name = NeuerName,
                Alter = NeuesAlter,
            };

            Personenliste.Add(person);

            NeuerName = String.Empty;
            NeuesAlter = 0;

            InformView(nameof(NeuerName));
            InformView(nameof(NeuesAlter));

        }

        public bool CanAddPerson(object parameter)
        {
            return (bool)parameter;
        }

        //Aufruf des PropertyChanged-Events zur Benachrichtigung der GUI über Veränderungen
        private void InformView(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

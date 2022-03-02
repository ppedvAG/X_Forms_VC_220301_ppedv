﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using X_Forms.Droid.Services;
using X_Forms.PersonenDb.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidDatabaseService))]
namespace X_Forms.Droid.Services
{
    internal class AndroidDatabaseService : IDatabaseService
    {
        public SQLiteConnection GetConnection()
        {
            string dic = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string dbName = "PersonenDB.db3";

            string path = Path.Combine(dic, dbName);

            SQLiteConnection con = new SQLiteConnection(path);
            return con;
        }
    }
}
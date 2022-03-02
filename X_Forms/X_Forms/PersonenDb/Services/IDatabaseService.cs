using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace X_Forms.PersonenDb.Services
{
    //Interface zur Definition der plattformspezifischen Klassen
    //Implementierung in AndroidDatabaseService
    public interface IDatabaseService
    {
        SQLiteConnection GetConnection();
    }
}

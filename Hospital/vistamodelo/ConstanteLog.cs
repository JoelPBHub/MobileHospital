using System;
using System.Collections.Generic;
using System.Text;
using Hospital.modelo;
using Hospital.servicios;
using Hospital.vista;
using Hospital.vistamodelo;
using Firebase.Database.Query;
using Firebase.Database;


namespace Hospital.vistamodelo
{
    class ConstanteLog
    {
        public static FirebaseClient firebase = new FirebaseClient("https://hospital-cbf09-default-rtdb.firebaseio.com/");
        public const string WebapyFirebase = "Aa";
    }
}

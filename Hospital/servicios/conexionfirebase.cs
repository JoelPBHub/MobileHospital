using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;


namespace Hospital.servicios
{
    public class conexionfirebase
    {
        public static FirebaseClient firebase = new FirebaseClient("https://hospital-cbf09-default-rtdb.firebaseio.com/");

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Hospital.modelo;
using Hospital.vistamodelo;
using System.Threading.Tasks;
using Firebase.Database.Query;

namespace Hospital.vistamodelo
{
    public class VMUsuario
    {
        public async Task IsertUser (musuario parametros)
        {
            await ConstanteLog.firebase
                .Child("usuarios")
                .PostAsync(new musuario()
                {
                    correo = parametros.correo,
                    id_user = parametros.id_user,
                    nombre = parametros.nombre,
                    password = parametros.password

                });
                

        }


    }
}

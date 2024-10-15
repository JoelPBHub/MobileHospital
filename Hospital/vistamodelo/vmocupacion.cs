using System;
using System.Collections.Generic;
using System.Text;
using Hospital.modelo;
using Hospital.vista;
using System.Threading.Tasks;
using Firebase.Database.Query;
using Hospital.servicios;

namespace Hospital.vistamodelo
{
   internal class vmocupacion
    {
        List<mocupacion> ocupacion = new List<mocupacion>();
        public async Task<List<mocupacion>> mostrar_ocupacion()

        {
            var data = await conexionfirebase.firebase
            .Child("ocupacion")
            .OrderByKey()
            .OnceAsync<mocupacion>();

            foreach (var rdr in data)

            {
                mocupacion parametros = new mocupacion();
                parametros.cama = rdr.Key;
                parametros.hospital_cod = rdr.Object.hospital_cod;
                parametros.inscripcion = rdr.Object.inscripcion;
                parametros.sala_cod = rdr.Object.sala_cod;
                ocupacion.Add(parametros);
            }
            return ocupacion;



        }
        public async Task insertar_ocupacion(mocupacion parametros)
        {

            await conexionfirebase.firebase
                .Child("Hospital")
                .PostAsync(new mocupacion()
                {
                    cama = parametros.cama,
                    hospital_cod = parametros.hospital_cod,
                    inscripcion = parametros.inscripcion,
                    sala_cod = parametros.sala_cod,
                });
        }
    }
}

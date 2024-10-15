using System;
using System.Collections.Generic;
using System.Text;
using Hospital.modelo;
using Hospital.servicios;
using Firebase.Database.Query;
using System.Threading.Tasks;

namespace Hospital.vistamodelo

{
    public class vmenfermo
    {
        List<menfermos> enfermos = new List<menfermos>();
        public async Task <List<menfermos>> mostrar_enfermos()

        {
            var data = await conexionfirebase.firebase
            .Child("enfermo")
            .OrderByKey()
            .OnceAsync<menfermos>();

            foreach (var rdr in data)

            {
                menfermos parametros = new menfermos();
                parametros.apellido = rdr.Key;
                parametros.direccion = rdr.Object.direccion;
                parametros.fecha_nac = rdr.Object.fecha_nac;
                parametros.inscripcion = rdr.Object.inscripcion;
                enfermos.Add(parametros);
            }
            return enfermos;



        }
        public async Task Insertar_enfermos(menfermos parametros)
        {

            await conexionfirebase.firebase
                .Child("enfermos")
                .PostAsync(new menfermos()
                {
                    apellido = parametros.apellido,
                    direccion = parametros.direccion,
                    fecha_nac = parametros.fecha_nac,
                    inscripcion = parametros.inscripcion,
                    
                });
        }
    }
}
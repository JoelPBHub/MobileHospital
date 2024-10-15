using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;
using Hospital.modelo;
using Hospital.servicios;

namespace Hospital.vistamodelo
{
    public class vmhospital
    {
        List<mhospitales> hospitales = new List<mhospitales>();
        public async Task <List<mhospitales>> mostrar_hospitales()

        {
            var data = await conexionfirebase.firebase
            .Child("Hospital")
            .OrderByKey()
            .OnceAsync<mhospitales>();

            foreach(var rdr in data)

            {
                mhospitales parametros = new mhospitales();
                parametros.hospital_cod = rdr.Key;
                parametros.nombre = rdr.Object.nombre;
                parametros.telefono = rdr.Object.telefono;
                parametros.direccion = rdr.Object.direccion;
                parametros.num_cama = rdr.Object.direccion;
                hospitales.Add(parametros);
            }
            return hospitales;

          

        }
        public async Task insertar_hospitales(mhospitales parametros)
        {

            await conexionfirebase.firebase
                .Child("Hospital")
                .PostAsync(new mhospitales()
                { 
                   direccion = parametros.direccion,
                   hospital_cod = parametros.hospital_cod,
                   nombre = parametros.nombre,
                   num_cama = parametros.num_cama,
                   telefono = parametros.telefono
                });        
        }
    }
}

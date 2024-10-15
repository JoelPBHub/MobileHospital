using Firebase.Database.Query;
using Hospital.modelo;
using Hospital.servicios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.vistamodelo
{
    internal class vmsala
    {
        List<msala> sala = new List<msala>();
        public async Task<List<msala>> mostrar_sala()

        {
            var data = await conexionfirebase.firebase
            .Child("Hospital")
            .OrderByKey()
            .OnceAsync<msala>();

            foreach (var rdr in data)

            {
                msala parametros = new msala();
                parametros.hospital_cod = rdr.Key;
                parametros.nombre = rdr.Object.nombre;
                parametros.sala_cod = rdr.Object.sala_cod;
                parametros.num_cama = rdr.Object.num_cama;
                sala.Add(parametros);
            }
            return sala;



        }
        public async Task insertar_sala(msala parametros)
        {

            await conexionfirebase.firebase
                .Child("sala")
                .PostAsync(new msala()
                {
                    sala_cod = parametros.sala_cod,
                    hospital_cod = parametros.hospital_cod,
                    nombre = parametros.nombre,
                    num_cama = parametros.num_cama,
                    
                });
        }
    }
}

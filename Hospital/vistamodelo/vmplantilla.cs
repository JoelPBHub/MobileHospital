using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;
using Hospital.modelo;
using Hospital.servicios;
using Hospital.vista;

namespace Hospital.vistamodelo
{
    internal class vmplantilla
    {
        List<mplantilla> plantilla = new List<mplantilla>();
        public async Task<List<mplantilla>> mostrar_plantilla()

        {
            var data = await conexionfirebase.firebase
            .Child("platilla")
            .OrderByKey()
            .OnceAsync<mplantilla>();

            foreach (var rdr in data)

            {
                mplantilla parametros = new mplantilla();
                parametros.hospital_cod = rdr.Key;
                parametros.apellido = rdr.Object.apellido;
                parametros.empleado_no = rdr.Object.empleado_no;
                parametros.hospital_cod = rdr.Object.hospital_cod;
                parametros.sala_cod = rdr.Object.sala_cod;
                parametros.salario = rdr.Object.salario;
                parametros.turno = rdr.Object.turno;
                plantilla.Add(parametros);
            }
            return plantilla;



        }
        public async Task insertar_plantilla (mplantilla parametros)
        {

            await conexionfirebase.firebase
                .Child("plantilla")
                .PostAsync(new mplantilla()
                {
                    apellido = parametros.apellido,
                    empleado_no = parametros.empleado_no,
                    funcion = parametros.funcion,
                    hospital_cod = parametros.hospital_cod,
                    sala_cod = parametros.sala_cod,
                    salario = parametros.salario,   
                    turno = parametros.turno,
                });
        }
    }
}
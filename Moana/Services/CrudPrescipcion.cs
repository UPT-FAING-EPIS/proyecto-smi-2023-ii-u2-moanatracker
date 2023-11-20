using Supabase;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moana.Models;
using System.Net;

namespace Moana
{
    public interface IPrescripcionService
    {
        Task<List<Prescripcion>> GetPrescripciones();
        Task<(bool success, string errorMessage)> CreatePrescripcion(string fechaInicio, string fechaFin, string fkIdMedico, string fkIdPaciente);
    }

    public class PrescripcionService : IPrescripcionService
    {
        private readonly Supabase.Client _supabase;

        public PrescripcionService(Supabase.Client supabase)
        {
            _supabase = supabase ?? throw new ArgumentNullException(nameof(supabase));
        }

        public async Task<List<Prescripcion>> GetPrescripciones()
        {
            try
            {
                var prescripciones = await _supabase
                    .From<Prescripcion>()
                    .Select("id, Fecha_inicio, Fecha_fin, fkIdMedico, fkIdPaciente")
                    .Get();
                return prescripciones.Models;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener prescripciones: " + ex.Message);
                return new List<Prescripcion>();
            }
        }

        public async Task<(bool success, string errorMessage)> CreatePrescripcion(string fechaInicio, string fechaFin, string fkIdMedico, string fkIdPaciente)
        {
            try
            {
                var prescripcion = new Prescripcion
                {
                    Fecha_inicio = fechaInicio,
                    Fecha_fin = fechaFin,
                    fkIdMedico = fkIdMedico,
                    fkIdPaciente = fkIdPaciente
                };

                var insertResult = await _supabase
                    .From<Prescripcion>()
                    .Insert(prescripcion);

                if (insertResult.ResponseMessage.IsSuccessStatusCode)
                    return (true, null);
                else
                    return (false, "Error en la inserción de la prescripción.");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la creación de la prescripción: " + ex.Message);
                return (false, ex.Message);
            }
        }
    }
}

using Supabase;
using Supabase.Storage.Exceptions;
using System;
using System.Threading.Tasks;
using Moana.Models;
using System.Net;

namespace Moana
{
    public interface IPacienteService
    {
        Task<List<Paciente>> GetPacientes();
        Task<(bool success, string errorMessage)> CreatePaciente(string nombre, string apellido, string fkidUsuario);
    }


    
    public class PacienteService : IPacienteService
    {
        private readonly Supabase.Client _supabase;

        public PacienteService(Supabase.Client supabase)
        {
            _supabase = supabase ?? throw new ArgumentNullException(nameof(supabase));
        }

        public async Task<List<Paciente>> GetPacientes()
        {
            try
            {
                var pacientes = await _supabase
                    .From<Paciente>()
                    .Select("nombre,apellido")
                    .Get();
                return pacientes.Models;
            }
            catch
            {
                return new List<Paciente>();
            }
        }

        public async Task<(bool success, string errorMessage)> CreatePaciente(string nombre, string apellido, string fkidUsuario)
        {
            try
            {
                var paciente = new Paciente
                {
                    nombre = nombre,
                    apellido = apellido,
                    fkidUsuario = fkidUsuario,
                };
                var insertResult = await _supabase
                    .From<Paciente>()
                    .Insert(paciente);

                if (insertResult.ResponseMessage.IsSuccessStatusCode)
                {
                    return (true, null);
                }
                else
                {
                    return (false, "Error en la inserción del paciente.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la creación de paciente: " + ex.Message);
                return (false, ex.Message);
            }
        }
    }
}


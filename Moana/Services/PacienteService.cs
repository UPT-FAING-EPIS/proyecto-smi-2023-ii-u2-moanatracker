using Supabase;
using Supabase.Storage.Exceptions;
using System;
using System.Threading.Tasks;
using Moana.Models;
using System.Net;
using static Postgrest.Constants;
using Newtonsoft.Json;

namespace Moana
{
    public interface IPacienteService
    {
        Task<List<RecetaCompleta>> GetPacientesbyMedico(int IdMedico);
        Task<List<Paciente>> GetPacientes();

        Task<(bool success, string errorMessage)> CreatePaciente(string nombre, string apellido, int fkidUsuario);
    }
    
    public class PacienteService : IPacienteService
    {
        private readonly Supabase.Client _supabase;

        public PacienteService(Supabase.Client supabase)
        {
            _supabase = supabase ?? throw new ArgumentNullException(nameof(supabase));
        }
        public async Task<Paciente> GetPatientsbyIdUser(int IdUser)
        {
            try
            {
                var patients = await _supabase
                    .From<Paciente>()
                    .Select("IdPaciente")
                    .Where(x => x.FkIdUsuario == IdUser)
                    .Get();

                return patients.Model;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en: {ex.Message}");
                throw;
            }
        }

        public async Task<List<RecetaCompleta>> GetPacientesbyMedico(int IdMedico)
        {
            try
            {
                var responseRecetas = await _supabase
                    .From<RecetaCompleta>()
                    .Select("*")
                    .Where(x => x.IdMedico == IdMedico)
                    .Get();

                var recetas = responseRecetas.Models;

                var responsePacientes = await _supabase
                    .From<Paciente>()
                    .Select("*")
                    .Get();

                var pacientes = responsePacientes.Models;

                foreach (var receta in recetas)
                {
                    var pacienteParaAgregar = pacientes.FirstOrDefault(p => p.IdPaciente == receta.IdPaciente);

                    if (pacienteParaAgregar != null)
                    {
                        receta.Paciente = pacienteParaAgregar;

                    }
                    else
                    {
                        Console.WriteLine("Paciente no encontrado o no válido");
                    }
                }

                return recetas;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en: {ex.Message}");
                throw;
            }
        }

        public async Task<(bool success, string errorMessage)> CreatePaciente(string nombre, string apellido, int fkidUsuario)
        {
            try
            {
                var paciente = new Paciente
                {
                    Nombre = nombre,
                    Apellido = apellido,
                    FkIdUsuario = fkidUsuario,
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

        public async Task<List<Paciente>> GetPacientes()
        {
            try
            {
                var pacientes = await _supabase
                    .From<Paciente>()
                    .Select("*")
                    .Get();
                return pacientes.Models;
            }
            catch
            {
                return new List<Paciente>();
            }
        }
    }
}


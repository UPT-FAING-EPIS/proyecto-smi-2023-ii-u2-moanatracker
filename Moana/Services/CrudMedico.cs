using Supabase;
using Supabase.Storage.Exceptions;
using System;
using System.Threading.Tasks;
using Moana.Models;
using System.Net;

namespace Moana
{
    public interface IMedicoService
    {
        Task<List<Medico>> GetMedicos();
        Task<(bool success, string errorMessage)> CreateMedico(string nombre, string apellido, string fkidUsuario, string direccion, string contacto, string fkIdEspecialidad);
        
    
    
    }

    public class MedicoService : IMedicoService
    {
        private readonly Supabase.Client _supabase;

        public MedicoService(Supabase.Client supabase)
        {
            _supabase = supabase ?? throw new ArgumentNullException(nameof(supabase));
        }

        public async Task<List<Medico>> GetMedicos()
        {
            try
            {
                var medicos = await _supabase
                    .From<Medico>()
                    .Select("id, nombre, apellido, Direccion, Contacto, FkIdEspecialidad, FkIdUsuario")
                    .Get();
                return medicos.Models;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener médicos: " + ex.Message);
                return new List<Medico>();
            }
        }

        public async Task<(bool success, string errorMessage)> CreateMedico(string nombre, string apellido, string fkidUsuario, string direccion, string contacto, string fkIdEspecialidad)
        {
            try
            {
                var medico = new Medico
                {
                    nombre = nombre,
                    apellido = apellido,
                    Direccion = direccion,
                    Contacto = contacto,
                    FkIdEspecialidad = fkIdEspecialidad,
                    FkIdUsuario = fkidUsuario
                };

                var insertResult = await _supabase
                    .From<Medico>()
                    .Insert(medico);

                if (insertResult.ResponseMessage.IsSuccessStatusCode)
                {
                    return (true, null);
                }
                else
                {
                    return (false, "Error en la inserción del médico.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la creación del médico: " + ex.Message);
                return (false, ex.Message);
            }
        }


        


        

    }


}
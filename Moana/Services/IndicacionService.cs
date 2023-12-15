using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moana.Models;

namespace Moana.Services
{
    public interface IIndicacionService
    {
        Task<List<Indicacion>> GetIndicaciones();
        Task<Indicacion> CreateIndicacion(Indicacion Indidetalle);
        Task<Indicacion> GetIndicacionesbyid(int IdIndicacion);

    }

    public class IndicacionService : IIndicacionService
    {
        private readonly Supabase.Client _supabase;

        public IndicacionService(Supabase.Client supabase)
        {
            _supabase = supabase ?? throw new ArgumentNullException(nameof(supabase));

        }
        public async Task<Indicacion> GetIndicacionesbyid(int IdIndicacion)
        {
            try
            {
                var indicacion = await _supabase
                    .From<Indicacion>()
                    .Select("*")
                    .Where(x => x.IdIndicacion == IdIndicacion)
                    .Get();
                return indicacion.Model;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener médicos: " + ex.Message);
                return new Indicacion();
            }
        }

        public async Task<Indicacion> CreateIndicacion(Indicacion Indidetalle)
        {
            try
            {
                Indicacion indicacion = Indidetalle;
                var indicacionCreada = await _supabase.From<Indicacion>().Insert(indicacion);

                return indicacionCreada.Model;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error creating receta: {e.Message}");
                throw;
            }
        }

        public async Task<List<Indicacion>> GetIndicaciones()
        {
            try
            {
                var indicaciones = await _supabase
                    .From<Indicacion>()
                    .Select("*")
                    .Get();
                return indicaciones.Models;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener médicos: " + ex.Message);
                return new List<Indicacion>();
            }
        }
    }
}

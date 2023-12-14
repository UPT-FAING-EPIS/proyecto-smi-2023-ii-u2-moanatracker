using Moana.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Postgrest.Constants;

namespace Moana
{
    public interface IRecetaService
    {
        Task<List<Receta>> GetRecetas();
        Task<List<Receta>> GetRecetasByPrescripcionId(string idPaciente);

    }

    public class RecetaService : IRecetaService
    {
        public RecetaService(Supabase.Client supabase)
        {
            _supabase = supabase ?? throw new ArgumentNullException(nameof(supabase));

        }

        private readonly Supabase.Client _supabase;

        public async Task<List<Receta>> GetRecetas()
        {
            try
            {
                var patients = await _supabase
                    .From<Receta>()
                    .Select("*")
                    .Get();
                return patients.Models;
            }
            catch
            {
                return new List<Receta>();
            }
        }

        public async Task<List<Receta>> GetRecetasByPrescripcionId(string idPaciente)
        {
            try
            {
                var recetas = await _supabase
                    .From<Receta>()
                    .Select("id, CantidadConsumida, HoraTomar, FechaInicioTratamiento, FechaFinalTratamiento, FkIdPrescripcion, IntervaloConsumo")
                    .Filter("prescripcion.fkIdPaciente", Operator.Equals, idPaciente)
                    .Get();

                return recetas.Models;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener recetas: " + ex.Message);
                return new List<Receta>();
            }
        }
    }
}

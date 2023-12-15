using Moana.Models;


namespace Moana
{
    public interface IRecetaService
    {
        Task<List<Receta>> GetRecetas();
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
        public async Task<Receta> CreateReceta(Receta receta)
        {
            try
            {
                Receta recetamedica = receta;
                // Mostrar valores usando Console.WriteLine
                Console.WriteLine($"IdReceta: {recetamedica.IdReceta}");
                Console.WriteLine($"IdPaciente: {recetamedica.IdPaciente}");
                Console.WriteLine($"FechaCreacion: {recetamedica.FechaCreacion}");
                Console.WriteLine($"ValidoHasta: {recetamedica.ValidoHasta}");
                Console.WriteLine($"EstadoReceta: {recetamedica.EstadoReceta}");
                Console.WriteLine($"TipoAtencion: {recetamedica.TipoAtencion}");
                Console.WriteLine($"CIE10: {recetamedica.CIE10}");
                Console.WriteLine($"Diagnostico: {recetamedica.Diagnostico}");
                Console.WriteLine($"IdMedico: {recetamedica.IdMedico}");    
                var recetacreada =  await _supabase.From<Receta>().Insert(recetamedica);

                Console.WriteLine(recetacreada.Model.IdReceta);
                return recetacreada.Model;
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error creating receta: {e.Message}");
                throw;
            }
        }
        public async Task<List<Receta>> GetRecetasbyMedico(int IdMedico)
        {
            try
            {
                var responseRecetas = await _supabase
                    .From<Receta>()
                    .Select("*")
                    .Where(x => x.IdMedico == IdMedico)
                    .Get();

                var recetas = responseRecetas.Models;

                var idPacientes = recetas.Select(r => r.IdPaciente).ToList();

                var responsePacientes = await _supabase
                    .From<Paciente>()
                    .Select("*")
                    .Get();

                var pacientes = responsePacientes.Models.ToDictionary(p => p.IdPaciente);

                foreach (var receta in recetas)
                {
                    if (pacientes.TryGetValue(receta.IdPaciente, out var pacienteParaAgregar))
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

        public async Task<List<Receta>> GetRecetasByPaciente(int IdPaciente)
        {
            try
            {
                var responseRecetas = await _supabase
                    .From<Receta>()
                    .Select("*")
                    .Where(x => x.IdPaciente == IdPaciente)
                    .Get();

                var recetas = responseRecetas.Models;

                return recetas;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en: {ex.Message}");
                throw;
            }
        }
    }
}

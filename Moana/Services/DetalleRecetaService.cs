using Moana.Models;


namespace Moana
{
    public interface IDetalleRecetaService
    {
        Task<List<DetalleReceta>> GetRecetas();
        Task<DetalleReceta> CreateDetalleReceta(DetalleReceta detreceta);
    }

    public class DetalleRecetaService : IDetalleRecetaService
    {
        public DetalleRecetaService(Supabase.Client supabase)
        {
            _supabase = supabase ?? throw new ArgumentNullException(nameof(supabase));

        }

        private readonly Supabase.Client _supabase;

        public async Task<List<DetalleReceta>> GetRecetas()
        {
            try
            {
                var patients = await _supabase
                    .From<DetalleReceta>()
                    .Select("*")
                    .Get();
                return patients.Models;
            }
            catch
            {
                return new List<DetalleReceta>();
            }
        }
        public async Task<DetalleReceta> CreateDetalleReceta(DetalleReceta detreceta)
        {
            try
            {
                DetalleReceta detrecetamedica = detreceta;
                var recetacreada = await _supabase.From<DetalleReceta>().Insert(detrecetamedica);

                return recetacreada.Model;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error creating receta: {e.Message}");
                throw;
            }
        }
    }
}

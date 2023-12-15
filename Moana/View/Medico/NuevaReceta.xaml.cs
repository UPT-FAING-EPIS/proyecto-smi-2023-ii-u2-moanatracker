using Moana.Models;
using Moana.View.Medico;
using Supabase;

namespace Moana.View;

public partial class NuevaReceta : ContentPage
{
    private readonly Client _supabaseClient;
    private int _IdPaciente;
    public NuevaReceta(int IdPaciente)
	{
        InitializeComponent();
        _IdPaciente = IdPaciente;
        _supabaseClient = MauiProgram.CreateMauiApp().Services.GetRequiredService<Client>();

	}

    private async void Button_Clicked(object sender, EventArgs e)
	{
        Receta nuevareceta = new Receta();
        var idmedico = Int32.Parse(await SecureStorage.GetAsync("IdMedico"));
        nuevareceta.IdPaciente = _IdPaciente;
        nuevareceta.FechaCreacion = DateTime.Now.Date;
        nuevareceta.ValidoHasta = ValidoHastaEntry.Date;

        nuevareceta.EstadoReceta = "1";
        nuevareceta.TipoAtencion = TipoAtencionEntry.Text;
        nuevareceta.Diagnostico = DiagnosticoEntry.Text;
        nuevareceta.CIE10 = CIE10Entry.Text;
        nuevareceta.IdMedico = idmedico;

        var recetaservice = new RecetaService(_supabaseClient);
        try
        {
            var recetacreada= await recetaservice.CreateReceta(nuevareceta);
            if(recetacreada != null)
            {
            await Navigation.PushAsync(new AsignarDetalleReceta(recetacreada));

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    private void Back_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PopAsync();
    }
}
using Moana.Models;
using Supabase.Interfaces;
using Supabase;
using Moana.Services;

namespace Moana.View.Medico;

public partial class AsignarIndicacion : ContentPage
{
    private DetalleReceta _detalleReceta;
    private readonly Client _supabaseClient;

    public AsignarIndicacion(DetalleReceta detalleReceta)
	{
		InitializeComponent();
        _detalleReceta = detalleReceta;
        _supabaseClient = MauiProgram.CreateMauiApp().Services.GetRequiredService<Client>();

        Titulo.Text = "Indicaciones del producto " + _detalleReceta.ProductoFarmaceutico;

    }

    private void Back_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PopAsync();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        IndicacionService nuevaIndicacion = new IndicacionService(_supabaseClient);

        var indicacion = new Indicacion
        {
            IdDetalleReceta = _detalleReceta.IdDetalleReceta,
            Duracion = Int32.Parse(DuracionEntry.Text),
            Dosis = DosisEntry.Text,
            Via = ViaEntry.Text,
            Frecuencia = Int32.Parse(FrecuenciaEntry.Text),
            TiempoFrecuencia = FrecuenciaPicker.SelectedItem as string,
            TiempoDuracion = DuracionPicker.SelectedItem as string,
            ComentarioMedico = ComentariosEntry.Text,
            
        };
        // Output values of the created Indicacion object
        Console.WriteLine("Values of the created Indicacion object:");
        Console.WriteLine($"IdDetalleReceta: {indicacion.IdDetalleReceta}");
        Console.WriteLine($"Duracion: {indicacion.Duracion}");
        Console.WriteLine($"Dosis: {indicacion.Dosis}");
        Console.WriteLine($"Via: {indicacion.Via}");
        Console.WriteLine($"Frecuencia: {indicacion.Frecuencia}");
        Console.WriteLine($"TiempoFrecuencia: {indicacion.TiempoFrecuencia}");
        Console.WriteLine($"TiempoDuracion: {indicacion.TiempoDuracion}");
        Console.WriteLine($"ComentarioMedico: {indicacion.ComentarioMedico}");


        var indicacioncreada = await nuevaIndicacion.CreateIndicacion(indicacion);
        if(indicacioncreada != null)
        {
           await Navigation.PopAsync();
        }

    }

    private void DuracionPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedOption = DuracionPicker.SelectedItem as string;

    }

    private void FrecuenciaPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedOption = FrecuenciaPicker.SelectedItem as string;
    }
}
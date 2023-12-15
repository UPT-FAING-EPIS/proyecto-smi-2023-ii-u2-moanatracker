using Plugin.LocalNotification;
using Plugin.LocalNotification.AndroidOption;
using Moana.Services;
using Supabase;


namespace Moana.View;

public partial class IndicacionDetalle : ContentPage
{

    private readonly Client _supabaseClient;
    public IndicacionDetalle()
    {
        InitializeComponent();
        _supabaseClient = MauiProgram.CreateMauiApp().Services.GetRequiredService<Client>();
    }



    private async void TomarDosis_Clicked(object sender, EventArgs e)
    {

        IndicacionService IndicacionService = new IndicacionService(_supabaseClient);
        var indicacion = await IndicacionService.GetIndicacionesbyid(1)
            ;
        int Intervalo_horas_que_debe_tomar = indicacion.Frecuencia;
        int IdMedicamento = indicacion.IdDetalleReceta;
        int Dias_que_debe_tomar = indicacion.Duracion;


        var request = new NotificationRequest
        {
            NotificationId = IdMedicamento,
            Title = "Hora de tomar dosis " + indicacion.Dosis,
            Subtitle = "pastillas",
            Description = "Es hora de tomar tus medicamentos",
            ReturningData = "pastillas",
            BadgeNumber = 42,
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = DateTime.Now.AddHours(Intervalo_horas_que_debe_tomar),
                NotifyRepeatInterval = TimeSpan.FromHours(Intervalo_horas_que_debe_tomar),
                NotifyAutoCancelTime = DateTime.Now.AddDays(Dias_que_debe_tomar),
            },
            Android = new AndroidOptions
            {
                AutoCancel = false,
            }
        }; 

        await LocalNotificationCenter.Current.Show(request);

        await DisplayAlert("Dosis Tomada", "La dosis ha sido tomada con Exito.", "OK");

    }

    private void Back_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PopAsync();
    }
}
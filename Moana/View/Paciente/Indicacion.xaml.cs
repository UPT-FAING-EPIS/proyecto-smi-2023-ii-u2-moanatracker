using Plugin.LocalNotification;
using Plugin.LocalNotification.AndroidOption;
using Moana.Services;
using Moana.Models;
using Supabase;
using Supabase.Interfaces;


namespace Moana.View;

public partial class DetalleReceta : ContentPage
{

    private readonly Client _supabaseClient;
    public DetalleReceta()
    {
        InitializeComponent();
        _supabaseClient = MauiProgram.CreateMauiApp().Services.GetRequiredService<Client>();
    }



    private async void TomarDosis_Clicked(object sender, EventArgs e)
    {



        String Titulo = "Titulotxt.Text";
        String Contenido = "Contenidotxt.Text";

        IndicacionService IndicacionService = new IndicacionService(_supabaseClient);

        var indicacion = IndicacionService.GetIndicacionesbyid(1);

        int Intervalo_horas_que_debe_tomar = indicacion.Frecuencia;
        int IdMedicamento = indicacion.IdDetalleReceta;
        int Dias_que_debe_tomar = indicacion.Duracion;
        
        var request = new NotificationRequest
        {
            NotificationId = IdMedicamento,
            Title = Titulo,
            Subtitle = Contenido,
            Description = "Es hora de tomar tus medicamentos",
            ReturningData = Contenido,
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


        // var request = new NotificationRequest
        // {
        //     NotificationId = 1000,
        //     Title = "MOANA",
        //     Subtitle = "Toma tus pastillas",
        //     ReturningData = "asd",
        //     Description = "La hora de tomar tus pastilllas a llegado",
        //     BadgeNumber = 1,
        //     Schedule = new NotificationRequestSchedule
        //     {
        //         NotifyTime = DateTime.Now.AddSeconds(3),
        //         NotifyRepeatInterval=TimeSpan.FromDays(1),

        //     },
        //     Android = new AndroidOptions
        //         {
        //             AutoCancel = false,
        //         } 
        // };

        await LocalNotificationCenter.Current.Show(request);

        await DisplayAlert("Dosis Tomada", "La dosis ha sido tomada con Exito.", "OK");

    }

    private void Back_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PopAsync();
    }
}
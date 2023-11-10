using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Plugin.LocalNotification;
using Plugin.LocalNotification.AndroidOption;

namespace Moana.View
{
    public partial class HorarioPastillas : ContentPage
    {
        public HorarioPastillas()
        {
            InitializeComponent();
        }
        private async void OnCounterClicked(object sender, EventArgs e)
        {
            String Titulo = Titulotxt.Text;
            String Contenido = Contenidotxt.Text;
            var selectedTime = int.TryParse(timePicker.Text, out int selectedHour);

            if (selectedTime && selectedHour >= 0 && selectedHour <= 9)
            {
                DateTime now = DateTime.Now;

                DateTime scheduledDateTime = now.AddHours(selectedHour);

                if (now > scheduledDateTime)
                {
                    scheduledDateTime = scheduledDateTime.AddDays(1);
                }

                var request = new NotificationRequest
                {
                    NotificationId = 1337,
                    Title = Titulo,
                    Subtitle = Contenido,
                    Description = Contenido,
                    ReturningData = Contenido,
                    BadgeNumber = 1,
                    Schedule = new NotificationRequestSchedule
                    {
                        NotifyTime = scheduledDateTime,
                    },
                    Android = new AndroidOptions
                    {
                        AutoCancel = false,
                    }
                };

                if (await LocalNotificationCenter.Current.Show(request))
                {

                    statusLabel.Text = "La alarma sonará a las " + scheduledDateTime;
                    statusLabel.IsVisible = true;

                    Vibration.Vibrate();

                    await Task.Delay(5000);
                    Vibration.Cancel();

                    await Task.Delay(3000);
                    statusLabel.IsVisible = false;
                }
                else
                {

                }
            }
            else
            {
                Console.WriteLine("Entrada de tiempo no válida");
            }
        }

        private string FormatTimeSpan(TimeSpan timeSpan)
        {
            if (timeSpan.TotalMinutes < 1)
            {
                return "menos de 1 minuto";
            }
            else if (timeSpan.TotalMinutes < 2)
            {
                return "1 minuto";
            }
            else if (timeSpan.TotalHours < 1)
            {
                return $"{(int)timeSpan.TotalMinutes} minutos";
            }
            else if (timeSpan.TotalHours < 2)
            {
                return "1 hora";
            }
            else
            {
                return $"{(int)timeSpan.TotalHours} horas {(int)timeSpan.Minutes} minutos";
            }
        }
    }
}
